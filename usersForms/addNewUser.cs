using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace allN1.usersForms
{
    public partial class addNewUser : Form
    {
        public addNewUser()
        {
            InitializeComponent();
        }

        private void AddNewUser_Load(object sender, EventArgs e)
        {
            sqlcmd.AutoComplete(txtuser_add_new, "SELECT address FROM users");
            sqlcmd.AutoComplete(txtuser_new, "SELECT name FROM users");

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            int numberOfRecords = 0;
            List<string> Parameters = new List<string>()
                    {
                        "@name","@address","@phone","@mony"

                    };
            List<string> txtBox = new List<string>()
                    {
                        txtuser_new.Text,txtuser_add_new.Text,txtuser_phone_new.Text,txtuser_mony_new.Text
                    };
            try
            {
                String qqq = "if not EXISTS (SELECT name FROM users WHERE name = @name) begin insert into users (name,address,phone,mony,lastPayment) VALUES (@name , @address , @phone,@mony , null);insert into logs values ((select Id from users where name =@name) ,@mony) end";
                string quary = @"BEGIN TRANSACTION;
 insert or IGNORE into users (name,address,phone,mony,lastPayment) 
 VALUES (@name , @address , @phone,@mony , null);
 insert or IGNORE into logs values ((select Id from users where name =@name) ,@mony);
 END;";

                if (txtuser_new.Text == "" || txtuser_phone_new.Text == "" || txtuser_add_new.Text == "" || txtuser_mony_new.Text == "")
                {
                    MessageBox.Show("تأكد من صحه البيانات وقم بإدخال جميع البيانات");
                }
                else
                {
                    numberOfRecords = sqlcmd.addNewRecord(quary, Parameters, txtBox);
                    if (numberOfRecords == -1)
                    {

                        time_now.Text = "هذا العميل موجود من قبل ولا يمكن إضافته";
                        txtuser_new.SelectAll();
                        txtuser_new.Focus();
                    }
                    else
                    {

                        time_now.Text = "عملية ناجحه : تم إضافة " + txtuser_new.Text + " إلى قاعدة البيانات ";
                        txtuser_new.Text = "";
                        txtuser_add_new.Text = "";

                        txtuser_phone_new.Text = "";
                        txtuser_mony_new.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            sqlcmd.AutoComplete(txtuser_new, "SELECT name FROM users");
            sqlcmd.AutoComplete(txtuser_add_new, "SELECT address FROM users");
        }

        private void Txtuser_mony_new_KeyPress(object sender, KeyPressEventArgs e)
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

        private void Txtuser_phone_new_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtuser_phone_new_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void Txtuser_mony_new_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
