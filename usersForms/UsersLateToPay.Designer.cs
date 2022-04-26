namespace allN1
{
    partial class UsersLateToPay
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
            this.groupBox21 = new System.Windows.Forms.GroupBox();
            this.usersWanted = new System.Windows.Forms.DataGridView();
            this.groupBox21.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.usersWanted)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox21
            // 
            this.groupBox21.Controls.Add(this.usersWanted);
            this.groupBox21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox21.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox21.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox21.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            this.groupBox21.Location = new System.Drawing.Point(0, 0);
            this.groupBox21.Margin = new System.Windows.Forms.Padding(12, 10, 12, 10);
            this.groupBox21.Name = "groupBox21";
            this.groupBox21.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox21.Size = new System.Drawing.Size(900, 878);
            this.groupBox21.TabIndex = 18;
            this.groupBox21.TabStop = false;
            this.groupBox21.Text = "بيان العملاء المطلوبين";
            // 
            // usersWanted
            // 
            this.usersWanted.AllowUserToAddRows = false;
            this.usersWanted.AllowUserToDeleteRows = false;
            this.usersWanted.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.usersWanted.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.usersWanted.BackgroundColor = System.Drawing.Color.White;
            this.usersWanted.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.usersWanted.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.usersWanted.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Droid Arabic Kufi", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(112)))), ((int)(((byte)(34)))), ((int)(((byte)(131)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(32)))), ((int)(((byte)(113)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.usersWanted.DefaultCellStyle = dataGridViewCellStyle2;
            this.usersWanted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersWanted.GridColor = System.Drawing.Color.White;
            this.usersWanted.Location = new System.Drawing.Point(4, 43);
            this.usersWanted.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.usersWanted.Name = "usersWanted";
            this.usersWanted.ReadOnly = true;
            this.usersWanted.RowHeadersVisible = false;
            this.usersWanted.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.usersWanted.Size = new System.Drawing.Size(892, 831);
            this.usersWanted.TabIndex = 3;
            // 
            // UsersLateToPay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 878);
            this.Controls.Add(this.groupBox21);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsersLateToPay";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تقرير العملاء المطلوبين";
            this.Load += new System.EventHandler(this.UsersLateToPay_Load);
            this.groupBox21.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.usersWanted)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox21;
        private System.Windows.Forms.DataGridView usersWanted;
    }
}