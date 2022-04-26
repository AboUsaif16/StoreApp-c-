namespace allN1.goodsForms
{
    partial class goodSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.typeList = new System.Windows.Forms.ListBox();
            this.kindList = new System.Windows.Forms.ListBox();
            this.goods = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.goods)).BeginInit();
            this.SuspendLayout();
            // 
            // typeList
            // 
            this.typeList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.typeList.Dock = System.Windows.Forms.DockStyle.Right;
            this.typeList.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F);
            this.typeList.ForeColor = System.Drawing.Color.White;
            this.typeList.FormattingEnabled = true;
            this.typeList.ItemHeight = 36;
            this.typeList.Location = new System.Drawing.Point(731, 0);
            this.typeList.Margin = new System.Windows.Forms.Padding(15, 8, 10, 8);
            this.typeList.Name = "typeList";
            this.typeList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeList.Size = new System.Drawing.Size(232, 842);
            this.typeList.TabIndex = 3;
            this.typeList.SelectedIndexChanged += new System.EventHandler(this.TypeList_SelectedIndexChanged);
            // 
            // kindList
            // 
            this.kindList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.kindList.Dock = System.Windows.Forms.DockStyle.Right;
            this.kindList.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F);
            this.kindList.ForeColor = System.Drawing.Color.White;
            this.kindList.FormattingEnabled = true;
            this.kindList.ItemHeight = 36;
            this.kindList.Location = new System.Drawing.Point(963, 0);
            this.kindList.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.kindList.Name = "kindList";
            this.kindList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kindList.Size = new System.Drawing.Size(269, 842);
            this.kindList.TabIndex = 4;
            this.kindList.SelectedIndexChanged += new System.EventHandler(this.KindList_SelectedIndexChanged);
            // 
            // goods
            // 
            this.goods.AllowUserToAddRows = false;
            this.goods.AllowUserToDeleteRows = false;
            this.goods.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.goods.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.goods.BackgroundColor = System.Drawing.Color.White;
            this.goods.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.goods.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Plum;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.goods.DefaultCellStyle = dataGridViewCellStyle2;
            this.goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goods.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.goods.Location = new System.Drawing.Point(0, 0);
            this.goods.Name = "goods";
            this.goods.ReadOnly = true;
            this.goods.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.goods.RowHeadersVisible = false;
            this.goods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.goods.Size = new System.Drawing.Size(731, 842);
            this.goods.TabIndex = 6;
            this.goods.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Goods_CellContentClick_1);
            this.goods.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Goods_KeyPress);
            // 
            // goodSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 842);
            this.Controls.Add(this.goods);
            this.Controls.Add(this.typeList);
            this.Controls.Add(this.kindList);
            this.MinimumSize = new System.Drawing.Size(984, 881);
            this.Name = "goodSelect";
            this.Text = "إختيار الصنف";
            this.Load += new System.EventHandler(this.GoodSelect_Load);
            ((System.ComponentModel.ISupportInitialize)(this.goods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox typeList;
        private System.Windows.Forms.ListBox kindList;
        private System.Windows.Forms.DataGridView goods;
    }
}