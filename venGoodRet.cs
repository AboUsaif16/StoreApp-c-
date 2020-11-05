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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1
{
    public partial class venGoodRet : Form
    {
        string sellID = vendor_bill.v_Cd;
        string id = vendor_bill.vid;
        readonly string connectionString;
        System.Data.SqlClient.SqlConnection connection;
        public venGoodRet()
        {
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
            InitializeComponent();
        }

        private void VenGoodRet_Load(object sender, EventArgs e)
        {
            billNumber.Text = vendor_bill.v_billN;
            goodName.Text =   vendor_bill.v_gName;
            goodId.Text =     vendor_bill.v_gID;
            sellDate.Text =   vendor_bill.v_sDate;
            sellAmount.Text = vendor_bill.v_sAmount;
            price.Text =      vendor_bill.v_price;
            total.Text =      vendor_bill.v_tot;
        }

        private void RetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int m = int.Parse(price.Text) * int.Parse(retAmount.Text);
                String quary = "update goods set amount = amount - @back where Id = @Id";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@Id", int.Parse(goodId.Text));
                    command.ExecuteNonQuery();
                }

                String quary1 = "update Buy set b_amount = b_amount - @back , b_total =(b_amount-@back)*b_price where b_id =@sellID ; delete from Buy where b_id = @sellID and b_amount = 0";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary1, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@sellID", sellID);
                    command.ExecuteNonQuery();
                }

                String quary2 = "update v_orders set total_buy = (select sum(b_total) from Buy where b_order_id = @orderID group by b_order_id) where v_order_id = @orderID ; delete from v_orders where v_order_id = @orderID and total_buy = 0";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary2, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@orderID", int.Parse(billNumber.Text));
                    command.ExecuteNonQuery();
                }

                String quary3 = string.Concat("update vendors set v_money = v_money - @mony where vendor_id = ", id);
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary3, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@mony", m);
                    command.ExecuteNonQuery();
                }
                MessageBox.Show("تم إسترجاع المنتج بنجاح");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void RetAmount_TextChanged(object sender, EventArgs e)
        {
            if (retAmount.Text != "")
            {
                if (Regex.IsMatch(retAmount.Text, "^[0-9]+$"))
                {
                    if (int.Parse(retAmount.Text) <= int.Parse(sellAmount.Text))
                    {
                        retBtn.Enabled = true;
                    }
                    else
                    {
                        retAmount.Text = "";
                        retBtn.Enabled = false;
                    }
                }
                else
                {

                    retAmount.Text = "";
                    retBtn.Enabled = false;
                }
            }
            else
            {
                retBtn.Enabled = false;
            }
        }
    }
}
