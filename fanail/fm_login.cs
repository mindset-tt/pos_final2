using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail
{
    public partial class fm_login : Form
    {
        public fm_login()
        {
            InitializeComponent();
            txtpassword.UseSystemPasswordChar = true;
            lblusername.Visible = false;
            lblpassword.Visible = false;
        }
        string Username;
        public static string em_id;
        model model = new model();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseHover(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.eye;
            txtpassword.UseSystemPasswordChar = false;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Properties.Resources.hidden;
            txtpassword.UseSystemPasswordChar = true;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            model.OpenConnection();
            if (string.IsNullOrEmpty(txtusername.Text))
            {
                lblusername.Visible = true;
            }
            else if (string.IsNullOrEmpty(txtpassword.Text))
            {
                lblpassword.Visible = true;

            }
            else
            {
                Main f = new Main();
                SqlDataReader dr;
                DataTable dt = new DataTable();
                SqlCommand cmd;
                cmd = new SqlCommand("select * from tb_user where user_name=@username and user_password=@password and user_status=1", model.con);
                cmd.Parameters.AddWithValue("username", txtusername.Text);
                cmd.Parameters.AddWithValue("password", txtpassword.Text);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dt.Load(dr);
                    Username = dt.Rows[0].ItemArray[2].ToString();
                    String em_name, em_surname;
                    em_name = dt.Rows[0].ItemArray[2].ToString();
                    em_surname = dt.Rows[0].ItemArray[3].ToString();
                    Main.Username = em_name + " " + em_surname;
                    Main.Status = dt.Rows[0].ItemArray[7].ToString();
                    em_id = dt.Rows[0].ItemArray[0].ToString();

                    this.Hide();
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    WrongDialog.Show("ຊື່ຜູ້ໃຊ້ ຫຼື ລະຫັດຜ່ານບໍ່ຖືກຕ້ອງ");
                    txtusername.Text = "";
                    txtpassword.Text = "";
                    txtusername.Focus();
                }
                dr.Close();
                dt.Clear();
            }
        }

        private void txtusername_TextChanged(object sender, EventArgs e)
        {
            lblusername.Visible = false;
        }

        private void txtpassword_TextChanged(object sender, EventArgs e)
        {
            lblpassword.Visible = false;
        }
    }
}
