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
    public partial class WrongDialog : Form
    {
        public WrongDialog()
        {
            InitializeComponent();
        }
        static WrongDialog WrongBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show(String msg)
        {
            WrongBox = new WrongDialog();
            WrongBox.lbMsg.Text = msg;
            WrongBox.ShowDialog();
            return result;
        }

        private void guna2Button1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                guna2Button1.PerformClick();
                e.Handled = true;
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            WrongBox.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            WrongBox.Close();
        }
    }
}
