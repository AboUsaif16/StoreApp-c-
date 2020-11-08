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


namespace allN1
{
    public partial class v_order : Form
    {
        #region variabls
        string kk = "%%";
        readonly string connectionString;
        SqlConnection connection;
        bool flag = false;
        int userId = int.Parse(Form1.vendoridSelected);
        int goodId;
        int order_id;
        int gID;
        decimal total;
        string sell_price;
        float alltotal = 0;
        readonly DateTime today = DateTime.Now.Date;
        readonly int[] good_id = new int[500];
        readonly int[] good_ammount = new int[500];
        int pt = 0;
        #endregion
        public v_order()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
            sell.Enabled = false;
        }

        #region functions 
        private void newOrder()
        {
            String quary = "insert into v_orders VALUES (@userId,null,@today)";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@userId", userId);
                command.Parameters.AddWithValue("@today", today);

                command.ExecuteNonQuery();
            }
            string sql = "SELECT TOP 1 * FROM v_orders ORDER BY v_order_id DESC";
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        order_id = int.Parse(reader["v_order_id"].ToString());
                    }
                    reader.Close();
                }
            }
            orderNum.Text = order_id.ToString();
        }
        private void orderData()
        {
            String quary = "select v_goods_id as [#],goods.name as [إسم الصنف] ,b_amount as [كمية] , b_price as [الوحده] , b_total as [اجمالى]  from Buy join v_goods on b_good_id = v_goods_id join goods on Id = good_id where b_order_id = @order_id and vendor_id = @userId ";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@order_id", order_id);
                command.Parameters.AddWithValue("@userId", userId);
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView1.DataSource = goods_info;
            }
        }
        private void AddToOrders()
        {
            String quary = "update v_orders set total_buy = @allTotal where v_order_id = @order_Id; update vendors set v_money = v_money + @allTotal where vendor_id = @userId";
            if (allTotaltxt.Text == "0")
            {
                MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
            }
            else
            {
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@allTotal", float.Parse(allTotaltxt.Text));
                    command.Parameters.AddWithValue("@order_Id", order_id);
                    command.Parameters.AddWithValue("@userId", userId);
                    command.ExecuteNonQuery();
                }
                //chk();
                flag = true;
                MessageBox.Show("تم حفظ الفاتورة رقم  " + order_id, "عملية ناجحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }


        }
        private void chk()
        {
            String quary = "insert into v_order (vendor_id , total) values (@userId , @allTotal)";
            try
            {
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@allTotal", float.Parse(allTotaltxt.Text));
                    command.Parameters.AddWithValue("@userId", userId);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {

                String sql = String.Concat("update  logs set total =  (select sum(total_price) from orders where orders.userId = ", userId, "  group by userId) where user_Id = ", userId);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
        }
        
        private void select_good(ListBox l)
        {
            String quary = String.Concat("select * from goods where id =", l.SelectedValue);
            using (connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(quary, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        pricetxt.Text = reader["buy_price"].ToString();
                        selltxt.Text = reader["sell_price"].ToString();
                        sell_price = pricetxt.Text;
                        avtxt.Text = reader["amount"].ToString();
                        //amount.Maximum = int.Parse(avtxt.Text);
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
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                rslt.DisplayMember = "type";
                rslt.ValueMember = "type";
                rslt.DataSource = goods_info;
            }
        }
        private void findalpha(string type, ListBox rslt)
        {
            String quary = String.Concat("SELECT SUBSTRING(name, 1, 1) As a from goods where kind like N'", type, "' group by SUBSTRING(name, 1, 1)");
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                rslt.DisplayMember = "a";
                rslt.ValueMember = "a";
                rslt.DataSource = goods_info;
            }
        }

        private void typeChecked(object sender, EventArgs e)
        {
            if (r0.Checked)
            {
                findtypes("%%", typeList);
                kk = "%%";
                findalpha("%%", alpha);
                r1.ForeColor = r2.ForeColor = r3.ForeColor = Color.Black;
                r0.ForeColor = Color.Red;
            }
            if (r1.Checked)
            {
                kk = "أجهزة كهربائية";
                findtypes("أجهزة كهربائية", typeList);
                findalpha("أجهزة كهربائية", alpha);
                r0.ForeColor = r2.ForeColor = r3.ForeColor = Color.Black;
                r1.ForeColor = Color.Red;
            }
            if (r2.Checked)
            {
                kk = "أدوات منزلية";
                findtypes("أدوات منزلية", typeList);
                findalpha("أدوات منزلية", alpha);
                r0.ForeColor = r1.ForeColor = r3.ForeColor = Color.Black;
                r2.ForeColor = Color.Red;
            }
            if (r3.Checked)
            {
                kk = "بلاستيك";
                findtypes("بلاستيك", typeList);
                findalpha("بلاستيك", alpha);
                r0.ForeColor = r1.ForeColor = r2.ForeColor = Color.Black;
                r3.ForeColor = Color.Red;
            }
        }
        #endregion

        private void Order_Load(object sender, EventArgs e)
        {
            userLabe.Text = Form1.vendornameSelected;
            idLabel.Text = Form1.vendoridSelected;
            newOrder();
            findtypes("%%", typeList);
            findalpha("%%", alpha);

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
                if (Regex.IsMatch(pricetxt.Text, "^[0-9]+$") | pricetxt.Text == "0")
                {
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
            //try
            //{
                sell.Enabled = true;
                alltotal = alltotal + float.Parse(totaltxt.Text);
                allTotaltxt.Text = alltotal.ToString();
                String q = "insert into buy (b_order_id,b_good_id,b_amount,b_total,b_price) VALUES (@order_id , @goodId , @amount,@total_price,@buy_price);";

                //insert into v_goods values (@userId ,@goodId , @buy_price,@amount )
                String quary = "update goods set buy_price = @buy_price ,sell_price = @sell_price, amount = amount + @amount where Id = @goodId  ;if EXISTS  (select * from v_goods where vendor_id = @userId and good_id = @goodId) update v_goods set v_price = @buy_price ,v_amount = @amount where vendor_id =  @userId and good_id = @goodId ;if not EXISTS  (select * from v_goods where vendor_id = @userId and good_id = @goodId) insert into v_goods values (@userId ,@goodId , @buy_price,@amount ); ";
                if (pricetxt.Text == "" || amount.Value == 0)
                {
                    MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
                }
                else
                {
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand cmd = new SqlCommand(quary, connection))
                    {
                        connection.Open();
                        cmd.Parameters.AddWithValue("@userId", userId);
                        cmd.Parameters.AddWithValue("@order_id", order_id);
                        cmd.Parameters.AddWithValue("@goodId", goodId);
                        cmd.Parameters.AddWithValue("@buy_price", float.Parse(pricetxt.Text));
                        cmd.Parameters.AddWithValue("@sell_price", float.Parse(selltxt.Text));
                        cmd.Parameters.AddWithValue("@amount", int.Parse(amount.Value.ToString()));
                        cmd.Parameters.AddWithValue("@total_price", float.Parse(totaltxt.Text));
                        cmd.ExecuteNonQuery();
                    }
                    string sql = "SELECT TOP 1 * FROM v_goods where vendor_id = @userId and good_id = @goodId ORDER BY v_goods_id DESC";
                    using (connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        using (SqlCommand command = new SqlCommand(sql, connection))
                        {
                            command.Parameters.AddWithValue("@userId", userId);
                            command.Parameters.AddWithValue("@goodId", goodId);
                            SqlDataReader reader = command.ExecuteReader();
                            while (reader.Read())
                            {

                                gID = int.Parse(reader["v_goods_id"].ToString());
                            }
                            reader.Close();
                        }
                    }
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(q, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@order_id", order_id);
                        command.Parameters.AddWithValue("@goodId", gID);
                        command.Parameters.AddWithValue("@buy_price", float.Parse(pricetxt.Text));
                        command.Parameters.AddWithValue("@amount", int.Parse(amount.Value.ToString()));
                        command.Parameters.AddWithValue("@total_price", float.Parse(totaltxt.Text));
                        command.ExecuteNonQuery();

                    }


                    orderData();
                    good_id[pt] = goodId;
                    good_ammount[pt] = int.Parse(amount.Value.ToString());
                    pt += 1;

                }
                counter.Text = "عدد الأصناف : " + (dataGridView1.Rows.Count - 1).ToString();



                amount.Value = 0;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.ToString());
            //}

        }
        private void Sell_Click(object sender, EventArgs e)
        {
            AddToOrders();
        }
        private void Del_Click(object sender, EventArgs e)
        {
            string sql = "delete from buy where b_order_id=@order_id";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(sql, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@order_Id", order_id);

                command.ExecuteNonQuery();
            }
            for (int i = 0; i < pt; i++)
            {
                string q = " update goods set  amount = amount - @back_amount where Id = @good_id ; ";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(q, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@good_id", good_id[i]);
                    command.Parameters.AddWithValue("@back_amount", good_ammount[i]);
                    command.ExecuteNonQuery();
                }
            }
            flag = true;

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
                            String q = " update v_goods set v_amount = v_amount - @amount where v_goods_id = @vGID ; update goods set amount = amount-@amount from v_goods join goods on Id = good_id where v_goods_id =@vGID ; delete from Buy where b_good_id = @vGID and b_order_id = @order_id";
                            using (connection = new SqlConnection(connectionString))

                            using (SqlCommand command = new SqlCommand(q, connection))
                            {
                                connection.Open();
                                command.Parameters.AddWithValue("@vGID", row.Cells[0].Value);
                                command.Parameters.AddWithValue("@order_id", order_id);
                                command.Parameters.AddWithValue("@amount", row.Cells[2].Value);
                                command.ExecuteNonQuery();

                            }
                            alltotal -= int.Parse(row.Cells[4].Value.ToString());
                            allTotaltxt.Text = alltotal.ToString();

                            dataGridView1.Rows.Remove(row);

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
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    prdList.DisplayMember = "name";
                    prdList.ValueMember = "id";
                    prdList.DataSource = goods_info;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void Btnnew_prd_Click(object sender, EventArgs e)
        {
            
            addproduct addproduct = new addproduct();
            var x = addproduct.ShowDialog(this);
            if (x.ToString() == "OK")
            {
               
                r0.Checked = true;
            }
            else
            {

            }

            
        }

        private void TypeGbox_Enter(object sender, EventArgs e)
        {

        }

        private void V_order_FormClosing(object sender, FormClosingEventArgs e)
        {
            String quary = "alter table Buy nocheck constraint all ;delete from  v_orders where total_buy IS NULL ;alter table Buy check constraint all ";

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }

            if(flag == false)
            {
                string sql = "delete from buy where b_order_id=@order_id";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@order_Id", order_id);

                    command.ExecuteNonQuery();
                }
                for (int i = 0; i < pt; i++)
                {
                    string q = " update goods set  amount = amount - @back_amount where Id = @good_id ; ";
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(q, connection))
                    {
                        connection.Open();
                        command.Parameters.AddWithValue("@good_id", good_id[i]);
                        command.Parameters.AddWithValue("@back_amount", good_ammount[i]);
                        command.ExecuteNonQuery();
                    }
                }
            }

        }

        private void Selltxt_TextChanged(object sender, EventArgs e)
        {
            if (selltxt.Text != "")
            {
                if (Regex.IsMatch(selltxt.Text, "^[0-9]+$") | selltxt.Text == "0")
                {
                   
                }
                else
                {
                    selltxt.Text = sell_price;
                }
            }
        }

        private void Selltxt_MouseClick(object sender, MouseEventArgs e)
        {
            selltxt.Focus();
            selltxt.SelectAll();
        }

        private void Alpha_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                String quary = String.Concat("select type  from goods where type like N'", alpha.SelectedValue, "%' and kind like N'",kk, "' group by type");
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    DataTable goods_info = new DataTable();
                    adapter.Fill(goods_info);
                    typeList.DisplayMember = "type";
                    typeList.ValueMember = "type";
                    typeList.DataSource = goods_info;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}

