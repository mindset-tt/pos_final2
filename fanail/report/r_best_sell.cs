﻿using System;
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
    public partial class r_best_sell : Form
    {
        public r_best_sell()
        {
            InitializeComponent();
            dateTimePicker1.Value = DateTime.Now;
            dateTimePicker2.Value = DateTime.Now;
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
				RProductTop bill = new RProductTop();
				bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
				bill.SetParameterValue("StartDate", dateTimePicker1.Text);
				bill.SetParameterValue("EndDate", dateTimePicker2.Text);
				crystalReportViewer1.Refresh();
				crystalReportViewer1.ReportSource = bill;
				crystalReportViewer1.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			dateTimePicker2.CustomFormat = "dd/MM/yyyy";
			dateTimePicker1.CustomFormat = "dd/MM/yyyy";
		}
	}
}
