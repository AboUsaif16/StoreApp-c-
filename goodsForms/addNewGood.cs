using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace allN1
{
    public partial class addNewGood : Form
    {

        public addNewGood()
        {
            InitializeComponent();

        }

        private void AddNewGood_Load(object sender, EventArgs e)
        {
            DataTable vendorDataTeble = sqlcmd.loadData("select vendor_id,v_name from vendors group by v_name,vendor_id");
            vendorCombo.DataSource = vendorDataTeble;
            vendorCombo.DisplayMember = "v_name";
            vendorCombo.ValueMember = "vendor_id";

            DataTable kindDataTeble = sqlcmd.loadData("select kind from goods group by kind");
            kindCombo.DataSource = kindDataTeble;
            kindCombo.DisplayMember = "kind";
            kindCombo.ValueMember = "kind";
            sqlcmd.AutoComplete(txtType_new, "SELECT type FROM goods");
            sqlcmd.AutoComplete(txtproduct_new, "SELECT name FROM goods");
        }
        private bool ChkInput()
        {
            try
            {
                if (txtproduct_new.Text == "" || txtBuy_new.Text == "0" || txtBuy_new.Text == "" || txtBuy_new.Text == "سعر الشراء" || txtSell_new.Text == "0" || txtSell_new.Text == "" || txtSell_new.Text == "سعر البيع" || txtAmount_new.Text == "0" || txtAmount_new.Text == "الكمية" || txtAmount_new.Text == "" || kindCombo.SelectedItem.ToString() == "" && (kindCombo.SelectedItem.ToString() != "أجهزة كهربائية" || kindCombo.SelectedItem.ToString() != "أدوات منزلية" || kindCombo.SelectedItem.ToString() != "بلاستيك"))
                {


                    MessageBox.Show("الرجاء التأكد من صحه البيانات", "خطأ");
                    return false;

                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("الرجاء التأكد من صحه البيانات\n" + ex.Message, "خطأ");
                return false;

            }

        }
        private void restInput()
        {
            txtproduct_new.Text = "";
            txtType_new.Text = "";
            txtSell_new.Text = "";
            txtBuy_new.Text = "";
            txtAmount_new.Text = "";
        }
        private void AddNewUser_Click(object sender, EventArgs e)
        {

            try
            {
                if (ChkInput())
                {

                    int numberOfRecords = 0;
                    String quary = @"BEGIN TRANSACTION;
 insert or IGNORE into goods (name,type,sell_price,buy_price,amount,kind) 
 VALUES (@name , @type , @sell , @buy , @amount , @kind);
 insert or IGNORE into v_goods (vendor_id , good_id,v_price,v_amount) 
 select  @v_id,Id,buy_price,amount from goods ORDER BY id DESC LIMIT 1;
 END;
 ";
                    List<string> Parameters = new List<string>()
                    {
                        "@name","@type","@sell","@buy","@amount","@kind","@v_id"

                    };
                    List<string> txtBox = new List<string>()
                    {
                        txtproduct_new.Text,
                        txtType_new.Text,
                        txtSell_new.Text,
                        txtBuy_new.Text,
                        txtAmount_new.Text,
                        kindCombo.SelectedValue.ToString(),
                        vendorCombo.SelectedValue.ToString()

                    };

                    numberOfRecords = sqlcmd.addNewRecord(quary, Parameters, txtBox);
                    if (numberOfRecords == -1)
                    {
                        MessageBox.Show("هذا الصنف موجود من قبل ولا يمكن إضافته", "خطأ");
                        txtproduct_new.SelectAll();
                        txtproduct_new.Focus();
                    }
                    else
                    {

                        MessageBox.Show("تم إضافة " + txtproduct_new.Text + " إلى قاعدة البيانات ", "غملية ناجحة");
                        restInput();

                    }
                    sqlcmd.AutoComplete(txtType_new, "SELECT type FROM goods");
                    sqlcmd.AutoComplete(txtproduct_new, "SELECT name FROM goods");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("حدث خطأ اثناء اضافة صنف ، اتصل بالمبرمج فورا\n " + ex.Message);

            }
        }

        private void Txtproduct_new_TextChanged(object sender, EventArgs e)
        {
            txtType_new.Text = txtproduct_new.Text.Split(' ')[0];
        }

        private void TxtAmount_new_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void TxtSell_new_KeyPress(object sender, KeyPressEventArgs e)
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

        private void TxtBuy_new_KeyPress(object sender, KeyPressEventArgs e)
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
