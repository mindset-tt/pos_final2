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
using System.Xml.Linq;

namespace fanail.management
{
    public partial class suppiler : Form
    {
        public suppiler()
        {
            InitializeComponent();
        }
        model model = new model();
        private void loadData()
        {
            model.ShowDataToGridView("select sup_id ,sup_name, sup_village, sup_district, sup_province, sup_tel, sup_contact from tb_suppiler where sup_status=1", guna2DataGridView1); 
        }
        void Delete(string id)
        {
            model.SqlExecute("update tb_suppiler set sup_status=0 where sup_id='" + id + "'");
            loadData();

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void suppiler_Load(object sender, EventArgs e)
        {
            lblname.Visible = false;
            lblvillage.Visible = false;
            lbldistrict.Visible = false;
            lblprovince.Visible = false;
            lblposition.Visible = false;
            loadData();
        }

        private void suppiler_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            lblvillage.Visible = false;
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            lbldistrict.Visible = false;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            lblprovince.Visible = false;
        }

        private void lblposition_TextChanged(object sender, EventArgs e)
        {
            lblposition.Visible = false;
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
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
                    string sup_id = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                    string name = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
                    string village = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                    string district = guna2DataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
                    string province = guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString();
                    string tel = guna2DataGridView1.CurrentRow.Cells["Column9"].Value.ToString();
                    string contact = guna2DataGridView1.CurrentRow.Cells["Column10"].Value.ToString();

                    edit_suppiler edit_Employee = new edit_suppiler();
                    edit_Employee.sup_id = sup_id;
                    edit_Employee.name = name;
                    edit_Employee.village = village;
                    edit_Employee.district = district;
                    edit_Employee.province = province;
                    edit_Employee.tel = tel;
                    edit_Employee.contact = contact;
                    edit_Employee.FormClosing += new FormClosingEventHandler(this.suppiler_FormClosing);
                    edit_Employee.Show();


                }
            }
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            bool b = true;
            if (guna2TextBox2.Text == "")
            {
                lblname.Visible = true;
                guna2TextBox2.Focus();
                b = false;
            }
            else if (guna2TextBox4.Text == "")
            {
                lblvillage.Visible = true;
                guna2TextBox4.Focus();
                b = false;
            }
            else if (guna2TextBox6.Text == "")
            {
                lbldistrict.Visible = true;
                guna2TextBox6.Focus();
                b = false;
            }
            else if (guna2TextBox3.Text == "")
            {
                lblprovince.Visible = true;
                guna2TextBox3.Focus();
                b = false;
            }
            else if (guna2TextBox1.Text == "")
            {
                lblposition.Visible = true;
                guna2TextBox1.Focus();
                b = false;
            }
            else
            {
                SaveData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ບັນທຶກສຳເລັດ");
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox4.Text = "";
                guna2TextBox5.Text = "";
                guna2TextBox6.Text = "";

                loadData();
            }
            
        }
        private void SaveData()
        {
            model.SqlExecute(@"insert into tb_suppiler (sup_name, sup_village, sup_district, sup_province, sup_tel, sup_contact, sup_status) 
            values (N'" + guna2TextBox2.Text + "',N'" + guna2TextBox4.Text + "',N'" + guna2TextBox6.Text + "',N'" + guna2TextBox3.Text + "',N'" + guna2TextBox1.Text + "',N'" + guna2TextBox5.Text + "',1)");
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblposition.Visible = false;
        }

        private void guna2TextBox2_TextChanged_1(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = "sup_name LIKE'%{0}%' or sup_village LIKE'%{0}%' or sup_district LIKE'%{0}%' or sup_province LIKE'%{0}%' or sup_contact LIKE'%{0}%' or sup_tel LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
             
            }
        }
    }
}
