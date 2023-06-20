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

namespace fanail.management
{
    public partial class edit_suppiler : Form
    {
        public edit_suppiler()
        {
            InitializeComponent();
        }
        public string sup_id, name, village, district, province, tel, contact;

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
            lblprovince.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblposition.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
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
                UpdateData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ແກ້ໄຂສຳເລັດ");
                this.Close();
            }
        }
        model model = new model();
        private void UpdateData()
        {
            model.SqlExecute(@"Update tb_suppiler set sup_name=N'" + guna2TextBox2.Text + "',sup_village=N'" + guna2TextBox4.Text + "',sup_district=N'" + guna2TextBox6.Text + "',sup_province=N'" + guna2TextBox3.Text + "',sup_tel=N'" + guna2TextBox1.Text + "'" +
                " ,sup_contact=N'" + guna2TextBox5.Text + "' where sup_id='" + sup_id + "'");
        }

        private void guna2TextBox6_TextChanged(object sender, EventArgs e)
        {
            lbldistrict.Visible = false;
        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {
            lblvillage.Visible = false;
        }

        private void edit_suppiler_Load(object sender, EventArgs e)
        {
            lblname.Visible = false;
            lblvillage.Visible = false;
            lbldistrict.Visible = false;
            lblprovince.Visible = false;
            lblposition.Visible = false;
            guna2TextBox2.Text = name;
            guna2TextBox4.Text = village;
            guna2TextBox6.Text = district;
            guna2TextBox3.Text = province;
            guna2TextBox1.Text = tel;
            guna2TextBox5.Text = contact;
            
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            lblname.Visible = false;
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
