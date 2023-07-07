//using Guna.UI2.WinForms;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace fanail.import
//{
//    public partial class import : Form
//    {
//        public import()
//        {
//            InitializeComponent();
//        }
//        model model = new model();
//        private void ShowData()
//        {
//            model.ShowDataToGridView("select order_id,sup_name,order_date from tb_order as d1 inner join tb_suppiler as d2 on(d1.sup_id=d2.sup_id) where order_status=1", guna2DataGridView1);
//            if (guna2DataGridView1.RowCount>0)
//            {
//                model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'","pro_id","pro_name","unit_name","type_name", "orderd_qty");
//                guna2DataGridView2.Rows.Clear();
//                for (int i = 0; i < model.Pro_ID.Count; i++)
//                {
//                    guna2DataGridView2.Rows.Add("",model.Pro_ID[i], model.Pro_Name[i],model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i],0, 0);
//                }
//                if (guna2DataGridView2.RowCount > 0)
//                {
//                    guna2Button3.Visible = true;
//                }
//                else
//                {
//                    guna2Button3.Visible = false;
//                }
//                sumQty();
//            }
//            else
//            {
//                guna2Button3.Visible = false;
//            }
//            model.Pro_ID.Clear();
//            model.Pro_Name.Clear();
//            model.Type_name.Clear();
//            model.Unit_Name.Clear();
//            model.Orderd_Qty.Clear();
//        }
//        int totalQty = 0;
//        int totalPrice = 0;
//        private void sumQty()
//        {
//            int totalqty = 0;
//            int totalprice = 0;
//            if (guna2DataGridView2.Rows.Count >= 0)
//            {
//                for (int i = 0; i < guna2DataGridView2.RowCount; i++)
//                {
//                    totalqty += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
//                    totalprice += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["Column1"].Value.ToString());
//                }
//                label1.Text = totalqty.ToString("#,###");
//                label4.Text = totalprice.ToString("#,###")+" ກີບ";
//                totalPrice = totalprice;
//                totalQty = totalqty;
//            }
//            else
//            {
//                label1.Text = "0";
//                label4.Text = "0 ກີບ";
//            }
//        }

//        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
//        {
//            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
//        }

//        private void guna2DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
//        {
//            guna2DataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value = (e.RowIndex + 1).ToString();
//        }

//        private void import_Load(object sender, EventArgs e)
//        {
//            ShowData();
//        }

//        private void guna2DataGridView1_KeyUp(object sender, KeyEventArgs e)
//        {
//            if (guna2DataGridView1.RowCount > 0)
//            {
//                model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'", "pro_id", "pro_name", "unit_name", "type_name", "orderd_qty");
//                guna2DataGridView2.Rows.Clear();
//                for (int i = 0; i < model.Pro_ID.Count; i++)
//                {
//                    guna2DataGridView2.Rows.Add("", model.Pro_ID[i], model.Pro_Name[i], model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i], 0);
//                }
//                if (guna2DataGridView2.RowCount > 0)
//                {
//                    guna2Button3.Visible = true;
//                }
//                else
//                {
//                    guna2Button3.Visible = false;
//                }
//                sumQty();
//                model.Pro_ID.Clear();
//                model.Pro_Name.Clear();
//                model.Type_name.Clear();
//                model.Unit_Name.Clear();
//                model.Orderd_Qty.Clear();
//            }
//            else
//            {
//                guna2Button3.Visible = false;
//            }
//        }

//        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (guna2DataGridView1.RowCount > 0)
//            {
//                model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'", "pro_id", "pro_name", "unit_name", "type_name", "orderd_qty");
//                guna2DataGridView2.Rows.Clear();
//                for (int i = 0; i < model.Pro_ID.Count; i++)
//                {
//                    guna2DataGridView2.Rows.Add("", model.Pro_ID[i], model.Pro_Name[i], model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i], 0, 0);
//                }
//                if (guna2DataGridView2.RowCount > 0)
//                {
//                    guna2Button3.Visible = true;
//                }
//                else
//                {
//                    guna2Button3.Visible = false;
//                }
//                sumQty();
//                model.Pro_ID.Clear();
//                model.Pro_Name.Clear();
//                model.Type_name.Clear();
//                model.Unit_Name.Clear();
//                model.Orderd_Qty.Clear();
//            }
//            else
//            {
//                guna2Button3.Visible = false;
//            }
//        }

//        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
//        {
//            if (guna2DataGridView2.Rows.Count>0)
//            {
//                guna2TextBox2.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
//                guna2TextBox1.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn7"].Value.ToString();
//            }
//        }

//        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
//        {
//            if (guna2DataGridView1.DataSource != null)
//            {
//                string sql = "order_id LIKE'%{0}%' or sup_name LIKE'%{0}%'";
//                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
//            }
//        }

