using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        model model = new model();
        public static string Username, Status;
        private async void switchPanel(Panel panel)
        {

            panel4.Visible = false;
            panel5.Visible = false;
            await Task.Delay(250);
            panel.Visible = true;
        }
        public void disiblePanel()
        {
            panel4.Visible = false;
            panel5.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button14_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == false)
            {
                switchPanel(panel5);

            }
            else
            {
                disiblePanel();

            }
            guna2Button13.PerformClick();
            guna2Button1.Checked = false;
            guna2Button14.Checked = true;
            guna2Button15.Checked = false;
            guna2Button16.Checked = false;
            guna2Button17.Checked = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (panel4.Visible == false)
            {
                switchPanel(panel4);

            }
            else
            {
                disiblePanel();

            }
            guna2Button2.PerformClick();
            guna2Button1.Checked = true;
            guna2Button14.Checked = false;
            guna2Button15.Checked = false;
            guna2Button16.Checked = false;
            guna2Button17.Checked = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            model.switchForm(new sell.sell(), panel6);
            disiblePanel();
            guna2Button1.Checked = false;
            guna2Button14.Checked = false;
            guna2Button15.Checked = false;
            guna2Button16.Checked = false;
            guna2Button17.Checked = true;

            if (Status == "Admin")
            {
                label2.ForeColor = Color.Green;
                guna2Button1.Visible = true;
                guna2Button14.Visible = true;
            }
            else
            {
                label2.ForeColor = Color.FromArgb(255, 219, 163, 44);
                guna2Button1.Visible = false;
                guna2Button14.Visible = false;
            }
            label1.Text = Username;
            label2.Text = Status;
            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ຍິນດີຕອນຮັບທ່ານ " + Username + " ເຂົ້າສູ່ລະບົບ");
        }

        private void guna2Button15_Click(object sender, EventArgs e)
        {
            model.switchForm(new order.order(), panel6);
            guna2Button1.Checked = false;
            guna2Button14.Checked = false;
            guna2Button15.Checked = true;
            guna2Button16.Checked = false;
            guna2Button17.Checked = false;
        }

        private void guna2Button16_Click(object sender, EventArgs e)
        {
            model.switchForm(new import.import(), panel6);
            guna2Button1.Checked = false;
            guna2Button14.Checked = false;
            guna2Button15.Checked = false;
            guna2Button16.Checked = true;
            guna2Button17.Checked = false;
        }

        private void guna2Button17_Click(object sender, EventArgs e)
        {
            model.switchForm(new sell.sell(), panel6);
            guna2Button1.Checked = false;
            guna2Button14.Checked = false;
            guna2Button15.Checked = false;
            guna2Button16.Checked = false;
            guna2Button17.Checked = true;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true;
            model.switchForm(new management.employee(), panel6);
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true;
            model.switchForm(new management.protype(), panel6);
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true;
            model.switchForm(new management.unit(), panel6);
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true; 
            model.switchForm(new management.product(), panel6);
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true; 
            model.switchForm(new management.suppiler(), panel6);
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            guna2Button1.Checked = true; 
            model.switchForm(new management.ex(), panel6);
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            guna2Button14.Checked = true;
            model.switchForm(new report.r_income_expense(), panel6);
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            guna2Button14.Checked = true; 
            model.switchForm(new report.r_import(), panel6);
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            guna2Button14.Checked = true; 
            model.switchForm(new report.r_product(), panel6);
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            guna2Button14.Checked = true; 
            model.switchForm(new report.r_best_sell(), panel6);
        }
    }
}
