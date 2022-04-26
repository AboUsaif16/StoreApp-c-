using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace allN1
{
    public partial class notAvGoods : Form
    {
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public notAvGoods()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;

        }

        private void NotAvGoods_Load(object sender, EventArgs e)
        {
            Not_Avalable();
        }
        private void Not_Avalable()
        {
            String quary = "select name as [إسم الصنف الناقص] , sell_price as[سعر البيع] , buy_price as [سعر الشراء] from goods Where amount = 0 ";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);

                notAvTable.DataSource = goods_info;
            }
            

        }
    }
}
