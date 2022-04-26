using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace allN1
{
    public partial class sellNow : Form
    {
        int avilable = goods.amount;
        decimal money = 0;
        decimal tot = 0;
        int u_id;
        int order_id = 0;
        int[] good_id = { goods.goodID };
        bool done = false;
        bool new_bill = true;
        float sell_p = 0;

        public sellNow()
        {
            InitializeComponent();
        }

        private void SellNow_Load(object sender, EventArgs e)
        {
            if (main.fromGoods)
            {
                selectGood.Visible = false;
                selectUser.Visible = true;
                goodNameLable.Text = goods.goodName;
                goodAmountLable.Text = avilable.ToString();
                sell_p = goods.sell;
                txtSell.Text = sell_p.ToString();

                txtAmount.Maximum = avilable;
            }
            else
            {
                selectGood.Visible = true;
                selectUser.Visible = false;
                userLable.Text = users.usernameSelected;
                u_id = int.Parse(users.useridSelected);
                order_id = sqlcmd.newOrder(u_id);
                new_bill = false;
                billNumberLable.Text += order_id.ToString();

            }



        }
        private void TxtAmount_ValueChanged(object sender, EventArgs e)
        {
            money = txtAmount.Value * decimal.Parse(txtSell.Text) - decimal.Parse(txtMoneyPaied.Text);
            remainLable.Text = money.ToString();
        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void TxtMoneyPaied_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtMoneyPaied.Text == "")
                {
                    txtMoneyPaied.Text = "0";
                }
                money = txtAmount.Value * decimal.Parse(txtSell.Text) - decimal.Parse(txtMoneyPaied.Text);
                remainLable.Text = money.ToString();
}
            catch
            {
                txtMoneyPaied.Text = "0";
                txtMoneyPaied.SelectAll();
            }
            
        }

        private void TxtSell_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtSell.Text == "")
                {
                    txtSell.Text = sell_p.ToString();
                }
                money = txtAmount.Value * decimal.Parse(txtSell.Text) - decimal.Parse(txtMoneyPaied.Text);
                remainLable.Text = money.ToString();
            }
            catch
            {
                txtSell.Text = sell_p.ToString();
            }
            
        }

        private void SelectUser_Click(object sender, EventArgs e)
        {
            usersForms.userSelect u_select = new usersForms.userSelect();
            u_select.ShowDialog();
            sellNowbtn.Enabled = true;
            userLable.Text = usersForms.userSelect.u_name;
            u_id = usersForms.userSelect.u_id;
            if (new_bill)
            {
                order_id = sqlcmd.newOrder(u_id);
                new_bill = false;
                billNumberLable.Text += order_id.ToString();
            }
            else
            {
                sqlcmd.updateOrderUserId(u_id, order_id);
            }



        }

        private void SellNow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (done == false)
            {
                MessageBox.Show("لم تتم عملية البيع");
                int[] amount = { Convert.ToInt32(txtAmount.Value) };
                sqlcmd.DeleteOrder(order_id, good_id, amount);
            }

        }

        private void SellNowbtn_Click(object sender, EventArgs e)
        {
            tot = txtAmount.Value * decimal.Parse(txtSell.Text);
            if (sqlcmd.AddOrder(tot, money, order_id, u_id))
            {

                sqlcmd.sellGood(order_id, good_id[0], decimal.Parse(txtSell.Text), Convert.ToInt32(txtAmount.Value), tot);
                MessageBox.Show("عملية ناجحة");
                done = true;
                this.Close();
            }
        }

        private void SelectGood_Click(object sender, EventArgs e)
        {
            goodsForms.goodSelect g_select = new goodsForms.goodSelect();
            g_select.ShowDialog();
            sellNowbtn.Enabled = true;
            goodNameLable.Text = goodsForms.goodSelect.goodName;
            good_id[0] = goodsForms.goodSelect.goodId;
            List<string> p = new List<string>() { "sell_price", "amount" };
            List<TextBox> txt = new List<TextBox>() { txtSell, goodAmountLable };
            sqlcmd.rowData("select sell_price , amount from goods where id = " + good_id[0], p, txt);
            sell_p = float.Parse(txtSell.Text);


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

        private void TxtMoneyPaied_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
