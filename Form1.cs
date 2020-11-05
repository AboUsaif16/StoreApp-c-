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
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Diagnostics;


using System.Drawing.Printing;

namespace allN1
{
    public partial class Form1 : Form
    {

        bool sell_info = false;
        float remain;
        float remain_v;
        int inc = 0;
        public static string usernameSelected = "";
        public static string useridSelected = "";
        public static string vendornameSelected = "";
        public static string vendoridSelected = "";
        string filename;
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SqlConnection connection;

        public string ConnectionString => connectionString;

        public Form1()
        {
            InitializeComponent();
            String thisprocessname = Process.GetCurrentProcess().ProcessName;

            if (Process.GetProcesses().Count(p => p.ProcessName == thisprocessname) > 1)
            {
                MessageBox.Show(this, "البرنامج يعمل بالفعل", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.Close();
            }
                


            time_now.ForeColor = Color.FromArgb(240,240,51);
            time_now.Text = "يتم تحميل الأن بيانات البرنامج";
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT name FROM users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                txtuser_new.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT address FROM users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                txtuser_add_new.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            @lock lck = new @lock();
            lck.ShowDialog(this);
            var d = today.ToString("dd/MM/yyyy");

            //groupBox28.Text = "إجمالى دخل يوم" + " " + today.ToString("dd/MM/yyyy");
            update_info();
            Viewgoods();
            AutoComplete(txtType_new, "SELECT type FROM goods");
            AutoComplete(txtproduct_new, "SELECT name FROM goods");
            Viewusers();
            Viewvendors();
            time_now.Text = "الحالة : متصل";
            time_now.ForeColor = Color.White;
        }

        private void update_info()
        {
            paymnts(today);
            totalToday(today);
            totalToday0(today);
            Not_Avalable();
            lastpay();
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
            
        }
        private void lastpay()
        {
            String quary = "select name as [إسم العميل] ,mony as [المتبقى عليه] ,lastPayment as [أخر عملية دفع] from users where MONTH(lastPayment) < 10 and mony > 0 order by lastPayment; ";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);

                usersWanted.DataSource = goods_info;
            }
             groupBox21.Text = "العملاء المطلوبين : "+ usersWanted.Rows.Count.ToString();
        }


