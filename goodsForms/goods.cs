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
using System.Data.SQLite;

namespace allN1
{
    public partial class goods : Form
    {
        public static int goodslistSelectedValue;
        public static int amount;
        public static float sell;
        public static string goodName;
        public static int goodID;
        readonly DateTime today = DateTime.Now;
        readonly string connectionString;
        SQLiteConnection connection;
        public string ConnectionString => connectionString;
        public goods()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["dataB"].ConnectionString;
        }

        private void Goods_Load(object sender, EventArgs e)
        {
            Viewgoods();
        }
        private void Viewgoods()
        {
            String quary = "select Id,name from goods";
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                goodslist.DisplayMember = "name";
                goodslist.ValueMember = "id";
                goodslist.DataSource = goods_info;

            }
        }

        private void Goodslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            String quary = String.Concat("select *  from goods where goods.id = ", goodslist.SelectedValue);
            using (connection = new SQLiteConnection(connectionString))
            using (SQLiteCommand command = new SQLiteCommand(quary, connection))
            using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
            {
                DataTable goods_info = new DataTable();
                adapter.Fill(goods_info);
                DataRow[] rows = goods_info.Select();
                goodslistSelectedValue =int.Parse(goodslist.SelectedValue.ToString());
                txtproduct.Text = rows[0]["name"].ToString();
                goodName = rows[0]["name"].ToString();
                txtType.Text = rows[0]["type"].ToString();
                txtAmount.Text = rows[0]["amount"].ToString();
                txtSell.Text = rows[0]["sell_price"].ToString();
                txtBuy.Text = rows[0]["buy_price"].ToString();
                txtType2.Text = rows[0]["kind"].ToString();
                amount = int.Parse(txtAmount.Text);
                sell = float.Parse(txtSell.Text);
                //vendortxt.Text = rows[0]["v_name"].ToString();

            }
            String qq = String.Concat("select sum(amount) as ss from Sells where good_id = ", goodslist.SelectedValue);
            DataTable dt =  sqlcmd.loadData(qq);
            DataRow[] row = dt.Select();
            sell_amount_txt.Text = row[0]["ss"].ToString();
            if (sell_amount_txt.Text == ""  || sell_amount_txt.Text =="0")
            {
                sell_amount_txt.Text = "0";
                button5.Enabled = true;
                button4.Enabled = false;
            }
            else
            {
                button5.Enabled = false;
                button4.Enabled = true;
            }
            if (amount == 0)
            {
                btn_sel.Enabled = false;
            }
            else
            {
                btn_sel.Enabled = true;
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            _ = editGood();
        }
        private async Task editGood()
        {
            try
            {
                String quary = String.Concat("update goods set name =@name , type = @type ,sell_price = @sell ,buy_price = @buy , amount = @amount  , kind = @kind where Id = ", goodslist.SelectedValue);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))

                {
                    connection.Open();
                    command.Parameters.AddWithValue("@name", txtproduct.Text);
                    command.Parameters.AddWithValue("@type", txtType.Text);
                    command.Parameters.AddWithValue("@sell", txtSell.Text);
                    command.Parameters.AddWithValue("@buy", txtBuy.Text);
                    command.Parameters.AddWithValue("@amount", txtAmount.Text);
                    command.Parameters.AddWithValue("@kind", txtType2.Text);
                    command.ExecuteNonQuery();

                }
                status.Text = "  تم تعديل بيانات " + txtproduct.Text;
                int s = goodslist.SelectedIndex;
                Viewgoods();
                goodslist.SetSelected(s, true);
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                status.Text = "الحالة : متصل";


            }
            catch (Exception)
            {
                
                status.Text = "حدثت مشكلةاثناء تعديل المنتج برجاء التواصل مع المبرمج ";


            }



        }

        private void Button5_Click(object sender, EventArgs e)
        {
            _ = del_goodAsync();


        }
        private async Task del_goodAsync()
        {
            try
            {
                String quary = String.Concat("delete from sells where good_id =", goodslist.SelectedValue, ";delete  from goods where Id = ", goodslist.SelectedValue);
                using (connection = new SQLiteConnection(connectionString))
                using (SQLiteCommand command = new SQLiteCommand(quary, connection))

                {
                    connection.Open();

                    command.ExecuteNonQuery();
                }

               
                status.Text = "تم حذف  " + txtproduct.Text + " من قاعدة البيانات";
                int ss = goodslist.SelectedIndex;
                Viewgoods();
                goodslist.SetSelected(ss, true);
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                status.Text = "الحالة : متصل";


            }
            catch (Exception)
            {
                
                status.Text = "لا يمكن حذف الصنف لأنه مباع قبل ذلك";
                int milliseconds = 3000;
                await Task.Delay(milliseconds);
                status.Text = "الحالة : متصل";
   
            }
        }

        private void Txtuer_search_TextChanged(object sender, EventArgs e)
        {
            try
            {

                String quary = "select Id,name  from goods where name like @name";
                goodslist.DisplayMember = "name";
                goodslist.ValueMember = "id";
                goodslist.DataSource = sqlcmd.searchbyName(quary,txt_search);
                //using (connection = new SQLiteConnection(connectionString))
                //using (SQLiteCommand command = new SQLiteCommand(quary, connection))
                //using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(command))
                //{
                //    DataTable goods_info = new DataTable();
                //    adapter.Fill(goods_info);
                //    goodslist.DisplayMember = "name";
                //    goodslist.ValueMember = "id";
                //    goodslist.DataSource = goods_info;
                //}
            }
            catch
            {

            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            GoodSellInfo g_info = new GoodSellInfo();
            g_info.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            addNewGood a = new addNewGood();
            a.ShowDialog(this);
            Viewgoods();

        }

        private void Btn_sel_Click(object sender, EventArgs e)
        {
            main.fromGoods = true;
            goodID = int.Parse(goodslist.SelectedValue.ToString());
            sellNow sNow = new sellNow();
            sNow.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            goodsForms.goodSelect g_select = new goodsForms.goodSelect();
            g_select.ShowDialog();
        }

        private void TxtSell_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtBuy_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
