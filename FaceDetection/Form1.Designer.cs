namespace FaceDetection
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
            this.DeviceDropBox = new System.Windows.Forms.ComboBox();
            this.DeviceLbl = new System.Windows.Forms.Label();
            this.picBox = new System.Windows.Forms.PictureBox();
            this.FacesLbl = new System.Windows.Forms.Label();
            this.NumOfFacesLbl = new System.Windows.Forms.Label();
            this.browseBtn = new System.Windows.Forms.Button();
            this.browseLbl = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileNameLbl = new System.Windows.Forms.Label();
            this.stopBtn = new System.Windows.Forms.Button();
            this.urlLbl = new System.Windows.Forms.Label();
            this.urlTxtBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).BeginInit();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(766, 64);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(145, 48);
            this.Start.TabIndex = 3;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // DeviceDropBox
            // 
            this.DeviceDropBox.FormattingEnabled = true;
            this.DeviceDropBox.Location = new System.Drawing.Point(72, 37);
            this.DeviceDropBox.Name = "DeviceDropBox";
            this.DeviceDropBox.Size = new System.Drawing.Size(121, 21);
            this.DeviceDropBox.TabIndex = 4;
            // 
            // DeviceLbl
            // 
            this.DeviceLbl.AutoSize = true;
            this.DeviceLbl.Location = new System.Drawing.Point(22, 40);
            this.DeviceLbl.Name = "DeviceLbl";
            this.DeviceLbl.Size = new System.Drawing.Size(44, 13);
            this.DeviceLbl.TabIndex = 5;
            this.DeviceLbl.Text = "Device:";
            // 
            // picBox
            // 
            this.picBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picBox.Location = new System.Drawing.Point(15, 64);
            this.picBox.Name = "picBox";
            this.picBox.Size = new System.Drawing.Size(744, 488);
            this.picBox.TabIndex = 6;
            this.picBox.TabStop = false;
            // 
            // FacesLbl
            // 
            this.FacesLbl.AutoSize = true;
            this.FacesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FacesLbl.Location = new System.Drawing.Point(782, 225);
            this.FacesLbl.Name = "FacesLbl";
            this.FacesLbl.Size = new System.Drawing.Size(120, 17);
            this.FacesLbl.TabIndex = 7;
            this.FacesLbl.Text = "Number of faces: ";
            // 
            // NumOfFacesLbl
            // 
            this.NumOfFacesLbl.AutoSize = true;
            this.NumOfFacesLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumOfFacesLbl.ForeColor = System.Drawing.Color.Red;
            this.NumOfFacesLbl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NumOfFacesLbl.Location = new System.Drawing.Point(825, 242);
            this.NumOfFacesLbl.Name = "NumOfFacesLbl";
            this.NumOfFacesLbl.Size = new System.Drawing.Size(30, 31);
            this.NumOfFacesLbl.TabIndex = 8;
            this.NumOfFacesLbl.Text = "0";
            // 
            // browseBtn
            // 
            this.browseBtn.Location = new System.Drawing.Point(249, 35);
            this.browseBtn.Name = "browseBtn";
            this.browseBtn.Size = new System.Drawing.Size(75, 23);
            this.browseBtn.TabIndex = 9;
            this.browseBtn.Text = "Browse";
            this.browseBtn.UseVisualStyleBackColor = true;
            this.browseBtn.Click += new System.EventHandler(this.browseBtn_Click);
            // 
            // browseLbl
            // 
            this.browseLbl.AutoSize = true;
            this.browseLbl.Location = new System.Drawing.Point(212, 40);
            this.browseLbl.Name = "browseLbl";
            this.browseLbl.Size = new System.Drawing.Size(31, 13);
            this.browseLbl.TabIndex = 10;
            this.browseLbl.Text = "Files:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // fileNameLbl
            // 
            this.fileNameLbl.AutoSize = true;
            this.fileNameLbl.Location = new System.Drawing.Point(440, 40);
            this.fileNameLbl.Name = "fileNameLbl";
            this.fileNameLbl.Size = new System.Drawing.Size(0, 13);
            this.fileNameLbl.TabIndex = 11;
            // 
            // stopBtn
            // 
            this.stopBtn.Location = new System.Drawing.Point(766, 118);
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(145, 48);
            this.stopBtn.TabIndex = 12;
            this.stopBtn.Text = "Stop";
            this.stopBtn.UseVisualStyleBackColor = true;
            this.stopBtn.Click += new System.EventHandler(this.StopBtn_Click);
            // 
            // urlLbl
            // 
            this.urlLbl.AutoSize = true;
            this.urlLbl.Location = new System.Drawing.Point(349, 40);
            this.urlLbl.Name = "urlLbl";
            this.urlLbl.Size = new System.Drawing.Size(32, 13);
            this.urlLbl.TabIndex = 13;
            this.urlLbl.Text = "URL:";
            this.urlLbl.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // urlTxtBox
            // 
            this.urlTxtBox.Location = new System.Drawing.Point(387, 37);
            this.urlTxtBox.Name = "urlTxtBox";
            this.urlTxtBox.Size = new System.Drawing.Size(373, 20);
            this.urlTxtBox.TabIndex = 14;
            this.urlTxtBox.Text = "http://192.168.1.1/videostream.cgi?user=admin&pwd=";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(924, 574);
            this.Controls.Add(this.urlTxtBox);
            this.Controls.Add(this.urlLbl);
            this.Controls.Add(this.stopBtn);
            this.Controls.Add(this.fileNameLbl);
            this.Controls.Add(this.browseLbl);
            this.Controls.Add(this.browseBtn);
            this.Controls.Add(this.NumOfFacesLbl);
            this.Controls.Add(this.FacesLbl);
            this.Controls.Add(this.picBox);
            this.Controls.Add(this.DeviceLbl);
            this.Controls.Add(this.DeviceDropBox);
            this.Controls.Add(this.Start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.ComboBox DeviceDropBox;
        private System.Windows.Forms.Label DeviceLbl;
        private System.Windows.Forms.PictureBox picBox;
        private System.Windows.Forms.Label FacesLbl;
        private System.Windows.Forms.Label NumOfFacesLbl;
        private System.Windows.Forms.Button browseBtn;
        private System.Windows.Forms.Label browseLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label fileNameLbl;
        private System.Windows.Forms.Button stopBtn;
        private System.Windows.Forms.Label urlLbl;
        private System.Windows.Forms.TextBox urlTxtBox;
    }
}

