using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Windows.Forms;
using System.Data.SQLite;

namespace allN1
{
    class sqlcmd
    {
        public static SQLiteConnection cnn;
        //public static SQLiteConnection cnnlite;
        //public static string connectionStringlie = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        public static string connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        public static DataTable loadData(string sql )
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
               
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        public static DataTable searchbyName(string sql,TextBox txt)
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {

                command.Parameters.AddWithValue("@name", "%" + txt.Text + "%");
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
                
            
        }


        public static DataTable paymnts(DateTime date)
        {
            string sql = "select users.name as [الإسم] ,payment as [المدفوع] from logs_info join users on logs_info.user_id = users.Id where strftime('%d/%m/%Y',date) like @date";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                command.Parameters.AddWithValue("@date", date.ToString("dd/MM/yyyy"));

                DataTable info = new DataTable();
                adapter.Fill(info);

                return info;


            }
        }
            public static int addNewRecord(string sql, List<string> varList, List<string> textBox)
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            {
                cnn.Open();
                for (int i = 0; i < varList.Count; i++)
                {
                    command.Parameters.AddWithValue(varList[i], textBox[i]);
                }

                return command.ExecuteNonQuery();
            }

        }
        public static int updateRecord(string sql, List<string> varList, List<string> textBox)
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            {
                cnn.Open();
                for (int i = 0; i < varList.Count; i++)
                {
                    command.Parameters.AddWithValue(varList[i], textBox[i]);
                }

                return command.ExecuteNonQuery();
            }

        }
        public static int execute(string sql)
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            {
                cnn.Open();
                return command.ExecuteNonQuery();
            }

        }


        public static void AutoComplete(TextBox t, string s)
        {
            using (SQLiteConnection con = new SQLiteConnection(connectionString: connectionString))
            {
                SQLiteCommand cmd = new SQLiteCommand(s, con);
                con.Open();
                SQLiteDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                t.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }
        public static void clean()
        {
            String quary = "delete from  orders where total_price IS NULL ; ";

            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            {
                cnn.Open();
                command.ExecuteNonQuery();
            }


        }
        public static void DeleteOrder(int order_id , int [] good_id  , int [] good_ammount , int pt = 1)
        {

            string sql = "delete from Sells where order_id=@order_id";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
            {
                cnn.Open();
                command.Parameters.AddWithValue("@order_Id", order_id);

                command.ExecuteNonQuery();
            }
            for (int i = 0; i < pt; i++)
            {
                string q = " update goods set  amount = amount +@back_amount where Id = @good_id";
                using (cnn = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(q, cnn))
                {
                    cnn.Open();
                    command.Parameters.AddWithValue("@good_id", good_id[i]);
                    command.Parameters.AddWithValue("@back_amount", good_ammount[i]);
                    command.ExecuteNonQuery();
                }
            }
            clean();
            
        }

        public static void sellGood(int order_id , int good_id,decimal price , int amount , decimal total)
        {
            String quary = "insert into Sells (order_id,good_id,amount,total_price,sell_price) VALUES (@order_id , @goodId , @amount,@total_price,@sell_price);update goods set amount = amount- @amount where Id = @goodId";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            {
                cnn.Open();
                command.Parameters.AddWithValue("@order_id", order_id);
                command.Parameters.AddWithValue("@goodId", good_id);
                command.Parameters.AddWithValue("@sell_price", price);
                command.Parameters.AddWithValue("@amount", amount);
                command.Parameters.AddWithValue("@total_price", total);
                command.ExecuteNonQuery();
            }
        }
        public static bool AddOrder(decimal total, decimal money, int order_id, int userId)
        {
            String quary = "update orders set total_price = @allTotal where order_id = @order_Id; update users set mony = mony + @money where Id = @userId";
            if (total == 0)
            {
                MessageBox.Show("عفوا لايوجد بيانات فى هذة الفاتورة\nبرجاء التأكد من إدخال صنف واحد على الأقل", "خطأ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                using (cnn = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
                {
                    cnn.Open();
                    command.Parameters.AddWithValue("@allTotal", total);
                    command.Parameters.AddWithValue("@money", money);
                    command.Parameters.AddWithValue("@order_Id", order_id);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
                chk(userId);
                return true;

            }
        }
        public static void chk(int userId)
        {
            String quary = String.Concat("insert into logs (user_Id , total) select userId ,sum( total_price) from orders where orders.userId =", userId, " group by userId");
            try
            {
                using (cnn = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
                {
                    cnn.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                String sql = String.Concat("update  logs set total =  (select sum(total_price) from orders where orders.userId = ", userId, "  group by userId) where user_Id = ", userId);
                using (cnn = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
                {
                    cnn.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
        public static void rowData(string quary, List<string> param, List<TextBox> txtBox)
        {
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                DataRow[] rows = dt.Select();
                for (int i = 0; i < param.Count; i++)
                {
                    txtBox[i].Text = rows[0][param[i]].ToString();
                }

            }
        }
        public static int getbillid()
        {
            int billId = 0;
            string sql = "SELECT * FROM orders ORDER BY order_id DESC limit 1";
            using (cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, cnn))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        billId =  int.Parse(reader["order_id"].ToString());
                    }
                    reader.Close();
                }
            }
            return billId+1;

        }

        public static int newOrder(int userId)
        {
            DateTime today = DateTime.Now;
            int order_id= 0;
            String quary = "insert into orders (userId,total_price,date) VALUES (@userId,null,@today)";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            {
                cnn.Open();

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@today", today);
                command.ExecuteNonQuery();
            }
            string sql = "SELECT * FROM orders ORDER BY order_id DESC LIMIT 1";
            using (cnn = new SQLiteConnection(connectionString))
            {
                cnn.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, cnn))

                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                 while (reader.Read())
                    {

                        order_id = int.Parse(reader["order_id"].ToString());
                    }
                    reader.Close();
                }
               
                }
            return order_id;
            }
        public static void updateOrderUserId(int userId, int orderId)
        {

            String quary = "update orders set userId = @userId where order_id = @orderid";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            {
                cnn.Open();

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@orderid", orderId);
                command.ExecuteNonQuery();
            }
            
        }
        public static DataTable kindList()
        {
            String quary = "select kind from goods group by kind";
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable kinds = new DataTable();
                adapter.Fill(kinds);
                return kinds;
            }
        }
        public static DataTable typeList(string kind)
        {
            String quary = String.Concat("select type from goods where kind = '", kind, "' group by type");
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable types = new DataTable();
                adapter.Fill(types);
                return types;
            }
        }
        public static DataTable goodList(string kind , string type)
        {
            String quary = String.Concat("select id as [#] ,name as [الإسم] , sell_price as [سعر البيع]  from goods where amount > 0 and type = '", type, "'", "and kind = '", kind, "'");
            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods = new DataTable();
                adapter.Fill(goods);
                return goods;
            }
        }
        public static string totalToday()
        {

            string sqli = @"SELECT
                            (SELECT sum (payment) as s FROM logs_info WHERE strftime('%m', date) like strftime('%m','now') and strftime('%Y', date) like strftime('%Y','now')) as mounth,
                            (select sum(v_payment) as ss  from v_logs where strftime('%m', v_date) like strftime('%m','now') and strftime('%Y', v_date) like strftime('%Y','now') 
                            )as mm,
                            (select sum(payment)) as day from logs_info  where strftime('%d/%m/%Y',date) like strftime('%d/%m/%Y','now') ;
                            ";

            using (cnn = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sqli, cnn))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["day"].ToString() == "")
                {
                     return "صفر جنية ";
                }
                else
                {
                    return "إجمالى دخل اليوم : " + rows[0]["day"].ToString() + " " + "جنية ";

                }


            }


        }

    }

    }

