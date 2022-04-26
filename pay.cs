using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SQLite;

namespace allN1
{
    public partial class pay : Form

    {
        string filename;
        public static string nameSelected = "";
        public static string idSelected = "";
        float remain;
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public pay()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtuer_payout.Text = "";remain_t.Text = "";
            
            if (main.is_vendor)
            {
               
                info_v();
            }
            else
            {
                info_u();
            }
            //txtuer_payout.Focus();
        }

        private void Pay_Load(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.FromCulture(new System.Globalization.CultureInfo("ar-EG"));
            if (main.is_vendor)
            {

                Viewvendors();
            }
            else
            {

                Viewusers();
                txtuer_search.Text = users.userName;
            }
        }
        private void Viewusers()
        {
            String quary = "select mony,name,Id from users order by name";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                userslist.DisplayMember = "name";
                userslist.ValueMember = "id";
                userslist.DataSource = goods_info;
                goods_info.ToCSV(Application.StartupPath + "/BackUp/users.txt");
            }

        }
        private void Viewvendors()
        {
            String quary = "select v_money,v_name,vendor_id from vendors order by v_name";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                userslist.DisplayMember = "v_name";
                userslist.ValueMember = "vendor_id";
                userslist.DataSource = goods_info;
                goods_info.ToCSV(Application.StartupPath + "/BackUp/vendors.txt");

            }

        }
        private void info_u()
        {
            String quary = String.Concat("select *  from users where id = ", userslist.SelectedValue);
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                info_GB.Text = "بيانات : " + rows[0]["name"].ToString();
                money.Text = rows[0]["mony"].ToString();
                nameSelected = rows[0]["name"].ToString();
                idSelected = rows[0]["Id"].ToString();

            }
        }

        private void info_v()
        {
            String quary = String.Concat("select *  from vendors where vendor_id = ", userslist.SelectedValue);
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                info_GB.Text = "بيانات : " + rows[0]["v_name"].ToString();
                money.Text = rows[0]["v_money"].ToString();
                nameSelected = rows[0]["v_name"].ToString();
                idSelected = rows[0]["vendor_id"].ToString();
            }
        }

        private void userByName()
        {
            try
            {
                String quary = String.Concat("select Id,name  from users where name like @name");
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@name", "%" + txtuer_search.Text + "%");
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    
                    userslist.DisplayMember = "name";
                    userslist.ValueMember = "id";
                    userslist.DataSource = goods_info;
                }
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }
        private void VendByName()
        {
            try
            {
                String quary = String.Concat("select vendor_id,v_name from vendors where v_name like @name");
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    command.Parameters.AddWithValue("@name", "%" + txtuer_search.Text + "%");
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    
                    userslist.DisplayMember = "v_name";
                    userslist.ValueMember = "vendor_id";
                    userslist.DataSource = goods_info;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Txtuer_search_TextChanged(object sender, EventArgs e)
        {
            if (main.is_vendor)
            {
               
                VendByName();
            }
            else
            {
                
                userByName();
            }
            
        }

        private void TextBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtuer_payout.Text != "")
                {
                    if (float.Parse(txtuer_payout.Text) <= float.Parse(money.Text))
                    {
                        remain = float.Parse(money.Text) - float.Parse(txtuer_payout.Text);
                        remain_t.Text = remain.ToString();
                        btn_pay.Enabled = true;
                    }
                    else
                    {
                        txtuer_payout.Text = "0";
                        btn_pay.Enabled = false;
                        txtuer_payout.SelectAll();
                    }


                }
                else
                {
                    remain_t.Text = money.Text;
                    btn_pay.Enabled = false;
                }
            }
            catch
            {
                txtuer_payout.Text = "0";
                txtuer_payout.SelectAll();
            }

        }

        private async Task do_pay_u_Async()
        {
            
            String quary = String.Concat("update logs set total =@remain  where user_Id = ", int.Parse(idSelected), ";insert into logs_info (user_id,payment,date) VALUES (@user_Id , @payment , @date)", ";update users set mony = @remain  , lastPayment = @date where Id = ", int.Parse(idSelected));

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))

            {
                connection.Open();
                command.Parameters.AddWithValue("@remain", remain);
                command.Parameters.AddWithValue("@user_Id", int.Parse(idSelected));
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@payment", float.Parse(txtuer_payout.Text));


                command.ExecuteNonQuery();
            }
            

            status.Text = " تم دفع القسط بنجاح ";


            if (MessageBox.Show("هل تريد طباعة إيصال الدفع؟", "طباعة", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                time_now.Text = "جارى إنشاء الإيصال";
                string name_of_payment = "/payments/" + today.ToString("dd-MM-yyyy") + "/" + nameSelected + ".docx";
                filename = Application.StartupPath + "/payments/" + today.ToString("dd-MM-yyyy");
                // Specify the directory you want to manipulate.
                string path = Application.StartupPath + "/payments/" + today.ToString("dd-MM-yyyy");
                try
                {
                    // Determine whether the directory exists.
                    if (!Directory.Exists(path))
                    {
                        DirectoryInfo di = Directory.CreateDirectory(path);
                    }
                }
                catch (Exception e)
                {
                    time_now.ForeColor = Color.FromArgb(240, 240, 51);
                    time_now.Text = e.ToString();
                }
                
                printReport.print(Application.StartupPath + "/payment.docx", Application.StartupPath + name_of_payment, today.ToString("dd-MM-yyyy"), txtuer_payout.Text, nameSelected, remain.ToString());
                if (File.Exists(Application.StartupPath + "\\123.txt"))
                {
                    if (MessageBox.Show("هل تريد الطباعه بطريقة اخرى؟؟", "طباعة", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        using (PrintDialog pd = new PrintDialog())
                        {
                            pd.ShowDialog();
                            ProcessStartInfo info = new ProcessStartInfo(Application.StartupPath + "\\temp.docx");
                            info.Verb = "PrintTo";
                            info.Arguments = pd.PrinterSettings.PrinterName;
                            info.CreateNoWindow = true;
                            info.WindowStyle = ProcessWindowStyle.Hidden;
                            Process.Start(info);
                        }
                    }
                }

            }
            int s = userslist.SelectedIndex;
            // Viewusers();
            userslist.SetSelected(s, true);
            txtuer_payout.Text = "";
            remain_t.Text = "";
            remain = 0;
            txtuer_search.Text = "";
            txtuer_search.Enabled = true;
            int milliseconds = 1000;
            await Task.Delay(milliseconds);
            status.Text = "الحالة : متصل";
           
        }
        private async Task do_pay_v_Async()
        {
            String quary = String.Concat("insert into v_logs (vendor_id,v_payment,v_date) VALUES (@user_Id , @payment , @date)", ";update vendors set v_money = @remain  where vendor_id = ", idSelected);
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))

            {
                connection.Open();
                command.Parameters.AddWithValue("@remain", remain);
                command.Parameters.AddWithValue("@user_Id", int.Parse(idSelected));
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@payment", float.Parse(txtuer_payout.Text));
                command.ExecuteNonQuery();
            }
            int s = userslist.SelectedIndex;
            //Viewvendors();

            userslist.SetSelected(s, true); ;


            status.Text = " تم دفع القسط بنجاح ";

            txtuer_payout.Text = "";
            remain_t.Text = "";
            remain = 0;
            txtuer_search.Text = "";
            int milliseconds = 3000;
            await Task.Delay(milliseconds);
            status.Text = "الحالة : متصل";
            
        }

        private void Btn_pay_Click(object sender, EventArgs e)
        {
            
            if (main.is_vendor)
            {
                _=do_pay_v_Async();
                
            }
            else
            {
               _= do_pay_u_Async();
                
            }

        }

        private void Txtuer_payout_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void Txtuer_payout_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if(main.is_vendor)
            {
                    _ = do_pay_v_Async();
                }
            else
                {
                    _ = do_pay_u_Async();
                }
            }
        }
    }
}
