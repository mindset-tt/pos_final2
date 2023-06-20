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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace fanail.management
{
    public partial class protype : Form
    {
        public protype()
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
                    string em_id = guna2DataGridView1.CurrentRow.Cells["Column1"].Value.ToString();
                    management.edit_protype edit = new management.edit_protype();
                    edit.ShowDialog();
                }
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void protype_Load(object sender, EventArgs e)
        {
            lblcode.Visible = false;
            loadData();
        }

        private void protype_Load_1(object sender, EventArgs e)
        {
            lblcode.Visible = false;
            loadData();
        }
        model model = new model();

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
        private void SaveData()
        {
            model.SqlExecute(@"insert into tb_producttype (type_name, type_status) values (N'" + guna2TextBox1.Text + "',1)");
        }
        private void loadData()
        {
            model.ShowDataToGridView("Select type_id, type_name From tb_producttype where type_status = 1 ", guna2DataGridView1);
        }
        void Delete(string id)
        {
            model.SqlExecute("update tb_producttype set type_status=0 where type_id='" + id + "'");
            loadData();

            AlertMessage alert = new AlertMessage();
            alert.TopMost = true;
            alert.showAlert("ລຶບລາຍການສຳເລັດ.");
        }

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
             guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = " type_name LIKE'%{0}%'";
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

                    edit_protype edit = new edit_protype();
                    edit.em_id = em_id;
                    edit.name = name;
                    edit.FormClosing += new FormClosingEventHandler(this.protype_FormClosing);
                    edit.Show();
                }
            }
        }

        private void protype_FormClosing(object sender, FormClosingEventArgs e)
        {
            loadData();
        }

        private void guna2TextBox1_TextChanged_1(object sender, EventArgs e)
        {
            lblcode.Visible = false;
        }
    }
}
