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
    public partial class WarningMessage : Form
    {
        public WarningMessage()
        {
            InitializeComponent();
        }
        static WarningMessage WrngBox;
        static DialogResult result = DialogResult.No;

        public static DialogResult Show(String msg)
        {
            WrngBox = new WarningMessage();
            WrngBox.lbMsg.Text = msg;
            WrngBox.ShowDialog();
            return result;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            result = DialogResult.Yes;
            WrngBox.Close();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            WrngBox.Close();
        }

        private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            WrngBox.Close();
        }
    }
}
