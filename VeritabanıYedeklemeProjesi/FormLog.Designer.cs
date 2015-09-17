namespace VeritabanıYedeklemeProjesi
{
    partial class FormLog
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
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridLog = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLog)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.buttonRefresh.ForeColor = System.Drawing.Color.Red;
            this.buttonRefresh.Location = new System.Drawing.Point(41, 38);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(107, 27);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "Yenile";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridLog
            // 
            this.dataGridLog.AllowUserToAddRows = false;
            this.dataGridLog.AllowUserToDeleteRows = false;
            this.dataGridLog.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridLog.Location = new System.Drawing.Point(41, 71);
            this.dataGridLog.Name = "dataGridLog";
            this.dataGridLog.ReadOnly = true;
            this.dataGridLog.Size = new System.Drawing.Size(671, 443);
            this.dataGridLog.TabIndex = 1;
            // 
            // FormLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(768, 526);
            this.Controls.Add(this.dataGridLog);
            this.Controls.Add(this.buttonRefresh);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormLog";
            this.Text = "KAYITLAR";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridLog)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridLog;
    }
}