//        private void guna2Button1_Click(object sender, EventArgs e)
//        {
//            if (guna2TextBox1.Text!="" && guna2TextBox2.Text!="")
//            {
//                guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value = guna2TextBox2.Text;
//                guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn7"].Value = guna2TextBox1.Text;
//                guna2DataGridView2.CurrentRow.Cells["Column1"].Value = Convert.ToInt32(guna2TextBox2.Text) * Convert.ToInt32(guna2TextBox1.Text);
//                guna2TextBox1.Text = "";
//                guna2TextBox2.Text = "";
//                sumQty();
//            }
//        }

//        private void guna2Button3_Click(object sender, EventArgs e)
//        {
//            bool Check = false;
//            for(int i=0; i < guna2DataGridView2.Rows.Count; i++)
//			{
//                if (guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()!="0")
//                {
//                    if (guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString() == "0" || guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString() == "")
//                    {
//                        Check= true;
//                        break;
//                    }
//                }
//                else
//                {
//                    Check = false;
//                }
//            }

//            if (Check==true)
//            {
//                WrongDialog.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ");
//            }
//            else
//            {
//				if (guna2DataGridView2.RowCount > 0)
//				{
//					sumQty();
//					model.SqlExecute("insert into tb_import(order_id,user_id,im_totalQty,im_totalPrice,im_date,im_status) values ('" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "','" + fm_login.em_id + "','" + totalQty + "','" + totalPrice + "',getdate(),1)");
//					for (int i = 0; i < guna2DataGridView2.RowCount; i++)
//					{
//						model.GetCount("select * from tb_import", "im_id");
//						model.SqlExecute("insert into tb_importdetail(im_id,pro_id,imd_qty,imd_price,imd_totalPrice) values ('" + model.count + "','" + guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "','" + Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + "','" + Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString()) + "','" + (Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) * Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString())) + "')");

//						model.GetCount("select pro_qty from tb_product where pro_id='" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "'", "pro_qty");
//						model.SqlExecute("update tb_product set pro_qty='" + (Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + Convert.ToInt32(model.count)) + "' where pro_id='" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "'");

//					}
//					model.SqlExecute("update tb_order set order_status=0 where order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'");


//					AlertMessage alert = new AlertMessage();
//					alert.TopMost = true;
//					alert.showAlert("ບັນທຶກການນຳເຂົ້າສຳເລັດແລ້ວ.");
//					ShowData();
//					sumQty();

//				}
//			}
//        }

//        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//            {
//                e.Handled = true;
//            }
//        }

