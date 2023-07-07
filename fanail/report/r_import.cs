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
			guna2CustomRadioButton1.Checked = true;
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			try
			{
				dateTimePicker2.CustomFormat = "yyyy-MM-dd";
				dateTimePicker1.CustomFormat = "yyyy-MM-dd";
				String StartDate = dateTimePicker1.Text;
				String EndDate = dateTimePicker2.Text;
				if (guna2CustomRadioButton1.Checked == true)
				{
					report_Order bill = new report_Order();
					bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
					bill.SetParameterValue("StartDate", StartDate);
					bill.SetParameterValue("EndDate",EndDate);
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = bill;
					crystalReportViewer1.Refresh();
				}
				else
				{
					report_Import bill = new report_Import();
					bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
					bill.SetParameterValue("StartDate", StartDate);
					bill.SetParameterValue("EndDate", EndDate);
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = bill;
					crystalReportViewer1.Refresh();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}


		}

		private void guna2CustomRadioButton1_CheckedChanged(object sender, EventArgs e)
		{

		}
	}
}
