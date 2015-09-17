using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using System.IO;


namespace VeritabanıYedeklemeProjesi
{
    public partial class BackUpSettings : Form
    {
        BackUp BackUpObj = new BackUp();
        //ThreadingClass[] ThreadObj;
        List<ThreadingClass> ThreadObj = new List<ThreadingClass>();


        /*Copy Only ve No Truncate Özelliği isteniyorsa CopyOnly stringinin sonuna virgül eklenmelidir.(SQL cümleciği doğruluğu için) */

        string ServerName, UserName, Password, BackUpLocation;
        List<string> databaseNames = new List<string>();

        public BackUpSettings(string ServerName, string UserName, string Password, string Location)
        {
            this.ServerName = ServerName;
            this.UserName = UserName;
            this.Password = Password;
            this.BackUpLocation = Location;

            InitializeComponent();
            dataGridDoldur();
            timerGetFileNames.Interval = 5000;
            timerGetFileNames.Enabled = true;

            GetFileNamesFromFolder();
        }

        private void listBackUps_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            richTextLog.Text = "";
            string selectedBackUp = "";

            try
            {
                if (listBackUps.SelectedItem != null)
                {
                    selectedBackUp = listBackUps.SelectedItem.ToString();
                }

                List<string> list = BackUpObj.BackUpLogs(ServerName, UserName, Password, BackUpLocation + selectedBackUp);

                for (int i = 0; i < list.Count; i++)
                {
                    richTextLog.Text += list[i];
                }
            }

            catch
            {
                MessageBox.Show("BİLGİLERİNİ GÖRÜNTÜLEMEK İSTEDİĞİNİZ VERİTABANI YEDEĞİNE TIKLAYIN.");
            }
        }

        public void GetFileNamesFromFolder()
        {
            //Diskteki yedekleri görüntüleyen fonksiyon
            try
            {
                List<string> databaseBackUps = new List<string>();
                int index = listBackUps.SelectedIndex;

                listBackUps.DataSource = null;
                DirectoryInfo BackUpFilesInfo = new DirectoryInfo(@BackUpLocation);
                foreach (FileInfo Inf in BackUpFilesInfo.GetFiles())
                {
                    databaseBackUps.Add(Inf.Name);
                }

                listBackUps.DataSource = databaseBackUps;
                if (index > -1 && listBackUps.Items.Count >= index)
                {
                    listBackUps.SetSelected(index, true);
                }
            }

            catch
            {
                MessageBox.Show("BEKLENMEDİK BİR HATA OLUŞTU.");
            }
            
        }

        private void timerGetFileNames_Tick(object sender, EventArgs e)
        {
            GetFileNamesFromFolder();
            //dataGridKontrol();
        }

    

       

        private void textSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            listBackUps.SelectedItems.Clear();

