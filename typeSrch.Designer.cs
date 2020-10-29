namespace allN1
{
    partial class typeSrch
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
            this.typeList = new System.Windows.Forms.ListBox();
            this.kindList = new System.Windows.Forms.ListBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtbx_search = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // typeList
            // 
            this.typeList.BackColor = System.Drawing.SystemColors.Control;
            this.typeList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.typeList.Dock = System.Windows.Forms.DockStyle.Right;
            this.typeList.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.typeList.ForeColor = System.Drawing.Color.Black;
            this.typeList.FormattingEnabled = true;
            this.typeList.ItemHeight = 24;
            this.typeList.Location = new System.Drawing.Point(724, 0);
            this.typeList.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.typeList.Name = "typeList";
            this.typeList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.typeList.Size = new System.Drawing.Size(157, 535);
            this.typeList.TabIndex = 0;
            this.typeList.SelectedIndexChanged += new System.EventHandler(this.TypeList_SelectedIndexChanged);
            // 
            // kindList
            // 
            this.kindList.BackColor = System.Drawing.SystemColors.Control;
            this.kindList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.kindList.Dock = System.Windows.Forms.DockStyle.Right;
            this.kindList.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.kindList.ForeColor = System.Drawing.Color.Black;
            this.kindList.FormattingEnabled = true;
            this.kindList.ItemHeight = 29;
            this.kindList.Location = new System.Drawing.Point(881, 0);
            this.kindList.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.kindList.Name = "kindList";
            this.kindList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.kindList.Size = new System.Drawing.Size(200, 535);
            this.kindList.TabIndex = 2;
            this.kindList.SelectedIndexChanged += new System.EventHandler(this.KindList_SelectedIndexChanged);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridView.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dataGridView.Location = new System.Drawing.Point(0, 49);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.Size = new System.Drawing.Size(724, 486);
            this.dataGridView.TabIndex = 3;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridView_CellContentClick_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.panel1.Controls.Add(this.txtbx_search);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(724, 49);
            this.panel1.TabIndex = 4;
            // 
            // txtbx_search
            // 
            this.txtbx_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(47)))), ((int)(((byte)(75)))));
            this.txtbx_search.Dock = System.Windows.Forms.DockStyle.Right;
            this.txtbx_search.Font = new System.Drawing.Font("Arial", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtbx_search.ForeColor = System.Drawing.Color.White;
            this.txtbx_search.Location = new System.Drawing.Point(119, 0);
            this.txtbx_search.Margin = new System.Windows.Forms.Padding(7, 9, 7, 9);
            this.txtbx_search.Name = "txtbx_search";
            this.txtbx_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtbx_search.Size = new System.Drawing.Size(457, 41);
            this.txtbx_search.TabIndex = 5;
            this.txtbx_search.Tag = "";
            this.txtbx_search.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtbx_search.TextChanged += new System.EventHandler(this.Txtbx_search_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Right;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(576, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 49);
            this.label1.TabIndex = 6;
            this.label1.Text = "أدخل إسم الصنف";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // typeSrch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 36F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1081, 535);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.typeList);
            this.Controls.Add(this.kindList);
            this.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.MinimizeBox = false;
            this.Name = "typeSrch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "عرض جميع الأصناف";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TypeSrch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox typeList;
        private System.Windows.Forms.ListBox kindList;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbx_search;
    }
}