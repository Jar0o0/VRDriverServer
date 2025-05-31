using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.Remoting;
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

        private const float gyroSens = 16.4f;
        private const float accelSens = 8192.0f;

        Quaternion currentOrientation = Quaternion.Identity;

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

        private void TimerTick(object sender, EventArgs e)
        {
            //UpdateOrientation(gyroX, gyroY, gyroZ, accelX, accelY, accelZ);
            //UpdateRotation();
            float finalGyroX = (gyroX / gyroSens) * (float)(Math.PI / 180f);
            float finalGyroY = (gyroY / gyroSens) * (float)(Math.PI / 180f);
            float finalGyroZ = (gyroZ / gyroSens) * (float)(Math.PI / 180f);
            float finalAccelX = (accelX / accelSens) * (float)(Math.PI / 180f);
            float finalAccelY = (accelY / accelSens) * (float)(Math.PI / 180f);
            float finalAccelZ = (accelZ / accelSens) * (float)(Math.PI / 180f);
            filter.UpdateIMU(finalGyroX, finalGyroY, finalGyroZ, finalAccelX, finalAccelY, finalAccelZ);
            Vector3 euler = filter.ToEulerAngles();
            yaw = euler.Z;
            pitch = euler.Y;
            roll = euler.X;
        }

        private float NormalizeAngle(float angle)
        {
            while (angle > 180) angle -= 360;
            while (angle < -180) angle += 360;
            return angle;
        }
    }
}
