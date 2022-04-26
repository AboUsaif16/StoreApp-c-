using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using Word = Microsoft.Office.Interop.Word;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Data.SQLite;

namespace allN1
{
    public partial class order : Form
    {
        #region variabls
            readonly string connectionString;
            SQLiteConnection connection;
            bool flag = false;
            int userId = int.Parse(Form1.useridSelected);
            int goodId;
            int order_id;
            decimal total;
            string sell_price; 
            float alltotal = 0;
            readonly DateTime today = DateTime.Now;
            readonly int[] good_id = new int[500];
            readonly int[] good_ammount = new int[500];
            int pt = 0;
        #endregion
        public order()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
            sell.Enabled = false;
        }
        #region functions 
        private void newOrder()
        {
            String quary = "insert into orders VALUES (@userId,null,@today)";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@today", today);

                command.ExecuteNonQuery();
            }
            string sql = "SELECT TOP 1 * FROM orders ORDER BY order_id DESC";
            using (connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {

                        order_id = int.Parse(reader["order_id"].ToString());
                    }
                    reader.Close();
                }
            }
            orderNum.Text = order_id.ToString();
        }
        private void orderData()
        {
            String quary = "select Sells.Id as [#] ,goods.name as [إســــم الصــــنف] ,Sells.amount as [الكمية] ,   Sells.sell_price as [الوحده] ,  total_price as [إجمالى] from  Sells join goods on Sells.good_id = goods.Id   where order_id = @order_id ";
            // String quary = "select goods.name as [إسم الصنف] ,COUNT (*) as [الكمية] ,   Sells.sell_price as [سعر الوحده] , (Sells.sell_price *COUNT (*) ) as [السعر الكلى]  from  Sells join goods on Sells.good_id = goods.Id  where order_id = @order_id group by goods.name , Sells.sell_price";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                command.Parameters.AddWithValue("@order_id", order_id);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView1.DataSource = goods_info;
                this.dataGridView1.Columns["#"].Visible = false;
                //this.dataGridView1.Columns["إســــم الصــــنف"].Width = 380;
            }
        }
        private void AddToOrders()
        {
            String quary = "update orders set total_price = @allTotal where order_id = @order_Id; update users set mony = mony + @allTotal where Id = @userId";
            if (allTotaltxt.Text == "0")
            {
                MessageBox.Show(owner: this, "عفوا لايوجد بيانات فى هذة الفاتورة\nبرجاء التأكد من إدخال صنف واحد على الأقل", "خطأ", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            else
            {
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@allTotal", float.Parse(allTotaltxt.Text));
                    command.Parameters.AddWithValue("@order_Id", order_id);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
                chk();
                flag = true;
                MessageBox.Show("تم حفظ الفاتورة رقم  " + order_id, "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


        }
        private void chk()
        {
            String quary = String.Concat("insert into logs (user_Id , total) select userId ,sum( total_price) from orders where orders.userId =", userId, " group by userId");
            try
            {
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                String sql = String.Concat("update  logs set total =  (select sum(total_price) from orders where orders.userId = ", userId, "  group by userId) where user_Id = ", userId);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
        private void clean()
        {
            String quary = "alter table Sells nocheck constraint all ;delete from  orders where total_price IS NULL ;alter table Sells check constraint all ";

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
        }
        private void select_good(ListBox l)
        {
            String quary = String.Concat("select * from goods where id =", l.SelectedValue);
            using (connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                {
                    SQLiteDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pricetxt.Text = reader["sell_price"].ToString();
                        sell_price = pricetxt.Text;
                        avtxt.Text = reader["amount"].ToString();
                        amount.Maximum = int.Parse(avtxt.Text);
                        goodId = int.Parse(reader["Id"].ToString());
                    }
                    reader.Close();
                }
                amount.Value = 0;
                amount.Enabled = true;
                add.Enabled = true;
            }

        }
        private void findtypes(string type, ListBox rslt)
        {
            String quary = String.Concat("select type from goods where kind like N'", type, "' group by type");
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                rslt.DisplayMember = "type";
                rslt.ValueMember = "type";
                rslt.DataSource = goods_info;
            }
        }
        private void typeChecked(object sender, EventArgs e)
        {
            if (r0.Checked)
            {
                findtypes("%%", typeList);
                typeGbox.Text = "النوع: " + "الكل";
                r1.ForeColor = r2.ForeColor = r3.ForeColor = Color.Black;
                r0.ForeColor = Color.Red;
            }
            if (r1.Checked)
            {
                findtypes("أجهزة كهربائية", typeList);
                typeGbox.Text = "النوع: " + "أجهزة كهربائية";
                r0.ForeColor = r2.ForeColor = r3.ForeColor = Color.Black;
                r1.ForeColor = Color.Red;
            }
            if (r2.Checked)
            {
                findtypes("أدوات منزلية", typeList);
                typeGbox.Text = "النوع: " + "أدوات منزلية";
                r0.ForeColor = r1.ForeColor = r3.ForeColor = Color.Black;
                r2.ForeColor = Color.Red;
            }
            if (r3.Checked)
            {
                findtypes("بلاستيك", typeList);
                typeGbox.Text = "النوع: " + "بلاستيك";
                r0.ForeColor = r1.ForeColor = r2.ForeColor = Color.Black;
                r3.ForeColor = Color.Red;
            }
        }
        #endregion
        private void Order_Load(object sender, EventArgs e)
        {
            userLabe.Text = Form1.usernameSelected;
            idLabel.Text = Form1.useridSelected;
            newOrder();
            findtypes("%%", typeList);
            
        }
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            decimal price = decimal.Parse(pricetxt.Text);
            decimal a = amount.Value;
            decimal total = price * a;
            totaltxt.Text = total.ToString();
        }
        private void Pricetxt_TextChanged(object sender, EventArgs e)
        {
            if (pricetxt.Text != "")
            {
                if (Regex.IsMatch(pricetxt.Text,"^[0-9]+$") | pricetxt.Text == "0") { 
                decimal price = decimal.Parse(pricetxt.Text);
                decimal a = amount.Value;
                total = price * a;
                totaltxt.Text = total.ToString();
                   
                }
                else
                {
                    pricetxt.Text = sell_price;
                }
            }

        }
        private void Add_Click(object sender, EventArgs e)
        {
            sell.Enabled = true;
            int remain = int.Parse(avtxt.Text)-int.Parse(amount.Value.ToString());
            avtxt.Text = remain.ToString();
            alltotal = alltotal + float.Parse(totaltxt.Text);
            allTotaltxt.Text = alltotal.ToString();
            String quary = "insert into Sells VALUES (@order_id , @goodId , @amount,@total_price,@sell_price);update goods set amount = @remain where Id = @goodId";
            if (pricetxt.Text == "" || amount.Value == 0)
            {
                MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
            }
            else
            {
                if (dataGridView1.Rows.Count > 27)
                {
                    MessageBox.Show("اكتمل الحد الأقصى للفاتروه , براجاء انشاء جديده");
                }
                else
                {
                    {
                        using (connection = new SQLiteConnection(connectionString))
                        using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                        {
                            connection.Open();

                            command.Parameters.AddWithValue("@order_id", order_id);
                            command.Parameters.AddWithValue("@goodId", goodId);
                            command.Parameters.AddWithValue("@sell_price", float.Parse(pricetxt.Text));
                            command.Parameters.AddWithValue("@amount", int.Parse(amount.Value.ToString()));
                            command.Parameters.AddWithValue("@remain", remain);
                            command.Parameters.AddWithValue("@total_price", float.Parse(totaltxt.Text));
                            command.ExecuteNonQuery();
                        }

                        orderData();
                        good_id[pt] = goodId;
                        good_ammount[pt] = int.Parse(amount.Value.ToString());
                        pt += 1;
                    }
                }
            }
            counter.Text = "عدد الأصناف : " + (dataGridView1.Rows.Count-1).ToString();



            amount.Value = 0;

        }
        private void Sell_Click(object sender, EventArgs e)
        {
            AddToOrders();
        }
        private void Del_Click(object sender, EventArgs e)
        {
            string sql = "delete from Sells where order_id=@order_id";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@order_Id", order_id);
                
                command.ExecuteNonQuery();
            }
            for (int i = 0; i < pt; i++)
            {
                string q = " update goods set  amount = amount +@back_amount where Id = @good_id";
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(q, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@good_id", good_id[i]);
                    command.Parameters.AddWithValue("@back_amount", good_ammount[i]);
                    command.ExecuteNonQuery();
                }
            }
            clean();
            this.Close();
        }
        private void DataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                int RowIndex = dataGridView1.CurrentCell.RowIndex;
                if (e.KeyData == Keys.Space && dataGridView1.Rows.Count > 1)
                {
                    if (MessageBox.Show("هل تريد حذف الصنف  من الفاتوره؟", "تحذير", MessageBoxButtons.OKCancel) == DialogResult.OK)

                    {
                        if (RowIndex >= 0)
                        {
                            DataGridViewRow row = this.dataGridView1.Rows[RowIndex];
                            String q = "update goods set goods.amount = goods.amount + @amount from Sells join goods on Sells.good_id = goods.Id and Sells.Id = @SID; delete from Sells where Id = @SID";
                            using (connection = new SQLiteConnection(connectionString))

                            using (SQLiteCommand command = new SQLiteCommand(q, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@SID", row.Cells[0].Value);
                                command.Parameters.AddWithValue("@amount", row.Cells[2].Value);
                                command.ExecuteNonQuery();
                            }
                            alltotal -= int.Parse(row.Cells[4].Value.ToString());
                            allTotaltxt.Text = alltotal.ToString();

                            dataGridView1.Rows.Remove(row);
                            //orderData();

                        }
                    }
                }
            }
            catch
            {

            }
        }
        private void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String quary = String.Concat("select  id,name  from goods where type like N'", typeList.SelectedValue, "'");
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    prdList.DisplayMember = "name";
                    prdList.ValueMember = "id";
                    prdList.DataSource = goods_info;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void PrdList_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_good(prdList);
        }

        private void Counter_Click(object sender, EventArgs e)
        {

        }

        private void Pricetxt_Click(object sender, EventArgs e)
        {
            pricetxt.Focus();
            pricetxt.SelectAll();
        }

        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(flag == false)
            {
                string sql = "delete from Sells where order_id=@order_id";
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@order_Id", order_id);

                    command.ExecuteNonQuery();
                }
                for (int i = 0; i < pt; i++)
                {
                    string q = " update goods set  amount = amount +@back_amount where Id = @good_id";
                    using (connection = new SQLiteConnection(connectionString))
                    using (SQLiteCommand command = new SQLiteCommand(q, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@good_id", good_id[i]);
                        command.Parameters.AddWithValue("@back_amount", good_ammount[i]);
                        command.ExecuteNonQuery();
                    }
                }
                clean();
            }
        }

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
    
}

