namespace VeritabanıYedeklemeProjesi
{
    partial class MainFTP
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFTP));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textFTPAdress = new System.Windows.Forms.TextBox();
            this.textUsername = new System.Windows.Forms.TextBox();
            this.textEnterTime = new System.Windows.Forms.TextBox();
            this.textDirectory = new System.Windows.Forms.TextBox();
            this.listDirect = new System.Windows.Forms.ListBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.buttonUploadFiles = new System.Windows.Forms.Button();
            this.timerGetList = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(216, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Kullanıcı";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(216, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "FTP Adresi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(468, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Dizin ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(468, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 17);
            this.label6.TabIndex = 6;
            this.label6.Text = "Giriş Zamanı";
            // 
            // textFTPAdress
            // 
            this.textFTPAdress.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textFTPAdress.Location = new System.Drawing.Point(300, 26);
            this.textFTPAdress.Name = "textFTPAdress";
            this.textFTPAdress.ReadOnly = true;
            this.textFTPAdress.Size = new System.Drawing.Size(148, 23);
            this.textFTPAdress.TabIndex = 8;
            // 
            // textUsername
            // 
            this.textUsername.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textUsername.Location = new System.Drawing.Point(300, 60);
            this.textUsername.Name = "textUsername";
            this.textUsername.ReadOnly = true;
            this.textUsername.Size = new System.Drawing.Size(148, 23);
            this.textUsername.TabIndex = 9;
            // 
            // textEnterTime
            // 
            this.textEnterTime.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textEnterTime.Location = new System.Drawing.Point(582, 26);
            this.textEnterTime.Name = "textEnterTime";
            this.textEnterTime.ReadOnly = true;
            this.textEnterTime.Size = new System.Drawing.Size(141, 23);
            this.textEnterTime.TabIndex = 10;
            // 
            // textDirectory
            // 
            this.textDirectory.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.textDirectory.Location = new System.Drawing.Point(582, 60);
            this.textDirectory.Name = "textDirectory";
            this.textDirectory.ReadOnly = true;
            this.textDirectory.Size = new System.Drawing.Size(141, 23);
            this.textDirectory.TabIndex = 11;
            // 
            // listDirect
            // 
            this.listDirect.FormattingEnabled = true;
            this.listDirect.Location = new System.Drawing.Point(218, 128);
            this.listDirect.Name = "listDirect";
            this.listDirect.Size = new System.Drawing.Size(179, 290);
            this.listDirect.TabIndex = 12;
            this.listDirect.Click += new System.EventHandler(this.listDirect_Click);
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.Location = new System.Drawing.Point(436, 128);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(409, 290);
            this.listFiles.TabIndex = 13;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(176, 218);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(278, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 17);
            this.label3.TabIndex = 15;
            this.label3.Text = "Dizinler";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(601, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 16;
            this.label4.Text = "Dosyalar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(68, 267);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "İşlemler";
            // 
            // buttonUploadFiles
            // 
            this.buttonUploadFiles.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonUploadFiles.Location = new System.Drawing.Point(25, 287);
            this.buttonUploadFiles.Name = "buttonUploadFiles";
            this.buttonUploadFiles.Size = new System.Drawing.Size(146, 28);
            this.buttonUploadFiles.TabIndex = 19;
            this.buttonUploadFiles.Text = "Diskteki Yedekleri Yükle";
            this.buttonUploadFiles.UseVisualStyleBackColor = true;
            this.buttonUploadFiles.Click += new System.EventHandler(this.buttonUploadFiles_Click);
            // 
            // timerGetList
            // 
            this.timerGetList.Interval = 10000;
            this.timerGetList.Tick += new System.EventHandler(this.timerGetList_Tick);
            // 
            // MainFTP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 438);
            this.Controls.Add(this.buttonUploadFiles);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.listDirect);
            this.Controls.Add(this.textDirectory);
            this.Controls.Add(this.textEnterTime);
            this.Controls.Add(this.textUsername);
            this.Controls.Add(this.textFTPAdress);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainFTP";
            this.Text = "FTP Ana Paneli";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textFTPAdress;
        private System.Windows.Forms.TextBox textUsername;
        private System.Windows.Forms.TextBox textEnterTime;
        private System.Windows.Forms.TextBox textDirectory;
        private System.Windows.Forms.ListBox listDirect;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button buttonUploadFiles;
        private System.Windows.Forms.Timer timerGetList;
    }
}