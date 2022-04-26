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
    public partial class users : Form
    {
        public static string usernameSelected;
        public static string useridSelected;
        public static string userName;
        public users()
        {
            InitializeComponent();
           
        }

        private void Txtuser_id_TextChanged(object sender, EventArgs e)
        {

        }
        private void edit()
        {
            List<string> Parameters = new List<string>() { "@name", "@address", "@phone", "@mony" };
            List<string> txtBox = new List<string>()
                {
                    txtuser.Text,txtuser_add.Text,txtuser_phone.Text,txtuser_mony.Text
                };
            try
            {

                String quary1 = String.Concat("update users set name =@name , address = @address ,phone = @phone , mony = @mony  where Id = ", userslist.SelectedValue, ";insert into logs values (", userslist.SelectedValue, ",@mony)");
                sqlcmd.updateRecord(quary1, Parameters, txtBox);

            }
            catch
            {
                String quary2 = String.Concat("update users set name =@name , address = @address ,phone = @phone , mony = @mony  where Id = ", userslist.SelectedValue, ";update logs set total = @mony where user_Id = ", userslist.SelectedValue);
                sqlcmd.updateRecord(quary2, Parameters, txtBox);

            }
            int s = userslist.SelectedIndex;
            Viewusers();
            userslist.SetSelected(s, true);
        }

        private void Btnuser_edit_Click(object sender, EventArgs e)
        {
            edit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int s = userslist.SelectedIndex;
           
            userName = usernameSelected;
            main.is_vendor = false;
            pay payForm = new pay();
            payForm.ShowDialog(this);
            userName = "";
            Viewusers();
            userslist.SetSelected(s, true);

        }

        private void Btnuser_del_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("برجاء العلم ان العميل سوف يتم حذفه من جميع السجلات نهائيا", "تحذير", MessageBoxButtons.OKCancel) == DialogResult.OK)

            {
                try
                {
                    String quary = String.Concat("delete from  users where id = ", userslist.SelectedValue);
                    sqlcmd.execute(quary);
                    MessageBox.Show(" تم حذف العميل " + txtuser.Text);
                    int s = userslist.SelectedIndex;
                    Viewusers();
                    userslist.SetSelected(s, true);

                }
                catch (Exception ex)
                {

                    MessageBox.Show("حدثت مشكلة أثناء حذف العميل ، برجاء التواصل مع المبرمج\n" + ex.Message);
                }



            }
        }

        private void Users_Load(object sender, EventArgs e)
        {
            userslist.SelectedIndexChanged -= Userslist_SelectedIndexChanged;
            Viewusers();
            userslist.SelectedIndexChanged += Userslist_SelectedIndexChanged;
        }
        private void Viewusers()
        {
            DataTable users_info = sqlcmd.loadData("select mony,name,Id from users order by name");
            userslist.DataSource = users_info;
            userslist.DisplayMember = "name";
            userslist.ValueMember = "id";
            users_info.ToCSV(Application.StartupPath + "/BackUp/users.txt");
        }
        private void userByName()
        {
            try
            {
                String quary = "select Id,name  from users where name like @name ";
                userslist.DataSource = sqlcmd.searchbyName(quary,txtuer_search);
                userslist.DisplayMember = "name";
                userslist.ValueMember = "id";

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }

        private void Txtuer_search_TextChanged(object sender, EventArgs e)
        {
            

            userByName();
        }

        private void Userslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtuser_mony.ReadOnly = true;
            String quary = String.Concat("select *  from users where id = ", userslist.SelectedValue);
            List<string> Parameters = new List<string>()
                    {
                        "name","address","phone","mony","Id"

                    };
            List<TextBox> txtBox = new List<TextBox>()
                    {
                        txtuser,
                        txtuser_add,
                        txtuser_phone,
                        txtuser_mony,
                        txtuser_id

                    };
            sqlcmd.rowData(quary, Parameters, txtBox);
            
            if (txtuser_id.Text != "")
            {
                String q = "select count(*) as s from orders where userId = " + int.Parse(txtuser_id.Text);
                List<string> p = new List<string>() { "s" };
                List<TextBox> txt = new List<TextBox>() { num_bills };
                sqlcmd.rowData(q, p,txt);
                if (num_bills.Text == "0")
                {
                    btnuser_bills.Enabled = false;
                    btnuser_del.Enabled = true;
                }
                else
                {
                    btnuser_bills.Enabled = true;
                    btnuser_del.Enabled = false;
                }
               
            
            }
            useridSelected=txtuser_id.Text;
            usernameSelected = txtuser.Text;


            String sql = String.Concat("select logs_info.id as [رقم الإيصال], payment as [المدفوع], strftime('%d/%m/%Y',date) as [الوقت ] from logs_info join users on logs_info.user_id = users.Id where users.Id =", userslist.SelectedValue);
            dataGridView1.DataSource = sqlcmd.loadData(sql);
            btnuser_del.Enabled = true;
            btnuser_edit.Enabled = true;
            btn_sel.Enabled = true;
            if (float.Parse(txtuser_mony.Text) > 0)
            {
                btnPay.Enabled = true;
            }
            else
            {
                btnPay.Enabled = false;
            }

            btnNewOrder.Enabled = true;
            
            if (float.Parse(txtuser_mony.Text) < 0)
            {
                if (MessageBox.Show("هل تريد تعديل الرصيد إلى صفر ام تريد البقاء كما هو؟", "تعديل الرصيد", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    txtuser_mony.Text = "0";
                    edit();

                }
            }
            

        }

        private void Txtuser_mony_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void Txtuser_mony_TextChanged(object sender, EventArgs e)
        {

        }

        private void Txtuser_mony_Enter(object sender, EventArgs e)
        {
            
        }

        private void Txtuser_mony_MouseHover(object sender, EventArgs e)
        {
            if (Control.ModifierKeys == Keys.Control)
            {
                txtuser_mony.ReadOnly = false;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            printpay pp = new printpay();
            this.Hide();
            pp.ShowDialog(this);
            this.Show();
        }

        private void Btnuser_bills_Click(object sender, EventArgs e)
        {
            bill_info bill_Info = new bill_info();
            bill_Info.Show(this);
            sqlcmd.clean();
            int s = userslist.SelectedIndex;
            Viewusers();
            userslist.SetSelected(s, true);
        }
        

        private void Button3_Click(object sender, EventArgs e)
        {
            usersForms.newBill new_bill = new usersForms.newBill();
            new_bill.ShowDialog(this);
        }

        private void AddNewUser_Click(object sender, EventArgs e)
        {
            usersForms.addNewUser newUser = new usersForms.addNewUser();
            newUser.ShowDialog();

        }

        private void Btn_sel_Click(object sender, EventArgs e)
        {
            int s = userslist.SelectedIndex;
            main.fromGoods = false;
            sellNow sNow = new sellNow();
            sNow.ShowDialog();
            Viewusers();
            userslist.SetSelected(s, true);
        }
    }

}
