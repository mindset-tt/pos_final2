using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace fanail.management
{
    public partial class ex : Form
    {
        public ex()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void ex_Load(object sender, EventArgs e)
        {
            label4.Visible = false;
            lblcode.Visible = false;
            loadData();
        }
        model model = new model();

        private void loadData()
        {
            model.ShowDataToGridView(@"SELECT TOP (1) * FROM tb_rate WHERE rate_status = 1 ORDER BY rate_id DESC ", guna2DataGridView1);
        }
        private void SaveData()
        {
            model.SqlExecute(@"insert into tb_rate (rate_bath, rate_dollar, rate_status) values (N'" + guna2TextBox1.Text + "',N'" + guna2TextBox2.Text + "',1)");
        }
        void Delete(string id)
        {
            model.SqlExecute("update tb_rate set rate_status = 0 where rate_id='" + id + "'");
            loadData();

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }


        private void ex_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
        }

        private void guna2TextBox2_TextChanged(object sender, EventArgs e)
        {
            label4.Visible = false;
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
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
                SaveData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ບັນທຶກສຳເລັດ");
                guna2TextBox1.Text = "";
                guna2TextBox2.Text = "";
                loadData();
            }
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2TextBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column1"].Index].ColumnIndex)
            {
                if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                {
                    string id = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                    
                    Delete(id);
                }
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column2"].Index].ColumnIndex)
                {
                    string id = guna2DataGridView1.CurrentRow.Cells["Column6"].Value.ToString();
                    string name = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                    string status = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();

                    edit_ex edit = new edit_ex();
                    edit.id = id;
                    edit.bath = name;
                    edit.dollar = status;
                    edit.FormClosing += new FormClosingEventHandler(this.ex_FormClosing);
                    edit.Show();
                }
            }
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }

		private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
