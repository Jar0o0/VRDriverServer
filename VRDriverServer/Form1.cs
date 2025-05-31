using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Microsoft.Kinect;

namespace VRDriverServer
{
    public partial class Form1 : Form
    {
        private ControllerInput input;
        private KinectHandler kinect;

        private Joycon leftJoycon;
        private Joycon rightJoycon;
        public Form1()
        {
            InitializeComponent();
            // UI stuff
            statusLabel.Text = "Stopped.";
            statusLabel.ForeColor = Color.Red;
            Timer updateTimer = new Timer();
            updateTimer.Interval = 20;
            updateTimer.Tick += (s, e) => DisplayJoyconStats(s, e);
            updateTimer.Start();
            //Initialization
            input = new ControllerInput();
            kinect = new KinectHandler(tilt, tiltValue, kinectView, start_stop, statusLabel);
            input.Initialize();
            if (input.rightJoycon != null) rightJoycon = input.rightJoycon;
            if (input.leftJoycon != null) leftJoycon = input.leftJoycon;
        }

        private void start_stop_Click(object sender, EventArgs e)
        {
            kinect.StartStop();

            if (rightJoycon == null && input.rightJoycon != null) rightJoycon = input.rightJoycon;
            if (leftJoycon == null && input.leftJoycon != null) leftJoycon = input.leftJoycon;
        }

        private void DisplayJoyconStats(object sender, EventArgs e)
        {
            if (rightJoycon != null)
            {
                rJoyGyroX.Text = $"X: {rightJoycon.pitch:F2}°";
                rJoyGyroY.Text = $"Y: {rightJoycon.yaw:F2}°";
                rJoyGyroZ.Text = $"Z: {rightJoycon.roll:F2}°";
                rJoyAccelX.Text = $"X: {rightJoycon.accelX / 8192.0f:F2}";
                rJoyAccelY.Text = $"Y: {rightJoycon.accelY / 8192.0f:F2}";
                rJoyAccelZ.Text = $"Z: {rightJoycon.accelZ / 8192.0f:F2}";
            }
            if(leftJoycon != null)
            {
                lJoyGyroX.Text = $"X: {leftJoycon.pitch:F2}°";
                lJoyGyroY.Text = $"Y: {leftJoycon.yaw:F2}°";
                lJoyGyroZ.Text = $"Z: {leftJoycon.roll:F2}°";
                lJoyAccelX.Text = $"X: {leftJoycon.accelX / 8192.0f:F2}";
                lJoyAccelY.Text = $"Y: {leftJoycon.accelY / 8192.0f:F2}";
                lJoyAccelZ.Text = $"Z: {leftJoycon.accelZ / 8192.0f:F2}";
            }
        }
    }
}
