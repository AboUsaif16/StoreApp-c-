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
    public partial class report : Form
    {
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public report()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            get_income();
            sqlcmd("select COUNT(name) as num from goods where amount != 0", prd_av);
            prd_av.Text += " صنف";
            sqlcmd("select COUNT(name) as num from goods where amount = 0", prd_not_av);
            prd_not_av.Text += " صنف";
            sqlcmd("select COUNT(name) as num from users", users_av);
            users_av.Text += " عميل";
            sqlcmd("select COUNT(v_name) as num from vendors", vend_av);
            vend_av.Text += " مورد";
            sqlcmd("select sum(mony) as num from users", needs_users_av);
            needs_users_av.Text += " جنيه";
            sqlcmd("select sum(v_money) as num from vendors", needs_vend_av);
            needs_vend_av.Text += " جنيه";
            outcome();
            outcome_year();
        }
        private void sqlcmd(string sql, Label o)
        {

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                o.Text = rows[0]["num"].ToString();

            }
        }


        void get_income()
        {
            string sql_quary = @"select strftime('%m', date) as [الشهر] , sum(payment) as [الإيرادات] , cast(sum(payment)/30 as int) as [المعدل اليومى]
                             from logs_info where strftime('%Y', date) like strftime('%Y', 'now') group by strftime('%m', date) ";

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql_quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {

                DataTable info = new DataTable();
                adapter.Fill(info);

                incomeTable.DataSource = info;
 


            }
        }
        private void outcome()
        {
            string sql_quary = "select sum(v_payment) as paid from v_logs where strftime('%m', v_date) like strftime('%m', 'now') and strftime('%Y', v_date) like strftime('%Y', 'now')";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql_quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {

                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["paid"].ToString() == "")
                {
                    v_paid.Text = "صفر جنية ";
                }
                else
                {
                    v_paid.Text = rows[0]["paid"].ToString() + " " + "جنية "; 
                }
            }
        }
        private void outcome_year()
        {
            string sql_quary = "select sum(v_payment) as paid from v_logs where strftime('%Y', v_date) like strftime('%Y', 'now')";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql_quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {

                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["paid"].ToString() == "")
                {
                    v_paid_year.Text = "صفر جنية ";
                }
                else
                {
                    v_paid_year.Text = rows[0]["paid"].ToString() + " " + "جنية ";
                }
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            notAvGoods needs = new notAvGoods();
            needs.ShowDialog(this);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            UsersLateToPay u = new UsersLateToPay();
            u.ShowDialog(this);
        }
    }
}
