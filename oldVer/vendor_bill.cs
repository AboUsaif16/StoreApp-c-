using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace allN1
{
    public partial class vendor_bill : Form
    {
        public static string v_Cd;
        public static string v_billN = "";
        public static string v_gName = "";
        public static string v_gID = "";
        public static string v_sDate = "";
        public static string v_price = "";
        public static string v_tot = "";
        public static string v_sAmount = "";
        public static string vid = "";

        readonly string connectionString;
        SQLiteConnection connection;
        //bool f = false;
        public vendor_bill()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }
        private void ViewOrdersIds()
        {
            try
            {
                String quary = "select v_orders.vendor_id,vendors.v_name , v_order_id,date,total_buy from v_orders join vendors on vendors.vendor_id = v_orders.vendor_id where v_orders.vendor_id = "+ int.Parse(txtid.Text);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    DataTable bills_info = new DataTable();
                    adapter.Fill(bills_info);
                    billList.DisplayMember = "v_order_id";
                    billList.ValueMember = "v_order_id";
                    billList.DataSource = bills_info;
                    // f = true;
                }
            }
            catch
            {
                MessageBox.Show("ViewOrdersIds error");
            }
        }

        private void ViewOrderInfo()
        {
            String quary = "select b_id as [#],goods.name as [إسم الصنف] ,b_amount as [الكمية] , b_price as [سعر الوحده] , b_total as [السعر الكلى] ,  goods.Id from Buy join v_goods on b_good_id = v_goods_id join goods on Id = good_id where b_order_id = @order_id and vendor_id = @userId ";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                command.Parameters.AddWithValue("@order_id", billList.SelectedValue);
                command.Parameters.AddWithValue("@userId", int.Parse(txtid.Text));
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView1.DataSource = goods_info;
            }
            this.dataGridView1.Columns[0].Visible = false;
            this.dataGridView1.Columns[5].Visible = false;

        }

        private void Vendor_bill_Load(object sender, EventArgs e)
        {
            txtid.Text = Form1.vendoridSelected;
            txtvendor.Text = Form1.vendornameSelected;
            this.Text = "سجل فواتير  : " + txtvendor.Text;
            ViewOrdersIds();

        }

        private void BillList_SelectedIndexChanged(object sender, EventArgs e)
        {
           // if (f)
            {
                String quary = "select total_buy  , (CONVERT(VARCHAR(10),date , 103)) as date from v_orders where v_order_id = " + billList.SelectedValue;
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    DataTable bill_info = new DataTable();
                    adapter.Fill(bill_info);
                    DataRow[] rows = bill_info.Select();
                    txttotal.Text = rows[0]["total_buy"].ToString();
                    txtdate.Text = rows[0]["date"].ToString();
                }
                ViewOrderInfo();
            }
            
        }

        private void Btn_backinfo_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "هل تريد إسترداد الصنف؟", "تحذير", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                try
                {
                    int x = dataGridView1.CurrentCell.RowIndex;
                    v_Cd = dataGridView1[0, x].Value.ToString();
                    v_gName = dataGridView1[1, x].Value.ToString();
                    v_sAmount = dataGridView1[2, x].Value.ToString();
                    v_price = dataGridView1[3, x].Value.ToString();
                    v_tot = dataGridView1[4, x].Value.ToString();
                    v_gID = dataGridView1[5, x].Value.ToString();
                    v_sDate = txtdate.Text;
                    v_billN = billList.SelectedValue.ToString();
                    vid = txtid.Text;
                    venGoodRet gRet = new venGoodRet();
                    gRet.ShowDialog(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            clean_v();
            ViewOrdersIds();

        }

        private void Btn_del_Click(object sender, EventArgs e)
        {

            DialogResult res = MessageBox.Show("هل تريد حذف الفاتورة؟ يرجى العلم ان الأصناف لن يتم حذفها من قاعدة البيانات", "تأكيد", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            if (res == DialogResult.OK)
            {
                MessageBox.Show("تم الحذف");
                delete();
                clean_v();
            }
            if (res == DialogResult.Cancel)
            {


            }
        }
        private void delete()
        {
            String quary = "alter table Buy nocheck constraint all ;delete from  v_orders where v_order_id = @order_id ;alter table Buy check constraint all ";

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            {
                connection.Open();

                command.Parameters.AddWithValue("@order_id", billList.SelectedValue);


                command.ExecuteNonQuery();
            }

            ViewOrdersIds();

            dataGridView1.DataSource = null;
        }
        private void clean_v()
        {
            String quary = "alter table Buy nocheck constraint all ;delete from  v_orders where total_buy IS NULL ;alter table Buy check constraint all ";

            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
            }


        }

        private void Txt_search_TextChanged(object sender, EventArgs e)
        {
            if (NumChk(txt_search))
            {
                try
                {
                    String quary = "select * from v_orders where vendor_id = " + int.Parse(txtid.Text) + " and v_order_id = " + int.Parse(txt_search.Text);
                    using (connection = new SQLiteConnection(connectionString))
                    using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                    {
                        DataTable bills_info = new DataTable();
                        adapter.Fill(bills_info);
                        billList.DisplayMember = "v_order_id";
                        billList.ValueMember = "v_order_id";
                        billList.DataSource = bills_info;

                    }
                }
                catch
                {
                    ViewOrdersIds();
                }
            }
            else
            {
                ViewOrdersIds();
            }
        }
        private bool NumChk(TextBox t)
        {
            if (!(Regex.IsMatch(t.Text, "^[0-9]+$")))
            {
                t.Text = "";
                t.SelectAll();
                return false;
            }
            else
            {
                return true;
            }
        }

        private void Txt_search_Enter(object sender, EventArgs e)
        {
            txt_search.Clear();
            txt_search.Focus();
            txt_search.ForeColor = Color.DarkRed;
        }
    }
}
