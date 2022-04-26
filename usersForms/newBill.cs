using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1.usersForms
{
    public partial class newBill : Form
    {
        decimal money;
        float sell_p = 0;
        int i = 0;
        int[] good_id = new int[26];
        int[] good_amount = new int[26];
        float[] good_price = new float[26];
        float sum = 0;

        public newBill()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void SelectGood_Click(object sender, EventArgs e)
        {
            if (i < 27)
            {
                try
                {
                    goodsForms.goodSelect g_select = new goodsForms.goodSelect();
                    g_select.ShowDialog();
                    selectedGoodName.Text = goodsForms.goodSelect.goodName;
                    good_id[i] = goodsForms.goodSelect.goodId;
                    List<string> p = new List<string>() { "sell_price", "amount" };
                    List<TextBox> txt = new List<TextBox>() { txtSell, goodAmountLable };
                    sqlcmd.rowData("select sell_price , amount from goods where id = " + good_id[i], p, txt);
                    sell_p = float.Parse(txtSell.Text);
                    txtAmount.Maximum = int.Parse(goodAmountLable.Text);
                    good_info.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("الفاتورة مكتملة");
            }
            

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

        private void TxtSell_TextChanged(object sender, EventArgs e)
        {
            if (txtSell.Text == "")
            {
                txtSell.Text = sell_p.ToString();
            }
            money = txtAmount.Value * decimal.Parse(txtSell.Text);
            totalLable.Text = money.ToString();

        }

        private void NewBill_Load(object sender, EventArgs e)
        {
            userLable.Text = users.usernameSelected;
            billNumberLable.Text += sqlcmd.getbillid().ToString();

        }

        private void TxtAmount_ValueChanged(object sender, EventArgs e)
        {
            money = txtAmount.Value * decimal.Parse(txtSell.Text);
            totalLable.Text = money.ToString();
            if(txtAmount.Value > 0)
            {
                addToBill.Enabled = true;
            }
            else
            {
                addToBill.Enabled = false;
            }

        }

        private void AddToBill_Click(object sender, EventArgs e)
        {
            if (i < 26)
            {
                if (good_id[i] == 0)
                {
                    MessageBox.Show("cc");
                }
                else
                {
                    sum += float.Parse(totalLable.Text);
                    good_amount[i] = Convert.ToInt32(txtAmount.Value);
                    good_price[i] = float.Parse(txtSell.Text);
                    bill.Rows.Add(good_id[i], selectedGoodName.Text, txtSell.Text, txtAmount.Value, totalLable.Text);
                    totalBill.Text = sum.ToString();
                    i++;
                    _i.Text = i.ToString();
                    selectedGoodName.Text = "";
                    goodAmountLable.Text = "";
                    txtSell.Text = "";
                    txtAmount.Value = 0;
                    good_info.Enabled = false;

                }
                
            }
            else
            {
                MessageBox.Show("الفاتورة مكتملة");
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            addNewGood newGood = new addNewGood();
            newGood.ShowDialog();
        }

        private void SelectedGoodName_Click(object sender, EventArgs e)
        {
            
        }

        private void SelectedGoodName_TextChanged(object sender, EventArgs e)
        {
            if (selectedGoodName.Text != "")
            {
                txtAmount.Enabled = true;
                txtSell.Enabled = true;
            }
            else
            {
                txtAmount.Enabled = false;
                txtSell.Enabled = false;
            }
        }

        private void Bill_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            

        }

        private void Bill_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            i--;
            _i.Text = i.ToString();
            int r_index = bill.CurrentRow.Index;
            for (int j = r_index; j < 26; j++)
            {
                good_id[j] = good_id[j + 1];
                good_price[j] = good_price[j + 1];
                good_amount[j] = good_amount[j + 1];

            }
            for (int j = 0; j < 27; j++)
                Console.WriteLine(good_id[j].ToString() + " : " + good_price[j].ToString() + " : " + good_amount[j].ToString());
        }
    }
}
