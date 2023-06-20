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
    public partial class r_income_expense : Form
    {
        public r_income_expense()
        {
            InitializeComponent();
			dateTimePicker1.Value = DateTime.Now;
			dateTimePicker2.Value = DateTime.Now;
			getcurrency();
        }
		double total, importprice, sellprice;
		double usd = 0, bath = 0;

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			Report_Paid reportreceipt_paid = new Report_Paid();
			reportreceipt_paid.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
			try
			{
				getcurrency();
				SqlConnection con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
				con.Open();
				string sql = "select sum(imd_qty) As qty,sum(imd_totalPrice) As price from tb_importdetail as d1 inner join tb_import as d2 on (d1.im_id=d2.im_id) where d2.im_date between @date1 and @date2";
				SqlCommand cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("date1", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("date2", dateTimePicker2.Value);
				SqlDataReader Myreader = cmd.ExecuteReader();
				if (Myreader.Read())
				{
					if (Myreader["qty"].ToString() != "")
					{
						reportreceipt_paid.SetParameterValue("sumimportqty", Convert.ToDouble(Myreader["qty"]).ToString("#,###"));
						reportreceipt_paid.SetParameterValue("sumpriceimport", Convert.ToDouble(Myreader["price"]).ToString("#,###"));
						//importprice = Convert.ToDouble(Myreader["price"]);
					}
					else
					{
						reportreceipt_paid.SetParameterValue("sumimportqty", "0");
						reportreceipt_paid.SetParameterValue("sumpriceimport", "0");
						//importprice = 0;
					}
				}
				con.Close();

				con.Open();
				sql = "select sum(sell_total_qty) As qty,sum(sell_total_price) As price from tb_sell where sell_date between @date1 and @date2";
				cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("date1", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("date2", dateTimePicker2.Value);
				Myreader = cmd.ExecuteReader();
				if (Myreader.Read())
				{
					if (Myreader["qty"].ToString() != "")
					{
						reportreceipt_paid.SetParameterValue("Sum_THB", (Convert.ToDouble(Myreader["price"]) / bath).ToString("#,###"));
					}
					else
					{
						reportreceipt_paid.SetParameterValue("Sum_THB", "0");
					}
				}
				con.Close();

				con.Open();
				sql = "select sum(sell_total_qty) As qty,sum(sell_total_price) As price from tb_sell where sell_date between @date1 and @date2";
				cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("date1", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("date2", dateTimePicker2.Value);
				Myreader = cmd.ExecuteReader();
				if (Myreader.Read())
				{
					if (Myreader["qty"].ToString() != "")
					{
						reportreceipt_paid.SetParameterValue("Sum_USD", (Convert.ToDouble(Myreader["price"]) / usd).ToString("#,###"));
					}
					else
					{
						reportreceipt_paid.SetParameterValue("Sum_USD", "0");
					}
				}
				con.Close();

				con.Open();
				sql = "select sum(sell_total_qty) As qty,sum(sell_total_price) As price from tb_sell where sell_date between @date1 and @date2";
				cmd = new SqlCommand(sql, con);
				cmd.Parameters.AddWithValue("date1", dateTimePicker1.Value);
				cmd.Parameters.AddWithValue("date2", dateTimePicker2.Value);
				Myreader = cmd.ExecuteReader();
				if (Myreader.Read())
				{
					if (Myreader["qty"].ToString() != "")
					{
						reportreceipt_paid.SetParameterValue("sumsellqty", Convert.ToDouble(Myreader["qty"]).ToString("#,###"));
						reportreceipt_paid.SetParameterValue("Sum_Kip", Convert.ToDouble(Myreader["price"]).ToString("#,###"));
						reportreceipt_paid.SetParameterValue("StartDate", dateTimePicker1.Value);
						reportreceipt_paid.SetParameterValue("EndDate", dateTimePicker2.Value);
						crystalReportViewer1.Refresh();
						crystalReportViewer1.ReportSource = reportreceipt_paid;
						crystalReportViewer1.Refresh();

					}
					else
					{
						MessageBox.Show("ຂໍອະໄພບໍ່ມີຂໍ້ມູນລາຍງານໃນຊ່ວງວັນທີ່ " + dateTimePicker1.Value.ToString("dd/MM/yyyy") + " ຫາ " + dateTimePicker2.Value.ToString("dd/MM/yyyy") + " ກະລຸນາກວດສອບຄຶນໃໝ່", "ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
				con.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}

		private void getcurrency()
		{
			try
			{

				SqlConnection con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
				string sql = "";
				SqlCommand Comd;
				SqlDataReader Myreader;
				con.Open();
				sql = "select max(rate_dollar) from tb_rate where rate_status = 1";
				Comd = new SqlCommand(sql, con);
				Comd.CommandType = CommandType.Text;
				Myreader = Comd.ExecuteReader();
				if (Myreader.HasRows)
				{
					while (Myreader.Read())
					{

						usd = Convert.ToDouble(Myreader[0]);

					}
				}
				con.Close();
				con.Open();
				sql = "select max(rate_bath) from tb_rate where rate_status = 1";
				Comd = new SqlCommand(sql, con);
				Comd.CommandType = CommandType.Text;
				Myreader = Comd.ExecuteReader();
				if (Myreader.HasRows)
				{
					while (Myreader.Read())
					{

						bath = Convert.ToDouble(Myreader[0]);

					}
				}
				con.Close();

			}
			catch (Exception Ex)
			{
				MessageBox.Show(Ex.Message);
			}

		}
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			crystalReportViewer1.PrintReport();
		}
		
	}
}
