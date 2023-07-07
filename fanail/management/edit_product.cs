using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;
using Guna.UI2.WinForms;

namespace fanail.management
{
	public partial class edit_product : Form
	{
		public edit_product()
		{
			InitializeComponent();
		}
		public string pro_id, type_id, unit_id, pro_name, pro_imp_price, pro_sell_price, pro_message, t_name, u_name;

		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{
			lblposition.Visible = false;
		}

		private void guna2TextBox5_TextChanged(object sender, EventArgs e)
		{
			label4.Visible = false;
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			/*  bool b = true;
              if (guna2TextBox2.Text == "")
              {
                  lblcode.Visible = true;
                  guna2TextBox2.Focus();
                  b = false;
              }
              else if (guna2TextBox4.Text == "")
              {
                  lblname.Visible = true;
                  guna2TextBox4.Focus();
                  b = false;
              }
              else if (cbbname.Text == "ກະລຸນາເລືອກ")
              {
                  lblvillage.Visible = true;
                  b = false;
              }
              else if (guna2ComboBox1.Text == "ກະລຸນາເລືອກ")
              {
                  lbldistrict.Visible = true;
                  b = false;
              }
              else if (guna2TextBox3.Text == "" || Convert.ToDouble(guna2TextBox3.Text) <= 0)
              {
                  lblprovince.Visible = true;
                  guna2TextBox3.Focus();
                  b = false;
              }
              else if (guna2TextBox1.Text == "" || Convert.ToDouble(guna2TextBox1.Text) <= 0)
              {
                  lblposition.Visible = true;
                  guna2TextBox1.Focus();
                  b = false;
              }
              else if (guna2TextBox5.Text == "" || Convert.ToDouble(guna2TextBox5.Text) <= 0)
              {
                  label4.Visible = true;
                  guna2TextBox5.Focus();
                  b = false;
              }
              else
              {
                  UpdateData();
                  AlertMessage alert = new AlertMessage();
                  alert.TopMost = true;
                  alert.showAlert("ແກ້ໄຂສຳເລັດ");

              }
          */

			if (checkIsnullText())
			{
				if (Convert.ToInt64(guna2TextBox3.Text) > Convert.ToInt64(guna2TextBox1.Text))
				{
					MessageBox.Show("ກະລຸນາກວດສອບຈຳນວນຂາຍ");

				}
				else if (Convert.ToInt64(guna2TextBox3.Text) == Convert.ToInt64(guna2TextBox1.Text))
				{
					MessageBox.Show("ກະລຸນາກວດສອບຈຳນວນຂາຍ");
				}

				else
				{
					UpdateData();
				}


			}
		}
		model model = new model();
		/*private void UpdateData()
        {
            model.SqlExecute(@"Update tb_product set pro_id=N'" + guna2TextBox2.Text + "',pro_name=N'" + guna2TextBox4.Text + "',type_id=N'" + cbbname.SelectedValue + "',unit_id=N'" + guna2ComboBox1.SelectedValue + "',pro_orderPrice=N'" + guna2TextBox3.Text + "'," +
                "pro_sellPrice=N'" + guna2TextBox1.Text + "',pro_message=N'" + guna2TextBox5.Text + "'" +
                " where pro_id='" + pro_id + "'");
        }*/

		private void guna2TextBox3_TextChanged(object sender, EventArgs e)
		{
			lblprovince.Visible = false;
		}

		private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
		{
			lbldistrict.Visible = false;
		}

		private void cbbname_SelectedIndexChanged(object sender, EventArgs e)
		{
			lblvillage.Visible = false;
		}

		private void guna2TextBox4_TextChanged(object sender, EventArgs e)
		{
			lblname.Visible = false;
		}

		private void guna2TextBox2_TabStopChanged(object sender, EventArgs e)
		{
			lblcode.Visible = false;
		}

		private void guna2TextBox2_TextChanged(object sender, EventArgs e)
		{
			lblcode.Visible = false;
		}
		static edit_product pop;
		static DialogResult result = DialogResult.No;
		private void FormsLoad()
		{
			lblcode.Visible = false;
			lblname.Visible = false;
			lblvillage.Visible = false;
			lbldistrict.Visible = false;
			lblprovince.Visible = false;
			lblposition.Visible = false;
			label4.Visible = false;
			guna2TextBox2.Focus();
		}
		private void FillInfo()
		{
			guna2TextBox2.Enabled = false;
			guna2TextBox4.Focus();
			guna2TextBox4.Text = pro_name;
			guna2TextBox3.Text = pro_imp_price;
			guna2TextBox2.Text = pro_id;
			guna2TextBox1.Text = pro_sell_price;
			guna2TextBox5.Text = pro_message;
			cbbname.Text = type_id;
			guna2ComboBox1.Text = unit_id;
		}
		private void cbb_producttype()
		{
			model.LoadDataToCombobox("select type_name, type_id from tb_producttype where type_status=1", cbbname, "type_id", "type_name");
		}
		private void cbb_unit()
		{
			model.LoadDataToCombobox("select unit_name, unit_id from tb_unit where unit_status=1", guna2ComboBox1, "unit_id", "unit_name");
		}

