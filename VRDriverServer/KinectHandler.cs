using Microsoft.Kinect;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VRDriverServer
{
    internal class KinectHandler
    {
        private KinectSensor sensor;
        private byte[] colorPixels;
        private Bitmap colorBitmap;
        private Skeleton[] skeletons = new Skeleton[6];

        TrackBar tilt;
        Label tiltValue;
        PictureBox kinectView;
        Button start_stop;
        Label label1;

        public void StartStop()
        {
            if (sensor == null)
            {
                if (KinectSensor.KinectSensors.Count > 0) sensor = KinectSensor.KinectSensors[0];
                else
                {
                    MessageBox.Show("Kinect v1 not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sensor.SkeletonStream.Enable();
                sensor.SkeletonFrameReady += Sensor_SkeletonFrameReady;
                sensor.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
                sensor.ColorFrameReady += Sensor_ColorFrameReady;
                colorPixels = new byte[sensor.ColorStream.FramePixelDataLength];
                colorBitmap = new Bitmap(sensor.ColorStream.FrameWidth, sensor.ColorStream.FrameHeight, PixelFormat.Format32bppRgb);
            }

            if (sensor.IsRunning)
            {
                sensor.Stop();
                label1.Text = "Stopped.";
                label1.ForeColor = Color.Red;
                start_stop.Text = "Start";
            }
            else
            {
                sensor.Start();
                label1.Text = "Running.";
                label1.ForeColor = Color.Green;
                start_stop.Text = "Stop";
            }

            if (sensor.IsRunning)
            {
                tiltValue.Text = sensor.ElevationAngle.ToString();
            }
        }

        private void Sensor_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            using (ColorImageFrame frame = e.OpenColorImageFrame())
            {
                if (frame == null) return;

                frame.CopyPixelDataTo(colorPixels);
                BitmapData data = colorBitmap.LockBits(
                    new Rectangle(0, 0, colorBitmap.Width, colorBitmap.Height), ImageLockMode.WriteOnly, colorBitmap.PixelFormat);
                System.Runtime.InteropServices.Marshal.Copy(colorPixels, 0, data.Scan0, colorPixels.Length);
                colorBitmap.UnlockBits(data);

                using (Graphics g = Graphics.FromImage(colorBitmap))
                {
                    foreach (Skeleton skeleton in skeletons)
                    {
                        if (skeleton != null)
                        {
                            if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                            {
                                DrawJoint(g, skeleton.Joints[JointType.Head], Brushes.Green, 40);
                                DrawJoint(g, skeleton.Joints[JointType.HandLeft], Brushes.Red, 30);
                                DrawJoint(g, skeleton.Joints[JointType.HandRight], Brushes.Blue, 30);
                            }
                        }
                    }
                }

                kinectView.Image = colorBitmap;
            }
        }

        private void Sensor_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (var frame = e.OpenSkeletonFrame())
            {
                if (frame != null)
                {
                    skeletons = new Skeleton[frame.SkeletonArrayLength];
                    frame.CopySkeletonDataTo(skeletons);
                }
            }
        }

        private void DrawJoint(Graphics g, Joint joint, Brush brush, int radius)
        {
            if (joint.TrackingState != JointTrackingState.NotTracked)
            {
                ColorImagePoint point = sensor.CoordinateMapper.MapSkeletonPointToColorPoint(
                    joint.Position, sensor.ColorStream.Format);

                g.FillEllipse(brush, point.X - radius / 2, point.Y - radius / 2, radius, radius);
            }
        }

        public void tilt_Scroll(object sender, EventArgs e)
        {
            sensor.ElevationAngle = tilt.Value;
            tiltValue.Text = tilt.Value.ToString();
        }

        public KinectHandler(TrackBar tilt, Label tiltValue, PictureBox kinectView, Button start_stop, Label label1)
        {
            this.tilt = tilt;
            this.tiltValue = tiltValue;
            this.kinectView = kinectView;
            this.start_stop = start_stop;
            this.label1 = label1;
        }
    }
}
