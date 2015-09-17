using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VeritabanıYedeklemeProjesi
{
    public partial class FormFTPEnter : Form
    {
        string BackUpDiskLocation;

        public FormFTPEnter(string BackUpDiskLocation)
        {
            InitializeComponent();
            this.BackUpDiskLocation = BackUpDiskLocation;
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            if (textFTPAdress.Text != "" && textUserName.Text != "" && textPassword.Text != "")
            {
                try
                {
                    ClassFTP FTPobj = new ClassFTP(textFTPAdress.Text, textUserName.Text, textPassword.Text);
                    string result = FTPobj.testFTPConnect();
                    if (result.Contains("150"))
                    {
                        MessageBox.Show("BAĞLANTI BAŞARILI");
                        MainFTP FTPMainObj = new MainFTP(textFTPAdress.Text, textUserName.Text, DateTime.Now.ToString(), textPassword.Text, BackUpDiskLocation);
                        FTPMainObj.Enabled = true;
                        FTPMainObj.Show();
                    }
                    else
                    {
                        MessageBox.Show("BAĞLANTI BAŞARISIZ");
                    }
                }
                catch
                {
                    MessageBox.Show("HATA OLUŞTU");
                }
            }
        }

        private void buttonTestConnect_Click(object sender, EventArgs e)
        {
            if (textFTPAdress.Text != "" && textUserName.Text != "" && textPassword.Text != "")
            {
                try
                {
                    ClassFTP FTPobj = new ClassFTP(textFTPAdress.Text, textUserName.Text, textPassword.Text);
                    string result = FTPobj.testFTPConnect();
                    if (result.Contains("150"))
                    {
                        MessageBox.Show("BAĞLANTI BAŞARILI");
                    }
                    else
                    {
                        MessageBox.Show("BAĞLANTI BAŞARISIZ");
                    }
                }
                catch
                {
                    MessageBox.Show("BAĞLANTI BAŞARISIZ");
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textFTPAdress.Text = "";
            textUserName.Text = "";
            textPassword.Text = "";
        }
    }
}
