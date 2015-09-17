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
    public partial class FormAddDatabaseForBackUp : Form
    {
        string ServerName, UserName, Password;
        BackUp BackUpObj = new BackUp();
        DataGridView DataGridView;


        public FormAddDatabaseForBackUp(string ServerName, string UserName, string Password, DataGridView DataGridView)
        {
            InitializeComponent();
            this.ServerName = ServerName;
            this.UserName = UserName;
            this.Password = Password;
            this.DataGridView = DataGridView;

            List<string> DatabaseListInServer = BackUpObj.GetDatabaseList(ServerName, UserName, Password);
            List<string> AddedDatabases = BackUpObj.GetDatabaseNames();

            List<string> CanAddDatabases = DatabaseListInServer.Except(AddedDatabases).ToList();

            for (int i = 0; i < CanAddDatabases.Count; i++)
            {
                comboDatabaseName.Items.Add(CanAddDatabases[i]);
            }
        }

        private void buttonAddDatabase_Click(object sender, EventArgs e)
        {
            if (comboDatabaseName.Text != "" && comboFullTiming.Text != "" && comboFullFrequency.Text != "" && comboFullCompressOption.Text != "" && comboFullBackUpLimit.Text != "" && comboDifferantialTiming.Text != "" && comboDifferantialFrequency.Text != "" && comboDifferantialCompressOption.Text != "" && comboDifferantialBackUpLimit.Text != "" && comboTransactLogTiming.Text != "" && comboTransactLogFrequency.Text != "" && comboTransactLogCompressOption.Text != "" && comboTransactLogBackUpLimit.Text != "")
            {
                BackUpObj.Insert(comboDatabaseName.Text, comboFullTiming.Text, Convert.ToInt32(comboFullFrequency.Text), comboFullCompressOption.Text, comboFullCopyOnlyOption.Text, Convert.ToInt32(comboFullBackUpLimit.Text), comboDifferantialTiming.Text, Convert.ToInt32(comboDifferantialFrequency.Text), comboDifferantialCompressOption.Text, Convert.ToInt32(comboDifferantialBackUpLimit.Text), comboTransactLogTiming.Text, Convert.ToInt32(comboTransactLogFrequency.Text), comboTransactLogCompressOption.Text, comboTransactLogCopyOnlyOption.Text, comboTransactLogTruncateOption.Text, Convert.ToInt32(comboTransactLogBackUpLimit.Text));
                ClearBoxes();
                UpdateDatabaseList();
                dataGridKontrol(DataGridView);
            }
            else
            {
                MessageBox.Show("ALANLAR BOŞ BIRAKILAMAZ.");
            }
        }


        public void dataGridKontrol(DataGridView dataGridBackUp)
        {

            /*Bu fonksiyon veritabanı yedeklemesi devam ederken sisteme 
              bir veritabanı eklenirse onu datagridviewe ekler ve önceki veritabanlarının durumlarını korur. */

            List<string> listDatabaseDefault = new List<string>();
            List<string> listDatabaseState = new List<string>();

            for (int i = 0; i < dataGridBackUp.Rows.Count; i++)
            {
                listDatabaseDefault.Insert(i, dataGridBackUp.Rows[i].Cells[0].Value.ToString());
                listDatabaseState.Insert(i, dataGridBackUp.Rows[i].Cells[1].Value.ToString());
            }

            dataGridBackUp.Rows.Clear();
            dataGridBackUp.Refresh();

            List<string> listDatabaseAll = BackUpObj.GetDatabaseNames();
            List<string> listDatabaseExcept = listDatabaseAll.Except(listDatabaseDefault).ToList();

            for (int i = 0; i < listDatabaseDefault.Count; i++)
            {
                dataGridBackUp.Rows.Add(listDatabaseDefault[i].ToString(), listDatabaseState[i].ToString());
            }

            for (int i = 0; i < listDatabaseExcept.Count; i++)
            {
                dataGridBackUp.Rows.Add(listDatabaseExcept[i].ToString(), "Yedeklemeyi Başlat");
            }


        }

        public void UpdateDatabaseList()
        {

            List<string> DatabaseListInServer = BackUpObj.GetDatabaseList(ServerName, UserName, Password);
            List<string> AddedDatabases = BackUpObj.GetDatabaseNames();

            List<string> CanAddDatabases = DatabaseListInServer.Except(AddedDatabases).ToList();

            for (int i = 0; i < CanAddDatabases.Count; i++)
            {
                comboDatabaseName.Items.Add(CanAddDatabases[i]);
            }
        }

        public void ClearBoxes()
        {
            comboDatabaseName.Items.Clear();


            //FULL CLEAR BOXES
            comboFullTiming.Items.Clear();
            comboFullTiming.Items.Add("DAKİKA");
            comboFullTiming.Items.Add("SAAT");
            comboFullTiming.Items.Add("GÜN");

            comboFullFrequency.Items.Clear();
            for (int i = 1; i < 46; i++)
            {
                comboFullFrequency.Items.Add(i.ToString());
            }

            comboFullCompressOption.Items.Clear();
            comboFullCompressOption.Items.Add("NO_COMPRESSION");
            comboFullCompressOption.Items.Add("COMPRESSION");

            comboFullCopyOnlyOption.Items.Clear();
            comboFullCopyOnlyOption.Items.Add("COPY_ONLY,");
            comboFullCopyOnlyOption.Items.Add("");

            comboFullBackUpLimit.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                comboFullBackUpLimit.Items.Add(i.ToString());
            }

            //DİFFERANTİAL CLEAR BOXES
            comboDifferantialTiming.Items.Clear();
            comboDifferantialTiming.Items.Add("DAKİKA");
            comboDifferantialTiming.Items.Add("SAAT");
            comboDifferantialTiming.Items.Add("GÜN");

            comboDifferantialFrequency.Items.Clear();
            for (int i = 1; i < 46; i++)
            {
                comboDifferantialFrequency.Items.Add(i.ToString());
            }

            comboDifferantialCompressOption.Items.Clear();
            comboDifferantialCompressOption.Items.Add("NO_COMPRESSION");
            comboDifferantialCompressOption.Items.Add("COMPRESSION");

            comboDifferantialBackUpLimit.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                comboDifferantialBackUpLimit.Items.Add(i.ToString());
            }

            //TRANSACT LOG CLEAR BOXES
            comboTransactLogTiming.Items.Clear();
            comboTransactLogTiming.Items.Add("DAKİKA");
            comboTransactLogTiming.Items.Add("SAAT");
            comboTransactLogTiming.Items.Add("GÜN");

            comboTransactLogFrequency.Items.Clear();
            for (int i = 1; i < 46; i++)
            {
                comboTransactLogFrequency.Items.Add(i.ToString());
            }

            comboTransactLogCompressOption.Items.Clear();
            comboTransactLogCompressOption.Items.Add("NO_COMPRESSION");
            comboTransactLogCompressOption.Items.Add("COMPRESSION");

            comboTransactLogCopyOnlyOption.Items.Clear();
            comboTransactLogCopyOnlyOption.Items.Add("");
            comboTransactLogCopyOnlyOption.Items.Add("COPY_ONLY,");

            comboTransactLogTruncateOption.Items.Clear();
            comboTransactLogTruncateOption.Items.Add("");
            comboTransactLogTruncateOption.Items.Add("NO_TRUNCATE,");

            comboTransactLogBackUpLimit.Items.Clear();
            for (int i = 1; i < 10; i++)
            {
                comboTransactLogBackUpLimit.Items.Add(i.ToString());
            }

        }


    }
}
