using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.management
{
    public partial class unit : Form
    {
        public unit()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column1"].Index].ColumnIndex)
            {
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column2"].Index].ColumnIndex)
                {
                    string em_id = guna2DataGridView1.CurrentRow.Cells["Column2"].Value.ToString();
                    management.edit_unit edit = new management.edit_unit();
                    edit.ShowDialog();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2TextBox1_TabStopChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }
        model model = new model();
        private void loadData()
        {
            model.ShowDataToGridView("Select unit_id, unit_name From tb_unit where unit_status = 1 ", guna2DataGridView1);
        }
        private void SaveData()
        {
            model.SqlExecute(@"insert into tb_unit (unit_name, unit_status) values (N'" + guna2TextBox1.Text + "',1)");
        }
        void Delete(string id)
        {
            model.SqlExecute("update tb_unit set unit_status=0 where unit_id='" + id + "'");
            loadData();

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }

        private void unit_Load(object sender, EventArgs e)
        {
            lblcode.Visible = false;
            loadData();
        }

        private void unit_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = " unit_name LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);

            }
        }

        private void guna2DataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column1"].Index].ColumnIndex)
            {
                if (WarningMessage.Show("ທ່ານຕ້ອງການລຶບລາຍການດັ່ງກ່າວແທ້ບໍ?") == DialogResult.Yes)
                {
                    Delete(guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString());
                }
            }
            if (guna2DataGridView1.Rows.Count > 0)
            {
                if (guna2DataGridView1.CurrentCell.ColumnIndex == guna2DataGridView1.CurrentRow.Cells[guna2DataGridView1.Columns["Column2"].Index].ColumnIndex)
                {
                    string em_id = guna2DataGridView1.CurrentRow.Cells["Column4"].Value.ToString();
                    string name = guna2DataGridView1.CurrentRow.Cells["Column5"].Value.ToString();

                    edit_unit edit = new edit_unit();
                    edit.em_id = em_id;
                    edit.name = name;
                    edit.FormClosing += new FormClosingEventHandler(this.unit_FormClosing);
                    edit.Show();
                }
            }
        }

        private void guna2Button1_Click_1(object sender, EventArgs e)
        {
            bool check = true;
            if (guna2TextBox1.Text == "")
            {
                lblcode.Visible = true;
                guna2TextBox1.Focus();
                check = false;
            }
            else
            {
                SaveData();
                AlertMessage alert = new AlertMessage();
                alert.TopMost = true;
                alert.showAlert("ບັນທຶກສຳເລັດ");
                guna2TextBox1.Text = "";
                loadData();
            }
        }

        private void guna2DataGridView1_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }
    }
}
