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
    public partial class FormLog : Form
    {
        BackUp BackUpObj = new BackUp();

        public FormLog()
        {
            InitializeComponent();
            BackUpObj.GetLogTable(dataGridLog, "BackUpMovementLogs");
            this.dataGridLog.Sort(this.dataGridLog.Columns["id"], ListSortDirection.Descending);
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            BackUpObj.GetLogTable(dataGridLog, "BackUpMovementLogs");
            this.dataGridLog.Sort(this.dataGridLog.Columns["id"], ListSortDirection.Descending);
        }
    }
}
