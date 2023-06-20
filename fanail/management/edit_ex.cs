using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.management
{
    public partial class edit_ex : Form
    {
        public edit_ex()
        {
            InitializeComponent();
        }
        public string id, dollar, bath;

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }

        private void edit_ex_Load(object sender, EventArgs e)
        {
            lblcode.Visible = false;
            label4.Visible = false;
            guna2TextBox1.Text = bath;
            guna2TextBox2.Text = dollar;
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (guna2TextBox1.Text == "" || Convert.ToDouble(guna2TextBox1.Text) <= 0)
            {
                lblcode.Visible = true;
                guna2TextBox1.Focus();
                check = false;
            }
            else if (guna2TextBox2.Text == "" || Convert.ToDouble(guna2TextBox1.Text) <= 0)
            {
                label4.Visible = true;
                guna2TextBox2.Focus();
                check = false;
            }
            else
            {
                checkTextNull();
            }
        }
        private void checkTextNull()
        {
            UpdateData();
            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ແກ້ໄຂສຳເລັດ.");
        }
        model model = new model();
        private void UpdateData()
        {
            model.SqlExecute(@"Update tb_rate set rate_bath =N'" + guna2TextBox1.Text + "'" + " ,rate_dollar =N'" + guna2TextBox2.Text + "'" + "where rate_id='" + id + "'");
            this.Close();
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
