namespace AutoWebOrder
{
    partial class FormOrder
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnStatLogin = new System.Windows.Forms.Button();
            this.btnStatInitCart = new System.Windows.Forms.Button();
            this.btnStatPayment = new System.Windows.Forms.Button();
            this.listOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnPayComp = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "작업상태";
            // 
            // btnStatLogin
            // 
            this.btnStatLogin.Enabled = false;
            this.btnStatLogin.Location = new System.Drawing.Point(85, 12);
            this.btnStatLogin.Name = "btnStatLogin";
            this.btnStatLogin.Size = new System.Drawing.Size(125, 40);
            this.btnStatLogin.TabIndex = 1;
            this.btnStatLogin.Text = "로그인";
            this.btnStatLogin.UseVisualStyleBackColor = true;
            // 
            // btnStatInitCart
            // 
            this.btnStatInitCart.Enabled = false;
            this.btnStatInitCart.Location = new System.Drawing.Point(216, 12);
            this.btnStatInitCart.Name = "btnStatInitCart";
            this.btnStatInitCart.Size = new System.Drawing.Size(132, 40);
            this.btnStatInitCart.TabIndex = 2;
            this.btnStatInitCart.Text = "장바구니초기화";
            this.btnStatInitCart.UseVisualStyleBackColor = true;
            // 
            // btnStatPayment
            // 
            this.btnStatPayment.Enabled = false;
            this.btnStatPayment.Location = new System.Drawing.Point(354, 12);
            this.btnStatPayment.Name = "btnStatPayment";
            this.btnStatPayment.Size = new System.Drawing.Size(128, 40);
            this.btnStatPayment.TabIndex = 3;
            this.btnStatPayment.Text = "상품주문";
            this.btnStatPayment.UseVisualStyleBackColor = true;
            // 
            // listOrder
            // 
            this.listOrder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listOrder.GridLines = true;
            this.listOrder.Location = new System.Drawing.Point(6, 18);
            this.listOrder.Name = "listOrder";
            this.listOrder.Size = new System.Drawing.Size(777, 203);
            this.listOrder.TabIndex = 5;
            this.listOrder.UseCompatibleStateImageBehavior = false;
            this.listOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SN";
            this.columnHeader1.Width = 52;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "제품명";
            this.columnHeader2.Width = 235;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "수량";
            this.columnHeader3.Width = 49;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "주문완료수량";
            this.columnHeader4.Width = 123;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "분류";
            this.columnHeader5.Width = 96;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "공급코드";
            this.columnHeader6.Width = 136;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "진행상";
            this.columnHeader7.Width = 68;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listOrder);
            this.groupBox1.Location = new System.Drawing.Point(15, 75);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(789, 229);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "주문상태";
            // 
            // btnPayComp
            // 
            this.btnPayComp.Location = new System.Drawing.Point(32, 315);
            this.btnPayComp.Name = "btnPayComp";
            this.btnPayComp.Size = new System.Drawing.Size(750, 30);
            this.btnPayComp.TabIndex = 7;
            this.btnPayComp.Text = "결제 수행 완료";
            this.btnPayComp.UseVisualStyleBackColor = true;
            // 
            // FormOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 359);
            this.Controls.Add(this.btnPayComp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnStatPayment);
            this.Controls.Add(this.btnStatInitCart);
            this.Controls.Add(this.btnStatLogin);
            this.Controls.Add(this.label1);
            this.Name = "FormOrder";
            this.Text = "상품 주문";
            this.Load += new System.EventHandler(this.FormOrder_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnStatLogin;
        private System.Windows.Forms.Button btnStatInitCart;
        private System.Windows.Forms.Button btnStatPayment;
        private System.Windows.Forms.ListView listOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.Button btnPayComp;
    }
}