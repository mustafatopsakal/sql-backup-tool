using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace VeritabanıYedeklemeProjesi
{
    public partial class MainFTP : Form
    {
        string FTPAdress, Username, EnterTime, Password, DiskLocation;

        public MainFTP(string FTPAdress, string Username, string EnterTime, string Password, string DiskLocation)
        {
            InitializeComponent();
            this.FTPAdress = FTPAdress;
            this.Username = Username;
            this.EnterTime = EnterTime;
            this.Password = Password;
            this.DiskLocation = DiskLocation;

            textFTPAdress.Text = FTPAdress;
            textUsername.Text = Username;
            textEnterTime.Text = EnterTime;

            ClassFTP FTPObj = new ClassFTP(FTPAdress, Username, Password);
            FTPObj.getDirectories(listDirect);

           
           
            timerGetList.Enabled = true;
        }

        private void listDirect_Click(object sender, EventArgs e)
        {
          if (listDirect.SelectedItem.ToString() != "")
            {
                //this.Directory = null;
                try
                {
                    textDirectory.Text = listDirect.SelectedItem.ToString();
                    listFiles.Items.Clear();
                    ClassFTP FTPObj = new ClassFTP(FTPAdress, Username, Password);
                    FTPObj.ListFiles(listDirect.SelectedItem.ToString(), listFiles);
                }
               catch
                {
                    MessageBox.Show("BİR HATA OLUŞTU");
                    int index = listDirect.SelectedIndex;
                    ClassFTP FTPObj = new ClassFTP(FTPAdress, Username, Password);
                    listDirect.Items.Clear();
                    listFiles.Items.Clear();
                    FTPObj.getDirectories(listDirect);


                    if (index > -1 && listDirect.Items.Count >= index)
                    {
                        listDirect.SelectedIndex = index;
                    }
                }
            }
        }

       

        private void buttonUploadFiles_Click(object sender, EventArgs e)
        {
            ClassFTP FTPObj = new ClassFTP(FTPAdress, Username, Password);

            int index = listDirect.FindString("SQLDatabaseBackUp");
            if (index > -1)
            {
                //Listede Klasör Var.
            }
            else
            {
                FTPObj.CreateNewDirectory("SQLDatabaseBackUp");
                listDirect.Items.Clear();
                listFiles.Items.Clear();
                FTPObj.getDirectories(listDirect);
            }

            List<string> databaseBackUps = new List<string>();
            DirectoryInfo BackUpFilesInfo = new DirectoryInfo(@DiskLocation);
            foreach (FileInfo Inf in BackUpFilesInfo.GetFiles())
            {
                databaseBackUps.Add(Inf.Name);
            }

            for (int i = 0; i < databaseBackUps.Count; i++)
            {
                FTPObj.UploadFile(DiskLocation, databaseBackUps[i].ToString(), "SQLDatabaseBackUp");
            }
        }

        private void timerGetList_Tick(object sender, EventArgs e)
        {

            int index = listDirect.SelectedIndex;
            ClassFTP FTPObj = new ClassFTP(FTPAdress, Username, Password);
            listDirect.Items.Clear();
            listFiles.Items.Clear();
            FTPObj.getDirectories(listDirect);
            

            if (index > -1 && listDirect.Items.Count >= index)
            {
                listDirect.SelectedIndex = index;
            }
           
        }

        
    }
}
