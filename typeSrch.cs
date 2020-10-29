using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace allN1
{
    public partial class typeSrch : Form
    {
        readonly string connectionString;
        SqlConnection connection;
        bool flag = false;
        public typeSrch()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }



        private void TypeSrch_Load(object sender, EventArgs e)
        {
            String quary = "select kind from goods group by kind";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                kindList.DisplayMember = "kind";
                kindList.ValueMember = "kind";
                kindList.DataSource = goods_info;
            }
        }
        


        private void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (flag)
            {
                String quary = String.Concat("select name as [إسم الصنف] , sell_price as [سعر البيع] , buy_price as [سعر الشراء] , amount as [الكمية] from goods where type = N'", typeList.SelectedValue.ToString(), "'", "and kind = N'", kindList.SelectedValue.ToString(), "'");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    dataGridView.DataSource = goods_info;
                }
            }
        }

        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void KindList_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quary = String.Concat("select type from goods where kind = N'", kindList.SelectedValue.ToString(), "' group by type");
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable good_info = new DataTable();
                adapter.Fill(good_info);

                typeList.DataSource = good_info;
                typeList.DisplayMember = "type";
                typeList.ValueMember = "type";


            }
            flag = true;
        }

        private void Txtbx_search_TextChanged(object sender, EventArgs e)
        {
            try
            {

            
            String quary = String.Concat("select top 20 name as [إســم الصـــــــنف] , sell_price as [سعر البيع] , buy_price as [سعر الشراء] , amount as [الكمية] from goods where name like N'", "%", txtbx_search.Text, "%' order by name ");
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView.DataSource = goods_info;
            }
            }
            catch
            {

            }
        }

        private void DataGridView_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
