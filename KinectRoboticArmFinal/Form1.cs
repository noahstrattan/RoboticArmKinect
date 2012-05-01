using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Kinect;
using System.IO.Ports;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace KinectRoboticArmFinal
{
    public partial class Form1 : Form
    {
        // Variables
        byte[] bytesOut = new byte[8] { 48, 151, 90, 90, 90, 90, 90, 90 };  // Byte array to send to arm
        double center_X, center_Y, center_Z;    // Center cords
        double[] array_X = new double[100];
        double[] array_Y = new double[100];
        double[] array_Z = new double[100];
        bool Calibrated = false;
        int i;
        byte[] feedback = new byte[2] { 127, 0 };

        // Physical Constants
        const double BASE_HEIGHT = 67.31;
        const double UPPER_ARM = 146.05;
        const double LOWER_ARM = 187.325;
        const double UPPER_ARM_SQ = UPPER_ARM * UPPER_ARM;
        const double LOWER_ARM_SQ = LOWER_ARM * LOWER_ARM;

        //Init of reference to the Kinect
        KinectSensor Kinect = KinectSensor.KinectSensors[0];

        //Init of reference to the tracked skeleton
        Skeleton[] User_Skeleton;

        // Parameter smoothing
        TransformSmoothParameters smooth_parameters = new TransformSmoothParameters { Correction = .2f, JitterRadius = .1f, MaxDeviationRadius = .2f, Prediction = .05f, Smoothing = .5f };

        // Setup serial ports
        SerialPort Serial_Xbee = new SerialPort();
        SerialPort Serial_Arm = new SerialPort();

        // Form constructor
        public Form1()
        {
            InitializeComponent();

            //Create a new event for when a frame of skeleton data is ready
            Kinect.SkeletonFrameReady += SkeletalFrameReady;

            //Enable the data streams from the RGB camera, the depth field from the infrared camera, and the processed
            //skeleton data stream
            Kinect.ColorStream.Enable(ColorImageFormat.RgbResolution640x480Fps30);
            Kinect.ColorFrameReady += new EventHandler<ColorImageFrameReadyEventArgs> (Kinect_ColorFrameReady);
            Kinect.DepthStream.Enable(DepthImageFormat.Resolution320x240Fps30);
            Kinect.SkeletonStream.Enable(smooth_parameters);

            // Init serial ports
            Init_Ports();

            // Form state
        }

        //This is the event handler for the SkeletonFrameReady event. This is the method that handles what to do with the skeleton data
        //when the Kinect indicates it has a frame of data ready.
        void SkeletalFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            //This is the exception handler that handles if the skeleton reference is empty or the wrong length
            if (User_Skeleton == null || User_Skeleton.Length != Kinect.SkeletonStream.FrameSkeletonArrayLength)
            {
                User_Skeleton = new Skeleton[Kinect.SkeletonStream.FrameSkeletonArrayLength];
            }

            //This method creates a new skeleton frame and sets it equal to the event argument SkeletonFrameReadyEventArgs.OpenSkeletonFrame
            //and then uses it to extract the skeleton from the skeleton frame
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                //Exception handler in the event that the frame was empty
                if (skeletonFrame != null)
                {
                    //Calls the CopySkeletonDataTo(Skeletons[] skeleton) method to copy the skeleton to the skeletons reference created earlier
                    skeletonFrame.CopySkeletonDataTo(User_Skeleton);

                    //Defines the instructions to be performed with each skeleton in the frame
                    foreach (Skeleton skeleton in User_Skeleton)
                    {
                        //Exception handler in the event that the skeleton in the collection is not tracked
                        if (skeleton.TrackingState == SkeletonTrackingState.Tracked)
                        {
                            //Initializes the references to the joints needed in the robotic arm project
                            Joint wrist_right = skeleton.Joints[JointType.WristRight];

                            // If nessisary joints are tracked
                            if (wrist_right.TrackingState == JointTrackingState.Tracked)
                            {
                                // If not calibrated
                                if (!Calibrated)
                                {
                                    // Populate arrays
                                    array_X[i] = wrist_right.Position.X;
                                    array_Y[i] = wrist_right.Position.Y;
                                    array_Z[i] = wrist_right.Position.Z;

                                    label1.Text = array_X[i].ToString();
                                    label2.Text = array_Y[i].ToString();
                                    label3.Text = array_Z[i].ToString();

                                    i++;
                                    progressBar1.Value = i;

                                    if (i == 100)
                                    {
                                        // Avg values
                                        center_X = Avg_Array(array_X);
                                        center_Y = Avg_Array(array_Y);
                                        center_Z = Avg_Array(array_Z);

                                        label1.Text = center_X.ToString();
                                        label2.Text = center_Y.ToString();
                                        label3.Text = center_Z.ToString();

                                        progressBar1.Visible = false;
                                        Calibrated = true;  // Finish calibration
                                    }
                                }

                                // If already calibrated
                                else
                                {
                                    double x = 500 * (wrist_right.Position.X - center_X);
                                    double z = 100 + (500 * (wrist_right.Position.Y - center_Y));
                                    double y = 100 + (500 * (center_Z - wrist_right.Position.Z));

                                    // Find angles
                                    Calc_Angles(x, y, z, (double)bytesOut[5]);

                                    // Feedback

                                    // Get feedback values
                                    if (Serial_Arm.BytesToRead > 1)
                                    {
                                        if ((byte)Serial_Arm.ReadByte() == (byte)48)
                                        {
                                            if (Serial_Arm.IsOpen)
                                            {
                                                feedback[1] = (byte)Serial_Arm.ReadByte();
                                            }
                                        }
                                    }
                                    Serial_Xbee.Write(feedback, 0, 2);

                                    // Output to arm
                                    if (bytesOut[2] > 0 && bytesOut[2] < 180 &&
                                        bytesOut[3] > 0 && bytesOut[3] < 180 &&
                                        bytesOut[4] > 0 && bytesOut[4] < 180)
                                    {
                                        Serial_Arm.Write(bytesOut, 0, 8);
                                    }

                                    // Debug labels
                                    label1.Text = bytesOut[2].ToString();
                                    label2.Text = bytesOut[3].ToString();
                                    label3.Text = bytesOut[4].ToString();
                                    label6.Text = bytesOut[5].ToString();
                                    label5.Text = bytesOut[6].ToString();
                                    label4.Text = bytesOut[7].ToString();
                                }
                            }
                        }
                    }
                }
            }
        }

        // When form is closing
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Stop Kinect
            Kinect.Stop();

            // Close serial ports
            Serial_Arm.Close();
            Serial_Xbee.Close();
        }

        // Starts Kinect
        private void Start_Click(object sender, EventArgs e)
        {
            //Start the Kinect
            try
            {
                Kinect.Start();
            }
            catch(System.IO.IOException)
            {
            }

            // Form state
            Calibrate.Enabled = true;
            Stop.Enabled = true;
            Start.Enabled = false;
            sensorAngle.Enabled = true;
            sensorAngle.Value = Kinect.ElevationAngle;
        }

        // Reset calibrate counter to center wrist
        private void Calibrate_Click(object sender, EventArgs e)
        {
            Calibrated = false;
            i = 0;

            // Form state
            Calibrate.Enabled = false;
            progressBar1.Visible = true;
        }

        // Average values in an array
        private double Avg_Array(double[] array)
        {
            double sum = 0;
            for (int n = 0; n < array.Length; n++)
            {
                sum += array[n];
            }
            sum = sum / array.Length;
            return (sum);
        }

        // Brings arm to rest, stops Kinect
        private void Stop_Click(object sender, EventArgs e)
        {
            // Stop Kinect
            Kinect.Stop();
            Calibrate.Enabled = false;
            Stop.Enabled = false;
            Start.Enabled = true;
            sensorAngle.Enabled = false;

            // Rest arm

        }

        /* My functions */
        private double RadianToDegree(double angle)
        {
            return (angle * 57.29578);
        }

        // Init serial ports
        private void Init_Ports()
        {
            // Setting up specifications for serial communication
            Serial_Arm.Close();
            Serial_Arm.PortName = "COM4";
            Serial_Arm.BaudRate = 9600;
            Serial_Arm.DataBits = 8;
            Serial_Arm.Parity = Parity.None;
            Serial_Arm.StopBits = StopBits.One;
            Serial_Arm.Encoding = Encoding.Default;
            Serial_Arm.DataReceived += new SerialDataReceivedEventHandler(Serial_Arm_DataReceived);
            Serial_Arm.Open();
            Serial_Arm.RtsEnable = true;

            Serial_Xbee.Close();
            Serial_Xbee.PortName = "COM6";
            Serial_Xbee.BaudRate = 9600;
            Serial_Xbee.DataBits = 8;
            Serial_Xbee.Parity = Parity.None;
            Serial_Xbee.StopBits = StopBits.One;
            Serial_Xbee.Encoding = Encoding.Default;
            Serial_Xbee.DataReceived += new SerialDataReceivedEventHandler(Serial_Xbee_DataReceived);
            Serial_Xbee.Open();
            Serial_Xbee.RtsEnable = true;
        }

        // Calculate angles
        private void Calc_Angles(double x, double y, double z, double wristAngle)
        {
            // Find base angle
            double base_Angle = Math.Atan2(y, x);
            // Find radial distance
            y = Math.Sqrt((x * x) + (y * y));
            // Adjust Z for base height
            z = z - BASE_HEIGHT;
            // Shoulder to wrist distance
            double sw_Squared = (z * z) + (y * y);
            double sw = Math.Sqrt(sw_Squared);
            // Right triangle angle
            double t1 = Math.Atan2(z, y);
            // Obtuse triangle angle
            double p1 = Math.Acos((-LOWER_ARM_SQ + UPPER_ARM_SQ + sw_Squared) / (2 * UPPER_ARM * sw));  // Law of cosines
            // Elbow angle
            double elbow_Angle = Math.Acos((LOWER_ARM_SQ + UPPER_ARM_SQ - sw_Squared) / (2 * LOWER_ARM * UPPER_ARM));   // Law of cosines
            // Shoulder angle
            double shoulder_Angle = t1 + p1;
            // Convert to degrees
            base_Angle = RadianToDegree(base_Angle);
            elbow_Angle = RadianToDegree(elbow_Angle);
            shoulder_Angle = RadianToDegree(shoulder_Angle);

            // Set bytes in ouput array
            bytesOut[2] = (byte)(base_Angle);
            bytesOut[3] = (byte)(shoulder_Angle);
            bytesOut[4] = (byte)(elbow_Angle);
        }

        // Just for testing
        private void debug_Button_Click(object sender, EventArgs e)
        {
        }

        // Changes the Kinect angle based on input from user
        private void sensorAngle_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                Kinect.ElevationAngle = (int)sensorAngle.Value;
            }
            catch (Exception a)
            {
            }
        }

        // Serial data received event handler
        private void Serial_Arm_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Get feedback values
            if (Serial_Arm.BytesToRead > 1)
            {
                if ((byte)Serial_Arm.ReadByte() == (byte)48)
                {
                    if (Serial_Arm.IsOpen)
                    {
                        //feedback[1] = (byte)Serial_Arm.ReadByte();
                    }
                }
            }
        }

        // Serial data received event handler
        private void Serial_Xbee_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // Get values from glove
            if (Serial_Xbee.BytesToRead > 4)
            {
                if ((byte)Serial_Xbee.ReadByte() == (byte)225 && (byte)Serial_Xbee.ReadByte() == (byte)47)
                {
                    Serial_Xbee.Read(bytesOut, 5, 3);
                }
            }
        }

        // Video stream
        void Kinect_ColorFrameReady(object sender, ColorImageFrameReadyEventArgs e)
        {
            ColorImageFrame imageFrame = e.OpenColorImageFrame();
            if (imageFrame != null)
            {
                Bitmap bmap = ImageToBitmap(imageFrame);
                pictureBox1.Image = bmap;
            }
        }

        // Used for video stream
        Bitmap ImageToBitmap(ColorImageFrame Image)
        {
            byte[] pixeldata = new byte[Image.PixelDataLength];
            Image.CopyPixelDataTo(pixeldata);
            Bitmap bmap = new Bitmap( Image.Width, Image.Height, PixelFormat.Format32bppRgb);
            BitmapData bmapdata = bmap.LockBits( new Rectangle(0, 0, Image.Width, Image.Height), ImageLockMode.WriteOnly, bmap.PixelFormat);
            IntPtr ptr = bmapdata.Scan0;
            Marshal.Copy(pixeldata, 0, ptr, Image.PixelDataLength);
            bmap.UnlockBits(bmapdata);
            return bmap;
        }
    }
}