        #region main
        private async Task errAsync()
        {
            time_now.ForeColor = Color.FromArgb(240,240,51);
            time_now.Text = "حدث خطأ برجاء التأكد من صحه البيانات";
            int milliseconds = 3000;
            await Task.Delay(milliseconds);
            time_now.Text = "الحالة : متصل";
            time_now.ForeColor = Color.White;
        }
        private void PictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        private void paymnts(DateTime date)
        {
            string sql = "select users.name as [الإسم] ,payment as [المدفوع] from logs_info join users on logs_info.user_id = users.Id where (CONVERT(VARCHAR(10),date , 103) like @date)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // CONVERT (varchar(10), date, 103) as [الوقت ]
                command.Parameters.AddWithValue("@date", date.ToString("dd/MM/yyyy"));

                DataTable info = new DataTable();
                adapter.Fill(info);

                paymentsTable.DataSource = info;
                txtselected_date.Text = "التاريخ" + " : " + date.ToString("dd/MM/yyyy");


            }
        }
        private void totalToday(DateTime date)
        {
            int mm = 0; int m = 0;

            var d = today.ToString("dd/MM/yyyy");
            string sql = "select sum(payment) as t from logs_info  where (CONVERT(VARCHAR(10),date , 103) like @date)";
            sql = @"
                select 
                    (select sum(payment) as s 
                        from logs_info
                        where month(date) like @mounth and YEAR(date) like @year) as mounth,
(select sum(v_payment) as s  from v_logs where month(v_date) like @mounth and YEAR(v_date) like @year) as mm,
                    (select sum(payment) as t 
                        from logs_info  
                        where (CONVERT(VARCHAR(10),date , 103) like @date)) as day";

                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    // CONVERT (varchar(10), date, 103) as [الوقت ]
                    command.Parameters.AddWithValue("@date", date.ToString("dd/MM/yyyy"));
                    command.Parameters.AddWithValue("@year", d.Split('/')[2]);
                    command.Parameters.AddWithValue("@mounth", d.Split('/')[1]);
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    DataRow[] rows = goods_info.Select();
                    if (rows[0]["day"].ToString() == "")
                    {
                        txttotal_today.Text = "صفر جنية ";
                    }
                    else
                    {
                        txttotal_today.Text = rows[0]["day"].ToString() + " " + "جنية ";
                        inc = int.Parse(rows[0]["day"].ToString());
                    }
                    ////////////////////////////////////////////
                    if (rows[0]["mounth"].ToString() == "")
                    {
                        txttotal_mounth.Text = "صفر جنية ";
                        mm = 0;
                    }
                    else
                    {
                        txttotal_mounth.Text = rows[0]["mounth"].ToString() + " " + "جنية ";
                        mm = int.Parse(rows[0]["mounth"].ToString());


                    }
                    //////////////////////////////////////////
                    if (rows[0]["mm"].ToString() == "")
                    {
                        txttotal_mm.Text = "صفر جنية ";
                        m = 0;
                    }
                    else
                    {
                        txttotal_mm.Text = rows[0]["mm"].ToString() + " " + "جنية ";
                        m = int.Parse(rows[0]["mm"].ToString());

                    }
                    int tot = mm - m;
                    if (tot >= 0)
                    {
                        earn_total.Text = tot.ToString() + " " + "جنية "; ;
                        earn_total.ForeColor = Color.ForestGreen;
                    }
                    else
                    {
                        earn_total.Text = (tot * -1).ToString() + " " + "جنية "; ;
                        earn_total.ForeColor = Color.Firebrick;
                    }
                }
            income(today);
          
          
        }
        private void income(DateTime date)
        {
            var d = today.ToString("dd/MM/yyyy");
            int temp = 0;
            string sql = "select cast(sum(payment)/30 as int) as t from logs_info where month(date) like @mounth and YEAR(date) like @year";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@year", d.Split('/')[2]);
                command.Parameters.AddWithValue("@mounth", d.Split('/')[1]);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["t"].ToString() == "")
                {
                    income_day.Text = "صفر جنية ";
                    temp = 0;
                }
                else
                {
                    income_day.Text = rows[0]["t"].ToString() + " " + "جنية ";
                    temp = int.Parse(rows[0]["t"].ToString());
                }
                
                if (temp <= inc)
                {
                    txttotal_today.ForeColor = Color.ForestGreen;
                }
                else
                {
                    txttotal_today.ForeColor = Color.Firebrick;
                }
            }
        }
        private void income0(DateTime date)
        {
            var d = today.ToString("dd/MM/yyyy");
           
            string sql = "select cast(sum(payment)/30 as int) as t from logs_info where month(date) like @mounth and YEAR(date) like @year";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@year", d.Split('/')[2]);
                command.Parameters.AddWithValue("@mounth", int.Parse(d.Split('/')[1]) - 1);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                if (rows[0]["t"].ToString() == "")
                {
                    income_day_0.Text = "صفر جنية ";
                    
                }
                else
                {
                    income_day_0.Text = rows[0]["t"].ToString() + " " + "جنية ";
                }

               
            }
        }
        private void totalToday0(DateTime date)
        {
            var d = today.ToString("dd/MM/yyyy");
           
            string sql = @"
                select 
                    (select sum(payment) as s 
                        from logs_info
                        where month(date) like @mounth and YEAR(date) like @year) as mounth,
(select sum(v_payment) as s  from v_logs where month(v_date) like @mounthLast and YEAR(v_date) like @year) as mm";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                // CONVERT (varchar(10), date, 103) as [الوقت ]
                command.Parameters.AddWithValue("@year", d.Split('/')[2]);
                command.Parameters.AddWithValue("@mounth", int.Parse(d.Split('/')[1])-1);
                command.Parameters.AddWithValue("@mounthLast", int.Parse(d.Split('/')[1]) - 2);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();

                txttotal_mounth_0.Text = rows[0]["mounth"].ToString() + " " + "جنية ";
                txttotal_mm_0.Text = rows[0]["mm"].ToString() + " " + "جنية ";
                int tot = int.Parse(rows[0]["mounth"].ToString()) - int.Parse(rows[0]["mm"].ToString());
                if (tot >= 0)
                {
                    earn_total_0.Text = tot.ToString() + " " + "جنية "; ;
                    earn_total_0.ForeColor = Color.ForestGreen;
                }
                else
                {
                    earn_total_0.Text = (tot * -1).ToString() + " " + "جنية "; ;
                    earn_total_0.ForeColor = Color.Firebrick;
                }
            }
            income0(today);
        }
        private void Not_Avalable()
        {
            String quary = "select name as [إسم الصنف الناقص] from goods Where amount = 0 ";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);

                needsTable.DataSource = goods_info;
            }
        }
        private void sqlcmd(string sql, Label o)
        {

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                o.Text = rows[0]["num"].ToString();

            }
        }

        #endregion

        #region product page

        #region functions 
        private bool ChkInput()
        {
            try
            {
                if (txtproduct_new.Text == "" || txtBuy_new.Text == "0" || txtBuy_new.Text == "" || txtBuy_new.Text == "سعر الشراء" || txtSell_new.Text == "0" || txtSell_new.Text == "" || txtSell_new.Text == "سعر البيع" || txtAmount_new.Text == "0" || txtAmount_new.Text == "الكمية" || txtAmount_new.Text == "" || cb_type.SelectedItem.ToString() == "" && (cb_type.SelectedItem.ToString() != "أجهزة كهربائية" || cb_type.SelectedItem.ToString() != "أدوات منزلية" || cb_type.SelectedItem.ToString() != "بلاستيك"))
                {


                    MessageBox.Show("الرجاء التأكد من صحه البيانات", "خطأ");
                    return false;

                }
                return true;
            }
            catch
            {
                MessageBox.Show("الرجاء التأكد من صحه البيانات", "خطأ");
                return false;

            }

        }
        private void Viewgoods()
        {
            String quary = "select Id,name from goods";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                goodslist.DisplayMember = "name";
                goodslist.ValueMember = "id";
                goodslist.DataSource = goods_info;

            }


        }
        private async Task del_goodAsync()
        {
            try
            {
                String quary = String.Concat("alter table v_goods nocheck constraint all;delete from sells where good_id =", goodslist.SelectedValue, ";delete  from goods where Id = ", goodslist.SelectedValue, ";alter table v_goods check constraint all");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }

                time_now.ForeColor = Color.Black;
                time_now.Text = "تم حذف  " + txtproduct.Text + " من قاعدة البيانات";
                int ss = goodslist.SelectedIndex;
                Viewgoods();
                goodslist.SetSelected(ss, true);
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                time_now.Text = "الحالة : متصل";
                time_now.ForeColor = Color.White;

            }
            catch (Exception)
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "لا يمكن حذف الصنف لأنه مباع قبل ذلك";
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                time_now.Text = "الحالة : متصل";
                time_now.ForeColor = Color.White;
            }
        }

        private void AutoComplete(TextBox t, string s)
        {
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(s, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                t.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }

        private void NumChk(TextBox t)
        {
            if (!(Regex.IsMatch(t.Text, "^[0-9]+$")))
            {
                t.Text = "0";
                t.SelectAll();
            }
        }
        private void SrchByName()
        {
            try
            {
                String quary = String.Concat("select Id,name  from goods where name like N'", "%", txt_search.Text, "%'");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    goodslist.DisplayMember = "name";
                    goodslist.ValueMember = "id";
                    goodslist.DataSource = goods_info;
                }
            }
            catch
            {

            }

        }

        #endregion
        private void Txt_search_TextChanged(object sender, EventArgs e)
        {
            if (txt_search.Text != "'")
            {
                SrchByName();
            }




            if (goodslist.Items.Count == 0)
                txt_search.ForeColor = Color.Crimson;
            else
                txt_search.ForeColor = Color.White;

        }


        private void TxtBuy_new_TextChanged(object sender, EventArgs e)
        {
            NumChk(txtBuy_new);
            if (txtBuy_new.Text == "سعر الشراء")
                btnproduct_save.Enabled = false;
            else
                btnproduct_save.Enabled = true;

        }

        private void TxtSell_new_TextChanged(object sender, EventArgs e)
        {
            NumChk(txtSell_new);
            if (txtSell_new.Text == "سعر البيع")
                btnproduct_save.Enabled = false;
            else
                btnproduct_save.Enabled = true;

        }

        private void TxtAmount_new_TextChanged(object sender, EventArgs e)
        {
            NumChk(txtAmount_new);
            if (txtAmount_new.Text == "الكمية")
                btnproduct_save.Enabled = false;
            else
                btnproduct_save.Enabled = true;

        }
        private void TxtBuy_new_Enter(object sender, EventArgs e)
        {
            txtBuy_new.Clear();
            txtBuy_new.SelectAll();
            txtBuy_new.Focus();

            txtBuy_new.ForeColor = Color.White;
        }

        private void TxtSell_new_Enter(object sender, EventArgs e)
        {
            txtSell_new.Clear();
            txtSell_new.SelectAll();
            txtSell_new.Focus();

            txtSell_new.ForeColor = Color.White;
        }

        private void TxtAmount_new_Enter(object sender, EventArgs e)
        {
            txtAmount_new.Clear();
            txtAmount_new.SelectAll();
            txtAmount_new.Focus();

            txtAmount_new.ForeColor = Color.White;
        }
        private void Txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.Focus();
            txt_search.ForeColor = Color.White;
        }

        private void Txt_search_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            txt_search.SelectAll();
        }
        bool f = false;
        private void New_p_Click(object sender, EventArgs e)
        {
            if (!f)
            {
                new_p.Image = allN1.Properties.Resources.cancel_48px;
            }
            else
            {
                new_p.Image = allN1.Properties.Resources.add_48px;
            }
            new_p_gb.Visible = !f;
            btn_sell_info.Enabled = f;
            //panel1.Enabled = f;
            groupBox4.Enabled = f;
            f = !f;

        }
        private void Btnproduct_save_Click(object sender, EventArgs e)
        {
            _ = add_newgood();



        }
        private void Button2_Click(object sender, EventArgs e)
        {
            _ = del_goodAsync();

            update_info();

        }
        private async Task add_newgood()
        {
            try
            {
                if (ChkInput())
                {

                    int numberOfRecords = 0;
                    String quary = "if not exists  (Select name from goods where name = @name) begin insert into goods VALUES (@name , @type , @sell , @buy , @amount , @kind)  insert into v_goods (vendor_id , good_id,v_price,v_amount) select  TOP 1 1,Id,buy_price,amount from goods ORDER BY id DESC  end";
                    using (connection = new SqlConnection(ConnectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@name", txtproduct_new.Text);
                        command.Parameters.AddWithValue("@type", txtType_new.Text);
                        command.Parameters.AddWithValue("@sell", txtSell_new.Text);
                        command.Parameters.AddWithValue("@buy", txtBuy_new.Text);
                        command.Parameters.AddWithValue("@amount", txtAmount_new.Text);
                        command.Parameters.AddWithValue("@kind", cb_type.SelectedItem.ToString());
                        numberOfRecords = command.ExecuteNonQuery();
                    }
                    if (numberOfRecords == -1)
                    {
                        time_now.ForeColor = Color.FromArgb(240,240,51);
                        time_now.Text = "هذا الصنف موجود من قبل ولا يمكن إضافته";
                        txtproduct_new.SelectAll();
                        txtproduct_new.Focus();




                    }
                    else
                    {
                        time_now.ForeColor = Color.Black;
                        time_now.Text = "عملية ناجحه : تم إضافة " + txtproduct_new.Text + " إلى قاعدة البيانات ";
                        txtproduct_new.Text = "";
                        txtType.Text = "";
                        txtSell_new.Text = "";
                        txtBuy_new.Text = "";
                        txtAmount_new.Text = "";
                        new_p.Image = allN1.Properties.Resources.add_48px;
                        f = false;
                        new_p_gb.Visible = false;
                        btn_sell_info.Enabled = true;
                        Viewgoods();
                        panel1.Enabled = true;
                        groupBox4.Enabled = true;
                        int milliseconds = 3000;
                        await Task.Delay(milliseconds);
                        time_now.Text = "الحالة : متصل";
                        time_now.ForeColor = Color.White;


                    }
                    AutoComplete(txtType_new, "SELECT type FROM goods");
                    AutoComplete(txtproduct_new, "SELECT name FROM goods");



                }
            }
            catch
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "حدث خطأ اثناء اضافة صنف ، اتصل بالمبرمج فورا ";


            }
        }
        private async Task editGood()
        {
            try
            {
                String quary = String.Concat("update goods set name =@name , type = @type ,sell_price = @sell ,buy_price = @buy , amount = @amount  , kind = @kind where Id = ", goodslist.SelectedValue);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", txtproduct.Text);
                    command.Parameters.AddWithValue("@type", txtType2.Text);
                    command.Parameters.AddWithValue("@sell", txtSell.Text);
                    command.Parameters.AddWithValue("@buy", txtBuy.Text);
                    command.Parameters.AddWithValue("@amount", txtAmount.Text);
                    command.Parameters.AddWithValue("@kind", txtType.Text);
                    command.ExecuteNonQuery();
                }
                time_now.ForeColor = Color.Black;
                time_now.Text = "  تم تعديل بيانات " + txtproduct.Text;
                int s = goodslist.SelectedIndex;
                Viewgoods();
                Viewgoods();
                Viewgoods();
                Viewgoods();             goodslist.SetSelected(s,true);
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                time_now.Text = "الحالة : متصل";
                time_now.ForeColor = Color.White;
                /*String g = String.Concat("update vendors set v_name =@vname where good_id = ", goodslist.SelectedValue);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(g, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@vname", vendortxt.Text);

                    command.ExecuteNonQuery();
                }*/
            }
            catch (Exception)
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "حدثت مشكلةاثناء تعديل المنتج برجاء التواصل مع المبرمج ";


            }



        }

        private void Btn_sell_info_Click(object sender, EventArgs e)
        {
            sell_info = !(sell_info);
            if (sell_info)
            {
                btn_sell_info.BackColor = Color.Firebrick;
                new_p.Enabled = false;
                //gb_sell_info.Size = new Size(524, 494);
                //gb_sell_info.Location = new Point(146, 8);
                gb_sell_info.Visible = true;

            }
            else
            {
                btn_sell_info.BackColor = Color.FromArgb(41, 57, 85);
                gb_sell_info.Visible = false;
                new_p.Enabled = true;
            }
        }

        private void Txtproduct_new_TextChanged(object sender, EventArgs e)
        {
            txtType_new.Text = txtproduct_new.Text.Split(' ')[0];
            if (txtproduct_new.Text == "")
                btnproduct_save.Enabled = false;
            else
                btnproduct_save.Enabled = true;

        }
        private void Goodslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quary = String.Concat("select *  from goods where goods.id = ", goodslist.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                txtproduct.Text = rows[0]["name"].ToString();
                txtType2.Text = rows[0]["type"].ToString();
                txtAmount.Text = rows[0]["amount"].ToString();
                txtSell.Text = rows[0]["sell_price"].ToString();
                txtBuy.Text = rows[0]["buy_price"].ToString();
                txtType.Text = rows[0]["kind"].ToString();
                //vendortxt.Text = rows[0]["v_name"].ToString();

            }

            String q = "select sells.order_id as [الفاتورة]  , amount as [الكمية] , sell_price as [السعر] , name as [اســم العمـيل] from Sells join orders on orders.order_id = Sells.order_id  join users on userId = users.Id where good_id = @ID";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(q, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
            {
                cmd.Parameters.AddWithValue("@ID", goodslist.SelectedValue);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dgv_sell_info.DataSource = goods_info;

            }
            if (dgv_sell_info.Rows.Count < 1)
            {

                button2.Enabled = true;
                button2.BackColor = Color.DarkRed;
                btn_sell_info.Enabled = false;
                gb_sell_info.Visible = false;
                sell_info = false;
                btn_sell_info.BackColor = Color.FromArgb(0, 102, 154);


            }
            else
            {

                button2.Enabled = false;
                button2.BackColor = Color.FromArgb(0, 102, 154);
                btn_sell_info.Enabled = true;


            }
        }
        #endregion

        #region users page

        private void Button6_Click(object sender, EventArgs e)
        {
            _ = editAsync();

            txtuser_mony.ReadOnly = true;

        }

        private void Vendor_mony_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtvendor_mony.ReadOnly)
            {
                using (modify mdf = new modify())
                {
                    if (mdf.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    txtvendor_mony.ReadOnly = false;
                }
            }
        }



        private void TextBox17_Enter(object sender, EventArgs e)
        {


        }

        private void Txtvendor_id_Enter(object sender, EventArgs e)
        {
            txtvendor_id.SelectAll();
            txtvendor_id.Copy();
        }
        bool f2 = false;
        private void New_u_Click(object sender, EventArgs e)
        {
            if (!f2)
            {
                new_u.Image = allN1.Properties.Resources.cancel_48px;
            }
            else
            {
                new_u.Image = allN1.Properties.Resources.add_48px;
            }
            new_u_gb.Visible = !f2;
            gbuser_info.Enabled = f2;
            userslist.Enabled = f2;
            groupBox20.Enabled = f2;
            pay_info_gb.Enabled = f2;
            f2 = !f2;
        }

        private void Button16_Click(object sender, EventArgs e)
        {
            _ = new_user();

        }
        bool f3 = false;
        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (!f3)
            {
                pictureBox2.Image = allN1.Properties.Resources.cancel_48px;
            }
            else
            {
                pictureBox2.Image = allN1.Properties.Resources.add_48px;
            }
            new_v_gb.Visible = !f3;
            gbven_info.Enabled = f3;
            vendorlist.Enabled = f3;
            groupBox5.Enabled = f3;
            pay_ven_info_gb.Enabled = f3;
            f3 = !f3;

        }

        private void Button17_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            bill_info bill_Info = new bill_info();
            bill_Info.Show(this);
            clean();
            int s = userslist.SelectedIndex;
            Viewusers();
            userslist.SetSelected(s, true);
        }


        #region options menu
        private void إغلاقToolStripMenuItem_Click(object sender, EventArgs e)
        {
            save_users_data();
            save_vendors_data();
            _ = BackupdatabaseAsync();
            
        }

        private void تصغيرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void قفلالشاشةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            @lock lck = new @lock();
            lck.ShowDialog(this);

        }

        private void طباعةإيصالToolStripMenuItem_Click(object sender, EventArgs e)
        {
            printpay printpay = new printpay();
            printpay.ShowDialog(this);
        }


        private void المدفوعاتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String quary = @"
                                WITH cte AS (
                                    SELECT 
                                        user_id, 
                                        payment, 
		                                (CONVERT(VARCHAR(10),date , 103)) as date,
                                        ROW_NUMBER() OVER (
                                            PARTITION BY 
                                                user_id, 
		                                CONVERT(VARCHAR(10),date , 103)
                                            ORDER BY 
 
		                                CONVERT(VARCHAR(10),date , 103)
                                        ) row_num
                                     FROM 
                                        logs_info
                                )
                                DELETE FROM cte
                                WHERE row_num > 1;";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            update_info();
        }

        private void TestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String quary = "delete from logs_info where user_id = 1431";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            update_info();
        }

        #endregion


        #region user & vendor page


        #region functions

        private void Viewusers()
        {
            String quary = "select mony,name,Id from users order by name";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                vendorlist.DisplayMember = "v_name";
                vendorlist.ValueMember = "vendor_id";
                vendorlist.DataSource = goods_info;
                goods_info.ToCSV(Application.StartupPath + "/BackUp/vendors.txt");

            }

        }
        private void FindAndReplace(Word.Application wordApp, object findText, object replaceWithText)
        {
            object matchCase = true;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundLike = false;
            object nmatchAllForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiactitics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;

            wordApp.Selection.Find.Execute(ref findText,
                        ref matchCase, ref matchWholeWord,
                        ref matchWildCards, ref matchSoundLike,
                        ref nmatchAllForms, ref forward,
                        ref wrap, ref format, ref replaceWithText,
                        ref replace, ref matchKashida,
                        ref matchDiactitics, ref matchAlefHamza,
                        ref matchControl);
        }
        private void printmotalba(object filename, object savaAs , string user , string payout , string remain)
        {
            foreach (var process in Process.GetProcessesByName("WINWORD"))
            {
                process.Kill();
            }
            object missing = Missing.Value;
            Word.Application wordApp = new Word.Application();

            Word.Document aDoc = null;

            if (File.Exists((string)filename))
            {
                object readOnly = false; //default
                object isVisible = false;

                wordApp.Visible = false;

                aDoc = wordApp.Documents.Open(ref filename, ref missing, ref readOnly,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing,
                                        ref missing, ref missing, ref missing, ref missing);
                FindAndReplace(wordApp, "<date>", today.ToString("dd/MM/yyyy"));
                FindAndReplace(wordApp, "<pay>", payout);
                FindAndReplace(wordApp, "<name>", user);
                FindAndReplace(wordApp, "<mony>", remain);
                
                    


                aDoc.PageSetup.Orientation = Word.WdOrientation.wdOrientPortrait;
                aDoc.Activate();

                //Find and replace:

                object copies = "1";
                object pages = "";
                object range = Word.WdPrintOutRange.wdPrintAllDocument;
                object items = Word.WdPrintOutItem.wdPrintDocumentContent;
                object pageType = Word.WdPrintOutPages.wdPrintAllPages;
                object oTrue = true;
                object oFalse = false;
                object oMissing = Missing.Value;
                time_now.Text = "جارى طباعة الإيصال";
                aDoc.PrintOut(ref oTrue, ref oFalse, ref range, ref oMissing, ref oMissing, ref oMissing, ref items, ref copies, ref pages, ref pageType, ref oFalse, ref oTrue, ref oMissing, ref oFalse, ref oMissing, ref oMissing, ref oMissing, ref oMissing);
                //

                //Close Document:
                time_now.Text = "تمت الطباعة";
                aDoc.SaveAs2(savaAs);
                aDoc.SaveAs2(Application.StartupPath + "/temp.docx");
                aDoc.Close(ref missing, ref missing, ref missing);
                foreach (var process in Process.GetProcessesByName("WINWORD"))
                {
                    process.Kill();
                }

            }
            else
            {
                MessageBox.Show("file dose not exist.");
                return;
            }


        }
        private async Task do_pay_u_Async()
        {
            String quary = String.Concat("update logs set total =@remain  where user_Id = ", int.Parse(txtuser_id.Text), ";insert into logs_info VALUES (@user_Id , @payment , @date)", ";update users set mony = @remain  , lastPayment = @date where Id = ", int.Parse(txtuser_id.Text));
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))

            {
                connection.Open();
                command.Parameters.AddWithValue("@remain", remain);
                command.Parameters.AddWithValue("@user_Id", int.Parse(txtuser_id.Text));
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@payment", float.Parse(txtuer_payout.Text));


                command.ExecuteNonQuery();
            }
            time_now.ForeColor = Color.Black;
            time_now.Text = " تم دفع القسط بنجاح ";
           

            if (MessageBox.Show("هل تريد طباعة إيصال الدفع؟", "طباعة", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                time_now.Text = "جارى إنشاء الإيصال";
                string name_of_payment = "/payments/" + today.ToString("dd-MM-yyyy") + "/" + txtuser.Text + ".docx";
                filename =Application.StartupPath + "/payments/" + today.ToString("dd-MM-yyyy");
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
                    time_now.ForeColor = Color.FromArgb(240,240,51);
                    time_now.Text = e.ToString();
                }
                printmotalba(Application.StartupPath + "/payment.docx", Application.StartupPath + name_of_payment, txtuser.Text, txtuer_payout.Text, remain.ToString());

                if (File.Exists(Application.StartupPath+"\\123.txt"))
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
            lastpay();
            int s = userslist.SelectedIndex;
           // Viewusers();
            userslist.SetSelected(s, true);
            txtuer_payout.Text = "";
            txtuer_remain.Text = "";
            txtuer_search.Text = "";
            userslist.Enabled = true;
            groupBox1.Enabled = true;
            txtuer_search.Enabled = true;
            groupBox20.Visible = false;
            int milliseconds = 1000;
            await Task.Delay(milliseconds);
            time_now.Text = "الحالة : متصل";
            time_now.ForeColor = Color.White;
        }

        private async Task do_pay_v_Async()
        {
            String quary = String.Concat("insert into v_logs VALUES (@user_Id , @payment , @date)", ";update vendors set v_money = @remain  where vendor_id = ", txtvendor_id.Text);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))

            {
                connection.Open();
                command.Parameters.AddWithValue("@remain", remain_v);
                command.Parameters.AddWithValue("@user_Id", int.Parse(txtvendor_id.Text));
                command.Parameters.AddWithValue("@date", today);
                command.Parameters.AddWithValue("@payment", float.Parse(txtvendor_payout.Text));
                command.ExecuteNonQuery();
            }
            int s = vendorlist.SelectedIndex;
            Viewvendors();

            vendorlist.SetSelected(s, true); ;

            time_now.ForeColor = Color.Black;
            time_now.Text = " تم دفع القسط بنجاح ";

            txtvendor_payout.Text = "";
            txtvendor_remain.Text = "";
            txtvendor_search.Text = "";
            int milliseconds = 3000;
            await Task.Delay(milliseconds);
            time_now.Text = "الحالة : متصل";
            time_now.ForeColor = Color.White;
        }

        private async Task editAsync()
        {
            try
            {
                String quary = String.Concat("update users set name =@name , address = @address ,phone = @phone , mony = @mony  where Id = ", userslist.SelectedValue, ";insert into logs values (", userslist.SelectedValue, ",@mony)");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", txtuser.Text);
                    command.Parameters.AddWithValue("@address", txtuser_add.Text);
                    command.Parameters.AddWithValue("@phone", txtuser_phone.Text);
                    command.Parameters.AddWithValue("@mony", int.Parse(txtuser_mony.Text));


                    command.ExecuteNonQuery();
                }
                time_now.Text = "تم التعديل بنجاح";
                int s = userslist.SelectedIndex;
                Viewusers();
                userslist.SetSelected(s, true);
                int milliseconds = 1000;
                await Task.Delay(milliseconds);
                time_now.Text = "الحالة متصل";
            }
            catch
            {
                String quary = String.Concat("update users set name =@name , address = @address ,phone = @phone , mony = @mony  where Id = ", userslist.SelectedValue, ";update logs set total = @mony where user_Id = ", userslist.SelectedValue);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", txtuser.Text);
                    command.Parameters.AddWithValue("@address", txtuser_add.Text);
                    command.Parameters.AddWithValue("@phone", txtuser_phone.Text);
                    command.Parameters.AddWithValue("@mony", int.Parse(txtuser_mony.Text));
                    command.ExecuteNonQuery();
                }
                time_now.ForeColor = Color.Black;
                time_now.Text = " تم تعديل بيانات " + txtuser.Text;
                int s = userslist.SelectedIndex;
                Viewusers();
                userslist.SetSelected(s, true);
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                time_now.Text = "الحالة : متصل";
                time_now.ForeColor = Color.White;
            }
        }

        private async Task delete_user()
        {
            if (MessageBox.Show("برجاء العلم ان العميل سوف يتم حذفه من جميع السجلات نهائيا", "تحذير", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                try
                {
                    String quary = String.Concat("alter table logs nocheck constraint all ;alter table logs_info nocheck constraint all;delete from  users where id = ", userslist.SelectedValue, ";alter table logs check constraint all;alter table logs_info check constraint all");
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))

                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    time_now.ForeColor = Color.Black;
                    time_now.Text = " تم حذف العميل " + txtuser.Text;
                    int s = userslist.SelectedIndex;
                    Viewusers();
                    userslist.SetSelected(s, true);
                    int milliseconds = 3000;
                    await Task.Delay(milliseconds);
                    time_now.Text = "الحالة : متصل";
                    time_now.ForeColor = Color.White;


                }
                catch (Exception)
                {
                    time_now.ForeColor = Color.FromArgb(240,240,51);
                    time_now.Text = "حدثت مشكلة أثناء حذف العميل ، برجاء التواصل مع المبرمج";
                }



            }
        }

        private async Task new_user()
        {
            int numberOfRecords = 0;
            try
            {
                String quary = "if not EXISTS (SELECT name FROM users WHERE name = @name) begin insert into users VALUES (@name , @address , @phone,@mony , null);insert into logs values ((select Id from users where name =@name) ,@mony) end";
                if (txtuser_new.Text == "" || txtuser_phone_new.Text == "" || txtuser_add_new.Text == "" || txtuser_mony_new.Text == "")
                {
                    MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
                }
                else
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@name", txtuser_new.Text);
                        command.Parameters.AddWithValue("@address", txtuser_add_new.Text);
                        command.Parameters.AddWithValue("@phone", txtuser_phone_new.Text);
                        command.Parameters.AddWithValue("@mony", int.Parse(txtuser_mony_new.Text));
                        numberOfRecords = command.ExecuteNonQuery();

                    }
                    if (numberOfRecords == -1)
                    {
                        time_now.ForeColor = Color.FromArgb(240,240,51);
                        time_now.Text = "هذا العميل موجود من قبل ولا يمكن إضافته";
                        txtuser_new.SelectAll();
                        txtuser_new.Focus();
                    }
                    else
                    {
                        time_now.ForeColor = Color.Black;
                        time_now.Text = "عملية ناجحه : تم إضافة " + txtuser_new.Text + " إلى قاعدة البيانات ";
                        Viewusers();
                        txtuser_new.Text = "";
                        txtuser_add_new.ForeColor = Color.FromArgb(160, 160, 160);
                        txtuser_add_new.Text = "العنوان";
                        txtuser_phone_new.ForeColor = Color.FromArgb(160, 160, 160);
                        txtuser_phone_new.Text = "رقم التليفون";
                        txtuser_mony_new.Text = "";
                        new_u.Image = allN1.Properties.Resources.add_48px;
                        f2 = false;
                        new_u_gb.Visible = f2;
                        gbuser_info.Enabled = !f2;
                        userslist.Enabled = !f2;
                        groupBox20.Enabled = !f2;
                        pay_info_gb.Enabled = !f2;
                        int milliseconds = 3000;
                        await Task.Delay(milliseconds);
                        time_now.Text = "الحالة : متصل";
                        time_now.ForeColor = Color.White;
                    }

                }
            }
            catch(Exception ex)
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "حدث خطأ، تأكد من بيانات العميل فى سجل العملاء واتصل فورا بالمبرمج";
                MessageBox.Show(ex.ToString());

            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT name FROM users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                txtuser_new.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT address FROM users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                while (reader.Read())
                {
                    MyCollection.Add(reader.GetString(0));
                }
                txtuser_add_new.AutoCompleteCustomSource = MyCollection;
                con.Close();
            }
        }
        #endregion


        private void Userslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quary = String.Concat("select *  from users where id = ", userslist.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                txtuser.Text = rows[0]["name"].ToString();
                txtuser_add.Text = rows[0]["address"].ToString();
                txtuser_phone.Text = rows[0]["phone"].ToString();
                txtuser_mony.Text = rows[0]["mony"].ToString();
                txtuser_id.Text = rows[0]["Id"].ToString();
                usernameSelected = txtuser.Text;
                useridSelected = txtuser_id.Text;

            }
            String q = "select count(*) as s from orders where userId = " + int.Parse(txtuser_id.Text);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(q, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable bills = new DataTable();
                adapter.Fill(bills);
                DataRow[] rows = bills.Select();
                num_bills.Text = rows[0]["s"].ToString();


            }

            groupBox20.Visible = false;
            txtuer_remain.Text = "";
            txtuer_payout.Clear();
            remain = 0;

            info_user();
        }



        #endregion


        private void New_v_SelectedIndexChanged(object sender, EventArgs e)
        {
            //update_info();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            _ = editGood();
        }

        private void Btnuser_del_Click(object sender, EventArgs e)
        {
            _ = delete_user();
        }

        private void Btnuser_payInfo_Click(object sender, EventArgs e)
        {

            pay_info_gb.Visible = true;
        }

        private void info_user()
        {

            String sql = String.Concat("select logs_info.id as [رقم الإيصال], payment as [المدفوع], CONVERT (varchar(10), date, 103) as [الوقت ] from logs_info join users on logs_info.user_id = users.Id where users.Id =", userslist.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);

                dataGridView1.DataSource = info;


            }
        }
        private void info_vendors()
        {

            String sql = String.Concat("select v_logs.v_log_id as [رقم الدفع], v_payment as [المدفوع], CONVERT (varchar(10), v_date, 103) as [الوقت ] from v_logs join vendors on v_logs.vendor_id = vendors.vendor_id where v_logs.vendor_id =", vendorlist.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);

                dgv_vendor.DataSource = info;


            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void Txtuser_phone_new_Enter(object sender, EventArgs e)
        {
            txtuser_phone_new.Clear();
            txtuser_phone_new.SelectAll();
            txtuser_phone_new.Focus();

            txtuser_phone_new.ForeColor = Color.White;
        }

        private void Txtuser_add_new_Enter(object sender, EventArgs e)
        {
            txtuser_add_new.Clear();
            txtuser_add_new.SelectAll();
            txtuser_add_new.Focus();

            txtuser_add_new.ForeColor = Color.White;
        }

        private void Txtuser_mony_new_TextChanged(object sender, EventArgs e)
        {

            NumChk(txtuser_mony_new);
        }

        private void Txtuser_phone_new_TextChanged(object sender, EventArgs e)
        {
            NumChk(txtuser_phone_new);
        }

        private void Btn_pay_Click(object sender, EventArgs e)
        {
            //print payment
            _ = do_pay_u_Async();

            totalToday(today);
            paymnts(today);

            

        }

        private void Txtuer_payout_TextChanged(object sender, EventArgs e)
        {
            if (txtuer_payout.Text != "")
            {
                if (Regex.IsMatch(txtuer_payout.Text, "^[0-9]+$"))
                {
                    if (int.Parse(txtuer_payout.Text) <= int.Parse(txtuser_mony.Text))
                    {
                        remain = float.Parse(txtuser_mony.Text) - float.Parse(txtuer_payout.Text);
                        txtuer_remain.Text = remain.ToString();
                        btn_pay.Enabled = true;
                    }
                    else
                    {
                        txtuer_payout.Text = "";
                        btn_pay.Enabled = false;
                    }
                }
                else
                {

                    txtuer_payout.Text = "";
                    btn_pay.Enabled = false;

                }

            }
            else
            {
                txtuer_remain.Text = txtuser_mony.Text;
                btn_pay.Enabled = false;
            }
        }

        private void Userslist_DoubleClick(object sender, EventArgs e)
        {
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtuer_remain_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtuer_search_TextChanged(object sender, EventArgs e)
        {
            userByName();
        }
        private void userByName()
        {
            try
            {
                String quary = String.Concat("select Id,name  from users where name like N'", "%", txtuer_search.Text, "%'");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    userslist.DisplayMember = "name";
                    userslist.ValueMember = "id";
                    userslist.DataSource = goods_info;
                }
            }
            catch
            {

            }

        }

        private void Txtuer_search_Enter(object sender, EventArgs e)
        {
            txtuer_search.Clear();
            txtuer_search.Focus();
            txtuer_search.ForeColor = Color.White;
        }


        private void Txtvendor_mony_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtvendor_mony.ReadOnly)
            {
                using (modify mdf = new modify())
                {
                    if (mdf.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    txtvendor_mony.ReadOnly = false;
                }
            }
        }

        private void BtnVen_edit_Click(object sender, EventArgs e)
        {
            txtvendor_mony.ReadOnly = true;
            _ = Vendor_EditAsync();
        }


        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            update_info();
        }

        private void TextBox14_Enter(object sender, EventArgs e)
        {
            txtvendor_search.Clear();
            txtvendor_search.Focus();
            txtvendor_search.ForeColor = Color.White;
        }

        private void Txtvendor_search_TextChanged(object sender, EventArgs e)
        {
            VendByName();
        }
        private void VendByName()
        {
            try
            {
                String quary = String.Concat("select vendor_id,v_name from vendors where v_name like N'", "%", txtvendor_search.Text, "%'");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    vendorlist.DisplayMember = "v_name";
                    vendorlist.ValueMember = "vendor_id";
                    vendorlist.DataSource = goods_info;
                }
            }
            catch
            {

            }

        }

        private void BtnVen_pay_Click(object sender, EventArgs e)
        {
            _ = do_pay_v_Async();
        }

        private void Vendorlist_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quary = String.Concat("select *  from vendors where vendor_id = ", vendorlist.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                txtvendor_name.Text = rows[0]["v_name"].ToString();
                txtvendor_phone.Text = rows[0]["v_phone"].ToString();
                txtvendor_mony.Text = rows[0]["v_money"].ToString();
                txtvendor_id.Text = rows[0]["vendor_id"].ToString();
                vendornameSelected = txtvendor_name.Text;
                vendoridSelected = txtvendor_id.Text;
            }
            String q = "select count(*) as s from v_orders where vendor_id = " + int.Parse(txtvendor_id.Text);
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(q, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable bills = new DataTable();
                adapter.Fill(bills);
                DataRow[] rows = bills.Select();
                txtvendor_No_bills.Text = rows[0]["s"].ToString();


            }

            pay_ven_info_gb.Visible = false;
            pay_ven_info_gb.Visible = false;
            txtvendor_remain.Text = "";
            txtvendor_payout.Text = "";
            remain_v = 0;
            info_vendors();
        }

        private void Txtvendor_phone_new_TextChanged(object sender, EventArgs e)
        {
            NumChk(txtvendor_phone_new);
        }

        private void Txtvendor_phone_new_Enter(object sender, EventArgs e)
        {
            txtvendor_phone_new.Clear();
            txtvendor_phone_new.ForeColor = Color.White;
        }

        private void TextBox8_TextChanged(object sender, EventArgs e)
        {
            if (txtvendor_payout.Text != "")
            {
                if (Regex.IsMatch(txtvendor_payout.Text, "^[0-9]+$"))
                {
                    if (int.Parse(txtvendor_payout.Text) <= int.Parse(txtvendor_mony.Text))
                    {
                        remain_v = float.Parse(txtvendor_mony.Text) - float.Parse(txtvendor_payout.Text);
                        txtvendor_remain.Text = remain_v.ToString();
                        btnVen_pay.Enabled = true;
                    }
                    else
                    {
                        txtvendor_payout.Text = "";
                        btnVen_pay.Enabled = false;
                    }
                }
                else
                {

                    txtvendor_payout.Text = "";
                    btnVen_pay.Enabled = false;

                }

            }
            else
            {
                txtvendor_remain.Text = txtvendor_mony.Text;
                btnVen_pay.Enabled = false;
            }
        }


        private async Task Vendor_EditAsync()
        {
            try
            {
                String quary = String.Concat("update vendors set v_name =@name  ,v_phone = @phone ,v_money = @mony  where vendor_id = ", txtvendor_id.Text);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", txtvendor_name.Text);
                    command.Parameters.AddWithValue("@phone", txtvendor_phone.Text);
                    command.Parameters.AddWithValue("@mony", int.Parse(txtvendor_mony.Text));
                    command.ExecuteNonQuery();
                    time_now.ForeColor = Color.Black;
                    time_now.Text = "  تم تعديل بيانات " + txtvendor_name.Text;
                    int s = vendorlist.SelectedIndex;
                    Viewvendors();
                    
                    vendorlist.SetSelected(s, true);
                    int milliseconds = 3000;
                    await Task.Delay(milliseconds);
                    time_now.Text = "الحالة : متصل";
                    time_now.ForeColor = Color.White;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());
            }
        }

        private async Task Vendor_DelAsync()
        {
            if (MessageBox.Show("برجاء العلم ان المورد سوف يتم حذفه من جميع السجلات نهائيا", "تحذير", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                try
                {
                    String quary = String.Concat("alter table v_logs nocheck constraint all ;alter table v_goods nocheck constraint all;delete from  vendors where vendor_id = ", txtvendor_id.Text, ";alter table v_logs check constraint all;alter table v_goods check constraint all");
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))

                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                    time_now.ForeColor = Color.Black;
                    time_now.Text = "  تم حذف " + txtvendor_name.Text;
                    int ss = goodslist.SelectedIndex;
                    Viewgoods();
                    goodslist.SetSelected(ss, true);
                    int s = vendorlist.SelectedIndex;
                    Viewvendors();

                    vendorlist.SetSelected(s, true);
                    int milliseconds = 3000;
                    await Task.Delay(milliseconds);
                    time_now.Text = "الحالة : متصل";
                    Viewvendors();
                    time_now.ForeColor = Color.White;
                    
                }
                catch (Exception)
                {
                    time_now.Text = "حدث خطأ ، برجاء التأكد من عدم وجود فواتير للمورد حتى يتم الحذف";
                    time_now.ForeColor = Color.FromArgb(240,240,51);
                }



            }
        }

        private void BtnVen_billsInfo_Click(object sender, EventArgs e)
        {
            vendor_bill bill_Info = new vendor_bill();
            bill_Info.ShowDialog(this);
            clean_v();
            int s = vendorlist.SelectedIndex;
            Viewvendors();

            vendorlist.SetSelected(s, true);

        }

        private void BtnVen_del_Click(object sender, EventArgs e)
        {
            _ = Vendor_DelAsync();
        }


        private void Vendorlist_MouseDoubleClick(object sender, MouseEventArgs e)
        {
           
        }

        private void BtnVen_save_Click(object sender, EventArgs e)
        {
            _ = new_vendor();
        }
        private async Task new_vendor()
        {
            int numberOfRecords = 0;
            try
            {
                // String quary = "insert into vendors VALUES (@name,@mony, @phone);";
                String q = "if not EXISTS (SELECT v_name FROM vendors WHERE v_name = @name) begin insert into vendors VALUES (@name,@mony, @phone);end";
                if (txtvendor_name_new.Text == "" || txtvendor_phone_new.Text == "" || txtvendor_mony_new.Text == "")
                {
                    MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
                }
                else
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(q, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@name", txtvendor_name_new.Text);
                        command.Parameters.AddWithValue("@phone", txtvendor_phone_new.Text);
                        command.Parameters.AddWithValue("@mony", int.Parse(txtvendor_mony_new.Text));

                        numberOfRecords = command.ExecuteNonQuery();

                    }
                    if (numberOfRecords == -1)
                    {
                        time_now.ForeColor = Color.FromArgb(240,240,51);
                        time_now.Text = "هذا المورد موجود من قبل ولا يمكن إضافته";
                        txtvendor_name_new.SelectAll();
                        txtvendor_name_new.Focus();
                    }
                    else
                    {
                        time_now.ForeColor = Color.Black;
                        time_now.Text = "عملية ناجحه : تم إضافة " + txtvendor_name_new.Text + " إلى قاعدة البيانات ";
                        Viewvendors();
                        txtvendor_name_new.Text = "";
                        txtvendor_phone_new.ForeColor = Color.FromArgb(160, 160, 160);
                        txtvendor_phone_new.Text = "رقم التليفون";
                        txtvendor_mony_new.Text = "";
                        pictureBox2.Image = allN1.Properties.Resources.add_48px;
                        f3 = false;
                        new_v_gb.Visible = f3;
                        gbven_info.Enabled = !f3;
                        vendorlist.Enabled = !f3;
                        groupBox5.Enabled = !f3;
                        pay_ven_info_gb.Enabled = !f3;
                        int milliseconds = 3000;
                        await Task.Delay(milliseconds);
                        time_now.Text = "الحالة : متصل";
                        time_now.ForeColor = Color.White;
                    }

                }
            }
            catch
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "حدث خطأ، تأكد من بيانات العميل فى سجل العملاء واتصل فورا بالمبرمج";

            }
        }

        private void Label7_Click(object sender, EventArgs e)
        {
            save_users_data();
        }

        private void save_users_data()
        {
            String quary = "select *  from users";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);
                userdata.DataSource = info;
                userdata.SaveExportedData(Application.StartupPath + "/BackUp/بيانات العملاء.txt");

            }
        }
        private void save_vendors_data()
        {
            String quary = "select *  from vendors";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable info = new DataTable();
                adapter.Fill(info);
                userdata.DataSource = info;
                userdata.SaveExportedData(Application.StartupPath + "/BackUp/بيانات الموردين.txt");

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
                time_now.ForeColor = Color.Black;
                time_now.Text = "تم تحديث قاعدة البيانات";
                int milliseconds = 200;
                await Task.Delay(milliseconds);
                File.Delete(file);
            }
            String quary = "BACKUP DATABASE AppDB TO DISK = @dir";
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@dir", file);
                    command.ExecuteNonQuery();
                }
                this.Close();
            }
            catch (Exception e)
            {
                time_now.ForeColor = Color.FromArgb(240,240,51);
                time_now.Text = "حدث خطأ : لم يتم تحديث قاعدة البيانات";
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
                    time_now.ForeColor = Color.FromArgb(240,240,51);
                    time_now.Text = "حدث خطأ : يجب التواصل مع المهندس فورا";
                    await Task.Delay(milliseconds);
                    this.Close();
                }
                
            }
        }




        private void TextBox19_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (txtuser_mony.ReadOnly)
            {
                using (modify mdf = new modify())
                {
                    if (mdf.ShowDialog(this) != DialogResult.OK)
                    {
                        return;
                    }
                    txtuser_mony.ReadOnly = false;
                }
            }

        }

        #endregion


       
        private void clean()
        {
            String quary = "alter table Sells nocheck constraint all ;delete from  orders where total_price IS NULL ;alter table Sells check constraint all ";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            order user_order = new order();
            user_order.Show(this);
            
            int s = userslist.SelectedIndex;
            Viewusers();
            userslist.SetSelected(s, true);
        }

        private void الفواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clean();
            clean_v();
        }
        private void clean_v()
        {
            String quary = "alter table Buy nocheck constraint all ;delete from  v_orders where total_buy IS NULL ;alter table Buy check constraint all ";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

           
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            groupBox20.Visible = true;
        }


        private void Button5_Click(object sender, EventArgs e)
        {
            pay_ven_info_gb.Visible = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {

            v_order v_Order = new v_order();
            v_Order.ShowDialog(this);
            
            //clean_v();
            int s = vendorlist.SelectedIndex;
            Viewvendors();

            vendorlist.SetSelected(s, true);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            typeSrch typeSrch = new typeSrch();
            typeSrch.ShowDialog(this);
        }

        private void DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                paymnts(dateTimePicker1.Value);
            }
            catch
            {
                _ = errAsync();
            }
        }

        private void ToolStripDropDownButton1_Click(object sender, EventArgs e)
        {

        }

        private void ToolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void إيصالاتاليومToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath+ "\\payments\\"+ today.ToString("dd-MM-yyyy"));
            }
            catch 
            {
                //The system cannot find the file specified...
                MessageBox.Show(this, "لا توجد إيصالات اليوم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void فواتيرToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\bills");
            }
            catch (Exception ex)
            {
                //The system cannot find the file specified...
                MessageBox.Show(this, "حدث خطأ برجاء التواصل مع المبرمج\n"+ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void إيصالاتاليومToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\payments\\" + today.ToString("dd-MM-yyyy"));
            }
            catch
            {
                //The system cannot find the file specified...
                MessageBox.Show(this, "لا توجد إيصالات اليوم", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void فواتيرToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start(Application.StartupPath + "\\bills");
            }
            catch (Exception ex)
            {
                //The system cannot find the file specified...
                MessageBox.Show(this, "حدث خطأ برجاء التواصل مع المبرمج\n" + ex.Message, "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}



