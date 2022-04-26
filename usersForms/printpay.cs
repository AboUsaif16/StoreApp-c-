using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Data.SQLite;


namespace allN1
{
    public partial class printpay : Form
    {
        readonly string connectionString;
        SQLiteConnection connection;
        public printpay()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void Printpay_Load(object sender, EventArgs e)
        {

        }


        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                String quary = "select payment , strftime('%d/%m/%Y',date) as d ,name from logs_info join users on user_id = users.Id where logs_info.Id =" + int.Parse(id.Text);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                {
                    DataTable payinfo = new DataTable();
                    adapter.Fill(payinfo);
                    DataRow[] rows = payinfo.Select();
                    user.Text = rows[0]["name"].ToString();
                    pay.Text = rows[0]["payment"].ToString();
                    date.Text = rows[0]["d"].ToString();



                }
                button1.Visible = true;
            }
            catch
            {
                MessageBox.Show("تأكد من رقم الإيصال");
                id.SelectAll();
                id.Focus();
            }
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            time_now.Text = "جارى إنشاء الإيصال";
            string dd = date.Text.Replace("/", "-");
            string name_of_payment = "/payments/" + dd + "/" + user.Text + ".docx";
            // Specify the directory you want to manipulate.
            string path = Application.StartupPath + "/payments/" + dd;
            try
            {
                // Determine whether the directory exists.
                if (!Directory.Exists(path))
                {
                    DirectoryInfo di = Directory.CreateDirectory(path);
                }
            }
            catch
            {
                time_now.ForeColor = Color.Red;
                time_now.Text = e.ToString();
            }

            printReport.print(Application.StartupPath + "/payment2.docx", Application.StartupPath + name_of_payment,date.Text,pay.Text,user.Text,null);
            time_now.Text = "الحالة : متصل";
            button1.Visible = false;
            user.Text = pay.Text = date.Text = id.Text = "";
        }
        
    }
}
