using fanail.order;
using fanail.report;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fanail.sell
{
    public partial class pay_sell : Form
    {
        public pay_sell()
        {
            InitializeComponent();
            guna2RadioButton1.Checked = true;
            label3.Text = "0 ກິບ";
        }
        string cer_id = "";
        int ID;
        string sell_id = "";
        SqlConnection con = new SqlConnection(@"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;");
        string sql = "";
        double totalprice;
        private void getsellid()
        {
            try
            {
                con.Open();
                string sql = "select max(sell_id) from tb_sell";
                SqlCommand Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                SqlDataReader Myreader = Comd.ExecuteReader();
                Myreader.Read();
                if (Myreader.HasRows)
                {
                    if (Myreader.GetValue(0).ToString() != "")
                    {
                        ID = Convert.ToInt32(Myreader.GetValue(0).ToString()) + 1;
                        sell_id = ID.ToString();
                    }
                    else
                    {
                        sell_id = ID.ToString("1");
                    }
                }
                con.Close();

                con.Open();
                sql = "select max(rate_dollar) from tb_rate where rate_status = 1";
                Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                Myreader = Comd.ExecuteReader();
                if (Myreader.HasRows)
                {
                    while (Myreader.Read())
                    {

                        usd = Convert.ToDouble(Myreader[0]);

                    }
                }
                con.Close();
                con.Open();
                sql = "select max(rate_bath) from tb_rate where rate_status = 1";
                Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                Myreader = Comd.ExecuteReader();
                if (Myreader.HasRows)
                {
                    while (Myreader.Read())
                    {

                        bath = Convert.ToDouble(Myreader[0]);

                    }
                }
                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void getcerid()
        {
            try
            {
                con.Open();
                sql = "select max(rate_id) from tb_rate where rate_status = 1";
                SqlCommand Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                SqlDataReader Myreader = Comd.ExecuteReader();
                if (Myreader.HasRows)
                {
                    while (Myreader.Read())
                    {
                        cer_id = Myreader[0].ToString();
                    }
                }
                con.Close();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        sell sells = new sell();
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        double bath = 0;
        double usd = 0;
        private void guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {

                if (guna2RadioButton1.Checked == true)
                {
                    if (guna2TextBox1.Text == "")
                    {

                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາ");

                    }
                    else if (Convert.ToInt64(guna2TextBox1.Text) < Convert.ToInt64(label2.Text.Replace(",", "")))
                    {
                        //WrongDialog alertMessage = new WrongDialog();
                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາໃຫ້ຖືກຕ້ອງ");

                    }
                    else
                    {
                        getcerid();
                        getsellid();
                        if (sell.Pro_id.Count != 0)
                        {
                            con.Open();
                            double totalqty = Convert.ToDouble(label1.Text.Replace(",", ""));
                            double totalprice = Convert.ToDouble(label2.Text.Replace(",", ""));
                            //double totalincome = Convert.ToDouble(label3.Text.Replace(",", ""));
                            string sql = "insert into tb_sell(sell_id, user_id, sell_total_qty, sell_total_price, sell_date, rate_id)" +
                                " values (@sell_id,@em_id,@sell_totalqty,@sell_totalprice,getdate(), @rate_id)";
                            SqlCommand Comd = new SqlCommand(sql, con);
                            Comd.Parameters.AddWithValue("sell_id", sell_id);
                            Comd.Parameters.AddWithValue("em_id", fm_login.em_id);
                            Comd.Parameters.AddWithValue("rate_id", cer_id);
                            Comd.Parameters.AddWithValue("sell_totalqty", totalqty);
                            Comd.Parameters.AddWithValue("sell_totalprice", Convert.ToInt64(label13.Text));
                            //Comd.Parameters.AddWithValue("sell_status", "LAK");
                            Comd.ExecuteNonQuery();
                            con.Close();

                            for (int i = 0; i < sell.Pro_id.Count; i++)
                            {
                                con.Open();
                                sql = "insert into tb_selldetail (sell_id, pro_id, selld_qty, selld_price) values (@order_id,@pro_id,@qty,@price)";
                                Comd = new SqlCommand(sql, con);
                                Comd.Parameters.AddWithValue("order_id", sell_id);
                                Comd.Parameters.AddWithValue("pro_id", sell.Pro_id[i]);
                                Comd.Parameters.AddWithValue("qty", sell.Pro_qty[i]);
                                Comd.Parameters.AddWithValue("price", sell.Pro_price[i]);
                                Comd.ExecuteNonQuery();
                                con.Close();
                                con.Close();
                                int qty = 0;
                                con.Open();
                                sql = "select pro_qty from tb_product where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                SqlDataReader Myreader = Comd.ExecuteReader();
                                if (Myreader.Read())
                                {
                                    qty = Convert.ToInt32(Myreader["pro_qty"]);
                                }
                                con.Close();

                                con.Open();
                                sql = "update tb_product set pro_qty='" + (qty - Convert.ToInt32(sell.Pro_qty[i])) + "' where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                Comd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        sells.loadData();
                        sells.guna2DataGridView2.Rows.Clear();
                        MessageBox.Show("ບັນທຶກການສັ່ງຊື້ສຳເລັດແລ້ວ", "ສຳເລັດ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult DialogMessege = MessageBox.Show("ທ່ານຕ້ອງການໃບພີມບິນ ຫຼື ບໍ່ ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogMessege == DialogResult.OK)
                        {
                            bills bf = new bills();
                            sell sell = new sell();
                            sell.loadData();
                            sell_bill import_bill = new sell_bill();
                            bf.crystalReportViewer1.Refresh();
                            import_bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
                            import_bill.SetParameterValue("sell_id", sell_id);
                            import_bill.SetParameterValue("SUM_USD", (Convert.ToDouble(label13.Text) / Convert.ToDouble(usd)).ToString());
                            import_bill.SetParameterValue("SUM_THB", (Convert.ToDouble(label13.Text) / Convert.ToDouble(bath)).ToString());
                            bf.crystalReportViewer1.ReportSource = import_bill;
                            bf.crystalReportViewer1.Refresh();
                            bf.ShowDialog();
                        }
                        this.Close();

                    }
                }
                else if (guna2RadioButton2.Checked == true)
                {
                    if (guna2TextBox1.Text == "")
                    {

                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາ");

                    }
                    else if (Convert.ToInt64(guna2TextBox1.Text) < totalprice)
                    {
                        //WrongDialog alertMessage = new WrongDialog();
                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາໃຫ້ຖືກຕ້ອງ");

                    }
                    else
                    {
                        getcerid();
                        getsellid();
                        if (sell.Pro_id.Count != 0)
                        {
                            con.Open();
                            double totalqty = Convert.ToDouble(label1.Text.Replace(",", ""));
                            double totalprice = Convert.ToDouble(label2.Text.Replace(",", ""));
                            //double totalincome = Convert.ToDouble(label14.Text.Replace(",", ""));
                            string sql = "insert into tb_sell(sell_id, user_id, sell_total_qty, sell_total_price, sell_date, rate_id)" +
                                " values (@sell_id,@em_id,@sell_totalqty,@sell_totalprice,getdate(), @rate_id)";
                            SqlCommand Comd = new SqlCommand(sql, con);
                            Comd.Parameters.AddWithValue("sell_id", sell_id);
                            Comd.Parameters.AddWithValue("em_id", fm_login.em_id);
                            Comd.Parameters.AddWithValue("rate_id", cer_id);
                            Comd.Parameters.AddWithValue("sell_totalqty", totalqty);
                            Comd.Parameters.AddWithValue("sell_totalprice", Convert.ToInt64(label13.Text));
                            Comd.ExecuteNonQuery();
                            con.Close();

                            for (int i = 0; i < sell.Pro_id.Count; i++)
                            {
                                con.Open();
                                sql = "insert into tb_selldetail (sell_id, pro_id, selld_qty, selld_price) values (@order_id,@pro_id,@qty,@price)";
                                Comd = new SqlCommand(sql, con);
                                Comd.Parameters.AddWithValue("order_id", sell_id);
                                Comd.Parameters.AddWithValue("pro_id", sell.Pro_id[i]);
                                Comd.Parameters.AddWithValue("qty", sell.Pro_qty[i]);
                                Comd.Parameters.AddWithValue("price", sell.Pro_price[i]);
                                Comd.ExecuteNonQuery();
                                con.Close();
                                con.Close();
                                int qty = 0;
                                con.Open();
                                sql = "select pro_qty from tb_product where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                SqlDataReader Myreader = Comd.ExecuteReader();
                                if (Myreader.Read())
                                {
                                    qty = Convert.ToInt32(Myreader["pro_qty"]);
                                }
                                con.Close();

                                con.Open();
                                sql = "update tb_product set pro_qty='" + (qty - Convert.ToInt32(sell.Pro_qty[i])) + "' where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                Comd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        sells.loadData();
                        sells.guna2DataGridView2.Rows.Clear();
                        MessageBox.Show("ບັນທຶກການສັ່ງຊື້ສຳເລັດແລ້ວ", "ສຳເລັດ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult DialogMessege = MessageBox.Show("ທ່ານຕ້ອງການໃບພີມບິນ ຫຼື ບໍ່ ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogMessege == DialogResult.OK)
                        {
                            bills bf = new bills();
                            sell sell = new sell();
                            sell.loadData();
                            sell_bill import_bill = new sell_bill();
                            bf.crystalReportViewer1.Refresh();
                            import_bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
                            import_bill.SetParameterValue("sell_id", sell_id);
                            import_bill.SetParameterValue("SUM_USD", (Convert.ToDouble(label13.Text) / Convert.ToDouble(usd)).ToString());
                            import_bill.SetParameterValue("SUM_THB", (Convert.ToDouble(label13.Text) / Convert.ToDouble(bath)).ToString());
                            bf.crystalReportViewer1.ReportSource = import_bill;
                            bf.crystalReportViewer1.Refresh();
                            bf.ShowDialog();
                        }
                        this.Close();

                    }
                }
                else if (guna2RadioButton3.Checked == true)
                {
                    if (guna2TextBox1.Text == "")
                    {

                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາ");

                    }
                    else if (Convert.ToInt64(guna2TextBox1.Text) < totalprice)
                    {
                        //WrongDialog alertMessage = new WrongDialog();
                        WrongDialog.Show("ກະລຸນາປ້ອນລາຄາໃຫ້ຖືກຕ້ອງ");

                    }
                    else
                    {
                        getcerid();
                        getsellid();
                        if (sell.Pro_id.Count != 0)
                        {
                            con.Open();
                            double totalqty = Convert.ToDouble(label1.Text.Replace(",", ""));
                            double totalprice = Convert.ToDouble(label13.Text.Replace(",", ""));
                            //double totalincome = Convert.ToDouble(label2.Text.Replace(",", ""));
                            string sql = "insert into tb_sell(sell_id, user_id, sell_total_qty, sell_total_price, sell_date, rate_id)" +
                                " values (@sell_id,@em_id,@sell_totalqty,@sell_totalprice,getdate(), @rate_id)";
                            SqlCommand Comd = new SqlCommand(sql, con);
                            Comd.Parameters.AddWithValue("sell_id", sell_id);
                            Comd.Parameters.AddWithValue("em_id", fm_login.em_id);
                            Comd.Parameters.AddWithValue("rate_id", cer_id);
                            Comd.Parameters.AddWithValue("sell_totalqty", totalqty);
                            Comd.Parameters.AddWithValue("sell_totalprice", totalprice);
                            Comd.ExecuteNonQuery();
                            con.Close();

                            for (int i = 0; i < sell.Pro_id.Count; i++)
                            {
                                con.Open();
                                sql = "insert into tb_selldetail (sell_id, pro_id, selld_qty, selld_price) values (@order_id,@pro_id,@qty,@price)";
                                Comd = new SqlCommand(sql, con);
                                Comd.Parameters.AddWithValue("order_id", sell_id);
                                Comd.Parameters.AddWithValue("pro_id", sell.Pro_id[i]);
                                Comd.Parameters.AddWithValue("qty", sell.Pro_qty[i]);
                                Comd.Parameters.AddWithValue("price", sell.Pro_price[i]);
                                Comd.ExecuteNonQuery();
                                con.Close();
                                con.Close();
                                int qty = 0;
                                con.Open();
                                sql = "select pro_qty from tb_product where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                SqlDataReader Myreader = Comd.ExecuteReader();
                                if (Myreader.Read())
                                {
                                    qty = Convert.ToInt32(Myreader["pro_qty"]);
                                }
                                con.Close();

                                con.Open();
                                sql = "update tb_product set pro_qty='" + (qty - Convert.ToInt32(sell.Pro_qty[i])) + "' where pro_id='" + sell.Pro_id[i] + "'";
                                Comd = new SqlCommand(sql, con);
                                Comd.ExecuteNonQuery();
                                con.Close();
                            }
                        }
                        sells.loadData();
                        sells.guna2DataGridView2.Rows.Clear();
                        MessageBox.Show("ບັນທຶກການສັ່ງຊື້ສຳເລັດແລ້ວ", "ສຳເລັດ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult DialogMessege = MessageBox.Show("ທ່ານຕ້ອງການໃບພີມບິນ ຫຼື ບໍ່ ?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                        if (DialogMessege == DialogResult.OK)
                        {
                            bills bf = new bills();
                            sell sell = new sell();
                            sell.loadData();
                            sell_bill import_bill = new sell_bill();
                            bf.crystalReportViewer1.Refresh();
                            import_bill.SetDatabaseLogon("sa", "<Mylovefromthesky8553!>", "localhost,1433", "pos_db");
                            import_bill.SetParameterValue("sell_id", sell_id);
                            import_bill.SetParameterValue("SUM_USD", (Convert.ToDouble(label13.Text) / Convert.ToDouble(usd)).ToString());
                            import_bill.SetParameterValue("SUM_THB", (Convert.ToDouble(label13.Text) / Convert.ToDouble(bath)).ToString());
                            bf.crystalReportViewer1.ReportSource = import_bill;
                            bf.crystalReportViewer1.Refresh();
                            bf.ShowDialog();
                        }
                        this.Close();

                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }

        }

        private void guna2RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            label3.Text = "0";
            con.Open();
            string sql = "select max(rate_bath) from tb_rate where rate_status = 1";
            SqlCommand Comd = new SqlCommand(sql, con);
            Comd.CommandType = CommandType.Text;
            SqlDataReader Myreader = Comd.ExecuteReader();
            if (Myreader.HasRows)
            {
                while (Myreader.Read())
                {

                    bath = Convert.ToDouble(Myreader[0]);

                }
            }
            con.Close();

            totalprice = (Convert.ToDouble(label13.Text.Replace(",", "")) / bath);
            //label3.Text = Convert.ToDouble(totalprice).ToString();

            label2.Text = Convert.ToDouble(totalprice).ToString(".###");
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

            if (guna2RadioButton3.Checked == true)
            {
                con.Open();
                string sql = "select max(rate_dollar) from tb_rate where rate_status = 1";
                SqlCommand Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                SqlDataReader Myreader = Comd.ExecuteReader();
                if (Myreader.HasRows)
                {
                    while (Myreader.Read())
                    {

                        usd = Convert.ToDouble(Myreader[0]);

                    }
                }

                con.Close();
                if (guna2TextBox1.Text != "" && label3.Text != "")
                {

                    string totalprice = "";
                    totalprice = ((Convert.ToDouble(guna2TextBox1.Text) * usd) - Convert.ToDouble(label13.Text.Replace(",", ""))).ToString();
                    if (totalprice == "0")
                    {
                        label3.Text = "0";
                    }
                    else
                    {
                        label3.Text = Convert.ToDouble(totalprice).ToString();
                    }

                }
            }
            else if (guna2RadioButton2.Checked == true)
            {
                con.Open();
                string sql = "select max(rate_bath) from tb_rate where rate_status = 1";
                SqlCommand Comd = new SqlCommand(sql, con);
                Comd.CommandType = CommandType.Text;
                SqlDataReader Myreader = Comd.ExecuteReader();
                if (Myreader.HasRows)
                {
                    while (Myreader.Read())
                    {

                        bath = Convert.ToDouble(Myreader[0]);

                    }
                }

                con.Close();

                if (guna2TextBox1.Text != "" && label3.Text != "")
                {
                    string totalprice = "";
                    totalprice = ((Convert.ToDouble(guna2TextBox1.Text) * bath) - Convert.ToDouble(label13.Text.Replace(",", ""))).ToString();

                    if (totalprice == "0")
                    {
                        label3.Text = "0";
                    }
                    else
                    {
                        label3.Text = Convert.ToDouble(totalprice).ToString();
                    }

                }
            }
            else if (guna2RadioButton1.Checked == true)
            {
                if (guna2TextBox1.Text != "" && label3.Text != "")
                {
                    string totalprice = "";
                    totalprice = ((Convert.ToDouble(guna2TextBox1.Text)) - Convert.ToDouble(label13.Text.Replace(",", ""))).ToString();
                    if (totalprice == "0")
                    {
                        label3.Text = "0";
                    }
                    else
                    {
                        label3.Text = Convert.ToDouble(totalprice).ToString();
                    }
                }

            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void guna2RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            label3.Text = "0";
            con.Open();
            string sql = "select max(rate_dollar) from tb_rate where rate_status = 1";
            SqlCommand Comd = new SqlCommand(sql, con);
            Comd.CommandType = CommandType.Text;
            SqlDataReader Myreader = Comd.ExecuteReader();
            if (Myreader.HasRows)
            {
                while (Myreader.Read())
                {

                    usd = Convert.ToDouble(Myreader[0]);

                }
            }
            con.Close();

            totalprice = (Convert.ToDouble(label13.Text.Replace(",", "")) / usd);

            label2.Text = Convert.ToDouble(totalprice).ToString(".###");
        }

        private void guna2RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            guna2TextBox1.Text = "";
            label3.Text = "0";
            label2.Text = Convert.ToDouble(label13.Text.Replace(",", "")).ToString();
        }
    }
}
