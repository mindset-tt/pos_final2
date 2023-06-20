using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;

namespace fanail.management
{
    public partial class employee : Form
    {
        public employee()
        {
            InitializeComponent();
         
        }

        model model = new model();
        private void loadData()
        {
            model.ShowDataToGridView("Select user_id, user_emName, user_emSurname, user_gender, user_tel, user_name, user_password, user_type  From tb_user where user_status = 1 ", guna2DataGridView1);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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
                    edit_employee edit = new edit_employee();
                    edit.ShowDialog();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (guna2TextBox5.Text == "")
            {
                lblname.Visible = true;
                guna2TextBox5.Focus();
                check = false;
            }
            else if (guna2TextBox4.Text == "")
            {
                lblsurname.Visible = true;
                guna2TextBox4.Focus();
                check = false;
            }
            else if (guna2TextBox8.Text == "")
            {
                label14.Visible = true;
                guna2TextBox8.Focus();
                check = false;
            }
            else if (guna2TextBox3.Text == "")
            {
                label11.Visible = true;
                guna2TextBox3.Focus();
                check = false;
            }
            else if (guna2TextBox9.Text == "")
            {
                label5.Visible = true;
                guna2TextBox9.Focus();
                check = false;
            }
            else
            {
                SaveData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ບັນທຶກສຳເລັດ");
                guna2TextBox9.Text = "";
                guna2TextBox5.Text = "";
                guna2TextBox4.Text = "";
                guna2TextBox3.Text = "";
                guna2TextBox8.Text = "";
                guna2ImageRadioButton2.Checked = true;
                rbtmale.Checked = true;
                loadData();
            }
            
        }
        string gender , status;
        private void SaveData()
        {
            if (rbtmale.Checked == true)
            {
                gender = lblmale.Text;
            }
            else
            {
                gender = lblfeemale.Text;
            }
            if (guna2ImageRadioButton2.Checked == true)
            {
                status = label28.Text;
            }
            else
            {
                status = label27.Text;
            }

            model.SqlExecute(@"insert into tb_user (user_gender, user_emName, user_emSurname, user_tel, user_name, user_password, user_type, user_status) 
            values (N'" + gender + "',N'" + guna2TextBox5.Text + "',N'" + guna2TextBox4.Text + "',N'" + guna2TextBox8.Text + "',N'" + guna2TextBox3.Text + "',N'" + guna2TextBox9.Text + "',N'" + status + "',1)");
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void employee_Load(object sender, EventArgs e)
        {
            lblname.Visible = false;
            lblsurname.Visible = false;
            label11.Visible = false;
            label5.Visible = false;
            label14.Visible = false;
            loadData();

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            lblsurname.Visible = false;
        }




        private void guna2TextBox8_TextChanged(object sender, EventArgs e)
        {
            label14.Visible = false;
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            label11.Visible = false;
        }

        private void guna2TextBox9_TextChanged(object sender, EventArgs e)
        {
            label5.Visible = false;
        }


        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2DataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }
        void Delete(string id)
        {
            model.SqlExecute("update tb_user set user_status=0 where user_id='" + id + "'");
            loadData();

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column12"].Index].ColumnIndex)
            {
                if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                {
                    Delete(guna2DataGridView1.CurrentRow.Cells["Column2"].Value.ToString());
                }
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column11"].Index].ColumnIndex)
                {
                    string em_id = guna2DataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                    string gender = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();
                    string name = guna2DataGridView1.CurrentRow.Cells["Column3"].Value.ToString();
                    string surname = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                    string tel = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                    string user = guna2DataGridView1.CurrentRow.Cells["Column7"].Value.ToString();
                    string password = guna2DataGridView1.CurrentRow.Cells["Column8"].Value.ToString();
                    string type = guna2DataGridView1.CurrentRow.Cells["Column9"].Value.ToString();
                   
                    
                    edit_employee edit_Employee = new edit_employee();
                    edit_Employee.user_id = em_id;
                    edit_Employee.gender = gender;
                    edit_Employee.name = name;
                    edit_Employee.surname = surname;
                    edit_Employee.tel = tel;
                    edit_Employee.user = user;
                    edit_Employee.password = password;
                    edit_Employee.type = type;
                    edit_Employee.FormClosing += new FormClosingEventHandler(this.employee_FormClosing);
                    edit_Employee.Show();
                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
           
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = " user_gender LIKE'%{0}%' or user_emName LIKE'%{0}%' or user_emSurname LIKE'%{0}%' or user_tel LIKE'%{0}%' or user_type LIKE'%{0}%' or user_name LIKE'%{0}%' or user_password LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
                
            }
        }

        private void guna2TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2DataGridView1_RowPostPaint_2(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column1"].Value = (e.RowIndex + 1).ToString();
        }
    }
}
