using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.order
{
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
            order_bill bill = new order_bill();
            crystalReportViewer1.Refresh();
			bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			bill.SetParameterValue("order_id", check_order.order_id);
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
