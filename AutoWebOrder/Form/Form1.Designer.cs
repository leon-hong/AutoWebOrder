namespace AutoWebOrder
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_test = new System.Windows.Forms.Button();
            this.btnConfig = new System.Windows.Forms.Button();
            this.edtOrder = new System.Windows.Forms.TextBox();
            this.btnOrder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.listOrder = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_test
            // 
            this.btn_test.Location = new System.Drawing.Point(12, 493);
            this.btn_test.Name = "btn_test";
            this.btn_test.Size = new System.Drawing.Size(769, 36);
            this.btn_test.TabIndex = 0;
            this.btn_test.Text = "Test";
            this.btn_test.UseVisualStyleBackColor = true;
            this.btn_test.Click += new System.EventHandler(this.btn_test_Click);
            // 
            // btnConfig
            // 
            this.btnConfig.Location = new System.Drawing.Point(31, 18);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(735, 22);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "설정";
            this.btnConfig.UseVisualStyleBackColor = true;
            // 
            // edtOrder
            // 
            this.edtOrder.Location = new System.Drawing.Point(18, 19);
            this.edtOrder.Name = "edtOrder";
            this.edtOrder.Size = new System.Drawing.Size(550, 21);
            this.edtOrder.TabIndex = 3;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(597, 14);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(157, 28);
            this.btnOrder.TabIndex = 4;
            this.btnOrder.Text = "주문서 선택";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOrder);
            this.groupBox1.Controls.Add(this.edtOrder);
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(768, 50);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "주문서";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listOrder);
            this.groupBox2.Location = new System.Drawing.Point(12, 133);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(768, 343);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "주문 내역";
            // 
            // listOrder
            // 
            this.listOrder.BackColor = System.Drawing.SystemColors.ControlLight;
            this.listOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader6,
            this.columnHeader5,
            this.columnHeader4});
            this.listOrder.GridLines = true;
            this.listOrder.Location = new System.Drawing.Point(19, 30);
            this.listOrder.Name = "listOrder";
            this.listOrder.Size = new System.Drawing.Size(735, 295);
            this.listOrder.TabIndex = 0;
            this.listOrder.UseCompatibleStateImageBehavior = false;
            this.listOrder.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "SN";
            this.columnHeader1.Width = 61;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Name";
            this.columnHeader2.Width = 250;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "수량";
            this.columnHeader3.Width = 51;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "분류";
            this.columnHeader6.Width = 89;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "공급업자";
            this.columnHeader5.Width = 149;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "바코드";
            this.columnHeader4.Width = 119;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(793, 541);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btn_test);
            this.Name = "MainForm";
            this.Text = "자동 주문";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_test;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.TextBox edtOrder;
        private System.Windows.Forms.Button btnOrder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView listOrder;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
    }
}

