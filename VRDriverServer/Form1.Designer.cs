namespace VRDriverServer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.start_stop = new System.Windows.Forms.Button();
            this.statusLabel = new System.Windows.Forms.Label();
            this.kinectView = new System.Windows.Forms.PictureBox();
            this.TiltLable = new System.Windows.Forms.Label();
            this.tiltValue = new System.Windows.Forms.Label();
            this.tilt = new System.Windows.Forms.TrackBar();
            this.rJoyLabel = new System.Windows.Forms.Label();
            this.lJoyLabel = new System.Windows.Forms.Label();
            this.rJoyGyroLabel = new System.Windows.Forms.Label();
            this.lJoyGyroLabel = new System.Windows.Forms.Label();
            this.rJoyGyroX = new System.Windows.Forms.Label();
            this.rJoyGyroY = new System.Windows.Forms.Label();
            this.rJoyGyroZ = new System.Windows.Forms.Label();
            this.lJoyGyroZ = new System.Windows.Forms.Label();
            this.lJoyGyroY = new System.Windows.Forms.Label();
            this.lJoyGyroX = new System.Windows.Forms.Label();
            this.rJoyAccelLabel = new System.Windows.Forms.Label();
            this.lJoyAccelLabel = new System.Windows.Forms.Label();
            this.rJoyAccelZ = new System.Windows.Forms.Label();
            this.rJoyAccelY = new System.Windows.Forms.Label();
            this.rJoyAccelX = new System.Windows.Forms.Label();
            this.lJoyAccelZ = new System.Windows.Forms.Label();
            this.lJoyAccelY = new System.Windows.Forms.Label();
            this.lJoyAccelX = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kinectView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilt)).BeginInit();
            this.SuspendLayout();
            // 
            // start_stop
            // 
            this.start_stop.Location = new System.Drawing.Point(12, 12);
            this.start_stop.Name = "start_stop";
            this.start_stop.Size = new System.Drawing.Size(139, 55);
            this.start_stop.TabIndex = 0;
            this.start_stop.Text = "Start";
            this.start_stop.UseVisualStyleBackColor = true;
            this.start_stop.Click += new System.EventHandler(this.start_stop_Click);
            // 
            // statusLabel
            // 
            this.statusLabel.AutoSize = true;
            this.statusLabel.Location = new System.Drawing.Point(157, 12);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(44, 16);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "label1";
            // 
            // kinectView
            // 
            this.kinectView.Location = new System.Drawing.Point(724, 12);
            this.kinectView.Name = "kinectView";
            this.kinectView.Size = new System.Drawing.Size(640, 480);
            this.kinectView.TabIndex = 2;
            this.kinectView.TabStop = false;
            // 
            // TiltLable
            // 
            this.TiltLable.AutoSize = true;
            this.TiltLable.Location = new System.Drawing.Point(12, 90);
            this.TiltLable.Name = "TiltLable";
            this.TiltLable.Size = new System.Drawing.Size(25, 16);
            this.TiltLable.TabIndex = 4;
            this.TiltLable.Text = "Tilt";
            // 
            // tiltValue
            // 
            this.tiltValue.AutoSize = true;
            this.tiltValue.Location = new System.Drawing.Point(160, 109);
            this.tiltValue.Name = "tiltValue";
            this.tiltValue.Size = new System.Drawing.Size(25, 16);
            this.tiltValue.TabIndex = 5;
            this.tiltValue.Text = "Tilt";
            // 
            // tilt
            // 
            this.tilt.Location = new System.Drawing.Point(15, 109);
            this.tilt.Maximum = 27;
            this.tilt.Minimum = -27;
            this.tilt.Name = "tilt";
            this.tilt.Size = new System.Drawing.Size(139, 56);
            this.tilt.TabIndex = 6;
            // 
            // rJoyLabel
            // 
            this.rJoyLabel.AutoSize = true;
            this.rJoyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyLabel.Location = new System.Drawing.Point(302, 12);
            this.rJoyLabel.Name = "rJoyLabel";
            this.rJoyLabel.Size = new System.Drawing.Size(130, 25);
            this.rJoyLabel.TabIndex = 7;
            this.rJoyLabel.Text = "Right JoyCon";
            // 
            // lJoyLabel
            // 
            this.lJoyLabel.AutoSize = true;
            this.lJoyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyLabel.Location = new System.Drawing.Point(535, 12);
            this.lJoyLabel.Name = "lJoyLabel";
            this.lJoyLabel.Size = new System.Drawing.Size(118, 25);
            this.lJoyLabel.TabIndex = 8;
            this.lJoyLabel.Text = "Left JoyCon";
            // 
            // rJoyGyroLabel
            // 
            this.rJoyGyroLabel.AutoSize = true;
            this.rJoyGyroLabel.Location = new System.Drawing.Point(304, 51);
            this.rJoyGyroLabel.Name = "rJoyGyroLabel";
            this.rJoyGyroLabel.Size = new System.Drawing.Size(39, 16);
            this.rJoyGyroLabel.TabIndex = 9;
            this.rJoyGyroLabel.Text = "Gyro:";
            // 
            // lJoyGyroLabel
            // 
            this.lJoyGyroLabel.AutoSize = true;
            this.lJoyGyroLabel.Location = new System.Drawing.Point(537, 51);
            this.lJoyGyroLabel.Name = "lJoyGyroLabel";
            this.lJoyGyroLabel.Size = new System.Drawing.Size(39, 16);
            this.lJoyGyroLabel.TabIndex = 10;
            this.lJoyGyroLabel.Text = "Gyro:";
            // 
            // rJoyGyroX
            // 
            this.rJoyGyroX.AutoSize = true;
            this.rJoyGyroX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyGyroX.ForeColor = System.Drawing.Color.Red;
            this.rJoyGyroX.Location = new System.Drawing.Point(302, 81);
            this.rJoyGyroX.Name = "rJoyGyroX";
            this.rJoyGyroX.Size = new System.Drawing.Size(32, 25);
            this.rJoyGyroX.TabIndex = 11;
            this.rJoyGyroX.Text = "X:";
            // 
            // rJoyGyroY
            // 
            this.rJoyGyroY.AutoSize = true;
            this.rJoyGyroY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyGyroY.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.rJoyGyroY.Location = new System.Drawing.Point(302, 106);
            this.rJoyGyroY.Name = "rJoyGyroY";
            this.rJoyGyroY.Size = new System.Drawing.Size(31, 25);
            this.rJoyGyroY.TabIndex = 12;
            this.rJoyGyroY.Text = "Y:";
            // 
            // rJoyGyroZ
            // 
            this.rJoyGyroZ.AutoSize = true;
            this.rJoyGyroZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyGyroZ.ForeColor = System.Drawing.Color.Blue;
            this.rJoyGyroZ.Location = new System.Drawing.Point(302, 131);
            this.rJoyGyroZ.Name = "rJoyGyroZ";
            this.rJoyGyroZ.Size = new System.Drawing.Size(30, 25);
            this.rJoyGyroZ.TabIndex = 13;
            this.rJoyGyroZ.Text = "Z:";
            // 
            // lJoyGyroZ
            // 
            this.lJoyGyroZ.AutoSize = true;
            this.lJoyGyroZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyGyroZ.ForeColor = System.Drawing.Color.Blue;
            this.lJoyGyroZ.Location = new System.Drawing.Point(535, 131);
            this.lJoyGyroZ.Name = "lJoyGyroZ";
            this.lJoyGyroZ.Size = new System.Drawing.Size(30, 25);
            this.lJoyGyroZ.TabIndex = 16;
            this.lJoyGyroZ.Text = "Z:";
            // 
            // lJoyGyroY
            // 
            this.lJoyGyroY.AutoSize = true;
            this.lJoyGyroY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyGyroY.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lJoyGyroY.Location = new System.Drawing.Point(535, 106);
            this.lJoyGyroY.Name = "lJoyGyroY";
            this.lJoyGyroY.Size = new System.Drawing.Size(31, 25);
            this.lJoyGyroY.TabIndex = 15;
            this.lJoyGyroY.Text = "Y:";
            // 
            // lJoyGyroX
            // 
            this.lJoyGyroX.AutoSize = true;
            this.lJoyGyroX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyGyroX.ForeColor = System.Drawing.Color.Red;
            this.lJoyGyroX.Location = new System.Drawing.Point(535, 81);
            this.lJoyGyroX.Name = "lJoyGyroX";
            this.lJoyGyroX.Size = new System.Drawing.Size(32, 25);
            this.lJoyGyroX.TabIndex = 14;
            this.lJoyGyroX.Text = "X:";
            // 
            // rJoyAccelLabel
            // 
            this.rJoyAccelLabel.AutoSize = true;
            this.rJoyAccelLabel.Location = new System.Drawing.Point(304, 183);
            this.rJoyAccelLabel.Name = "rJoyAccelLabel";
            this.rJoyAccelLabel.Size = new System.Drawing.Size(85, 16);
            this.rJoyAccelLabel.TabIndex = 17;
            this.rJoyAccelLabel.Text = "Acceleration:";
            // 
            // lJoyAccelLabel
            // 
            this.lJoyAccelLabel.AutoSize = true;
            this.lJoyAccelLabel.Location = new System.Drawing.Point(537, 183);
            this.lJoyAccelLabel.Name = "lJoyAccelLabel";
            this.lJoyAccelLabel.Size = new System.Drawing.Size(85, 16);
            this.lJoyAccelLabel.TabIndex = 18;
            this.lJoyAccelLabel.Text = "Acceleration:";
            // 
            // rJoyAccelZ
            // 
            this.rJoyAccelZ.AutoSize = true;
            this.rJoyAccelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyAccelZ.ForeColor = System.Drawing.Color.Blue;
            this.rJoyAccelZ.Location = new System.Drawing.Point(302, 261);
            this.rJoyAccelZ.Name = "rJoyAccelZ";
            this.rJoyAccelZ.Size = new System.Drawing.Size(30, 25);
            this.rJoyAccelZ.TabIndex = 21;
            this.rJoyAccelZ.Text = "Z:";
            // 
            // rJoyAccelY
            // 
            this.rJoyAccelY.AutoSize = true;
            this.rJoyAccelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyAccelY.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.rJoyAccelY.Location = new System.Drawing.Point(302, 236);
            this.rJoyAccelY.Name = "rJoyAccelY";
            this.rJoyAccelY.Size = new System.Drawing.Size(31, 25);
            this.rJoyAccelY.TabIndex = 20;
            this.rJoyAccelY.Text = "Y:";
            // 
            // rJoyAccelX
            // 
            this.rJoyAccelX.AutoSize = true;
            this.rJoyAccelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rJoyAccelX.ForeColor = System.Drawing.Color.Red;
            this.rJoyAccelX.Location = new System.Drawing.Point(302, 211);
            this.rJoyAccelX.Name = "rJoyAccelX";
            this.rJoyAccelX.Size = new System.Drawing.Size(32, 25);
            this.rJoyAccelX.TabIndex = 19;
            this.rJoyAccelX.Text = "X:";
            // 
            // lJoyAccelZ
            // 
            this.lJoyAccelZ.AutoSize = true;
            this.lJoyAccelZ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyAccelZ.ForeColor = System.Drawing.Color.Blue;
            this.lJoyAccelZ.Location = new System.Drawing.Point(535, 261);
            this.lJoyAccelZ.Name = "lJoyAccelZ";
            this.lJoyAccelZ.Size = new System.Drawing.Size(30, 25);
            this.lJoyAccelZ.TabIndex = 24;
            this.lJoyAccelZ.Text = "Z:";
            // 
            // lJoyAccelY
            // 
            this.lJoyAccelY.AutoSize = true;
            this.lJoyAccelY.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyAccelY.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.lJoyAccelY.Location = new System.Drawing.Point(535, 236);
            this.lJoyAccelY.Name = "lJoyAccelY";
            this.lJoyAccelY.Size = new System.Drawing.Size(31, 25);
            this.lJoyAccelY.TabIndex = 23;
            this.lJoyAccelY.Text = "Y:";
            // 
            // lJoyAccelX
            // 
            this.lJoyAccelX.AutoSize = true;
            this.lJoyAccelX.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lJoyAccelX.ForeColor = System.Drawing.Color.Red;
            this.lJoyAccelX.Location = new System.Drawing.Point(535, 211);
            this.lJoyAccelX.Name = "lJoyAccelX";
            this.lJoyAccelX.Size = new System.Drawing.Size(32, 25);
            this.lJoyAccelX.TabIndex = 22;
            this.lJoyAccelX.Text = "X:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 510);
            this.Controls.Add(this.lJoyAccelZ);
            this.Controls.Add(this.lJoyAccelY);
            this.Controls.Add(this.lJoyAccelX);
            this.Controls.Add(this.rJoyAccelZ);
            this.Controls.Add(this.rJoyAccelY);
            this.Controls.Add(this.rJoyAccelX);
            this.Controls.Add(this.lJoyAccelLabel);
            this.Controls.Add(this.rJoyAccelLabel);
            this.Controls.Add(this.lJoyGyroZ);
            this.Controls.Add(this.lJoyGyroY);
            this.Controls.Add(this.lJoyGyroX);
            this.Controls.Add(this.rJoyGyroZ);
            this.Controls.Add(this.rJoyGyroY);
            this.Controls.Add(this.rJoyGyroX);
            this.Controls.Add(this.lJoyGyroLabel);
            this.Controls.Add(this.rJoyGyroLabel);
            this.Controls.Add(this.lJoyLabel);
            this.Controls.Add(this.rJoyLabel);
            this.Controls.Add(this.tilt);
            this.Controls.Add(this.tiltValue);
            this.Controls.Add(this.TiltLable);
            this.Controls.Add(this.kinectView);
            this.Controls.Add(this.statusLabel);
            this.Controls.Add(this.start_stop);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kinectView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tilt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start_stop;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.PictureBox kinectView;
        private System.Windows.Forms.Label TiltLable;
        private System.Windows.Forms.Label tiltValue;
        private System.Windows.Forms.TrackBar tilt;
        private System.Windows.Forms.Label rJoyLabel;
        private System.Windows.Forms.Label lJoyLabel;
        private System.Windows.Forms.Label rJoyGyroLabel;
        private System.Windows.Forms.Label lJoyGyroLabel;
        private System.Windows.Forms.Label rJoyGyroX;
        private System.Windows.Forms.Label rJoyGyroY;
        private System.Windows.Forms.Label rJoyGyroZ;
        private System.Windows.Forms.Label lJoyGyroZ;
        private System.Windows.Forms.Label lJoyGyroY;
        private System.Windows.Forms.Label lJoyGyroX;
        private System.Windows.Forms.Label rJoyAccelLabel;
        private System.Windows.Forms.Label lJoyAccelLabel;
        private System.Windows.Forms.Label rJoyAccelZ;
        private System.Windows.Forms.Label rJoyAccelY;
        private System.Windows.Forms.Label rJoyAccelX;
        private System.Windows.Forms.Label lJoyAccelZ;
        private System.Windows.Forms.Label lJoyAccelY;
        private System.Windows.Forms.Label lJoyAccelX;
    }
}

