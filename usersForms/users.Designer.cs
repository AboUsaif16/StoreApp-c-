namespace allN1
{
    partial class users
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
            this.userslist = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtuer_search = new System.Windows.Forms.TextBox();
            this.gbuser_info = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtuser_add = new System.Windows.Forms.TextBox();
            this.txtuser_phone = new System.Windows.Forms.TextBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.num_bills = new System.Windows.Forms.TextBox();
            this.txtuser_mony = new System.Windows.Forms.TextBox();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.txtuser_id = new System.Windows.Forms.TextBox();
            this.txtuser = new System.Windows.Forms.TextBox();
            this.pay_info_gb = new System.Windows.Forms.GroupBox();
            this.panel17 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.addNewUser = new System.Windows.Forms.Button();
            this.btnuser_del = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNewOrder = new System.Windows.Forms.Button();
            this.btnuser_edit = new System.Windows.Forms.Button();
            this.btnuser_bills = new System.Windows.Forms.Button();
            this.btnPay = new System.Windows.Forms.Button();
            this.btn_sel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gbuser_info.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.pay_info_gb.SuspendLayout();
            this.panel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // userslist
            // 
            this.userslist.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.userslist.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.userslist.Dock = System.Windows.Forms.DockStyle.Right;
            this.userslist.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.userslist.ForeColor = System.Drawing.Color.White;
            this.userslist.FormattingEnabled = true;
            this.userslist.ItemHeight = 31;
            this.userslist.Location = new System.Drawing.Point(687, 0);
            this.userslist.Name = "userslist";
            this.userslist.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.userslist.Size = new System.Drawing.Size(334, 820);
            this.userslist.TabIndex = 4;
            this.userslist.SelectedIndexChanged += new System.EventHandler(this.Userslist_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtuer_search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(687, 95);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إسم العميل";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::allN1.Properties.Resources.user_24px;
            this.pictureBox1.Location = new System.Drawing.Point(644, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 24);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtuer_search
            // 
            this.txtuer_search.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuer_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.txtuer_search.Location = new System.Drawing.Point(244, 39);
            this.txtuer_search.Name = "txtuer_search";
            this.txtuer_search.Size = new System.Drawing.Size(394, 38);
            this.txtuer_search.TabIndex = 4;
            this.txtuer_search.TextChanged += new System.EventHandler(this.Txtuer_search_TextChanged);
            // 
            // gbuser_info
            // 
            this.gbuser_info.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbuser_info.AutoSize = true;
            this.gbuser_info.Controls.Add(this.groupBox9);
            this.gbuser_info.Controls.Add(this.groupBox10);
            this.gbuser_info.Controls.Add(this.groupBox11);
            this.gbuser_info.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.gbuser_info.Location = new System.Drawing.Point(196, 101);
            this.gbuser_info.Name = "gbuser_info";
            this.gbuser_info.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.gbuser_info.Size = new System.Drawing.Size(485, 500);
            this.gbuser_info.TabIndex = 6;
            this.gbuser_info.TabStop = false;
            this.gbuser_info.Text = "بيانات العميل";
            // 
            // groupBox9
            // 
            this.groupBox9.AutoSize = true;
            this.groupBox9.Controls.Add(this.label7);
            this.groupBox9.Controls.Add(this.label6);
            this.groupBox9.Controls.Add(this.txtuser_add);
            this.groupBox9.Controls.Add(this.txtuser_phone);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(3, 293);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(479, 173);
            this.groupBox9.TabIndex = 6;
            this.groupBox9.TabStop = false;
            this.groupBox9.Text = "بيانات أخرى";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.label7.Location = new System.Drawing.Point(394, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 31);
            this.label7.TabIndex = 8;
            this.label7.Text = "العنوان";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.label6.Location = new System.Drawing.Point(357, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 31);
            this.label6.TabIndex = 7;
            this.label6.Text = "رقم التليفون";
            // 
            // txtuser_add
            // 
            this.txtuser_add.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.txtuser_add.Location = new System.Drawing.Point(21, 93);
            this.txtuser_add.Name = "txtuser_add";
            this.txtuser_add.Size = new System.Drawing.Size(330, 38);
            this.txtuser_add.TabIndex = 6;
            // 
            // txtuser_phone
            // 
            this.txtuser_phone.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.txtuser_phone.Location = new System.Drawing.Point(21, 39);
            this.txtuser_phone.Name = "txtuser_phone";
            this.txtuser_phone.Size = new System.Drawing.Size(330, 38);
            this.txtuser_phone.TabIndex = 5;
            // 
            // groupBox10
            // 
            this.groupBox10.AutoSize = true;
            this.groupBox10.Controls.Add(this.label9);
            this.groupBox10.Controls.Add(this.label8);
            this.groupBox10.Controls.Add(this.num_bills);
            this.groupBox10.Controls.Add(this.txtuser_mony);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox10.Location = new System.Drawing.Point(3, 165);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(479, 128);
            this.groupBox10.TabIndex = 5;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "الرصيد";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.label9.Location = new System.Drawing.Point(400, 52);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 31);
            this.label9.TabIndex = 14;
            this.label9.Text = "الرصيد";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.label8.Location = new System.Drawing.Point(147, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 31);
            this.label8.TabIndex = 13;
            this.label8.Text = "عدد الفواتير";
            // 
            // num_bills
            // 
            this.num_bills.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.num_bills.ForeColor = System.Drawing.Color.DarkRed;
            this.num_bills.Location = new System.Drawing.Point(21, 48);
            this.num_bills.Name = "num_bills";
            this.num_bills.ReadOnly = true;
            this.num_bills.Size = new System.Drawing.Size(120, 38);
            this.num_bills.TabIndex = 12;
            // 
            // txtuser_mony
            // 
            this.txtuser_mony.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.txtuser_mony.ForeColor = System.Drawing.Color.DarkRed;
            this.txtuser_mony.Location = new System.Drawing.Point(271, 48);
            this.txtuser_mony.Name = "txtuser_mony";
            this.txtuser_mony.ReadOnly = true;
            this.txtuser_mony.Size = new System.Drawing.Size(123, 38);
            this.txtuser_mony.TabIndex = 2;
            this.txtuser_mony.TextChanged += new System.EventHandler(this.Txtuser_mony_TextChanged);
            this.txtuser_mony.Enter += new System.EventHandler(this.Txtuser_mony_Enter);
            this.txtuser_mony.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtuser_mony_KeyPress);
            this.txtuser_mony.MouseHover += new System.EventHandler(this.Txtuser_mony_MouseHover);
            // 
            // groupBox11
            // 
            this.groupBox11.AutoSize = true;
            this.groupBox11.Controls.Add(this.txtuser_id);
            this.groupBox11.Controls.Add(this.txtuser);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox11.Location = new System.Drawing.Point(3, 39);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(479, 126);
            this.groupBox11.TabIndex = 4;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "الإسم والكود";
            // 
            // txtuser_id
            // 
            this.txtuser_id.Font = new System.Drawing.Font("Droid Arabic Kufi", 14F);
            this.txtuser_id.ForeColor = System.Drawing.Color.DarkRed;
            this.txtuser_id.Location = new System.Drawing.Point(357, 41);
            this.txtuser_id.Name = "txtuser_id";
            this.txtuser_id.ReadOnly = true;
            this.txtuser_id.Size = new System.Drawing.Size(112, 43);
            this.txtuser_id.TabIndex = 1;
            // 
            // txtuser
            // 
            this.txtuser.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuser.ForeColor = System.Drawing.Color.DarkRed;
            this.txtuser.Location = new System.Drawing.Point(21, 40);
            this.txtuser.Name = "txtuser";
            this.txtuser.Size = new System.Drawing.Size(330, 44);
            this.txtuser.TabIndex = 0;
            // 
            // pay_info_gb
            // 
            this.pay_info_gb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pay_info_gb.Controls.Add(this.panel17);
            this.pay_info_gb.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.pay_info_gb.Location = new System.Drawing.Point(196, 607);
            this.pay_info_gb.Name = "pay_info_gb";
            this.pay_info_gb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.pay_info_gb.Size = new System.Drawing.Size(485, 201);
            this.pay_info_gb.TabIndex = 9;
            this.pay_info_gb.TabStop = false;
            this.pay_info_gb.Text = "سجل الدفع";
            // 
            // panel17
            // 
            this.panel17.Controls.Add(this.dataGridView1);
            this.panel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel17.Location = new System.Drawing.Point(3, 34);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(479, 164);
            this.panel17.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(479, 164);
            this.dataGridView1.TabIndex = 16;
            // 
            // addNewUser
            // 
            this.addNewUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addNewUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(86)))));
            this.addNewUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(205)))), ((int)(((byte)(83)))));
            this.addNewUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addNewUser.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.addNewUser.ForeColor = System.Drawing.SystemColors.Control;
            this.addNewUser.Image = global::allN1.Properties.Resources.add_user_male_30px;
            this.addNewUser.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.addNewUser.Location = new System.Drawing.Point(8, 140);
            this.addNewUser.Name = "addNewUser";
            this.addNewUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.addNewUser.Size = new System.Drawing.Size(182, 51);
            this.addNewUser.TabIndex = 5;
            this.addNewUser.Text = "عميل جديد";
            this.addNewUser.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.addNewUser.UseVisualStyleBackColor = false;
            this.addNewUser.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // btnuser_del
            // 
            this.btnuser_del.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnuser_del.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.btnuser_del.Enabled = false;
            this.btnuser_del.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser_del.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.btnuser_del.ForeColor = System.Drawing.SystemColors.Control;
            this.btnuser_del.Image = global::allN1.Properties.Resources.delete_bin_30px;
            this.btnuser_del.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser_del.Location = new System.Drawing.Point(8, 197);
            this.btnuser_del.Name = "btnuser_del";
            this.btnuser_del.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnuser_del.Size = new System.Drawing.Size(182, 51);
            this.btnuser_del.TabIndex = 5;
            this.btnuser_del.Text = "حذف العميل";
            this.btnuser_del.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnuser_del.UseVisualStyleBackColor = false;
            this.btnuser_del.Click += new System.EventHandler(this.Btnuser_del_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.button1.ForeColor = System.Drawing.SystemColors.Control;
            this.button1.Image = global::allN1.Properties.Resources.print_30px21;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(8, 477);
            this.button1.Name = "button1";
            this.button1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.button1.Size = new System.Drawing.Size(182, 51);
            this.button1.TabIndex = 7;
            this.button1.Text = "طباعة إيصال";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // btnNewOrder
            // 
            this.btnNewOrder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewOrder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btnNewOrder.Enabled = false;
            this.btnNewOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewOrder.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.btnNewOrder.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNewOrder.Image = global::allN1.Properties.Resources.new_copy_30px;
            this.btnNewOrder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewOrder.Location = new System.Drawing.Point(8, 421);
            this.btnNewOrder.Name = "btnNewOrder";
            this.btnNewOrder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNewOrder.Size = new System.Drawing.Size(182, 51);
            this.btnNewOrder.TabIndex = 7;
            this.btnNewOrder.Text = "إنشاء فاتورة";
            this.btnNewOrder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewOrder.UseVisualStyleBackColor = false;
            this.btnNewOrder.Click += new System.EventHandler(this.Button3_Click);
            // 
            // btnuser_edit
            // 
            this.btnuser_edit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnuser_edit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btnuser_edit.Enabled = false;
            this.btnuser_edit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser_edit.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.btnuser_edit.ForeColor = System.Drawing.SystemColors.Control;
            this.btnuser_edit.Image = global::allN1.Properties.Resources.edit_file_30px;
            this.btnuser_edit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser_edit.Location = new System.Drawing.Point(8, 253);
            this.btnuser_edit.Name = "btnuser_edit";
            this.btnuser_edit.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnuser_edit.Size = new System.Drawing.Size(182, 51);
            this.btnuser_edit.TabIndex = 4;
            this.btnuser_edit.Text = "تعديل البيانات";
            this.btnuser_edit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnuser_edit.UseVisualStyleBackColor = false;
            this.btnuser_edit.Click += new System.EventHandler(this.Btnuser_edit_Click);
            // 
            // btnuser_bills
            // 
            this.btnuser_bills.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnuser_bills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btnuser_bills.Enabled = false;
            this.btnuser_bills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnuser_bills.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.btnuser_bills.ForeColor = System.Drawing.SystemColors.Control;
            this.btnuser_bills.Image = global::allN1.Properties.Resources.sell_30px;
            this.btnuser_bills.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnuser_bills.Location = new System.Drawing.Point(8, 365);
            this.btnuser_bills.Name = "btnuser_bills";
            this.btnuser_bills.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnuser_bills.Size = new System.Drawing.Size(182, 51);
            this.btnuser_bills.TabIndex = 6;
            this.btnuser_bills.Text = "المشتريات";
            this.btnuser_bills.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnuser_bills.UseVisualStyleBackColor = false;
            this.btnuser_bills.Click += new System.EventHandler(this.Btnuser_bills_Click);
            // 
            // btnPay
            // 
            this.btnPay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btnPay.Enabled = false;
            this.btnPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPay.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F);
            this.btnPay.ForeColor = System.Drawing.SystemColors.Control;
            this.btnPay.Image = global::allN1.Properties.Resources.refund_30px;
            this.btnPay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPay.Location = new System.Drawing.Point(8, 309);
            this.btnPay.Name = "btnPay";
            this.btnPay.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnPay.Size = new System.Drawing.Size(182, 51);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = " دفع قسط";
            this.btnPay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.Button4_Click);
            // 
            // btn_sel
            // 
            this.btn_sel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_sel.AutoSize = true;
            this.btn_sel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btn_sel.Enabled = false;
            this.btn_sel.FlatAppearance.BorderSize = 0;
            this.btn_sel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_sel.Font = new System.Drawing.Font("Droid Arabic Kufi", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_sel.ForeColor = System.Drawing.Color.White;
            this.btn_sel.Location = new System.Drawing.Point(8, 534);
            this.btn_sel.Name = "btn_sel";
            this.btn_sel.Size = new System.Drawing.Size(182, 51);
            this.btn_sel.TabIndex = 10;
            this.btn_sel.Text = "بيع مباشر";
            this.btn_sel.UseVisualStyleBackColor = false;
            this.btn_sel.Click += new System.EventHandler(this.Btn_sel_Click);
            // 
            // users
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 820);
            this.Controls.Add(this.btn_sel);
            this.Controls.Add(this.pay_info_gb);
            this.Controls.Add(this.addNewUser);
            this.Controls.Add(this.btnuser_del);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNewOrder);
            this.Controls.Add(this.btnuser_edit);
            this.Controls.Add(this.btnuser_bills);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.gbuser_info);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userslist);
            this.Location = new System.Drawing.Point(1746, 1372);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1037, 859);
            this.MinimumSize = new System.Drawing.Size(1037, 859);
            this.Name = "users";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "users";
            this.Load += new System.EventHandler(this.Users_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gbuser_info.ResumeLayout(false);
            this.gbuser_info.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.pay_info_gb.ResumeLayout(false);
            this.panel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox userslist;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtuer_search;
        private System.Windows.Forms.GroupBox gbuser_info;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Button btnNewOrder;
        private System.Windows.Forms.Button btnuser_bills;
        private System.Windows.Forms.Button btnuser_del;
        private System.Windows.Forms.Button btnuser_edit;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtuser_add;
        private System.Windows.Forms.TextBox txtuser_phone;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox num_bills;
        private System.Windows.Forms.TextBox txtuser_mony;
        private System.Windows.Forms.GroupBox groupBox11;
        public System.Windows.Forms.TextBox txtuser_id;
        public System.Windows.Forms.TextBox txtuser;
        private System.Windows.Forms.GroupBox pay_info_gb;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button addNewUser;
        private System.Windows.Forms.Button btn_sel;
    }
}