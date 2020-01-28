using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using AForge.Video;
using AForge.Video.DirectShow;
using Emgu.CV.Structure;
using System.IO;
using System.Windows.Threading;
using System.Drawing.Imaging;
using Accord.Video.VFW;

namespace FaceDetection
{
    public partial class Form1 : Form
    {
        static readonly CascadeClassifier cascadeClassifier = new CascadeClassifier("haarcascade_frontalface_alt_tree.xml");
        FilterInfoCollection videoDevices;
        VideoCaptureDevice device;
        ScreenCaptureStream stream;
        FileVideoSource videoSource;
        MJPEGStream jpegStream;
        AsyncVideoSource asyncVS;
        string filePath;
        static int numOfImg;
        int numOfFaces;
        private int secondInFrames;
        private int secondInFramesDefault;
        bool faceDetected;
        AVIWriter writer;
        bool isRecording = false;
        string safeFilePath;

        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            secondInFramesDefault = 150;
            
            
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            
            //fill dropbox
            foreach (FilterInfo device in videoDevices)
            {
                DeviceDropBox.Items.Add(device.Name);
            }
            DeviceDropBox.Items.Add("Video File");
            DeviceDropBox.SelectedIndex = 2;
            device = new VideoCaptureDevice();
            videoSource = new FileVideoSource();
            writer = new AVIWriter();
            //asyncVS = new AsyncVideoSource();
            secondInFrames = secondInFramesDefault;

        }

        private void Start_Click(object sender, EventArgs e)
        {
            if (urlTxtBox.Text.Any())
            {
                jpegStream = new MJPEGStream(urlTxtBox.Text);
                asyncVS = new AsyncVideoSource(jpegStream);
                asyncVS.NewFrame += Device_NewFrameAsync;
                asyncVS.Start();

            }

            else if (DeviceDropBox.Text.Equals("Video File"))
            {
                videoSource = new FileVideoSource(filePath);
                // set NewFrame event handler
                videoSource.NewFrame += Device_NewFrameAsync;
                videoSource.VideoSourceError += new VideoSourceErrorEventHandler(videoSource_Error);
                // start the video source
                videoSource.Start();
            }
            
            else 
            {
                //VideoCaptureDevice vcd = new VideoCaptureDevice(stream.Source);
                var selected = DeviceDropBox.SelectedIndex;
                device = new VideoCaptureDevice(videoDevices[selected].MonikerString);
                device.NewFrame += Device_NewFrameAsync;

                device.Start();
            }

            
        }
        private void videoSource_Error(object sender, VideoSourceErrorEventArgs eventArgs)
        {
            Console.WriteLine(eventArgs.Description);
        }


        private void Device_NewFrameAsync(object sender, NewFrameEventArgs eventArgs)
        {
            numOfFaces = 0;
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            Bitmap newImage = ResizeBitmap(bitmap, picBox.Width, picBox.Height);
            Detect(newImage);

            if (FaceDetected())
            {
                
                Record(newImage);
                secondInFrames = secondInFramesDefault;
                BeginInvoke(new Action(() =>               
                {             
                    NumOfFacesLbl.Text = numOfFaces.ToString();                 
                }));            
            }
            else if (isRecording)
            {          
                if(secondInFrames == 0)
                {                 
                    StopRecord();                   
                    numOfImg++;
                    secondInFrames = secondInFramesDefault ;                   
                }                   
                else                  
                {                   
                    Record(newImage);                   
                    secondInFrames--;
                }
                BeginInvoke(new Action(() =>
                {
                    NumOfFacesLbl.Text = numOfFaces.ToString();
                }));
            }


            /*else if (recording && !FaceDetected() && secondInFrames == 0)
            {
                StopRecord();
                numOfImg++;
            }
           */
            picBox.Image = newImage;
        }
        public Bitmap ResizeBitmap(Bitmap bmp, int width, int height)
        {
            Bitmap result = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(bmp, 0, 0, width, height);
            }

            return result;
        }
        public void Detect(Bitmap newImage)
        {
            Image<Bgr, byte> grayImage = new Image<Bgr, byte>(newImage);
            Rectangle[] rectangles = cascadeClassifier.DetectMultiScale(grayImage, 1.2, 1);
            numOfFaces = rectangles.Count();
            
            foreach (Rectangle rectangle in rectangles)
            {
                using (Graphics graphics = Graphics.FromImage(newImage))
                {
                    using (Pen pen = new Pen(Color.Red, 1))
                    {
                        graphics.DrawRectangle(pen, rectangle);

                    }
                }

            }
        }
        public bool FaceDetected()
        {
            if (numOfFaces != 0)
            {
                return true;
            }
            return false;
        }
        public void Record(Bitmap frame)
        {
            // int width = frame.Width - (frame.Width % 2);
            // int height = frame.Width - (frame.Height % 2);
            if (!isRecording)
            {
                isRecording = true;
                writer.Open(@"C:\Users\navar\OneDrive\Pictures\FaceDetection\Face-" + numOfImg + ".avi", frame.Width, frame.Height);
                
            }
            
            writer.AddFrame(frame);



        }
        public void StopRecord()
        {
            isRecording = false;
            writer.Close();
        }

        
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isRecording)
            {
                StopRecord();
            }
            if (device.IsRunning)
            {
                device.Stop();
            }
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
            if (asyncVS is null)
            {
                return;
            }
            if (asyncVS.IsRunning)
            {
                asyncVS.Stop();
            }

        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            int size = -1;
            openFileDialog1.Filter = "Video Files(*.AVI;*.FLV;*.WMV;*.MOV;*.MP4)|*.AVI;*.FLV;*.WMV;*.MOV;*.MP4";
            openFileDialog1.RestoreDirectory = true;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                filePath = openFileDialog1.FileName;
                safeFilePath = openFileDialog1.SafeFileName;
                fileNameLbl.Text = openFileDialog1.SafeFileName;
                try
                {
                   // string text = File.ReadAllText(filePath);
                    //size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.

        }

        private void StopBtn_Click(object sender, EventArgs e)
        {
            if (isRecording)
            {
                StopRecord();
            }
            if (device.IsRunning)
            {
                device.Stop();
            }
            if (videoSource.IsRunning)
            {
                videoSource.Stop();
            }
            if (asyncVS is null || asyncVS.IsRunning)
            {
                try
                {
                    asyncVS.Stop();
                }
                catch (Exception)
                {

                    
                }
                
            }
            picBox.Image = null;
        }

        
    }
}
