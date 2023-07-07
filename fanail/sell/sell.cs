using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace fanail.sell
{
	public partial class sell : Form
	{
		public static List<string> Pro_id = new List<string>();
		public static List<string> Pro_qty = new List<string>();
		public static List<string> Pro_price = new List<string>();
		public sell()
		{
			InitializeComponent();
			loadData();
			//lblemname.Visible = false;
			lblpassword.Visible = false;
			////guna2Button3.Visible = false;
			//label7.Visible = false;
			label1.Text = "0";
			label4.Text = "0";
			label5.Text = "0";
			//label8.Visible = false;
		}
		model model = new model();
		private void guna2Button3_Click(object sender, EventArgs e)
		{
			try
			{
				if (guna2DataGridView2.Rows.Count == 0)
				{
					MessageBox.Show("ທ່ານໄດ້ເພີ່ມສີນຄ້າ ຫຼື ບໍ່?", "ເກີດຂໍ້ຜີດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Question);
				}
				if (guna2DataGridView2.Rows.Count != 0)
				{
					Pro_id.Clear();
					Pro_qty.Clear();
					Pro_price.Clear();
					for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
					{
						Pro_id.Add(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString());
						Pro_qty.Add(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
						Pro_price.Add(guna2DataGridView2.Rows[i].Cells["Column1"].Value.ToString());
					}
					pay_sell m = new pay_sell();
					//m.Show();
					//Pay_bill  = new Pay_bill();
					m.label12.Text = this.label5.Text;
					m.label1.Text = this.label1.Text.ToString();
					m.label2.Text = this.label4.Text.ToString();
					m.label13.Text = this.label4.Text.Replace(",", "");
					label1.Text = "0";
					label4.Text = "0";
					guna2DataGridView2.Rows.Clear();
					loadData();
					m.ShowDialog();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}

		}
		public void loadData()
		{
			model.ShowDataToGridView("select pro_id,type_name,unit_name,pro_name,pro_qty, pro_sellPrice from tb_product as d1 inner join tb_producttype as d2 on(d1.type_id=d2.type_id) inner join tb_unit as d3 on(d1.unit_id=d3.unit_id) where pro_status=1", guna2DataGridView1);
			model.Generate_ID("select max(sell_id)+1 from tb_sell");
			label5.Text = model.ID;
		}
		private void guna2TextBox10_TextChanged(object sender, EventArgs e)
		{
			if (guna2DataGridView1.DataSource != null)
			{
				string sql = "pro_id LIKE'%{0}%' or pro_name LIKE'%{0}%' or type_name LIKE'%{0}%' or unit_name LIKE'%{0}%'";
				model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
			}
		}
		private void sumQty()
		{
			if (guna2DataGridView2.Rows.Count >= 0)
			{
				int totalQty = 0;
				int totalPrice = 0;
				for (int i = 0; i < guna2DataGridView2.RowCount; i++)
				{
					totalQty += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
					totalPrice += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["Column9"].Value.ToString());
				}
				label1.Text = totalQty.ToString("#,###");
				label4.Text = totalPrice.ToString("#,###");
			}
			else
			{
				label1.Text = "0";
				label4.Text = "0";
			}
		}
		private void guna2Button1_Click(object sender, EventArgs e)
		{
			try
			{
				SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FD3T47E\SQLEXPRESS;Initial Catalog=pos_db ;Integrated Security=True");
				con.Close();
				con.Open();
				string sql = "Select pro_qty From tb_product Where pro_id=@pro_id";
				SqlCommand Comd = new SqlCommand(sql, con);
				Comd.Parameters.AddWithValue("pro_id", guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString());
				SqlDataReader Myreader = Comd.ExecuteReader();
				Myreader.Read();
				if (Myreader.HasRows)
				{
					string qty = Myreader["pro_qty"].ToString();
					if (Convert.ToInt32(qty) < Convert.ToInt32(guna2TextBox1.Text))
					{
						MessageBox.Show("ຈຳນວນສີນຄ້າໃນສະຕ໋ອກມີບໍ່ພຽງພໍ", "ເກີດຂໍ້ຜີດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
					else
					{
						if (guna2DataGridView2.RowCount != 0)
						{
							if (guna2TextBox1.Text != "" && Convert.ToInt32(guna2TextBox1.Text) > -1)
							{
								int qtyIndex = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString());
								guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value = Convert.ToInt32(guna2TextBox1.Text);
								guna2DataGridView2.CurrentRow.Cells["Column9"].Value = Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString()) * Convert.ToInt32(guna2DataGridView2.CurrentRow.Cells["Column1"].Value.ToString());

								//status = true;
								//break;
								//guna2DataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn14"].Value = Convert.ToInt32(guna2TextBox2.Text);
								//guna2DataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value = Convert.ToInt32(guna2TextBox2.Text) * Convert.ToInt32(guna2DataGridView1.CurrentRow.Cells["dataGridViewTextBoxColumn15"].Value);
							}
							else
							{
								MessageBox.Show("ບໍ່ສາມາດແກ້ໄຂໄດ້ເນື່ອງຈາກຂໍ້ມູນບໍ່ຖຶກຕ້ອງ", "ເກີດຂໍ້ຜີດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
							sumQty();
						}
						else
						{
							MessageBox.Show("ບໍ່ສາມາດແກ້ໄຂໄດ້ເນື່ອງຈາກຂໍ້ມູນບໍ່ຖຶກຕ້ອງ", "ເກີດຂໍ້ຜີດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
					}
				}

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			//if (guna2TextBox1.Text != "")
			//{
			//    if (guna2DataGridView2.Rows.Count > 0)
			//    {
			//        guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value = guna2TextBox1.Text;
			//    }
			//    sumQty();
			//    guna2TextBox1.Text = "1";
			//    label8.Visible = false;
			//}
			//else
			//{
			//    label8.Visible = true;
			//}
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			if (guna2TextBox1.Text == "" || Convert.ToInt32(guna2TextBox1.Text) <= 0)
			{
				lblpassword.Visible = true;
			}
			else
			{
				if (guna2DataGridView1.DataSource != null)
				{
					bool status = false;
					string pro_id = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
					string pro_name = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
					string type_name = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
					string unit_name = guna2DataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
					string qty = guna2TextBox1.Text;
					string price = guna2DataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
					if (guna2DataGridView2.RowCount != 0)
					{
						for (int i = 0; i < guna2DataGridView2.RowCount; i++)
						{
							if (guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() == guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString())
							{
								if (guna2TextBox1.Text == "" && Convert.ToDouble(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + 1 <= Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()))
								{
									int qtyIndex = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
									guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value = Convert.ToInt32(qtyIndex) + 1;
									guna2DataGridView2.Rows[i].Cells["Column1"].Value = Convert.ToDouble(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) * Convert.ToInt32(price);
									status = true;
									break;
									//guna2DataGridView1.Rows[i].Cells["dataGridViewTextBoxColumn14"].Value = Convert.ToInt32(guna2DataGridView1.Rows[i].Cells["dataGridViewTextBoxColumn14"].Value.ToString()) + 1;
									//guna2DataGridView1.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value = Convert.ToDouble(guna2DataGridView1.Rows[i].Cells["dataGridViewTextBoxColumn14"].Value.ToString()) * Convert.ToInt32(pro_price);
									//break;
								}
								else if (guna2TextBox1.Text != "" && Convert.ToDouble(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + Convert.ToDouble(guna2TextBox1.Text) <= Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()))
								{
									int qtyIndex = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
									guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value = Convert.ToInt32(qtyIndex) + Convert.ToInt32(guna2TextBox1.Text);
									guna2DataGridView2.Rows[i].Cells["Column1"].Value = Convert.ToDouble(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) * Convert.ToInt32(price);
									status = true;
									break;
								}
								else
								{
									MessageBox.Show("ສິນຄ້າບໍ່ພຽງພໍ", "ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
								}
							}
						}
						if (status == false)
						{
							if (guna2TextBox1.Text == "" && Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()) > 0)
							{
								guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, 1, price, price);
							}
							else if (guna2TextBox1.Text != "" && Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()) >= Convert.ToDouble(guna2TextBox1.Text))
							{
								guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, guna2TextBox1.Text, price, Convert.ToDouble(guna2TextBox1.Text) * Convert.ToDouble(price));
							}
							else
							{
								MessageBox.Show("ສິນຄ້າບໍ່ພຽງພໍ", "ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
					else
					{
						if (status == false)
						{
							if (guna2TextBox1.Text == "" && Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()) > 0)
							{
								guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, 1, price, price);
							}
							else if (guna2TextBox1.Text != "" && Convert.ToDouble(guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString()) >= Convert.ToDouble(guna2TextBox1.Text))
							{
								guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, guna2TextBox1.Text, price, Convert.ToDouble(guna2TextBox1.Text) * Convert.ToDouble(price));
							}
							else
							{
								MessageBox.Show("ສິນຄ້າບໍ່ພຽງພໍ", "ຜິດພາດ", MessageBoxButtons.OK, MessageBoxIcon.Error);
							}
						}
					}
					guna2Button3.Visible = true;
				}
				else
				{
					//label7.Visible = true;
				}
				sumQty();
				guna2TextBox1.Text = "1";
			}
		}

		private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (guna2DataGridView2.Rows.Count > 0)
			{
				guna2TextBox1.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
				//if (guna2DataGridView2.CurrentCell.ColumnIndex == guna2DataGridView2.CurrentRow.Cells[guna2DataGridView2.Columns["dataGridViewImageColumn2"].Index].ColumnIndex)
				//{
				//    if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
				//    {
				//        guna2DataGridView2.Rows.Remove(guna2DataGridView2.CurrentRow);
				//        guna2TextBox1.Text = "";
				//    }
				//}
				sumQty();
			}
			if (guna2DataGridView2.Rows.Count == 0)
			{
				guna2Button3.Visible = false;
			}
		}

		private void guna2DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			guna2DataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value = (e.RowIndex + 1).ToString();
		}

		private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
		}
	}
}
