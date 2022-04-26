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
    public partial class GoodSellInfo : Form
    {
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public GoodSellInfo()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void GoodSellInfo_Load(object sender, EventArgs e)
        {
            gb_sell_info.Text += goods.goodName;
            String q = "select sells.order_id as [الفاتورة]  , amount as [الكمية] , sell_price as [السعر] , name as [اســم العمـيل] from Sells join orders on orders.order_id = Sells.order_id  join users on userId = users.Id where good_id = @ID";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand cmd = new SQLiteCommand(q, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@ID", goods.goodslistSelectedValue);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dgv_sell_info.DataSource = goods_info;

            }
        }

    }
}