		private void edit_product_Load(object sender, EventArgs e)
		{
			FormsLoad();
			FillInfo();
			cbb_producttype();
			cbb_unit();
			if (!string.IsNullOrEmpty(pro_id))
			{
				FillInfo();
			}

			/*guna2TextBox2.Focus();
            guna2TextBox4.Text = pro_name;
            guna2TextBox3.Text = pro_imp_price;
            guna2TextBox2.Text = pro_id;
            guna2TextBox1.Text = pro_sell_price;
            guna2TextBox5.Text = pro_message;
            cbbname.Text = t_name;
            guna2ComboBox1.Text = u_name;
            lblcode.Visible = false;
            lblname.Visible = false;
            lblprovince.Visible = false;
            lbldistrict.Visible = false;
            lblvillage.Visible = false;
            lblposition.Visible = false;
            label1.Visible = false;*/

		}
		private bool checkIsnullText()
		{
			model.b = true;
			model.Get_ID("SELECT * FROM tb_product WHERE pro_id='" + guna2TextBox2.Text + "' and pro_status=1");
			bool b = true;
			if (guna2TextBox2.Text == "")
			{
				lblcode.Visible = true;
				guna2TextBox2.Focus();
				b = false;
			}
			else if (guna2TextBox4.Text == "")
			{
				lblname.Visible = true;
				guna2TextBox4.Focus();
				b = false;
			}
			else if (cbbname.Text == "ກະລຸນາເລືອກ")
			{
				lblvillage.Visible = true;
				b = false;
			}
			else if (guna2ComboBox1.Text == "ກະລຸນາເລືອກ")
			{
				lbldistrict.Visible = true;
				b = false;
			}
			else if (guna2TextBox3.Text == "" || Convert.ToInt32(guna2TextBox3.Text) <= 0)
			{
				lblprovince.Visible = true;
				guna2TextBox3.Focus();
				b = false;
			}
			else if (guna2TextBox1.Text == "" || Convert.ToInt32(guna2TextBox1.Text) <= 0)
			{
				lblposition.Visible = true;
				guna2TextBox1.Focus();
				b = false;
			}
			else if (guna2TextBox5.Text == "" || Convert.ToInt32(guna2TextBox5.Text) <= 0)
			{
				label4.Visible = true;
				guna2TextBox5.Focus();
				b = false;
			}
			else if (model.b == false && string.IsNullOrEmpty(pro_id))
			{
				b = false;
				WrongDialog.Show("ຂໍອະໄພ ບໍ່ສາມາດເພີ່ມຂໍ້ມູນໄດ້ ເນື່ອງຈາກມີຂໍ້ມູນໃນລະບົບຢູ່ແລ້ວ");
			}
			else if (Convert.ToDouble(guna2TextBox3.Text) > Convert.ToDouble(guna2TextBox1.Text))
			{
				b = false;
				WrongDialog.Show("ຂໍອະໄພ ບໍ່ສາມາດແກ້ໄຂໄດ້ເນື່ອງຈາກລາຄາຊື້ຫຼາຍກວ່າລາຄາຂາຍ");
			}
			return b;
		}
		private void UpdateData()
		{
			model.SqlExecute(@"Update tb_product set pro_id=N'" + guna2TextBox2.Text + "',pro_name=N'" + guna2TextBox4.Text + "',type_id=N'" + cbbname.SelectedValue + "',unit_id=N'" + guna2ComboBox1.SelectedValue + "',pro_orderPrice=N'" + guna2TextBox3.Text + "'," +
				"pro_sellPrice=N'" + guna2TextBox1.Text + "',pro_message=N'" + guna2TextBox5.Text + "'" +
				" where pro_id='" + pro_id + "'");
			result = DialogResult.Yes;
			this.Close();
		}
		public static DialogResult Show(string pro_id, string type_id, string unit_id, string pro_name, string pro_imp_price, string pro_sell_price, string pro_message)
		{
			pop = new edit_product();

			pop.pro_id = pro_id;
			pop.type_id = type_id;
			pop.unit_id = unit_id;
			pop.pro_name = pro_name;
			pop.pro_imp_price = pro_imp_price;
			pop.pro_sell_price = pro_sell_price;
			pop.pro_message = pro_message;

			pop.ShowDialog();
			return result;
		}

		private void guna2Button2_Click(object sender, EventArgs e)
		{
			this.Close();
			result = DialogResult.No;
		}
	}
}
