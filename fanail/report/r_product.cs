using fanail.order;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.report
{
	public partial class r_product : Form
	{
		public r_product()
		{
			InitializeComponent();
			cbb_producttype();
			cbb_unit();

		}
		model model = new model();
		SqlConnection con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
		string sql = "";
		private void cbb_producttype()
		{
			try
			{
				con.Open();
				string sql = "Select * From tb_producttype where type_status = 1";
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				DataSet ds = new DataSet();
				da.Fill(ds);
				ds.Tables[0].Clear();
				DataRow row = ds.Tables[0].NewRow();
				row["type_id"] = -1;
				row["type_name"] = "ທັງໝົດ";
				ds.Tables[0].Rows.Add(row);
				da.Fill(ds);
				guna2ComboBox1.DataSource = ds.Tables[0];
				guna2ComboBox1.DisplayMember = "type_name";
				guna2ComboBox1.ValueMember = "type_id";
				con.Close();
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
			//model.LoadDataToCombobox("select type_name, type_id from tb_producttype where type_status=1", cbbname, "type_id", "type_name");
		}
		private void cbb_unit()
		{
			try
			{
				con.Open();
				string sql = "Select * From tb_unit where unit_status = 1";
				SqlDataAdapter da = new SqlDataAdapter(sql, con);
				DataSet ds = new DataSet();
				da.Fill(ds);
				ds.Tables[0].Clear();
				DataRow row = ds.Tables[0].NewRow();
				row["unit_id"] = -1;
				row["unit_name"] = "ທັງໝົດ";
				ds.Tables[0].Rows.Add(row);
				da.Fill(ds);
				guna2ComboBox2.DataSource = ds.Tables[0];
				guna2ComboBox2.DisplayMember = "unit_name";
				guna2ComboBox2.ValueMember = "unit_id";
				con.Close();
			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}
			//model.LoadDataToReportCombobox("select unit_name, unit_id from tb_unit where unit_status=1", guna2ComboBox1, "unit_id", "unit_name");
		}
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			report_Sell report = new report_Sell();
			report_Sell_with_type report1 = new report_Sell_with_type();
			report_Sell_with_unit report2 = new report_Sell_with_unit();
			report_Sell_with_type_and_unit report3 = new report_Sell_with_type_and_unit();
			report.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			report1.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			report2.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			report3.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			if (guna2ComboBox1.Text == "ທັງໝົດ" && guna2ComboBox2.Text == "ທັງໝົດ")
			{
				try
				{

					//SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
					//Con.Open();
					//string Sql = "select * from View_ReportProduct where sell_date between '" + dateTimePicker1.Value + "' and '" + dateTimePicker2.Value + "'";
					//SqlCommand Cmd = new SqlCommand(Sql, Con);
					//SqlDataReader myreader = Cmd.ExecuteReader();
					//DataTable Dt = new DataTable();
					//Dt.Load(myreader);
					//report.SetDataSource(Dt);
					
					report.SetParameterValue("StartDate", dateTimePicker1.Value);
					report.SetParameterValue("EndDate", dateTimePicker2.Value);
					
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = report;
					crystalReportViewer1.Refresh();

				}
				catch
				{
					MessageBox.Show("ບໍ່ສາມາດສະແດງລາຍງານໄດ້");
				}

			}
			else if (guna2ComboBox1.Text != "ທັງໝົດ" && guna2ComboBox2.Text == "ທັງໝົດ")
			{
				try
				{

					//SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
					//Con.Open();
					//string Sql = "select * from View_ReportProduct where sell_date between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and type_name = N'" + guna2ComboBox1.Text + "'";
					//SqlCommand Cmd = new SqlCommand(Sql, Con);
					//SqlDataReader myreader = Cmd.ExecuteReader();
					//DataTable Dt = new DataTable();
					//Dt.Load(myreader);
					//report.SetDataSource(Dt);

					report1.SetParameterValue("type_name", guna2ComboBox1.Text);
					report1.SetParameterValue("StartDate", dateTimePicker1.Value);
					report1.SetParameterValue("EndDate", dateTimePicker2.Value);
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = report1;
					crystalReportViewer1.Refresh();

					//Con.Close();

				}
				catch
				{
					MessageBox.Show("ບໍ່ສາມາດສະແດງລາຍງານໄດ້");
				}

			}
			else if (guna2ComboBox1.Text == "ທັງໝົດ" && guna2ComboBox2.Text != "ທັງໝົດ")
			{
				try
				{

					//SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
					//Con.Open();
					//string Sql = "select * from View_ReportProduct where sell_date between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and unit_name = N'" + guna2ComboBox2.Text + "'";
					//SqlCommand Cmd = new SqlCommand(Sql, Con);
					//SqlDataReader myreader = Cmd.ExecuteReader();
					//DataTable Dt = new DataTable();
					//Dt.Load(myreader);
					//report.SetDataSource(Dt);
					report2.SetParameterValue("unit_name", guna2ComboBox2.Text);
					report2.SetParameterValue("StartDate", dateTimePicker1.Value);
					report2.SetParameterValue("EndDate", dateTimePicker2.Value);
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = report2;
					crystalReportViewer1.Refresh();
					//Con.Close();
				}
				catch
				{
					MessageBox.Show("ບໍ່ສາມາດສະແດງລາຍງານໄດ້");
				}
			}
			else
			{
				try
				{

					//SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
					//Con.Open();
					//string Sql = "select * from View_ReportProduct where sell_date between '" + dateTimePicker1.Value.ToString() + "' and '" + dateTimePicker2.Value.ToString() + "' and type_name = N'" + guna2ComboBox1.Text + "' and unit_name = N'" + guna2ComboBox2.Text + "'";
					//SqlCommand Cmd = new SqlCommand(Sql, Con);
					//SqlDataReader myreader = Cmd.ExecuteReader();
					//DataTable Dt = new DataTable();
					//Dt.Load(myreader);
					//report.SetDataSource(Dt);
					report3.SetParameterValue("type_name", guna2ComboBox1.Text);
					report3.SetParameterValue("unit_name", guna2ComboBox2.Text);
					report3.SetParameterValue("StartDate", dateTimePicker1.Value);
					report3.SetParameterValue("EndDate", dateTimePicker2.Value);
					crystalReportViewer1.Refresh();
					crystalReportViewer1.ReportSource = report3;
					crystalReportViewer1.Refresh();
					//Con.Close();

				}
				catch
				{
					MessageBox.Show("ບໍ່ສາມາດສະແດງລາຍງານໄດ້");
				}
			}
		}
	}
}
