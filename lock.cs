using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1
{
    public partial class @lock : Form
    {
        readonly string connectionString;
        SqlConnection connection;

        public string ConnectionString => connectionString;
        public @lock()
        {

            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            //if (textBox1.Text != "1617")
            //{
            //    MessageBox.Show(this, "تأكد من ادخال كلمة المرور بشكل صحيح او قم بالإتصال على المبرمج");
            //    textBox1.SelectAll();
            //    textBox1.Focus();
            //    return;
            //}
            //this.Close();
        }

        private void lock_Load(object sender, EventArgs e)
        {
            int x = textBox1.Location.X + 190 - 30;
            int y = textBox1.Location.Y + 56;

            fixSql();
        }

        private void fixSql()
        {
            try
            {
                String quary = "ALTER TABLE users ADD lastPayment date null; ";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();
                   
                    command.ExecuteNonQuery();
                }
                quary = @"  UPDATE users 
                            SET users.lastPayment = s.ss
                            FROM users, (select max(date) as ss, user_id from logs_info  group by user_id)  s
                            WHERE users.Id = s.user_id";
                using (connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(quary, connection))

                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }
            }
            catch 
            {


            }

        } 


       

        private void lock_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ModifierKeys != Keys.Alt && ModifierKeys != Keys.F4)
            {
                return;
            }
            e.Cancel = true;
        }

        private void TextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void TextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                if (textBox1.Text != "1617")
                {
                    MessageBox.Show(this, "تأكد من ادخال كلمة المرور بشكل صحيح او قم بالإتصال على المبرمج");
                    textBox1.SelectAll();
                    textBox1.Focus();
                    return;
                }
                this.Close();
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button1_Click(object sender, EventArgs e)
        {

            BackupdatabaseAsync();
            Application.Exit();
        }



        private void  BackupdatabaseAsync()
        {
            //DateTime t = DateTime.Now;
            Directory.CreateDirectory("BackUp");
            // string file = Application.StartupPath + "/BackUp/AppDB"+t.ToString("dd-MM")+".bak";
            string file = Application.StartupPath + "/BackUp/AppDB.bak";
            file = file.Replace('\\', '/');
            // Check if file already exists. If yes, delete it.     
            if (File.Exists(file))
            {
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
 
                    this.Close();
                }

            }
        }
    }
}
