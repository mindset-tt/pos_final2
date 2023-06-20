using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
//using Guna.UI2.WinForms;

namespace fanail
{
    internal class model
    {
        public SqlConnection con = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet dataSet = new DataSet();
        SqlDataReader dr;
        string connectionString;
        public bool connection = false;
        public void switchForm(Form form, Panel panel)
        {
            form.TopLevel = false;
            panel.Controls.Clear();
            panel.Controls.Add(form);
            form.Dock = DockStyle.Fill;
            form.BringToFront();
            form.Show();
        }
        public model()
        {
            Initilize();
        }
        private void Initilize()
        {
            connectionString = @"Server=localhost,1433;Database=pos_db;User ID=sa;Password=<Mylovefromthesky8553!>;MultipleActiveResultSets=False;TrustServerCertificate=True;";

            con = new SqlConnection(connectionString);
        }
        public void ShowDataToGridView(String sql, DataGridView dataGrid)
        {
            OpenConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataSet, "table");
                if (dataSet.Tables["table"].Rows.Count > 0)
                {
                    dataSet.Tables["table"].Clear();
                }
                adapter.Fill(dataSet, "table");
                dataGrid.DataSource = dataSet.Tables["table"];
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        
        public void showdata(String sql1, DataGridView dataGrid)
        {
            OpenConnection();
            try
            {
               
                SqlCommand cmd = new SqlCommand(sql1, con);
                SqlDataReader Myreader = cmd.ExecuteReader();
                DataTable mytabel = new DataTable();
                mytabel.Load(Myreader);
                dataGrid.DataSource = mytabel;
                
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public bool OpenConnection()
        {
            try
            {
                con.Close();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    connection = true;
                }
                else
                {
                    con.Close();
                }

                return true;
            }
            catch (SqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        WrongDialog.Show("ບໍ່ສາມາດເຊື່ອມຕໍ່ກັບ Sever ກະລຸນາຕິດຕໍ່ຫາ ແອັດມິນ");
                        break;

                    case 1045:
                        WrongDialog.Show("ຊື່ຜູ້ໃຊ້ ຫຼື ລະຫັດຜ່ານ ບໍ່ຖຶກຕ້ອງ ກະລຸນາລອງໃໝ່ອີກຄັ້ງ");
                        break;
                }

                return false;

            }
        }
        public static String ID;
        public void GetQty(String sql, string qty)
        {
            OpenConnection();
            {
                try
                {
                    cmd = new SqlCommand(sql, con);
                    dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            qty = dr[0].ToString();
                        }
                        if (String.IsNullOrEmpty(qty))
                        {
                            qty = "1";
                        }
                    }
                    else
                    {
                        qty = "1";
                        return;
                    }
                }
                catch (Exception ex)
                {
                    WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
                }
            }
        }
        public void Generate_ID(String sql)
        {
            OpenConnection();
            try
            {
                cmd = new SqlCommand(sql, con);
                dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {

                    while (dr.Read())
                    {
                        ID = dr[0].ToString();
                    }
                    if (String.IsNullOrEmpty(ID))
                    {
                        ID = "1";
                    }
                }
                else
                {
                    ID = "1";
                    return;
                }
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
       
        public void LoadDataToCombobox(string sql, ComboBox comboBox, string id, string name)
        {
            OpenConnection();
            try
            {
                adapter = new SqlDataAdapter(sql, con);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataSet.Tables[0].Clear();
                DataRow row = dataSet.Tables[0].NewRow();
                row[id] = -1;
                row[name] = "ກະລຸນາເລືອກ";
                dataSet.Tables[0].Rows.Add(row);
                adapter.Fill(dataSet);
                comboBox.DataSource = dataSet.Tables[0];
                comboBox.DisplayMember = name;
                comboBox.ValueMember = id;
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public void LoadDataToCombobox1(string sql, ComboBox comboBox, string id, string name)
        {
            OpenConnection();
            try
            {
                adapter = new SqlDataAdapter(sql, con);
                dataSet = new DataSet();
                adapter.Fill(dataSet);
                dataSet.Tables[0].Clear();
                DataRow row = dataSet.Tables[0].NewRow();
                row[id] = -1;
                row[name] = "ກະລຸນາເລືອກ";
                dataSet.Tables[0].Rows.Add(row);
                adapter.Fill(dataSet);
                comboBox.DataSource = dataSet.Tables[0];
                comboBox.DisplayMember = name;
                comboBox.ValueMember = id;
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public string count;
        public void GetCount(string sql, string Count)
        {
            OpenConnection();
            try
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader SqlDataReader = cmd.ExecuteReader();
                while (SqlDataReader.Read())
                {
                    count = SqlDataReader[Count].ToString();
                }
                con.Close();
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public bool b = true;
        public bool Get_ID(string sql)
        {
            OpenConnection();
            try
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        b = false;
                    }
                }
                con.Close();
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
            return b;
        }

        public void Search(DataGridView dataGrid, string sql, string search)
        {
            try
            {
                (dataGrid.DataSource as DataTable).DefaultView.RowFilter = string.Format(sql, search);
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public void SqlExecute(string sql)
        {
            OpenConnection();
            cmd = new SqlCommand(sql, con);
            try
            {
                con.Close();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public  List<String> Pro_ID = new List<String>();
        public List<String> Pro_Name = new List<String>();
        public List<String> Type_name = new List<String>();
        public List<String> Unit_Name = new List<String>();
        public List<String> Orderd_Qty = new List<String>();

        public void ShowProduct(string sql,string pro_id,string pro_name,string unit_name,string type_name,string orderd_qty)
        {
            OpenConnection();
            try
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand(sql, con);
                SqlDataReader SqlDataReader = cmd.ExecuteReader();
                while (SqlDataReader.Read())
                {
                    Pro_ID.Add(SqlDataReader[pro_id].ToString());
                    Pro_Name.Add(SqlDataReader[pro_name].ToString());
                    Type_name.Add(SqlDataReader[type_name].ToString());
                    Unit_Name.Add(SqlDataReader[unit_name].ToString());
                    Orderd_Qty.Add(SqlDataReader[orderd_qty].ToString());
                }
                con.Close();
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }
        public string bath, dollar, show_baht, show_dollar, rate_id;
        public void Show_rate()
        {
            OpenConnection();
            try
            {
                con.Close();
                con.Open();
                cmd = new SqlCommand("Select * from tb_rate where rate_status=1", con);
                SqlDataReader mySqlDataReader = cmd.ExecuteReader();
                if (mySqlDataReader.Read())
                {
                    if (mySqlDataReader.HasRows)
                    {
                        bath = mySqlDataReader["rate_bath"].ToString();
                        dollar = mySqlDataReader["rate_dollar"].ToString();
                        rate_id = mySqlDataReader["rate_id"].ToString();
                    }
                }
                show_baht = Convert.ToInt32(bath).ToString("#,###");
                show_dollar = Convert.ToInt32(dollar).ToString("#,###");
                con.Close();
            }
            catch (Exception ex)
            {
                WrongDialog.Show("ຂໍອະໄພເກີດຂໍ້ຜິດພາດເນື່ອງຈາກ " + ex.Message + " ກະລຸນາປິດໂປຣແກຣມແລ້ວລອງໃໝ່ອີກຄັ້ງ");
            }
        }

    }
}
