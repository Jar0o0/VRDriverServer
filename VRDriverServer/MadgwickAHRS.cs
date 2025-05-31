using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace VRDriverServer
{
    class MadgwickAHRS
    {
        public float SamplePeriod { get; set; } = 1.0f / 256.0f;
        public float Beta { get; set; } = 0.1f;  // Gain
        public Quaternion Quaternion { get; private set; } = Quaternion.Identity;

        public void UpdateIMU(float gx, float gy, float gz, float ax, float ay, float az)
        {
            var q = Quaternion;
            float q1 = q.W, q2 = q.X, q3 = q.Y, q4 = q.Z;

            float norm = (float)Math.Sqrt(ax * ax + ay * ay + az * az);
            if (norm == 0f) return; // invalid data
            ax /= norm;
            ay /= norm;
            az /= norm;

            // Auxiliary variables
            float _2q1 = 2f * q1;
            float _2q2 = 2f * q2;
            float _2q3 = 2f * q3;
            float _2q4 = 2f * q4;
            float _4q1 = 4f * q1;
            float _4q2 = 4f * q2;
            float _4q3 = 4f * q3;
            float _8q2 = 8f * q2;
            float _8q3 = 8f * q3;
            float q1q1 = q1 * q1;
            float q2q2 = q2 * q2;
            float q3q3 = q3 * q3;
            float q4q4 = q4 * q4;

            float s1 = _4q1 * q3q3 + _2q3 * ax + _4q1 * q2q2 - _2q2 * ay;
            float s2 = _4q2 * q4q4 - _2q4 * ax + 4f * q1q1 * q2 - _2q1 * ay - _4q2 + _8q2 * q2q2 + _8q2 * q3q3 + _4q2 * az;
            float s3 = 4f * q1q1 * q3 + _2q1 * ax + _4q3 * q4q4 - _2q4 * ay - _4q3 + _8q3 * q2q2 + _8q3 * q3q3 + _4q3 * az;
            float s4 = 4f * q2q2 * q4 - _2q2 * ax + 4f * q3q3 * q4 - _2q3 * ay;

            norm = (float)Math.Sqrt(s1 * s1 + s2 * s2 + s3 * s3 + s4 * s4);
            if (norm == 0f) return;
            s1 /= norm;
            s2 /= norm;
            s3 /= norm;
            s4 /= norm;

            // Integrate rate of change
            float gxRad = gx * (float)Math.PI / 180f;
            float gyRad = gy * (float)Math.PI / 180f;
            float gzRad = gz * (float)Math.PI / 180f;

            float qDot1 = 0.5f * (-q2 * gxRad - q3 * gyRad - q4 * gzRad) - Beta * s1;
            float qDot2 = 0.5f * (q1 * gxRad + q3 * gzRad - q4 * gyRad) - Beta * s2;
            float qDot3 = 0.5f * (q1 * gyRad - q2 * gzRad + q4 * gxRad) - Beta * s3;
            float qDot4 = 0.5f * (q1 * gzRad + q2 * gyRad - q3 * gxRad) - Beta * s4;

            q1 += qDot1 * SamplePeriod;
            q2 += qDot2 * SamplePeriod;
            q3 += qDot3 * SamplePeriod;
            q4 += qDot4 * SamplePeriod;

            norm = (float)Math.Sqrt(q1 * q1 + q2 * q2 + q3 * q3 + q4 * q4);
            Quaternion = new Quaternion(q2 / norm, q3 / norm, q4 / norm, q1 / norm);
        }

        public Vector3 ToEulerAngles()
        {
            var q = Quaternion;
            float roll = (float)Math.Atan2(2.0 * (q.W * q.X + q.Y * q.Z), 1.0 - 2.0 * (q.X * q.X + q.Y * q.Y));
            float pitch = (float)Math.Asin(2.0 * (q.W * q.Y - q.Z * q.X));
            float yaw = (float)Math.Atan2(2.0 * (q.W * q.Z + q.X * q.Y), 1.0 - 2.0 * (q.Y * q.Y + q.Z * q.Z));
            return new Vector3(roll, pitch, yaw) * (180f / (float)Math.PI);
        }
    }
}
