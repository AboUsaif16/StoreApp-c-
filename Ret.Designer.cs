namespace allN1
{
    partial class Ret
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.Sell_ID = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.returnAmount = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.billNumber = new System.Windows.Forms.Label();
            this.goodName = new System.Windows.Forms.Label();
            this.sellDate = new System.Windows.Forms.Label();
            this.sellAmount = new System.Windows.Forms.Label();
            this.priceOne = new System.Windows.Forms.Label();
            this.priceTotal = new System.Windows.Forms.Label();
            this.code = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.code);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.priceTotal);
            this.groupBox4.Controls.Add(this.priceOne);
            this.groupBox4.Controls.Add(this.sellAmount);
            this.groupBox4.Controls.Add(this.sellDate);
            this.groupBox4.Controls.Add(this.goodName);
            this.groupBox4.Controls.Add(this.billNumber);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.label10);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold);
            this.groupBox4.Location = new System.Drawing.Point(0, 122);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(542, 318);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "بيانات الصنف المرتجع";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label18.Location = new System.Drawing.Point(359, 247);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 35);
            this.label18.TabIndex = 17;
            this.label18.Text = "السعر الكلى";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label19.Location = new System.Drawing.Point(359, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(131, 35);
            this.label19.TabIndex = 16;
            this.label19.Text = "رقم الفاتورة";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label19.Click += new System.EventHandler(this.Label19_Click);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label10.Location = new System.Drawing.Point(359, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(131, 35);
            this.label10.TabIndex = 8;
            this.label10.Text = "إسم الصنف";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label16.Location = new System.Drawing.Point(359, 212);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(131, 35);
            this.label16.TabIndex = 13;
            this.label16.Text = "سعر بيع الواحده";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label15.Location = new System.Drawing.Point(359, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(131, 35);
            this.label15.TabIndex = 9;
            this.label15.Text = "تاريخ البيع";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label17.Location = new System.Drawing.Point(359, 177);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(131, 35);
            this.label17.TabIndex = 12;
            this.label17.Text = "الكمية المباعة";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.Sell_ID);
            this.groupBox5.Controls.Add(this.label20);
            this.groupBox5.Controls.Add(this.returnAmount);
            this.groupBox5.Controls.Add(this.button1);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(542, 122);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "عملية الإسترداد";
            // 
            // Sell_ID
            // 
            this.Sell_ID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Sell_ID.BackColor = System.Drawing.SystemColors.Control;
            this.Sell_ID.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Sell_ID.Enabled = false;
            this.Sell_ID.Location = new System.Drawing.Point(146, 161);
            this.Sell_ID.Name = "Sell_ID";
            this.Sell_ID.Size = new System.Drawing.Size(390, 25);
            this.Sell_ID.TabIndex = 19;
            // 
            // label20
            // 
            this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(410, 53);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(120, 24);
            this.label20.TabIndex = 18;
            this.label20.Text = "الكمية المرتجعه";
            // 
            // returnAmount
            // 
            this.returnAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.returnAmount.Location = new System.Drawing.Point(179, 50);
            this.returnAmount.Name = "returnAmount";
            this.returnAmount.Size = new System.Drawing.Size(225, 32);
            this.returnAmount.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(17, 43);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(156, 45);
            this.button1.TabIndex = 5;
            this.button1.Text = "إسترداد المنتج";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // billNumber
            // 
            this.billNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.billNumber.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.billNumber.Location = new System.Drawing.Point(17, 35);
            this.billNumber.Name = "billNumber";
            this.billNumber.Size = new System.Drawing.Size(337, 35);
            this.billNumber.TabIndex = 18;
            this.billNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // goodName
            // 
            this.goodName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goodName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.goodName.Location = new System.Drawing.Point(17, 105);
            this.goodName.Name = "goodName";
            this.goodName.Size = new System.Drawing.Size(337, 35);
            this.goodName.TabIndex = 19;
            this.goodName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sellDate
            // 
            this.sellDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sellDate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sellDate.Location = new System.Drawing.Point(17, 140);
            this.sellDate.Name = "sellDate";
            this.sellDate.Size = new System.Drawing.Size(337, 35);
            this.sellDate.TabIndex = 20;
            this.sellDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sellAmount
            // 
            this.sellAmount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sellAmount.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.sellAmount.Location = new System.Drawing.Point(17, 177);
            this.sellAmount.Name = "sellAmount";
            this.sellAmount.Size = new System.Drawing.Size(337, 35);
            this.sellAmount.TabIndex = 21;
            this.sellAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceOne
            // 
            this.priceOne.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceOne.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.priceOne.Location = new System.Drawing.Point(17, 212);
            this.priceOne.Name = "priceOne";
            this.priceOne.Size = new System.Drawing.Size(337, 35);
            this.priceOne.TabIndex = 22;
            this.priceOne.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // priceTotal
            // 
            this.priceTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.priceTotal.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.priceTotal.Location = new System.Drawing.Point(17, 247);
            this.priceTotal.Name = "priceTotal";
            this.priceTotal.Size = new System.Drawing.Size(337, 35);
            this.priceTotal.TabIndex = 23;
            this.priceTotal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // code
            // 
            this.code.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.code.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.code.Location = new System.Drawing.Point(17, 70);
            this.code.Name = "code";
            this.code.Size = new System.Drawing.Size(337, 35);
            this.code.TabIndex = 25;
            this.code.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(359, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 35);
            this.label2.TabIndex = 24;
            this.label2.Text = "كود الصنف";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Ret
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 440);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Ret";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label priceTotal;
        private System.Windows.Forms.Label priceOne;
        private System.Windows.Forms.Label sellAmount;
        private System.Windows.Forms.Label sellDate;
        private System.Windows.Forms.Label goodName;
        private System.Windows.Forms.Label billNumber;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox Sell_ID;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox returnAmount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label code;
        private System.Windows.Forms.Label label2;
    }
}