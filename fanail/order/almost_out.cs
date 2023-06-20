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
    public partial class almost_out : Form
    {
        public almost_out()
        {
            InitializeComponent();
            ShowData();
        }
        model model = new model();
        string pro_ID, type_name, unit_name, pro_name, pro_qty;
        static almost_out pop;
        static DialogResult result = DialogResult.No;
        public static DialogResult Show(string pro_ID, string type_name, string unit_name, string pro_name, string pro_qty)
        {
            pop = new almost_out();

            pop.pro_ID = pro_ID;
            pop.type_name = type_name;
            pop.unit_name = unit_name;
            pop.pro_name = pro_name;
            pop.pro_qty = pro_qty;

            pop.ShowDialog();
            return result;
        }
        private void ShowData()
        {
            try
            {
                model.ShowDataToGridView("select pro_id,type_name,unit_name,pro_name,pro_qty from tb_product as d1 inner join tb_producttype as d2 on(d1.type_id=d2.type_id) inner join tb_unit as d3 on(d1.unit_id=d3.unit_id) where pro_status=1 and pro_qty<pro_message", guna2DataGridView1);
                if (guna2DataGridView1.RowCount > 0)
                {
                    for (int j = 0; j < order.Pro_ID.Count; j++)
                    {
                        for (int i = 0; i < guna2DataGridView1.RowCount; i++)
                        {
                            if (order.Pro_ID[j] == guna2DataGridView1.Rows[i].Cells["Column4"].Value.ToString())
                            {
                                guna2DataGridView1.Rows.RemoveAt(guna2DataGridView1.Rows[i].Index);
                            }
                        }
                    }
                }

                label2.Text = '(' + guna2DataGridView1.Rows.Count.ToString() + " ລາຍການ" + ')';

            }
            catch (Exception ex)
            {
                WrongDialog.Show("ເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex + " ກະລຸນາກວດສອບຂໍ້ມູນແລ້ວລອງໃໝ່ອີກຄັ້ງ.");
            }
        }
        public static List<String> proid = new List<String>();

        private void guna2DataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            guna2DataGridView1.Rows[e.RowIndex].Cells["Column3"].Value = (e.RowIndex + 1).ToString();
        }

        private void guna2TextBox10_TextChanged(object sender, EventArgs e)
        {
            if (guna2DataGridView1.DataSource != null)
            {
                string sql = "pro_id LIKE'%{0}%' or pro_name LIKE'%{0}%' or type_name LIKE'%{0}%' or unit_name LIKE'%{0}%'";
                model.Search(guna2DataGridView1, sql, guna2TextBox10.Text);
                label2.Text = '(' + guna2DataGridView1.Rows.Count.ToString() + " ລາຍການ" + ')';
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2DataGridView1.Rows.Count > 0)
            {
                for (int i = 0; i < guna2DataGridView1.RowCount; i++)
                {
                    proid.Add(guna2DataGridView1.Rows[i].Cells["Column4"].Value.ToString());
                    proname.Add(guna2DataGridView1.Rows[i].Cells["Column5"].Value.ToString());
                    typname.Add(guna2DataGridView1.Rows[i].Cells["Column6"].Value.ToString());
                    unitname.Add(guna2DataGridView1.Rows[i].Cells["Column7"].Value.ToString());
                    result = DialogResult.Yes;
                    this.Close();
                }
            }
            else
            {
                WrongDialog.Show("ບໍ່ພົບຂໍ້ມູນສີນຄ້າໃກ້ໝົດ.");
                this.Close();
            }
        }

        public static List<String> proname = new List<String>();
        public static List<String> typname = new List<String>();
        public static List<String> unitname = new List<String>();
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            result = DialogResult.No;
            this.Close();
        }
    }
}
