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
using static System.Runtime.CompilerServices.RuntimeHelpers;
using System.Xml.Linq;

namespace fanail.management
{
    public partial class product : Form
    {
        public product()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        model model = new model();
        
        private void cbb_producttype()
        {
            model.LoadDataToCombobox("select * from tb_producttype where type_status=1", cbbname, "type_id", "type_name");
        }
        private void cbb_unit()
        {
            model.LoadDataToCombobox1("select * from tb_unit where unit_status=1", guna2ComboBox1, "unit_id", "unit_name");
        }
        private void loadData()
        {
            model.showdata(@"select pro_id,pro_name,type_name,unit_name,pro_qty,pro_orderPrice,pro_sellPrice,pro_message from tb_product as d1 inner join tb_producttype as d2 on(d1.type_id=d2.type_id) inner join tb_unit as d3 on(d1.unit_id=d3.unit_id) where pro_status=1", guna2DataGridView1);
            //model.ShowDataToGridView(@"select pro_id,pro_name,type_name,unit_name,pro_qty,pro_orderPrice,pro_sellPrice,pro_message from tb_product as d1 inner join tb_producttype as d2 on(d1.type_id=d2.type_id) inner join tb_unit as d3 on(d1.unit_id=d3.unit_id) where pro_status=1", guna2DataGridView1);
            //model.ShowDataToGridView("select * From View_product", guna2DataGridView1);
        }
        private void SaveData()
        {
            model.SqlExecute(@"insert into tb_product (pro_id,type_id,unit_id,pro_name,pro_qty,pro_orderPrice,pro_sellPrice,pro_message,pro_status) 
            values (N'" + guna2TextBox2.Text + "',N'" + cbbname.SelectedValue + "',N'" + guna2ComboBox1.SelectedValue + "','" + guna2TextBox4.Text + "','" + 0 + "',N'" + guna2TextBox3.Text + "',N'" + guna2TextBox1.Text + "',N'" + guna2TextBox5.Text + "',1)");
        }
        void Delete(string id)
        {
            model.SqlExecute("DELETE FROM tb_product where pro_id='" + id + "'");
            loadData();
            cbb_producttype();
            cbb_unit();
            

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column1"].Index].ColumnIndex)
            {
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column2"].Index].ColumnIndex)
                {
                    string em_id = guna2DataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                    edit_product edit = new edit_product();
                    edit.ShowDialog();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void product_Load(object sender, EventArgs e)
        {
            lblcode.Visible = false;
            lblname.Visible = false;
            lblvillage.Visible = false;
            lbldistrict.Visible = false;
            lblprovince.Visible = false;
            lblposition.Visible = false;
            label4.Visible = false;
            loadData();
            cbb_producttype();
            cbb_unit();
            

        }

        private void product_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }

        private void guna2TextBox4_Validated(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void cbbname_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblvillage.Visible = false;
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lbldistrict.Visible = false;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            lblprovince.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblposition.Visible = false;
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString(); guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox3_KeyPress(object sender, KeyPressEventArgs e)
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

        private void guna2TextBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            checkIsnullText();
            
        }
        private bool checkIsnullText()
        {
            bool b = true;
            for (int i = 0; i < guna2DataGridView1.Rows.Count; i++)
            {
                if (guna2TextBox2.Text == guna2DataGridView1.Rows[i].Cells["Column4"].Value.ToString() || guna2DataGridView1.Rows[i].Cells["Column4"].Value.ToString() == guna2TextBox2.Text)
                {
                    WrongDialog.Show("ຂໍອະໄພ ລະຫັດນີ້ມີຢູ່ແລ້ວ.");
                    guna2TextBox2.Text = "";
                    guna2TextBox2.Focus();
                    b = false;
                    break;
                }
                else
                {
                    
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
                        SaveData();
                        AlertMessage alert = new AlertMessage();
                        alert.TopMost = true;
                        alert.showAlert("ບັນທຶກສຳເລັດ");
                        loadData();
                        cbb_producttype();
                        cbb_unit();
                        guna2TextBox1.Text = "";
                        guna2TextBox2.Text = "";
                        guna2TextBox3.Text = "";
                        guna2TextBox4.Text = "";
                        guna2TextBox5.Text = "";
                        b = false;
                        break;
                    }
                }
            }
            return b;
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = "pro_id LIKE'%{0}%' or pro_name LIKE'%{0}%' or type_name LIKE'%{0}%' or unit_name LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
            }
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column1"].Index].ColumnIndex)
            {
                if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                {
                    Delete(guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString());
                }
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column2"].Index].ColumnIndex)
                {
                    string pro_id = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                    string pro_name = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
                    string pro_imp_price = guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString();
                    string pro_sell_price = guna2DataGridView1.CurrentRow.Cells["Column9"].Value.ToString();
                    string pro_message = guna2DataGridView1.CurrentRow.Cells["Column10"].Value.ToString();
                    string u_name = guna2DataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
                    string type_name = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                    if (edit_product.Show(pro_id, type_name, u_name, pro_name, pro_imp_price, pro_sell_price, pro_message) == DialogResult.Yes)
                    {
                        loadData();
                        AlertMessage alert = new AlertMessage();
                        alert.TopMost = true;
                        alert.showAlert("ແກ້ໄຂສຳເລັດ.");
                    }
                }
            }
        }

        private void guna2TextBox2_Click(object sender, EventArgs e)
        {
        }

        private void guna2TabControl1_Click(object sender, EventArgs e)
        {
            loadData();
            cbb_producttype();
            cbb_unit();
        }
    }
}
