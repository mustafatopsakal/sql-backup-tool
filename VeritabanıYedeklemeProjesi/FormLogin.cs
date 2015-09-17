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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string Location = Application.StartupPath + "\\SQLDatabaseBackUp\\";

            if (textServerName.Text != "" && textUserName.Text != "" && textPassword.Text != "")
            {
                BackUp BackUpObj = new BackUp();
                if (BackUpObj.Connect(textServerName.Text, textUserName.Text, textPassword.Text))
                {
                    bool exists = System.IO.Directory.Exists(@Location);

                    if (!exists)
                    {
                        System.IO.Directory.CreateDirectory(@Location);
                    }
                    BackUpSettings BackUpSettingsObj = new BackUpSettings(textServerName.Text, textUserName.Text, textPassword.Text, @Location);
                    BackUpSettingsObj.Enabled = true;
                    BackUpSettingsObj.Show();
                    this.Hide();
                }

                else
                {
                    MessageBox.Show("BİLGİLERİ DOĞRU GİRİNİZ");
                }
            }

            else
            {
                MessageBox.Show("ALANLARI BOŞ BIRAKMAYINIZ.");
            }
        }
    }
}
