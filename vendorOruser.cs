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
    public partial class vendorOruser : Form
    {
        public vendorOruser()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            main.is_vendor = false;
            main.selected = true;
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            main.is_vendor = true;
            main.selected = true;
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            printpay pp = new printpay();
            this.Hide();
            pp.ShowDialog(this);
            this.Show();

        }
    }
}
