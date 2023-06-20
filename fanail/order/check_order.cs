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

namespace fanail.order
{
    public partial class check_order : Form
    {
        public check_order()
        {
            InitializeComponent();
            ShowData();
        }
        model model = new model();
        private void ShowData()
        {
            model.ShowDataToGridView("select order_id,sup_name,order_date from tb_order as d1 inner join tb_suppiler as d2 on(d1.sup_id=d2.sup_id) where order_status=1", guna2DataGridView1);
            label2.Text = '(' + guna2DataGridView1.Rows.Count.ToString() + " ລາຍການ" + ')';
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = "order_id LIKE'%{0}%' or sup_name LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
                label2.Text = '(' + guna2DataGridView1.Rows.Count.ToString() + " ລາຍການ" + ')';
            }
        }
        public static string order_id;

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.RowCount > 0)
            {
                order_id = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                bill f = new bill();
                f.ShowDialog();
                this.Close();
            }
            else
            {
                WrongDialog.Show("ຂໍອະໄພບໍ່ພົບຂໍ້ມູນບິນ.");
                this.Close();
            }
        }
    }
}
