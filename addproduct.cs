using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1
{
    public partial class addproduct : Form
    {
        readonly string connectionString;
        SqlConnection connection;
        string txtKind_new = "";

        public addproduct()
        {
            InitializeComponent();
            this.AcceptButton = button1;
            this.button1.DialogResult = DialogResult.OK;
            connectionString = ConfigurationManager.ConnectionStrings["allN1.Properties.Settings.DBConnectionString"].ConnectionString;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           

            if (prdname.Text != "")
            {
                if (txtKind_new != "")
                {
                    Add();

                    
                }
                else
                {
                    this.DialogResult = DialogResult.None;
                    MessageBox.Show(this, "برجاء إختيار نوع الصنف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                this.DialogResult = DialogResult.None;
                MessageBox.Show(this, "إدخال إسم الصنف", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }



            
            
        }

        private void KindChanged(object sender, EventArgs e)
        {
            if (r1.Checked)
            {
                txtKind_new = "أجهزة كهربائية";
                r2.ForeColor = r3.ForeColor = Color.Black;
                r1.ForeColor = Color.Red;
            }
            if (r2.Checked)
            {
                txtKind_new = "أدوات منزلية";
                r1.ForeColor = r3.ForeColor = Color.Black;
                r2.ForeColor = Color.Red;
            }
            if (r3.Checked)
            {
                txtKind_new = "بلاستيك";
                r1.ForeColor = r2.ForeColor = Color.Black;
                r3.ForeColor = Color.Red;
            }
        }

        private void Add()
        {
            int numberOfRecords = 0;
            String quary = "if not exists  (Select name from goods where name = @name) begin insert into goods VALUES (@name , @type , @sell , @buy , @amount , @kind)  insert into v_goods (vendor_id , good_id,v_price,v_amount) select  TOP 1 1,Id,buy_price,amount from goods ORDER BY id DESC  end";
            using (connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(quary, connection))
            {
                connection.Open();
                command.Parameters.AddWithValue("@name", prdname.Text);
                command.Parameters.AddWithValue("@type", prdname.Text.Split(' ')[0]);
                command.Parameters.AddWithValue("@sell", "0");
                command.Parameters.AddWithValue("@buy", "0");
                command.Parameters.AddWithValue("@amount", "0");
                command.Parameters.AddWithValue("@kind", txtKind_new);
                numberOfRecords = command.ExecuteNonQuery();
            }
            if (numberOfRecords == -1)
            {
                this.DialogResult = DialogResult.None;
                string msg = "هذا الصنف موجود من قبل ولا يمكن إضافته";
                string caption = "خطأ";
                MessageBox.Show(this, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                prdname.SelectAll();
                prdname.Focus();
            }
            else
            {
                string msg = "تم إضافة صنف جديد";
                string caption = "عملية ناجحة";
                MessageBox.Show(this, msg, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Addproduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.DialogResult == DialogResult.None)
                e.Cancel = true;
        }
    }
}
