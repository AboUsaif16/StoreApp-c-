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
    public partial class userSelect : Form
    {
        public static int u_id;
        public static string u_name;

        public userSelect()
        {
            InitializeComponent();
        }

        private void UserSelect_Load(object sender, EventArgs e)
        {
            DataTable users_info = sqlcmd.loadData("select mony,name,Id from users order by name");
            userslist.DataSource = users_info;
            userslist.DisplayMember = "name";
            userslist.ValueMember = "id";
        }

        private void Userslist_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                u_id = int.Parse(userslist.SelectedValue.ToString());
                u_name = userslist.GetItemText(userslist.SelectedItem);
            }
            catch
            {
               
            }
            
            
        }
    }
}
