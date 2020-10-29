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
    public partial class modify : Form
    {
        public modify()
        {
            InitializeComponent();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.Black;
            textBox1.UseSystemPasswordChar = true;
            
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "C 0rteX1209")
            {
                MessageBox.Show(this, "تأكد من ادخال كلمة المرور بشكل صحيح او قم بالإتصال على المبرمج");
                textBox1.Focus();
                return;
            }
            button1.DialogResult = DialogResult.OK;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
