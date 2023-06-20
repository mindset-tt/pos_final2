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
		SqlConnection con = new SqlConnection(@"Server=localhost,1433;Database=Anna_shop;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
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
			Report_Porduct report = new Report_Porduct();
			if (guna2ComboBox1.Text == "ທັງໝົດ" && guna2ComboBox2.Text == "ທັງໝົດ")
			{
				try
				{
					con.Open();
					string sql = "select sum(pro_qty) as pro_qty from View_RProducts where pro_status = 1";
					SqlCommand cmd = new SqlCommand(sql, con);
					SqlDataReader Myreader = cmd.ExecuteReader();
					if (Myreader.Read())
					{
						if (Myreader["pro_qty"].ToString() != "")
						{
							SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=Anna_shop;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
							Con.Open();
							string Sql = "select * from View_RProducts where pro_status = 1";
							SqlCommand Cmd = new SqlCommand(Sql, Con);
							SqlDataReader myreader = Cmd.ExecuteReader();
							DataTable Dt = new DataTable();
							Dt.Load(myreader);
							report.SetDataSource(Dt);
							crystalReportViewer1.Refresh();
							crystalReportViewer1.ReportSource = report;
							crystalReportViewer1.Refresh();
							Con.Close();
						}
					}
					con.Close();
				}
				catch
				{
					throw;
				}

			}
			else if (guna2ComboBox1.Text == "ທັງໝົດ" && guna2ComboBox2.Text != "ທັງໝົດ")
			{
				try
				{
					con.Open();
					string sql = "select sum(pro_qty) as pro_qty from View_RProducts where pro_status = 1 and type_name = N'" + guna2ComboBox1.Text + "'";
					SqlCommand cmd = new SqlCommand(sql, con);
					SqlDataReader Myreader = cmd.ExecuteReader();
					if (Myreader.Read())
					{
						if (Myreader["pro_qty"].ToString() != "")
						{
							SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=Anna_shop;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
							Con.Open();
							string Sql = "select * from View_RProducts where pro_status = 1 and type_name = N'" + guna2ComboBox1.Text + "'";
							SqlCommand Cmd = new SqlCommand(Sql, Con);
							SqlDataReader myreader = Cmd.ExecuteReader();
							DataTable Dt = new DataTable();
							Dt.Load(myreader);
							report.SetDataSource(Dt);
							crystalReportViewer1.Refresh();
							crystalReportViewer1.ReportSource = report;
							crystalReportViewer1.Refresh();
							Con.Close();

						}
					}
					con.Close();
				}
				catch
				{
					throw;
				}

			}
			else if (guna2ComboBox1.Text != "ທັງໝົດ" && guna2ComboBox1.Text == "ທັງໝົດ")
			{
				try
				{
					con.Open();
					string sql = "select sum(pro_qty) as pro_qty from View_RProducts where pro_status = 1 and unit_name = N'" + guna2ComboBox2.Text + "'";
					SqlCommand cmd = new SqlCommand(sql, con);
					SqlDataReader Myreader = cmd.ExecuteReader();
					if (Myreader.Read())
					{
						if (Myreader["pro_qty"].ToString() != "")
						{
							SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=Anna_shop;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
							Con.Open();
							string Sql = "select * from View_RProducts where pro_status = 1 and unit_name = N'" + guna2ComboBox2.Text + "'";
							SqlCommand Cmd = new SqlCommand(Sql, Con);
							SqlDataReader myreader = Cmd.ExecuteReader();
							DataTable Dt = new DataTable();
							Dt.Load(myreader);
							report.SetDataSource(Dt);
							crystalReportViewer1.Refresh();
							crystalReportViewer1.ReportSource = report;
							crystalReportViewer1.Refresh();
							Con.Close();
						}
					}
					con.Close();
				}
				catch
				{
					throw;
				}
			}
			else
			{
				try
				{
					con.Open();
					string sql = "select sum(pro_qty) as pro_qty from View_RProducts where pro_status = 1 and type_name = N'" + guna2ComboBox1.Text + "' and unit_name = N'" + guna2ComboBox2.Text + "'";
					SqlCommand cmd = new SqlCommand(sql, con);
					SqlDataReader Myreader = cmd.ExecuteReader();
					if (Myreader.Read())
					{
						if (Myreader["pro_qty"].ToString() != "")
						{
							SqlConnection Con = new SqlConnection(@"Server=localhost,1433;Database=Anna_shop;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
							Con.Open();
							string Sql = "select * from View_RProducts where pro_status = 1 and type_name = N'" + guna2ComboBox1.Text + "' and unit_name = N'" + guna2ComboBox2.Text + "'";
							SqlCommand Cmd = new SqlCommand(Sql, Con);
							SqlDataReader myreader = Cmd.ExecuteReader();
							DataTable Dt = new DataTable();
							Dt.Load(myreader);
							report.SetDataSource(Dt);
							crystalReportViewer1.Refresh();
							crystalReportViewer1.ReportSource = report;
							crystalReportViewer1.Refresh();
							Con.Close();
						}
					}
					con.Close();
				}
				catch
				{
					throw;
				}
			}
		}
	}
}
