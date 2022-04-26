using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace allN1.goodsForms
{
    public partial class goodSelect : Form
    {
        public static string goodName;
        public static int goodId;

        public goodSelect()
        {
            InitializeComponent();
        }

        private void GoodSelect_Load(object sender, EventArgs e)
        {
            DataTable k = sqlcmd.kindList();
            kindList.DisplayMember = "kind";
            kindList.ValueMember = "kind";
            kindList.DataSource = k;

        }

        private void KindList_SelectedIndexChanged(object sender, EventArgs e)
        {

                DataTable t = sqlcmd.typeList(kindList.SelectedValue.ToString());
                typeList.DisplayMember = "type";
                typeList.ValueMember = "type";
                typeList.DataSource = t;



        }

        private void TypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable g = sqlcmd.goodList(kindList.SelectedValue.ToString(), typeList.SelectedValue.ToString());
            goods.DataSource = g;
            goods.Columns[0].Width = 0;
            goods.Columns[2].Width = 150;

        }



        private void Goods_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = goods.CurrentCell.RowIndex;
            if (RowIndex >= 0)
            {
                DataGridViewRow row = this.goods.Rows[RowIndex];
                goodId = int.Parse(row.Cells[0].Value.ToString());
                goodName = row.Cells[1].Value.ToString();

            }
        }

        private void Goods_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.Close();
        }
    }
}
