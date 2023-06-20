using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fanail.management
{
    public partial class edit_employee : Form
    {
        public edit_employee()
        {
            InitializeComponent();

        }
        public string user_id, type, password, user, tel, surname, name, gender;

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

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            lblsurname.Visible = false;
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void loadData()
        {
            label14.Visible = false;
            label11.Visible = false;
            label5.Visible = false;
            lblsurname.Visible = false;
            lblname.Visible = false;

            if (gender == "ຊາຍ")
            {
                rbtmale.Checked = true;
            }
            else
            {
                rbtfeemale.Checked = true;
            }
            if (type == "Admin")
            {
                guna2ImageRadioButton2.Checked = true;
            }
            else
            {
                guna2ImageRadioButton1.Checked = true;
            }
            guna2TextBox5.Text = name;
            guna2TextBox4.Text = surname;
            guna2TextBox8.Text = tel;
            guna2TextBox3.Text = user;
            guna2TextBox9.Text = password;
        }

        private void edit_employee_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
        }

        private void guna2TextBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void edit_employee_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void lblcode_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            checkTextNull();
            
        }
        
        private void checkTextNull()
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
                UpdateData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ແກ້ໄຂສຳເລັດ.");
            }
        }
        model model = new model();
        private void UpdateData()
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
                type = label28.Text;
            }
            else
            {
                type = label27.Text;
            }
            model.SqlExecute(@"Update tb_user set user_gender=N'" + gender + "',user_emName=N'" + guna2TextBox5.Text + "',user_emSurname=N'" + guna2TextBox4.Text + "'," +
                "user_tel=N'" + guna2TextBox8.Text + "',user_type=N'" + type + "',user_name=N'" + guna2TextBox3.Text + "',user_password=N'" +guna2TextBox9.Text + "'" +
                " where user_id='" + user_id + "'");
            this.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
