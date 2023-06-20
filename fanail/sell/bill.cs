using fanail.report;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.sell
{
    public partial class bills : Form
    {
        public bills()
        {
            InitializeComponent();
            sell_bill bill = new sell_bill();
            crystalReportViewer1.Refresh();
            //bill.SetParameterValue("sell_id", pay_sell.sell_id);
            crystalReportViewer1.ReportSource = bill;
            crystalReportViewer1.Refresh();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            crystalReportViewer1.PrintReport();
        }
    }
}
