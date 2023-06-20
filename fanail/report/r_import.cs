using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.report
{
    public partial class r_import : Form
    {
        public r_import()
        {
            InitializeComponent();
        }

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			report_Import bill = new report_Import();

			bill.SetParameterValue("StartDate", dateTimePicker1.Value);
			bill.SetParameterValue("EndDate", dateTimePicker2.Value);
			crystalReportViewer1.Refresh();
			crystalReportViewer1.ReportSource = bill;
			crystalReportViewer1.Refresh();
		}
	}
}
