using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace allN1
{
    public partial class vendor_bill : Form
    {
        readonly string connectionString;
        SqlConnection connection;
        //bool f = false;
        public vendor_bill()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }
        private void ViewOrdersIds()
        {
            try
            {
                String quary = "select v_orders.vendor_id,vendors.v_name , v_order_id,date,total_buy from v_orders join vendors on vendors.vendor_id = v_orders.vendor_id where v_orders.vendor_id = "+ int.Parse(txtid.Text);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
            String quary = "select goods.name as [إسم الصنف] ,b_amount as [الكمية] , b_price as [سعر الوحده] , b_total as [السعر الكلى]  from Buy join v_goods on b_good_id = v_goods_id join goods on Id = good_id where b_order_id = @order_id and vendor_id = @userId ";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            using (SqlDataAdapter adapter = new SqlDataAdapter(command))
            {
                command.Parameters.AddWithValue("@order_id", billList.SelectedValue);
                command.Parameters.AddWithValue("@userId", int.Parse(txtid.Text));
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                dataGridView1.DataSource = goods_info;
            }


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
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
            MessageBox.Show("إنتظر النسخه القادمة");
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

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
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

            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
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
                    using (connection = new SqlConnection(connectionString))
                    using (SqlCommand command = new SqlCommand(quary, connection))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
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
