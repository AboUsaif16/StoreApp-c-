namespace allN1.usersForms
{
    partial class userSelect
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
            this.userslist = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // userslist
            // 
            this.userslist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.userslist.Font = new System.Drawing.Font("Droid Arabic Kufi", 14.25F);
            this.userslist.FormattingEnabled = true;
            this.userslist.ItemHeight = 36;
            this.userslist.Location = new System.Drawing.Point(0, 0);
            this.userslist.Name = "userslist";
            this.userslist.Size = new System.Drawing.Size(323, 764);
            this.userslist.TabIndex = 0;
            this.userslist.SelectedIndexChanged += new System.EventHandler(this.Userslist_SelectedIndexChanged);
            // 
            // userSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(323, 764);
            this.Controls.Add(this.userslist);
            this.Name = "userSelect";
            this.Text = "إختيار العميل";
            this.Load += new System.EventHandler(this.UserSelect_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox userslist;
    }
}