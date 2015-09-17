namespace VeritabanıYedeklemeProjesi
{
    partial class BackUpSettings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BackUpSettings));
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.richTextLog = new System.Windows.Forms.RichTextBox();
            this.textSearch = new System.Windows.Forms.TextBox();
            this.listBackUps = new System.Windows.Forms.ListBox();
            this.timerGetFileNames = new System.Windows.Forms.Timer(this.components);
            this.menuBackUp = new System.Windows.Forms.MenuStrip();
            this.işlemlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.veritabanıEkleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yedeklemeAyarlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yedeklemeKayıtlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.yedeklemeKonumlarıToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fTPServerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridBackUp = new System.Windows.Forms.DataGridView();
            this.DatabaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BackUpStart = new System.Windows.Forms.DataGridViewButtonColumn();
            this.buttonStopAllDatabase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonStartAllDatabase = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.menuBackUp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackUp)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(464, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Diskteki Yedekler";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(745, 44);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 17);
            this.label5.TabIndex = 4;
            this.label5.Text = "Yedek Bilgileri";
            // 
            // richTextLog
            // 
            this.richTextLog.Location = new System.Drawing.Point(674, 108);
            this.richTextLog.Name = "richTextLog";
            this.richTextLog.ReadOnly = true;
            this.richTextLog.Size = new System.Drawing.Size(239, 240);
            this.richTextLog.TabIndex = 12;
            this.richTextLog.Text = "";
            // 
            // textSearch
            // 
            this.textSearch.Location = new System.Drawing.Point(467, 78);
            this.textSearch.Name = "textSearch";
            this.textSearch.Size = new System.Drawing.Size(171, 20);
            this.textSearch.TabIndex = 13;
            this.textSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textSearch_KeyPress);
            // 
            // listBackUps
            // 
            this.listBackUps.FormattingEnabled = true;
            this.listBackUps.Location = new System.Drawing.Point(419, 108);
            this.listBackUps.Name = "listBackUps";
            this.listBackUps.Size = new System.Drawing.Size(219, 355);
            this.listBackUps.TabIndex = 14;
            this.listBackUps.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listBackUps_MouseDoubleClick);
            // 
            // timerGetFileNames
            // 
            this.timerGetFileNames.Interval = 5000;
            this.timerGetFileNames.Tick += new System.EventHandler(this.timerGetFileNames_Tick);
            // 
            // menuBackUp
            // 
            this.menuBackUp.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuBackUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.işlemlerToolStripMenuItem,
            this.yedeklemeKonumlarıToolStripMenuItem});
            this.menuBackUp.Location = new System.Drawing.Point(0, 0);
            this.menuBackUp.Name = "menuBackUp";
            this.menuBackUp.Size = new System.Drawing.Size(954, 24);
            this.menuBackUp.TabIndex = 16;
            this.menuBackUp.Text = "menuStrip1";
            // 
            // işlemlerToolStripMenuItem
            // 
            this.işlemlerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.veritabanıEkleToolStripMenuItem,
            this.yedeklemeAyarlarıToolStripMenuItem,
            this.yedeklemeKayıtlarıToolStripMenuItem});
            this.işlemlerToolStripMenuItem.Name = "işlemlerToolStripMenuItem";
            this.işlemlerToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.işlemlerToolStripMenuItem.Text = "İşlemler";
            // 
            // veritabanıEkleToolStripMenuItem
            // 
            this.veritabanıEkleToolStripMenuItem.Name = "veritabanıEkleToolStripMenuItem";
            this.veritabanıEkleToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.veritabanıEkleToolStripMenuItem.Text = "Veritabanı Ekle";
            this.veritabanıEkleToolStripMenuItem.Click += new System.EventHandler(this.veritabanıEkleToolStripMenuItem_Click);
            // 
            // yedeklemeAyarlarıToolStripMenuItem
            // 
            this.yedeklemeAyarlarıToolStripMenuItem.Name = "yedeklemeAyarlarıToolStripMenuItem";
            this.yedeklemeAyarlarıToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.yedeklemeAyarlarıToolStripMenuItem.Text = "Yedekleme Ayarları";
            this.yedeklemeAyarlarıToolStripMenuItem.Click += new System.EventHandler(this.yedeklemeAyarlarıToolStripMenuItem_Click);
            // 
            // yedeklemeKayıtlarıToolStripMenuItem
            // 
            this.yedeklemeKayıtlarıToolStripMenuItem.Name = "yedeklemeKayıtlarıToolStripMenuItem";
            this.yedeklemeKayıtlarıToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.yedeklemeKayıtlarıToolStripMenuItem.Text = "Yedekleme Kayıtları";
            this.yedeklemeKayıtlarıToolStripMenuItem.Click += new System.EventHandler(this.yedeklemeKayıtlarıToolStripMenuItem_Click);
            // 
            // yedeklemeKonumlarıToolStripMenuItem
            // 
            this.yedeklemeKonumlarıToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fTPServerToolStripMenuItem});
            this.yedeklemeKonumlarıToolStripMenuItem.Name = "yedeklemeKonumlarıToolStripMenuItem";
            this.yedeklemeKonumlarıToolStripMenuItem.Size = new System.Drawing.Size(135, 20);
            this.yedeklemeKonumlarıToolStripMenuItem.Text = "Yedekleme Konumları";
            // 
            // fTPServerToolStripMenuItem
            // 
            this.fTPServerToolStripMenuItem.Name = "fTPServerToolStripMenuItem";
            this.fTPServerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.fTPServerToolStripMenuItem.Text = "FTP Server";
            this.fTPServerToolStripMenuItem.Click += new System.EventHandler(this.fTPServerToolStripMenuItem_Click);
            // 
            // dataGridBackUp
            // 
            this.dataGridBackUp.AllowUserToAddRows = false;
            this.dataGridBackUp.AllowUserToDeleteRows = false;
            this.dataGridBackUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBackUp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DatabaseName,
            this.BackUpStart});
            this.dataGridBackUp.Location = new System.Drawing.Point(28, 108);
            this.dataGridBackUp.Name = "dataGridBackUp";
            this.dataGridBackUp.ReadOnly = true;
            this.dataGridBackUp.Size = new System.Drawing.Size(342, 353);
            this.dataGridBackUp.TabIndex = 17;
            this.dataGridBackUp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBackUp_CellContentClick);
            // 
            // DatabaseName
            // 
            this.DatabaseName.HeaderText = "VeritabanıAdı";
            this.DatabaseName.Name = "DatabaseName";
            this.DatabaseName.ReadOnly = true;
            this.DatabaseName.Width = 150;
            // 
            // BackUpStart
            // 
            this.BackUpStart.HeaderText = "Başla";
            this.BackUpStart.Name = "BackUpStart";
            this.BackUpStart.ReadOnly = true;
            this.BackUpStart.Width = 150;
            // 
            // buttonStopAllDatabase
            // 
            this.buttonStopAllDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonStopAllDatabase.ForeColor = System.Drawing.Color.Red;
            this.buttonStopAllDatabase.Image = ((System.Drawing.Image)(resources.GetObject("buttonStopAllDatabase.Image")));
            this.buttonStopAllDatabase.Location = new System.Drawing.Point(229, 76);
            this.buttonStopAllDatabase.Name = "buttonStopAllDatabase";
            this.buttonStopAllDatabase.Size = new System.Drawing.Size(33, 26);
            this.buttonStopAllDatabase.TabIndex = 19;
            this.buttonStopAllDatabase.UseVisualStyleBackColor = true;
            this.buttonStopAllDatabase.Click += new System.EventHandler(this.buttonStopAllDatabase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(130, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 15);
            this.label1.TabIndex = 20;
            this.label1.Text = "Tümünü Başlat";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(130, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 15);
            this.label3.TabIndex = 21;
            this.label3.Text = "Tümünü Durdur";
            // 
            // buttonStartAllDatabase
            // 
            this.buttonStartAllDatabase.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonStartAllDatabase.ForeColor = System.Drawing.Color.Red;
            this.buttonStartAllDatabase.Image = ((System.Drawing.Image)(resources.GetObject("buttonStartAllDatabase.Image")));
            this.buttonStartAllDatabase.Location = new System.Drawing.Point(229, 44);
            this.buttonStartAllDatabase.Name = "buttonStartAllDatabase";
            this.buttonStartAllDatabase.Size = new System.Drawing.Size(33, 26);
            this.buttonStartAllDatabase.TabIndex = 18;
            this.buttonStartAllDatabase.UseVisualStyleBackColor = true;
            this.buttonStartAllDatabase.Click += new System.EventHandler(this.buttonStartAllDatabase_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(416, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 15);
            this.label6.TabIndex = 22;
            this.label6.Text = "Arama:";
            // 
            // BackUpSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 479);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonStopAllDatabase);
            this.Controls.Add(this.buttonStartAllDatabase);
            this.Controls.Add(this.dataGridBackUp);
            this.Controls.Add(this.listBackUps);
            this.Controls.Add(this.textSearch);
            this.Controls.Add(this.richTextLog);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.menuBackUp);
            this.MainMenuStrip = this.menuBackUp;
            this.Name = "BackUpSettings";
            this.Text = "VERİTABANI YEDEKLEME PROGRAMI";
            this.menuBackUp.ResumeLayout(false);
            this.menuBackUp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBackUp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox richTextLog;
        private System.Windows.Forms.TextBox textSearch;
        private System.Windows.Forms.ListBox listBackUps;
        private System.Windows.Forms.Timer timerGetFileNames;
        private System.Windows.Forms.MenuStrip menuBackUp;
        private System.Windows.Forms.ToolStripMenuItem işlemlerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem veritabanıEkleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yedeklemeAyarlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem yedeklemeKayıtlarıToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridBackUp;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatabaseName;
        private System.Windows.Forms.DataGridViewButtonColumn BackUpStart;
        private System.Windows.Forms.Button buttonStopAllDatabase;
        private System.Windows.Forms.ToolStripMenuItem yedeklemeKonumlarıToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fTPServerToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonStartAllDatabase;
        private System.Windows.Forms.Label label6;
    }
}