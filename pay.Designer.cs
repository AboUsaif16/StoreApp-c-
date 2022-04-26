namespace allN1
{
    partial class pay
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtuer_search = new System.Windows.Forms.TextBox();
            this.userslist = new System.Windows.Forms.ListBox();
            this.info_GB = new System.Windows.Forms.GroupBox();
            this.remain_t = new System.Windows.Forms.Label();
            this.money = new System.Windows.Forms.Label();
            this.btn_pay = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtuer_payout = new System.Windows.Forms.TextBox();
            this.status = new System.Windows.Forms.ToolStripStatusLabel();
            this.time_now = new System.Windows.Forms.StatusStrip();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.info_GB.SuspendLayout();
            this.time_now.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.txtuer_search);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(481, 95);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "إسم العميل / المورد";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::allN1.Properties.Resources.user_24px;
            this.pictureBox1.Location = new System.Drawing.Point(413, 44);
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
            this.txtuer_search.Location = new System.Drawing.Point(13, 37);
            this.txtuer_search.Name = "txtuer_search";
            this.txtuer_search.Size = new System.Drawing.Size(394, 38);
            this.txtuer_search.TabIndex = 4;
            this.txtuer_search.TextChanged += new System.EventHandler(this.Txtuer_search_TextChanged);
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
            this.userslist.Location = new System.Drawing.Point(481, 0);
            this.userslist.Name = "userslist";
            this.userslist.Size = new System.Drawing.Size(334, 495);
            this.userslist.TabIndex = 3;
            this.userslist.SelectedIndexChanged += new System.EventHandler(this.ListBox1_SelectedIndexChanged);
            // 
            // info_GB
            // 
            this.info_GB.Controls.Add(this.remain_t);
            this.info_GB.Controls.Add(this.money);
            this.info_GB.Controls.Add(this.btn_pay);
            this.info_GB.Controls.Add(this.label3);
            this.info_GB.Controls.Add(this.label2);
            this.info_GB.Controls.Add(this.label1);
            this.info_GB.Controls.Add(this.txtuer_payout);
            this.info_GB.Dock = System.Windows.Forms.DockStyle.Top;
            this.info_GB.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info_GB.Location = new System.Drawing.Point(0, 95);
            this.info_GB.Name = "info_GB";
            this.info_GB.Size = new System.Drawing.Size(481, 217);
            this.info_GB.TabIndex = 4;
            this.info_GB.TabStop = false;
            // 
            // remain_t
            // 
            this.remain_t.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remain_t.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.remain_t.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.remain_t.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remain_t.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.remain_t.Location = new System.Drawing.Point(158, 156);
            this.remain_t.Name = "remain_t";
            this.remain_t.Size = new System.Drawing.Size(196, 38);
            this.remain_t.TabIndex = 7;
            this.remain_t.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // money
            // 
            this.money.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.money.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.money.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.money.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.money.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.money.Location = new System.Drawing.Point(158, 41);
            this.money.Name = "money";
            this.money.Size = new System.Drawing.Size(196, 38);
            this.money.TabIndex = 7;
            this.money.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btn_pay
            // 
            this.btn_pay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btn_pay.AutoSize = true;
            this.btn_pay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.btn_pay.Enabled = false;
            this.btn_pay.FlatAppearance.BorderSize = 0;
            this.btn_pay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.btn_pay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.btn_pay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_pay.ForeColor = System.Drawing.Color.White;
            this.btn_pay.Location = new System.Drawing.Point(6, 155);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(130, 41);
            this.btn_pay.TabIndex = 6;
            this.btn_pay.Text = "دفع";
            this.btn_pay.UseVisualStyleBackColor = false;
            this.btn_pay.Click += new System.EventHandler(this.Btn_pay_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(373, 157);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 31);
            this.label3.TabIndex = 5;
            this.label3.Text = "الباقى";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(373, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 31);
            this.label2.TabIndex = 5;
            this.label2.Text = "المدفوع";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(373, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "الرصيد";
            // 
            // txtuer_payout
            // 
            this.txtuer_payout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtuer_payout.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuer_payout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.txtuer_payout.Location = new System.Drawing.Point(158, 95);
            this.txtuer_payout.Name = "txtuer_payout";
            this.txtuer_payout.Size = new System.Drawing.Size(196, 38);
            this.txtuer_payout.TabIndex = 4;
            this.txtuer_payout.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
            this.txtuer_payout.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Txtuer_payout_KeyDown);
            this.txtuer_payout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Txtuer_payout_KeyPress);
            // 
            // status
            // 
            this.status.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.status.Font = new System.Drawing.Font("Droid Arabic Kufi", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.status.ForeColor = System.Drawing.Color.White;
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(109, 25);
            this.status.Text = "الحالة : متصـــــل";
            // 
            // time_now
            // 
            this.time_now.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            this.time_now.Font = new System.Drawing.Font("Droid Arabic Kufi", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.time_now.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.status});
            this.time_now.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.time_now.Location = new System.Drawing.Point(0, 495);
            this.time_now.Name = "time_now";
            this.time_now.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.time_now.Size = new System.Drawing.Size(815, 30);
            this.time_now.SizingGrip = false;
            this.time_now.TabIndex = 7;
            this.time_now.Text = "statusStrip1";
            // 
            // pay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(815, 525);
            this.Controls.Add(this.info_GB);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.userslist);
            this.Controls.Add(this.time_now);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "pay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "دفع قسط";
            this.Load += new System.EventHandler(this.Pay_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.info_GB.ResumeLayout(false);
            this.info_GB.PerformLayout();
            this.time_now.ResumeLayout(false);
            this.time_now.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtuer_search;
        private System.Windows.Forms.ListBox userslist;
        private System.Windows.Forms.GroupBox info_GB;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtuer_payout;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Label money;
        private System.Windows.Forms.Label remain_t;
        private System.Windows.Forms.ToolStripStatusLabel status;
        private System.Windows.Forms.StatusStrip time_now;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}