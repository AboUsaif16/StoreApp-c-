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
    public partial class UsersLateToPay : Form
    {
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public UsersLateToPay()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void UsersLateToPay_Load(object sender, EventArgs e)
        {
            lastpay();
        }
        private void lastpay()
        {
            var d = today.ToString("dd/MM/yyyy");
            int m = int.Parse(d.Split('/')[1]);
            String quary = "select name as [إسم العميل] ,mony as [المتبقى عليه] ,lastPayment as [أخر عملية دفع],payment as [المطلوب] from users join logs_info on users.id = user_id where strftime('%m',lastPayment) < @month and mony > 0 and strftime('%Y/%m/%d',lastPayment)like strftime('%Y/%m/%d',date) order by lastPayment; ";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                command.Parameters.AddWithValue("@month", m.ToString());
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);

                usersWanted.DataSource = goods_info;
            }
            groupBox21.Text = "العملاء المطلوبين : " + usersWanted.Rows.Count.ToString();
        }
    }
}
