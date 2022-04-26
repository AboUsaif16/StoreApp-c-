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
using System.Data.SQLite;

namespace allN1
{
    public partial class goodReturn : Form
    {
        readonly string connectionString;
        SQLiteConnection connection;
        string sellID = bill_info.Cd;
        string id = bill_info.uid;
        public goodReturn()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void GoodReturn_Load(object sender, EventArgs e)
        {
            billNumber.Text = bill_info.billN;
            goodName.Text = bill_info.gName;
            goodId.Text = bill_info.gID;
            sellDate.Text = bill_info.sDate;
            sellAmount.Text = bill_info.sAmount;
            price.Text = bill_info.price;
            total.Text = bill_info.tot;
            

        }

        private void RetBtn_Click(object sender, EventArgs e)
        {
            try
            {
                int m = int.Parse(price.Text) * int.Parse(retAmount.Text);
                String quary = "update goods set amount = amount + @back where Id = @Id";
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@Id", int.Parse(goodId.Text));
                    command.ExecuteNonQuery();
                }

                String quary1 = "update Sells set amount = amount - @back , total_price =(amount-@back)*sell_price where Id =@sellID ; delete from Sells where Id = @sellID and amount = 0";
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary1, connection))
                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@sellID", sellID);
                    command.ExecuteNonQuery();
                }

                String quary2 = "update orders set total_price = (select sum(total_price) from Sells where order_id = @orderID group by order_id) where order_id = @orderID ; delete from orders where order_id = @orderID and total_price = 0";
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary2, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@back", int.Parse(retAmount.Text));
                    command.Parameters.AddWithValue("@orderID", int.Parse(billNumber.Text));
                    command.ExecuteNonQuery();
                }

                String quary3 = string.Concat("update users set mony = mony - @mony where Id = ", id);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary3, connection))
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
