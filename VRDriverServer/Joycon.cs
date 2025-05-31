using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRDriverServer
{
    public class Joycon
    {
        public short gyroX;
        public short gyroY;
        public short gyroZ;

        public short accelX;
        public short accelY;
        public short accelZ;

        public float yaw;
        public float pitch;
        public float roll;

        Quaternion currentOrientation = Quaternion.Identity;

        public const float gyroSensitivity = 16.4f;
        public const float accelScale = 8192.0f;

        private Stopwatch stopwatch = new Stopwatch();
        private MadgwickAHRS filter;

        public void Initialize()
        {
            stopwatch.Start();
            Timer timer = new Timer();
            timer.Interval = 16; // ~60 Hz
            timer.Tick += (s, e) => TimerTick(s, e);
            timer.Start();
            filter = new MadgwickAHRS();
        }

        private void UpdateOrientation(short rawGx, short rawGy, short rawGz, short rawAx, short rawAy, short rawAz)
        {
            float deltaTime = (float)stopwatch.Elapsed.TotalSeconds;
            stopwatch.Restart();

            // Convert gyro raw to radians per second
            Vector3 gyro = new Vector3(
                rawGx / gyroSensitivity,
                rawGy / gyroSensitivity,
                rawGz / gyroSensitivity
            );
            // Degrees to radians
            gyro = Vector3.Multiply(gyro, (float)(Math.PI / 180.0));

            // Create delta quaternion from gyro angular velocity
            float angle = gyro.Length() * deltaTime;
            Vector3 axis = (angle > 0.0001f) ? Vector3.Normalize(gyro) : Vector3.Zero;
            Quaternion deltaRotation = Quaternion.Identity;
            if (axis != Vector3.Zero)
                deltaRotation = Quaternion.CreateFromAxisAngle(axis, angle);

            // Update current orientation
            currentOrientation = Quaternion.Normalize(Quaternion.Concatenate(currentOrientation, deltaRotation));

            // Simple sensor fusion: use accelerometer to correct pitch and roll drift
            Vector3 accel = new Vector3(
                rawAx / accelScale,
                rawAy / accelScale,
                rawAz / accelScale
            );

            if (accel.LengthSquared() > 0.0001f)
                accel = Vector3.Normalize(accel);
            else
                return;

            // Calculate pitch and roll from accelerometer
            float pitchAccel = (float)Math.Atan2(accel.Y, accel.Z);
            float rollAccel = (float)Math.Atan2(accel.X, accel.Z);

            // Extract pitch and roll from currentOrientation quaternion
            float pitchQuat = (float)Math.Asin(-2.0 * (currentOrientation.X * currentOrientation.Z - currentOrientation.W * currentOrientation.Y));
            float rollQuat = (float)Math.Atan2(2.0 * (currentOrientation.Y * currentOrientation.Z + currentOrientation.W * currentOrientation.X),
                                               1.0 - 2.0 * (currentOrientation.X * currentOrientation.X + currentOrientation.Y * currentOrientation.Y));

            // Fuse by simple complementary filter (adjust alpha for smoothness)
            const float alpha = 0.02f;
            pitchQuat = (1 - alpha) * pitchQuat + alpha * pitchAccel;
            rollQuat = (1 - alpha) * rollQuat + alpha * rollAccel;

            // Rebuild quaternion with fused pitch and roll, keep yaw as is
            float yawQuat = GetYawFromQuaternion(currentOrientation);

            currentOrientation = Quaternion.CreateFromYawPitchRoll(yawQuat, pitchQuat, rollQuat);
            Console.WriteLine(yawQuat + " " + pitchQuat + " " + rollQuat);
        }

        private float GetYawFromQuaternion(Quaternion q)
        {
            // Yaw calculation from quaternion
            return (float)Math.Atan2(2.0 * (q.W * q.Z + q.X * q.Y), 1.0 - 2.0 * (q.Y * q.Y + q.Z * q.Z));
        }


        private void TimerTick(object sender, EventArgs e)
        {
            //UpdateOrientation(gyroX, gyroY, gyroZ, accelX, accelY, accelZ);
            //UpdateRotation();

            filter.UpdateIMU(gyroX, gyroY, gyroZ, accelX, accelY, accelZ);
            Vector3 euler = filter.ToEulerAngles();
            yaw = euler.Z;
            pitch = euler.Y;
            roll = euler.X;
        }

        public void UpdateRotation()
        {
            // Convert quaternion to Euler angles (degrees)
            yaw = GetYawFromQuaternion(currentOrientation) * (180f / (float)Math.PI);
            pitch = (float)Math.Asin(-2.0 * (currentOrientation.X * currentOrientation.Z - currentOrientation.W * currentOrientation.Y)) * (180f / (float)Math.PI);
            roll = (float)Math.Atan2(2.0 * (currentOrientation.Y * currentOrientation.Z + currentOrientation.W * currentOrientation.X),
                                           1.0 - 2.0 * (currentOrientation.X * currentOrientation.X + currentOrientation.Y * currentOrientation.Y)) * (180f / (float)Math.PI);

        }

        private float NormalizeAngle(float angle)
        {
            while (angle > 180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }
    }
}
