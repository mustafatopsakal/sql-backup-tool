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
    public partial class UpdateBackUpSettings : Form
    {
        string DatabaseName;
        string FullBackUpTiming, FullBackUpFrequency, FullCompressOption, FullCopyOnlyOption, FullBackUpLimit;
        string DifferantialBackUpTiming, DifferantialBackUpFrequency, DifferantialCompressOption, DifferantialBackUpLimit;
        string TransactLogBackUpTiming, TransactLogBackUpFrequency, TransactLogCompressOption, TransactLogCopyOnlyOption, TransactLogTruncateOption, TransactLogBackUpLimit;

        BackUp BackUpObj = new BackUp();

        public UpdateBackUpSettings()
        {
            InitializeComponent();
            List<string> list = BackUpObj.GetDatabaseNames();

            for (int i = 0; i < list.Count; i++)
            {
                comboDatabaseName.Items.Add(list[i]);
            }
        }

        public void UpdateBoxes()
        {

            List<string> list = BackUpObj.GetSettingsDatabase(DatabaseName);

            DatabaseName = list[0];

            FullBackUpTiming = list[1];
            FullBackUpFrequency = list[2];
            FullCompressOption = list[3];
            FullCopyOnlyOption = list[4];
            FullBackUpLimit = list[5];

            DifferantialBackUpTiming = list[6];
            DifferantialBackUpFrequency = list[7];
            DifferantialCompressOption = list[8];
            DifferantialBackUpLimit = list[9];

            TransactLogBackUpTiming = list[10];
            TransactLogBackUpFrequency = list[11];
            TransactLogCompressOption = list[12];
            TransactLogCopyOnlyOption = list[13];
            TransactLogTruncateOption = list[14];
            TransactLogBackUpLimit = list[15];


            textFullTiming.Text = FullBackUpTiming;
            textFullFrequency.Text = FullBackUpFrequency;
            textFullCompressOption.Text = FullCompressOption;
            textFullCopyOnlyOption.Text = FullCopyOnlyOption;
            textFullLimit.Text = FullBackUpLimit;

            textDifferantialBackUpTiming.Text = DifferantialBackUpTiming;
            textDifferantialFrequency.Text = DifferantialBackUpFrequency;
            textDifferantialCompressOption.Text = DifferantialCompressOption;
            textDifferantialLimit.Text = DifferantialBackUpLimit;

            textTransactLogTiming.Text = TransactLogBackUpTiming;
            textTransactLogFrequency.Text = TransactLogBackUpFrequency;
            textTransactLogCompressOption.Text = TransactLogCompressOption;
            textTransactLogCopyOnlyOption.Text = TransactLogCopyOnlyOption;
            textTransactLogTruncateOption.Text = TransactLogTruncateOption;
            textTransactLogLimit.Text = TransactLogBackUpLimit;
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
            if (comboDatabaseName.Text != "")
            {
                DatabaseName = comboDatabaseName.Text;
                UpdateBoxes();
            }

            else
            {
                MessageBox.Show("YEDEKLENME AYARI GÜNCELLENECEK BİR VERİTABANI SEÇİN");
            }
        }

        private void buttonFullUpdate_Click(object sender, EventArgs e)
        {
            if (comboFullTiming.Text != "" && comboFullFrequency.Text != "" && comboFullCompressOption.Text != "" && comboFullLimitNew.Text != "" && comboDatabaseName.Text != "")
            {

                BackUpObj.UpdateFull(comboDatabaseName.Text, comboFullTiming.Text, Convert.ToInt32(comboFullFrequency.Text), comboFullCompressOption.Text, comboFullCopyOnlyOption.Text, Convert.ToInt32(comboFullLimitNew.Text));

                UpdateBoxes();
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

                comboFullLimitNew.Items.Clear();
                for (int i = 1; i < 10; i++)
                {
                    comboFullLimitNew.Items.Add(i.ToString());
                }
            }
            else
            {
                MessageBox.Show("GÜNCELLENECEK VERİTABANINI SEÇİNİZ VE ZAMANLAMA,SIKLIK,SIKIŞTIRMA VE LİMİT GİBİ SEÇENEKLERİNİ BOŞ BIRAKMAYINIZ.");
            }
        }

        private void buttonDifferantialUpdate_Click(object sender, EventArgs e)
        {
            if (comboDifferantialTiming.Text != "" && comboDifferantialFrequency.Text != "" && comboDifferantialCompressOption.Text != "" && comboDifferantialLimitNew.Text != "" && comboDatabaseName.Text != "")
            {

                BackUpObj.UpdateDifferantial(comboDatabaseName.Text, comboDifferantialTiming.Text, Convert.ToInt32(comboDifferantialFrequency.Text), comboDifferantialCompressOption.Text, Convert.ToInt32(comboDifferantialLimitNew.Text));

                UpdateBoxes();
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

                comboDifferantialLimitNew.Items.Clear();
                for (int i = 1; i < 10; i++)
                {
                    comboDifferantialLimitNew.Items.Add(i.ToString());
                }
            }
            else
            {
                MessageBox.Show("GÜNCELLENECEK VERİTABANINI SEÇİNİZ VE ZAMANLAMA,SIKLIK,SIKIŞTIRMA VE LİMİT GİBİ SEÇENEKLERİNİ BOŞ BIRAKMAYINIZ.");
            }
        }

        private void buttonTransactLogUpdate_Click(object sender, EventArgs e)
        {
            if (comboTransactLogTiming.Text != "" && comboTransactLogFrequency.Text != "" && comboTransactLogCompressOption.Text != "" && comboTransactLogLimitNew.Text != "" && comboDatabaseName.Text != "" && comboTransactLogLimitNew.Text != "")
            {

                BackUpObj.UpdateTransactLog(comboDatabaseName.Text, comboTransactLogTiming.Text, Convert.ToInt32(comboTransactLogFrequency.Text), comboTransactLogCompressOption.Text, comboTransactLogCopyOnlyOption.Text, comboTransactLogTruncateOption.Text, Convert.ToInt32(comboTransactLogLimitNew.Text));

                UpdateBoxes();
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

                comboTransactLogLimitNew.Items.Clear();
                for (int i = 1; i < 10; i++)
                {
                    comboTransactLogLimitNew.Items.Add(i.ToString());
                }

            }
            else
            {
                MessageBox.Show("GÜNCELLENECEK VERİTABANINI SEÇİNİZ VE ZAMANLAMA,SIKLIK,SIKIŞTIRMA VE LİMİT GİBİ SEÇENEKLERİNİ BOŞ BIRAKMAYINIZ.");
            }
        }
    
    }
}