            for (int i = 0; i < listBackUps.Items.Count; i++)
            {
                if (listBackUps.Items[i].ToString().Contains(textSearch.Text))
                {
                    listBackUps.SetSelected(i, true);
                }
            }
        }

        private void veritabanıEkleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddDatabaseForBackUp FormAddDb = new FormAddDatabaseForBackUp(ServerName, UserName, Password, dataGridBackUp);
            FormAddDb.Enabled = true;
            FormAddDb.Show();
            
        }

        private void yedeklemeAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateBackUpSettings FormUpdate = new UpdateBackUpSettings();
            FormUpdate.Enabled = true;
            FormUpdate.Show();
        }

        private void yedeklemeKayıtlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormLog LogForm = new FormLog();
            LogForm.Enabled = true;
            LogForm.Show();
        }


        public void dataGridDoldur()
        {
            dataGridBackUp.Rows.Clear();
            dataGridBackUp.Refresh();
            List<string> list = BackUpObj.GetDatabaseNames();

            for (int i = 0; i < list.Count; i++)
            {
                dataGridBackUp.Rows.Add(list[i],"Yedeklemeyi Başlat");
            }

            //ThreadObj = new ThreadingClass[list.Count];
        }

        
        

        private void dataGridBackUp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1 && e.ColumnIndex == BackUpStart.Index)
            {
                if (dataGridBackUp.Rows[e.RowIndex].Cells[1].Value.ToString() == "Yedeklemeyi Başlat")
                {
                    ThreadObj.Add(new ThreadingClass(ServerName, UserName, Password, Convert.ToString(dataGridBackUp.Rows[e.RowIndex].Cells[0].Value), BackUpLocation));
                    for (int i = 0; i < ThreadObj.Count; i++)
                    {
                        if(ThreadObj[i].DatabaseName == dataGridBackUp.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            ThreadObj[i].StartThread();
                            dataGridBackUp.Rows[e.RowIndex].Cells[1].Value = "Yedeklemeyi Durdur";
                            break;
                        }
                    }
                        
                }

                else if(dataGridBackUp.Rows[e.RowIndex].Cells[1].Value.ToString() == "Yedeklemeyi Durdur")
                {
                    for (int i = 0; i < ThreadObj.Count; i++)
                    {
                        if (ThreadObj[i].DatabaseName == dataGridBackUp.Rows[e.RowIndex].Cells[0].Value.ToString())
                        {
                            ThreadObj[i].CancelThread();
                            dataGridBackUp.Rows[e.RowIndex].Cells[1].Value = "Yedeklemeyi Başlat";
                            break;
                        }
                    }
                   
                }
              

                
            }
        }

        private void buttonStartAllDatabase_Click(object sender, EventArgs e)
        {
            if (dataGridBackUp.Rows.Count < 1)
            {
                MessageBox.Show("SİSTEME VERİTABANI EKLENİLMEMİŞ");
            }
            else
            {
                for (int i = 0; i < dataGridBackUp.Rows.Count; i++)
                {
                    if (dataGridBackUp.Rows[i].Cells[1].Value.ToString() == "Yedeklemeyi Başlat")
                    {
                        ThreadObj.Add(new ThreadingClass(ServerName, UserName, Password, Convert.ToString(dataGridBackUp.Rows[i].Cells[0].Value), BackUpLocation));
                        for (int j = 0; j < ThreadObj.Count; j++)
                        {
                            if (ThreadObj[j].DatabaseName == dataGridBackUp.Rows[i].Cells[0].Value.ToString())
                            {
                                ThreadObj[j].StartThread();
                                dataGridBackUp.Rows[i].Cells[1].Value = "Yedeklemeyi Durdur";
                                break;
                            }
                        }

                    }

                    else
                    {

                    }
                }
            }
        }

        private void buttonStopAllDatabase_Click(object sender, EventArgs e)
        {
            if (dataGridBackUp.Rows.Count < 1)
            {
                MessageBox.Show("SİSTEME VERİTABANI EKLENİLMEMİŞ");
            }
            else
            {
                for (int i = 0; i < dataGridBackUp.Rows.Count; i++)
                {
                    if (dataGridBackUp.Rows[i].Cells[1].Value.ToString() == "Yedeklemeyi Durdur")
                    {
                        ThreadObj.Add(new ThreadingClass(ServerName, UserName, Password, Convert.ToString(dataGridBackUp.Rows[i].Cells[0].Value), BackUpLocation));
                        for (int j = 0; j < ThreadObj.Count; j++)
                        {
                            if (ThreadObj[j].DatabaseName == dataGridBackUp.Rows[i].Cells[0].Value.ToString())
                            {
                                ThreadObj[j].CancelThread();
                                dataGridBackUp.Rows[i].Cells[1].Value = "Yedeklemeyi Başlat";
                                break;
                            }
                        }

                    }

                    else
                    {

                    }
                }
            }
        }

        private void fTPServerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFTPEnter EnterFTP = new FormFTPEnter(BackUpLocation);
            EnterFTP.Enabled = true;
            EnterFTP.Show();
        }

    }
}