//        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
//        {
//            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
//            {
//                e.Handled = true;
//            }
//        }
//    }
//}
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.import
{
	public partial class import : Form
	{
		public import()
		{
			InitializeComponent();
		}
		model model = new model();
		private void ShowData()
		{
			model.ShowDataToGridView("select order_id,sup_name,order_date from tb_order as d1 inner join tb_suppiler as d2 on(d1.sup_id=d2.sup_id) where order_status=1", guna2DataGridView1);
			if (guna2DataGridView1.RowCount > 0)
			{
				model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'", "pro_id", "pro_name", "unit_name", "type_name", "orderd_qty");
				guna2DataGridView2.Rows.Clear();
				for (int i = 0; i < model.Pro_ID.Count; i++)
				{
					guna2DataGridView2.Rows.Add("", model.Pro_ID[i], model.Pro_Name[i], model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i], 0);
				}
				if (guna2DataGridView2.RowCount > 0)
				{
					guna2Button3.Visible = true;
				}
				else
				{
					guna2Button3.Visible = false;
				}
				sumQty();
			}
			else
			{
				guna2Button3.Visible = false;
			}
			model.Pro_ID.Clear();
			model.Pro_Name.Clear();
			model.Type_name.Clear();
			model.Unit_Name.Clear();
			model.Orderd_Qty.Clear();
		}
		int totalQty = 0;
		int totalPrice = 0;
		private void sumQty()
		{
			int totalqty = 0;
			int totalprice = 0;
			if (guna2DataGridView2.Rows.Count >= 0)
			{
				for (int i = 0; i < guna2DataGridView2.RowCount; i++)
				{
					totalqty += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
					totalprice += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["Column1"].Value.ToString());
				}
				label1.Text = totalqty.ToString("#,###");
				label4.Text = totalprice.ToString("#,###") + " ກີບ";
				totalPrice = totalprice;
				totalQty = totalqty;
			}
			else
			{
				label1.Text = "0";
				label4.Text = "0 ກີບ";
			}
		}

		private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
		}

		private void guna2DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			guna2DataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value = (e.RowIndex + 1).ToString();
		}

		private void import_Load(object sender, EventArgs e)
		{
			ShowData();
		}

		private void guna2DataGridView1_KeyUp(object sender, KeyEventArgs e)
		{
			if (guna2DataGridView1.RowCount > 0)
			{
				model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'", "pro_id", "pro_name", "unit_name", "type_name", "orderd_qty");
				guna2DataGridView2.Rows.Clear();
				for (int i = 0; i < model.Pro_ID.Count; i++)
				{
					guna2DataGridView2.Rows.Add("", model.Pro_ID[i], model.Pro_Name[i], model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i], 0);
				}
				if (guna2DataGridView2.RowCount > 0)
				{
					guna2Button3.Visible = true;
				}
				else
				{
					guna2Button3.Visible = false;
				}
				sumQty();
				model.Pro_ID.Clear();
				model.Pro_Name.Clear();
				model.Type_name.Clear();
				model.Unit_Name.Clear();
				model.Orderd_Qty.Clear();
			}
			else
			{
				guna2Button3.Visible = false;
			}
		}

		private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (guna2DataGridView1.RowCount > 0)
			{
				model.ShowProduct("select d3.pro_id,pro_name,type_name,unit_name,orderd_qty from tb_order as d1 inner join tb_orderdetail as d2 on(d1.order_id=d2.order_id) inner join tb_product as d3 on (d2.pro_id=d3.pro_id) inner join tb_producttype as d4 on(d3.type_id=d4.type_id) inner join tb_unit as d5 on(d3.unit_id=d5.unit_id) where order_status=1 and d1.order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'", "pro_id", "pro_name", "unit_name", "type_name", "orderd_qty");
				guna2DataGridView2.Rows.Clear();
				for (int i = 0; i < model.Pro_ID.Count; i++)
				{
					guna2DataGridView2.Rows.Add("", model.Pro_ID[i], model.Pro_Name[i], model.Type_name[i], model.Unit_Name[i], model.Orderd_Qty[i], 0);
				}
				if (guna2DataGridView2.RowCount > 0)
				{
					guna2Button3.Visible = true;
				}
				else
				{
					guna2Button3.Visible = false;
				}
				sumQty();
				model.Pro_ID.Clear();
				model.Pro_Name.Clear();
				model.Type_name.Clear();
				model.Unit_Name.Clear();
				model.Orderd_Qty.Clear();
			}
			else
			{
				guna2Button3.Visible = false;
			}
		}

		private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (guna2DataGridView2.Rows.Count > 0)
			{
				guna2TextBox2.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
				guna2TextBox1.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn7"].Value.ToString();
			}
		}

		private void guna2TextBox10_TextChanged(object sender, EventArgs e)
		{
			if (guna2DataGridView1.DataSource != null)
			{
				string sql = "order_id LIKE'%{0}%' or sup_name LIKE'%{0}%'";
				model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			if (guna2TextBox1.Text != "" && guna2TextBox2.Text != "")
			{
				guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value = guna2TextBox2.Text;
				guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn7"].Value = guna2TextBox1.Text;
				guna2DataGridView2.CurrentRow.Cells["Column1"].Value = Convert.ToInt32(guna2TextBox2.Text) * Convert.ToInt32(guna2TextBox1.Text);
				guna2TextBox1.Text = "";
				guna2TextBox2.Text = "";
				sumQty();
			}
		}

		private void guna2Button3_Click(object sender, EventArgs e)
		{
			bool Check = false;
			for (int i = 0; i < guna2DataGridView2.Rows.Count; i++)
			{
				if (guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString() != "0")
				{
					if (guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString() == "0" || guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString() == "")
					{
						Check = true;
						break;
					}
				}
				else
				{
					Check = false;
				}
			}

			if (Check == true)
			{
				WrongDialog.Show("ກະລຸນາປ້ອນຂໍ້ມູນໃຫ້ຄົບ");
			}
			else
			{
				if (guna2DataGridView2.RowCount > 0)
				{
					sumQty();
					model.SqlExecute("insert into tb_import(order_id,user_id,im_totalQty,im_totalPrice,im_date,im_status) values ('" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "','" + fm_login.em_id + "','" + totalQty + "','" + totalPrice + "',getdate(),1)");
					for (int i = 0; i < guna2DataGridView2.RowCount; i++)
					{
						model.GetCount("select * from tb_import", "im_id");
						model.SqlExecute("insert into tb_importdetail(im_id,pro_id,imd_qty,imd_price,imd_totalPrice) values ('" + model.count + "','" + guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "','" + Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + "','" + Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString()) + "','" + (Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) * Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn7"].Value.ToString())) + "')");

						model.GetCount("select pro_qty from tb_product where pro_id='" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "'", "pro_qty");
						model.SqlExecute("update tb_product set pro_qty='" + (Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString()) + Convert.ToInt32(model.count)) + "' where pro_id='" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "'");

					}
					model.SqlExecute("update tb_order set order_status=0 where order_id='" + guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() + "'");


					AlertMessage alert = new AlertMessage();
					alert.TopMost = true;
					alert.showAlert("ບັນທຶກການນຳເຂົ້າສຳເລັດແລ້ວ.");
					ShowData();

				}
			}
			if (guna2DataGridView1.Rows.Count < 1)
			{
				guna2DataGridView2.Rows.Clear();
			}
			sumQty();
		}

		private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}

		private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
			{
				e.Handled = true;
			}
		}
	}
}
