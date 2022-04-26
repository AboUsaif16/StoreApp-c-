namespace allN1
{
    partial class bill_info
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
            this.billList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txttotal = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label8 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txtuser = new System.Windows.Forms.Label();
            this.txtid = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.status = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // billList
            // 
            this.billList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.billList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.billList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.billList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billList.ForeColor = System.Drawing.Color.White;
            this.billList.FormattingEnabled = true;
            this.billList.ItemHeight = 29;
            this.billList.Location = new System.Drawing.Point(0, 41);
            this.billList.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.billList.Name = "billList";
            this.billList.Size = new System.Drawing.Size(161, 804);
            this.billList.TabIndex = 8;
            this.billList.SelectedIndexChanged += new System.EventHandler(this.BillList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txttotal);
            this.groupBox1.Controls.Add(this.txtdate);
            this.groupBox1.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(613, 56);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox1.Size = new System.Drawing.Size(338, 175);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "بيانات الفاتـــورة";
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label3.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.label3.Location = new System.Drawing.Point(233, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 42);
            this.label3.TabIndex = 26;
            this.label3.Text = "التاريخ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label2.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.label2.Location = new System.Drawing.Point(233, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 46);
            this.label2.TabIndex = 25;
            this.label2.Text = "الإجمالى";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txttotal
            // 
            this.txttotal.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txttotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txttotal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txttotal.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.txttotal.Location = new System.Drawing.Point(7, 38);
            this.txttotal.Name = "txttotal";
            this.txttotal.Size = new System.Drawing.Size(220, 46);
            this.txttotal.TabIndex = 24;
            this.txttotal.Text = "الإجمالى";
            this.txttotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtdate
            // 
            this.txtdate.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtdate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtdate.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.txtdate.Location = new System.Drawing.Point(6, 95);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(221, 42);
            this.txtdate.TabIndex = 23;
            this.txtdate.Text = "التاريخ";
            this.txtdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txt_search
            // 
            this.txt_search.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txt_search.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_search.Dock = System.Windows.Forms.DockStyle.Top;
            this.txt_search.Font = new System.Drawing.Font("Droid Arabic Kufi", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.txt_search.Location = new System.Drawing.Point(0, 0);
            this.txt_search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_search.MaxLength = 9;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(161, 41);
            this.txt_search.TabIndex = 10;
            this.txt_search.Text = "رقم الفاتورة";
            this.txt_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_search.TextChanged += new System.EventHandler(this.TextBox1_TextChanged);
            this.txt_search.Enter += new System.EventHandler(this.TextBox1_Enter);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.billList);
            this.panel2.Controls.Add(this.txt_search);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(957, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(161, 845);
            this.panel2.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(862, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 36);
            this.label4.TabIndex = 16;
            this.label4.Text = "الإسم : ";
            this.label4.Click += new System.EventHandler(this.Label4_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(14, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(937, 2);
            this.label5.TabIndex = 17;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.dataGridView1.Location = new System.Drawing.Point(3, 38);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(586, 738);
            this.dataGridView1.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(316, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 36);
            this.label8.TabIndex = 23;
            this.label8.Text = "الكود : ";
            this.label8.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Image = global::allN1.Properties.Resources.return_purchase_30px;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(840, 235);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(111, 57);
            this.button2.TabIndex = 24;
            this.button2.Text = "مرتجع";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::allN1.Properties.Resources.print_30px2;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(612, 235);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(118, 57);
            this.button1.TabIndex = 23;
            this.button1.Text = "طباعة";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // txtuser
            // 
            this.txtuser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuser.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtuser.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtuser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtuser.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.txtuser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.txtuser.Location = new System.Drawing.Point(407, 6);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(449, 43);
            this.txtuser.TabIndex = 26;
            this.txtuser.Text = "أحمد محمد على إبراهيم ";
            this.txtuser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtid
            // 
            this.txtid.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtid.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtid.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.txtid.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.txtid.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.txtid.Location = new System.Drawing.Point(187, 6);
            this.txtid.Name = "txtid";
            this.txtid.Size = new System.Drawing.Size(123, 43);
            this.txtid.TabIndex = 27;
            this.txtid.Text = "12345";
            this.txtid.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtid.Visible = false;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.button3.ForeColor = System.Drawing.SystemColors.Control;
            this.button3.Image = global::allN1.Properties.Resources.delete_bin_30px;
            this.button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button3.Location = new System.Drawing.Point(741, 235);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(93, 57);
            this.button3.TabIndex = 28;
            this.button3.Text = "حذف";
            this.button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.Button3_Click);
            // 
            // status
            // 
            this.status.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.status.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.status.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.status.ForeColor = System.Drawing.Color.ForestGreen;
            this.status.Location = new System.Drawing.Point(612, 295);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(338, 42);
            this.status.TabIndex = 27;
            this.status.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSize = true;
            this.groupBox3.Controls.Add(this.dataGridView1);
            this.groupBox3.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(14, 56);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.groupBox3.Size = new System.Drawing.Size(592, 778);
            this.groupBox3.TabIndex = 29;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "بيانات الفاتورة";
            // 
            // bill_info
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1118, 845);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.status);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.txtid);
            this.Controls.Add(this.txtuser);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.Name = "bill_info";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.Text = "سجل الفواتير";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Bill_info_Load);
            this.groupBox1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox billList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label txtdate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txttotal;
        private System.Windows.Forms.Label txtuser;
        private System.Windows.Forms.Label txtid;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label status;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}