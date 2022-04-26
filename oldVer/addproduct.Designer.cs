namespace allN1
{
    partial class addproduct
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
            this.prdname = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.r1 = new System.Windows.Forms.RadioButton();
            this.r2 = new System.Windows.Forms.RadioButton();
            this.r3 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.AutoSize = true;
            this.groupBox1.Controls.Add(this.prdname);
            this.groupBox1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox1.Size = new System.Drawing.Size(310, 94);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "الإسم";
            // 
            // prdname
            // 
            this.prdname.Location = new System.Drawing.Point(6, 31);
            this.prdname.Name = "prdname";
            this.prdname.Size = new System.Drawing.Size(298, 32);
            this.prdname.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.AutoSize = true;
            this.groupBox2.Controls.Add(this.r1);
            this.groupBox2.Controls.Add(this.r2);
            this.groupBox2.Controls.Add(this.r3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 112);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(310, 96);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "النوع";
            // 
            // r1
            // 
            this.r1.Appearance = System.Windows.Forms.Appearance.Button;
            this.r1.AutoSize = true;
            this.r1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r1.Location = new System.Drawing.Point(6, 31);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(116, 34);
            this.r1.TabIndex = 4;
            this.r1.TabStop = true;
            this.r1.Text = "أجهزة كهربائية";
            this.r1.UseVisualStyleBackColor = true;
            this.r1.CheckedChanged += new System.EventHandler(this.KindChanged);
            // 
            // r2
            // 
            this.r2.Appearance = System.Windows.Forms.Appearance.Button;
            this.r2.AutoSize = true;
            this.r2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r2.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r2.Location = new System.Drawing.Point(128, 31);
            this.r2.Name = "r2";
            this.r2.Size = new System.Drawing.Size(101, 34);
            this.r2.TabIndex = 3;
            this.r2.TabStop = true;
            this.r2.Text = "أدوات منزلية";
            this.r2.UseVisualStyleBackColor = true;
            this.r2.CheckedChanged += new System.EventHandler(this.KindChanged);
            // 
            // r3
            // 
            this.r3.Appearance = System.Windows.Forms.Appearance.Button;
            this.r3.AutoSize = true;
            this.r3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.r3.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.r3.Location = new System.Drawing.Point(235, 31);
            this.r3.Name = "r3";
            this.r3.Size = new System.Drawing.Size(69, 34);
            this.r3.TabIndex = 2;
            this.r3.TabStop = true;
            this.r3.Text = "بلاسيتك";
            this.r3.UseVisualStyleBackColor = true;
            this.r3.CheckedChanged += new System.EventHandler(this.KindChanged);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(12, 214);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(130, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "حفـــــظ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // addproduct
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 257);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "addproduct";
            this.ShowIcon = false;
            this.Text = "إضافة صنف جديد";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Addproduct_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton r1;
        private System.Windows.Forms.RadioButton r2;
        private System.Windows.Forms.RadioButton r3;
        private System.Windows.Forms.TextBox prdname;
        private System.Windows.Forms.Button button1;
    }
}