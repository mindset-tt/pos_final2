using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.order
{
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
            ShowData();
            lblemname.Visible = false;
            lblpassword.Visible = false;
            guna2Button3.Visible = false;
            label7.Visible = false;
            label1.Text = "0";
            label8.Visible = false;
        }
        model model = new model();
        Main fm = new Main();
        public void showCount()
        {
            model.GetCount("SELECT COUNT(order_id) as count FROM tb_order where order_status=1", "count");
            double count2 = Convert.ToDouble(model.count);
            if (count2 == 0)
            {
                guna2Button5.Visible = false;
            }
            else if (count2 > 0)
            {
                if (count2 > 99)
                {
                    guna2Button5.Text = "99+";
                }
                else
                {
                    guna2Button5.Text = count2.ToString();
                }
                guna2Button5.Visible = true;
            }

            model.GetCount("SELECT COUNT(pro_id) as count FROM tb_product where pro_status=1 and pro_qty<pro_message", "count");
            double count = Convert.ToDouble(model.count);
            if (count == 0)
            {
                guna2Button4.Visible = false;
            }
            else if (count > 0)
            {
                if (count > 99)
                {
                    guna2Button4.Text = "99+";
                }
                else
                {
                    guna2Button4.Text = count.ToString();
                }
                guna2Button4.Visible = true;
            }
        }
        private void cbb_suppiler()
        {
            model.LoadDataToCombobox("select sup_name, sup_id from tb_suppiler where sup_status=1", cbbname, "sup_id", "sup_name");
        }
        private void ShowData()
        {
            model.ShowDataToGridView("select pro_id,type_name,unit_name,pro_name,pro_qty from tb_product as d1 inner join tb_producttype as d2 on(d1.type_id=d2.type_id) inner join tb_unit as d3 on(d1.unit_id=d3.unit_id) where pro_status=1", guna2DataGridView1);
            showCount();
            cbb_suppiler();
            model.Generate_ID("select max(order_id)+1 from tb_order");
            label1.Text = model.ID;
        }
        private void sumQty()
        {
            if (guna2DataGridView2.Rows.Count >= 0)
            {
                int totalQty = 0;
                for (int i = 0; i < guna2DataGridView2.RowCount; i++)
                {
                    totalQty += Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
                }
                label1.Text = totalQty.ToString("#,###");
            }
            else
            {
                label1.Text = "0";
            }
        }
        private void order_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        public static List<String> Pro_ID = new List<String>();
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView2.RowCount > 0)
            {
                for (int i = 0; i < guna2DataGridView2.RowCount; i++)
                {
                    Pro_ID.Add(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString());
                }
            }

            if (almost_out.Show("", "", "", "", "") == DialogResult.Yes)
            {

                for (int i = 0; i < almost_out.proid.Count; i++)
                {
                    guna2DataGridView2.Rows.Add("", almost_out.proid[i], almost_out.proname[i], almost_out.typname[i], almost_out.unitname[i], "1");
                }
                if (guna2DataGridView2.RowCount > 0)
                {
                    guna2Button3.Visible = true;
                    sumQty();
                }

                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ເພີ່ມເຂົ້າລາຍການສັ່ງຊື້ສຳເລັດແລ້ວ");
            }

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            check_order check_Order = new check_order();
            check_Order.ShowDialog();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {

            if (guna2DataGridView2.RowCount > 0)
            {
                if (cbbname.Text == "ກະລຸນາເລືອກ")
                {
                    lblemname.Visible = true;
                }
                else
                {
                    if (WarningMessage.Show("ທ່ານຕ້ອງການສັ່ງຊື້ລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                    {
                        model.SqlExecute("insert into tb_order (sup_id,user_id,order_date,order_status) values('" + cbbname.SelectedValue + "','" + fm_login.em_id + "',getdate(),1)");
                        model.GetCount("select * from tb_order", "order_id");

                        for (int i = 0; i < guna2DataGridView2.RowCount; i++)
                        {
                            model.SqlExecute("insert into tb_orderdetail (order_id,pro_id,orderd_qty) values (N'" + model.count + "',N'" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString() + "',N'" + guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString() + "')");
                        }
                        label1.Text = "";
                        guna2DataGridView2.Rows.Clear();
                        label1.Text = "0";
                        guna2TextBox1.Text = "";
                        guna2Button3.Visible = false;

                        AlertMessage alert = new AlertMessage();
                        alert.TopMost = true;
                        alert.showAlert("ບັນທຶກການສັ່ງຊື້ສຳເລັດແລ້ວ.");
                    }
                }
            }
            showCount();
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2DataGridView2_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView2.Rows[e.RowIndex].Cells["dataGridViewTextBoxColumn1"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            //if (cbbname.Text == "ກະລຸນາເລືອກ")
            //{
            //    lblemname.Visible = true;
            //}
            //else 
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
                    if (guna2DataGridView2.RowCount == 0)
                    {
                        guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, qty);
                    }
                    else
                    {
                        for (int i = 0; i < guna2DataGridView2.RowCount; i++)
                        {
                            if (guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString() == guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn2"].Value.ToString())
                            {
                                int qtyIndex = Convert.ToInt32(guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value.ToString());
                                guna2DataGridView2.Rows[i].Cells["dataGridViewTextBoxColumn6"].Value = Convert.ToInt32(qtyIndex) + Convert.ToInt32(guna2TextBox1.Text);
                                status = true;
                                break;
                            }
                        }
                        if (status == false)
                        {
                            guna2DataGridView2.Rows.Add("", pro_id, pro_name, type_name, unit_name, qty);
                        }
                    }
                    guna2Button3.Visible = true;
                }
                else
                {
                    label7.Visible = true;
                }
                sumQty();
                guna2TextBox1.Text = "";
            }
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cbbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblemname.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblpassword.Visible = false;
        }

        private void guna2DataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView2.Rows.Count > 0)
            {
                guna2TextBox1.Text = guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value.ToString();
                if (guna2DataGridView2.CurrentCell.ColumnIndex == guna2DataGridView2.CurrentRow.Cells[guna2DataGridView2.Columns["dataGridViewImageColumn2"].Index].ColumnIndex)
                {
                    if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                    {
                        guna2DataGridView2.Rows.Remove(guna2DataGridView2.CurrentRow);
                        guna2TextBox1.Text = "";
                    }
                }
                sumQty();
            }
            if (guna2DataGridView2.Rows.Count == 0)
            {
                guna2Button3.Visible = false;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2TextBox1.Text != "")
            {
                if (guna2DataGridView2.Rows.Count > 0)
                {
                    guna2DataGridView2.CurrentRow.Cells["dataGridViewTextBoxColumn6"].Value = guna2TextBox1.Text;
                }
                sumQty();
                guna2TextBox1.Text = "";
                label8.Visible = false;
            }
            else
            {
                label8.Visible = true;
            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = "pro_id LIKE'%{0}%' or pro_name LIKE'%{0}%' or type_name LIKE'%{0}%' or unit_name LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
            }
        }
    }
}
