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
    public partial class edit_unit : Form
    {
        public edit_unit()
        {
            InitializeComponent();
        }
        public string em_id, gender, name, surname, village, district, province, position, birthday;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            bool check = true;
            if (guna2TextBox1.Text == "")
            {
                label4.Visible = true;
                guna2TextBox1.Focus();
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
            model.SqlExecute(@"Update tb_unit set unit_name=N'" + guna2TextBox1.Text + "'" + " where unit_id='" + em_id + "'");
            this.Close();
        }

        private void edit_unit_Load(object sender, EventArgs e)
        {
            guna2TextBox1.Text = name;
            label4.Visible = false;
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
