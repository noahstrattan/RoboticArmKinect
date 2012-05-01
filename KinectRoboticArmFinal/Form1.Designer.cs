namespace KinectRoboticArmFinal
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
            this.Start = new System.Windows.Forms.Button();
            this.Calibrate = new System.Windows.Forms.Button();
            this.Stop = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.debug_Button = new System.Windows.Forms.Button();
            this.sensorAngle = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.inputX = new System.Windows.Forms.NumericUpDown();
            this.inputY = new System.Windows.Forms.NumericUpDown();
            this.inputZ = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.sensorAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputZ)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(28, 105);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(125, 50);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Calibrate
            // 
            this.Calibrate.Enabled = false;
            this.Calibrate.Location = new System.Drawing.Point(28, 180);
            this.Calibrate.Name = "Calibrate";
            this.Calibrate.Size = new System.Drawing.Size(125, 50);
            this.Calibrate.TabIndex = 1;
            this.Calibrate.Text = "Calibrate";
            this.Calibrate.UseVisualStyleBackColor = true;
            this.Calibrate.Click += new System.EventHandler(this.Calibrate_Click);
            // 
            // Stop
            // 
            this.Stop.Enabled = false;
            this.Stop.Location = new System.Drawing.Point(28, 255);
            this.Stop.Name = "Stop";
            this.Stop.Size = new System.Drawing.Size(125, 50);
            this.Stop.TabIndex = 2;
            this.Stop.Text = "Stop";
            this.Stop.UseVisualStyleBackColor = true;
            this.Stop.Click += new System.EventHandler(this.Stop_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(555, 500);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "center_X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(636, 500);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "center_Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(715, 500);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "center_Z";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(715, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "center_Z";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(636, 526);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "center_Y";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(555, 526);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "center_X";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(28, 231);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar1.Size = new System.Drawing.Size(125, 10);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 10;
            this.progressBar1.Visible = false;
            // 
            // debug_Button
            // 
            this.debug_Button.Location = new System.Drawing.Point(53, 513);
            this.debug_Button.Name = "debug_Button";
            this.debug_Button.Size = new System.Drawing.Size(75, 23);
            this.debug_Button.TabIndex = 11;
            this.debug_Button.Text = "Test";
            this.debug_Button.UseVisualStyleBackColor = true;
            this.debug_Button.Click += new System.EventHandler(this.debug_Button_Click);
            // 
            // sensorAngle
            // 
            this.sensorAngle.Enabled = false;
            this.sensorAngle.Location = new System.Drawing.Point(64, 389);
            this.sensorAngle.Maximum = new decimal(new int[] {
            25,
            0,
            0,
            0});
            this.sensorAngle.Minimum = new decimal(new int[] {
            25,
            0,
            0,
            -2147483648});
            this.sensorAngle.Name = "sensorAngle";
            this.sensorAngle.Size = new System.Drawing.Size(64, 20);
            this.sensorAngle.TabIndex = 12;
            this.sensorAngle.ValueChanged += new System.EventHandler(this.sensorAngle_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(61, 373);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Kinect Angle";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(188, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // inputX
            // 
            this.inputX.Location = new System.Drawing.Point(215, 516);
            this.inputX.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.inputX.Minimum = new decimal(new int[] {
            500,
            0,
            0,
            -2147483648});
            this.inputX.Name = "inputX";
            this.inputX.Size = new System.Drawing.Size(64, 20);
            this.inputX.TabIndex = 15;
            // 
            // inputY
            // 
            this.inputY.Location = new System.Drawing.Point(312, 516);
            this.inputY.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.inputY.Name = "inputY";
            this.inputY.Size = new System.Drawing.Size(64, 20);
            this.inputY.TabIndex = 16;
            this.inputY.Value = new decimal(new int[] {
            250,
            0,
            0,
            0});
            // 
            // inputZ
            // 
            this.inputZ.Location = new System.Drawing.Point(402, 516);
            this.inputZ.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.inputZ.Name = "inputZ";
            this.inputZ.Size = new System.Drawing.Size(64, 20);
            this.inputZ.TabIndex = 17;
            this.inputZ.Value = new decimal(new int[] {
            150,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 548);
            this.Controls.Add(this.inputZ);
            this.Controls.Add(this.inputY);
            this.Controls.Add(this.inputX);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.sensorAngle);
            this.Controls.Add(this.debug_Button);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Stop);
            this.Controls.Add(this.Calibrate);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Kinect Control Center";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.sensorAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Button Calibrate;
        private System.Windows.Forms.Button Stop;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button debug_Button;
        private System.Windows.Forms.NumericUpDown sensorAngle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.NumericUpDown inputX;
        private System.Windows.Forms.NumericUpDown inputY;
        private System.Windows.Forms.NumericUpDown inputZ;
    }
}

