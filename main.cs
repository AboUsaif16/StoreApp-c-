using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Drawing.Printing;
using System.Data.SQLite;

namespace allN1
{
    public partial class main : Form
    {
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection  connection;
        public static bool is_vendor = false;
        public static bool selected = false;
        public static bool fromGoods = true;
        public main()
        {
            InitializeComponent();
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                MessageBox.Show(this, "البرنامج يعمل بالفعل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            @lock lck = new @lock();
            lck.ShowDialog(this);
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ar-EG"));

            paymentsTable.DataSource = sqlcmd.paymnts(today);
            txtselected_date.Text = "التاريخ" + " : " + today.ToString("dd/MM/yyyy");
            //totalToday();
            txttotal_today.Text = sqlcmd.totalToday();




        }
        #region functions
        //public static void paymnts(DateTime date)
        //{
        //    string sql = "select users.name as [الإسم] ,payment as [المدفوع] from logs_info join users on logs_info.user_id = users.Id where (strftime('%d/%m/%Y',date) like @date)";
        //    using (connection = new SQLiteConnection(connectionString))
        //    using (SQLiteCommand command = new SQLiteCommand(sql, connection))
        //    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
        //    {
        //        // CONVERT (varchar(10), date, 103) as [الوقت ]
        //        command.Parameters.AddWithValue("@date", date.ToString("dd/MM/yyyy"));

        //        DataTable info = new DataTable();
        //        adapter.Fill(info);

        //        paymentsTable.DataSource = info;
        //        txtselected_date.Text = "التاريخ" + " : " + date.ToString("dd/MM/yyyy");


        //    }
        //}
        private async Task errAsync()
        {
            txttotal_today.ForeColor = Color.FromArgb(240, 240, 51);
            txttotal_today.Text = "حدث خطأ برجاء التأكد من صحه البيانات";
            int milliseconds = 3000;
            await Task.Delay(milliseconds);
            txttotal_today.Text = "الحالة : متصل";
            txttotal_today.ForeColor = Color.FromArgb(112, 34, 131);
        }
        private void save_users_data()
        {
            String quary = "select *  from users";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);
                bckup.DataSource = info;
                bckup.SaveExportedData(Application.StartupPath + "/BackUp/بيانات العملاء.txt");

            }
        }
        private void save_vendors_data()
        {
            String quary = "select *  from vendors";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);
                bckup.DataSource = info;
                bckup.SaveExportedData(Application.StartupPath + "/BackUp/بيانات الموردين.txt");

            }
        }
        private async Task BackupdatabaseAsync()
        {
            //DateTime t = DateTime.Now;
            Directory.CreateDirectory("BackUp");
            // string file = Application.StartupPath + "/BackUp/AppDB"+t.ToString("dd-MM")+".bak";
            string file = Application.StartupPath + "/BackUp/AppDB.bak";
            file = file.Replace('\\', '/');
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(file))
            {
                
                txttotal_today.Text = "تم تحديث قاعدة البيانات";
                int milliseconds = 200;
                await Task.Delay(milliseconds);
                File.Delete(file);
            }
            String quary = "BACKUP DATABASE AppDB TO DISK = @dir";
            try
            {
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@dir", file);
                    command.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (Exception e)
            {
                
                txttotal_today.Text = "حدث خطأ : لم يتم تحديث قاعدة البيانات";
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                string fileName = Application.StartupPath + "/error.txt";

                try
                {
                    // Check if file already exists. If yes, delete it.     
                    if (File.Exists(fileName))
                    {
                        File.Delete(fileName);
                    }

                    // Create a new file     
                    using (FileStream fs = File.Create(fileName))
                    {
                        // Add some text to file    
                        Byte[] title = new UTF8Encoding(true).GetBytes(e.ToString());
                        fs.Write(title, 0, title.Length);
                    }


                }
                catch (Exception)
                {
                    
                    txttotal_today.Text = "حدث خطأ : يجب التواصل مع المهندس فورا";
                    await Task.Delay(milliseconds);
                    this.Close();
                }

            }
        }
        #endregion

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                paymentsTable.DataSource = sqlcmd.paymnts(dateTimePicker1.Value);
                txtselected_date.Text = "التاريخ" + " : " + dateTimePicker1.Value.ToString("dd/MM/yyyy");
            }
            catch
            {
                _ = errAsync();
            }
        }

        private void خروجToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            save_users_data();
            save_vendors_data();
            //_ = BackupdatabaseAsync();
            this.Close();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            vendorOruser v = new vendorOruser();
            v.ShowDialog(this);
            if (selected)
            {
                selected = false;
                pay payForm = new pay();
                payForm.ShowDialog(this);
            }
            paymentsTable.DataSource = sqlcmd.paymnts(today);
            txtselected_date.Text = "التاريخ" + " : " + today.ToString("dd/MM/yyyy");

            //totalToday();
            txttotal_today.Text = sqlcmd.totalToday();
            this.Show();



        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            @lock lck = new @lock();
            lck.ShowDialog(this);
            this.Show();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            save_users_data();
            save_vendors_data();
            //_ = BackupdatabaseAsync();
            this.Close();
        }

        private void totalToday()
        {
            
            string sql = @"
                            select 
                            (select sum(payment) as s 
                            from logs_info
                            where month(date) like month(GETDATE()) and YEAR(date) like YEAR(GETDATE())) as mounth,
                            (select sum(v_payment) as s  from v_logs where month(v_date) like month(GETDATE()) and YEAR(v_date) like YEAR(GETDATE())) as mm,
                            (select sum(payment) as t 
                            from logs_info  
                            where (strftime('%d/%m/%Y',date) like (CONVERT(VARCHAR(10),GETDATE(),103)))) as day
                            ";

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["day"].ToString() == "")
                {
                    txttotal_today.Text = "صفر جنية ";
                }
                else
                {
                    txttotal_today.Text = "إجمالى دخل اليوم : "+rows[0]["day"].ToString() + " " + "جنية ";
                    
                }
                

            }
            //income(today);


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            report rep = new report();
            rep.ShowDialog(this);
            this.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            goods g = new goods();
            g.ShowDialog(this);
            this.Show();
        }

        private void Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            users u = new users();
            u.ShowDialog(this);
            this.Show();
            paymentsTable.DataSource = sqlcmd.paymnts(today);
            txtselected_date.Text = "التاريخ" + " : " + today.ToString("dd/MM/yyyy");

            // totalToday();
            txttotal_today.Text = sqlcmd.totalToday();
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void GroupBox25_Enter(object sender, EventArgs e)
        {

        }
    }
}
