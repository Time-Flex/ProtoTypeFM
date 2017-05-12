namespace TFClient
{
    partial class FormClient
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnFMFilledList = new System.Windows.Forms.Button();
            this.btnFMOrderList = new System.Windows.Forms.Button();
            this.btnFMPerformance = new System.Windows.Forms.Button();
            this.btnFMFundBalance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRMMaintenance = new System.Windows.Forms.Button();
            this.btnRMPerformance = new System.Windows.Forms.Button();
            this.btnRMFundBalance = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnPMFilledList = new System.Windows.Forms.Button();
            this.btnPMOrderList = new System.Windows.Forms.Button();
            this.btnPMPortBalance = new System.Windows.Forms.Button();
            this.btnPMAccBalance = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnFMFilledList);
            this.panel1.Controls.Add(this.btnFMOrderList);
            this.panel1.Controls.Add(this.btnFMPerformance);
            this.panel1.Controls.Add(this.btnFMFundBalance);
            this.panel1.Location = new System.Drawing.Point(12, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 28);
            this.panel1.TabIndex = 0;
            // 
            // btnFMFilledList
            // 
            this.btnFMFilledList.Location = new System.Drawing.Point(155, 3);
            this.btnFMFilledList.Name = "btnFMFilledList";
            this.btnFMFilledList.Size = new System.Drawing.Size(75, 23);
            this.btnFMFilledList.TabIndex = 2;
            this.btnFMFilledList.Text = "체결조회";
            this.btnFMFilledList.UseVisualStyleBackColor = true;
            this.btnFMFilledList.Click += new System.EventHandler(this.btnFMFilledList_Click);
            // 
            // btnFMOrderList
            // 
            this.btnFMOrderList.Location = new System.Drawing.Point(79, 3);
            this.btnFMOrderList.Name = "btnFMOrderList";
            this.btnFMOrderList.Size = new System.Drawing.Size(75, 23);
            this.btnFMOrderList.TabIndex = 1;
            this.btnFMOrderList.Text = "주문조회";
            this.btnFMOrderList.UseVisualStyleBackColor = true;
            this.btnFMOrderList.Click += new System.EventHandler(this.btnFMOrderList_Click);
            // 
            // btnFMPerformance
            // 
            this.btnFMPerformance.Location = new System.Drawing.Point(231, 3);
            this.btnFMPerformance.Name = "btnFMPerformance";
            this.btnFMPerformance.Size = new System.Drawing.Size(75, 23);
            this.btnFMPerformance.TabIndex = 3;
            this.btnFMPerformance.Text = "실적조회";
            this.btnFMPerformance.UseVisualStyleBackColor = true;
            this.btnFMPerformance.Click += new System.EventHandler(this.btnFMPerformance_Click);
            // 
            // btnFMFundBalance
            // 
            this.btnFMFundBalance.Location = new System.Drawing.Point(3, 3);
            this.btnFMFundBalance.Name = "btnFMFundBalance";
            this.btnFMFundBalance.Size = new System.Drawing.Size(75, 23);
            this.btnFMFundBalance.TabIndex = 0;
            this.btnFMFundBalance.Text = "펀드조회";
            this.btnFMFundBalance.UseVisualStyleBackColor = true;
            this.btnFMFundBalance.Click += new System.EventHandler(this.btnFMBalance_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRMMaintenance);
            this.panel2.Controls.Add(this.btnRMPerformance);
            this.panel2.Controls.Add(this.btnRMFundBalance);
            this.panel2.Location = new System.Drawing.Point(12, 99);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 28);
            this.panel2.TabIndex = 1;
            // 
            // btnRMMaintenance
            // 
            this.btnRMMaintenance.Location = new System.Drawing.Point(3, 3);
            this.btnRMMaintenance.Name = "btnRMMaintenance";
            this.btnRMMaintenance.Size = new System.Drawing.Size(75, 23);
            this.btnRMMaintenance.TabIndex = 0;
            this.btnRMMaintenance.Text = "펀드관리";
            this.btnRMMaintenance.UseVisualStyleBackColor = true;
            this.btnRMMaintenance.Click += new System.EventHandler(this.btnRMMaintenance_Click);
            // 
            // btnRMPerformance
            // 
            this.btnRMPerformance.Location = new System.Drawing.Point(155, 3);
            this.btnRMPerformance.Name = "btnRMPerformance";
            this.btnRMPerformance.Size = new System.Drawing.Size(75, 23);
            this.btnRMPerformance.TabIndex = 2;
            this.btnRMPerformance.Text = "실적조회";
            this.btnRMPerformance.UseVisualStyleBackColor = true;
            this.btnRMPerformance.Click += new System.EventHandler(this.btnRMPerformance_Click);
            // 
            // btnRMFundBalance
            // 
            this.btnRMFundBalance.Location = new System.Drawing.Point(79, 3);
            this.btnRMFundBalance.Name = "btnRMFundBalance";
            this.btnRMFundBalance.Size = new System.Drawing.Size(75, 23);
            this.btnRMFundBalance.TabIndex = 1;
            this.btnRMFundBalance.Text = "펀드조회";
            this.btnRMFundBalance.UseVisualStyleBackColor = true;
            this.btnRMFundBalance.Click += new System.EventHandler(this.btnRMFundBalance_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnPMFilledList);
            this.panel3.Controls.Add(this.btnPMOrderList);
            this.panel3.Controls.Add(this.btnPMPortBalance);
            this.panel3.Controls.Add(this.btnPMAccBalance);
            this.panel3.Location = new System.Drawing.Point(12, 131);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 28);
            this.panel3.TabIndex = 3;
            // 
            // btnPMFilledList
            // 
            this.btnPMFilledList.Location = new System.Drawing.Point(231, 3);
            this.btnPMFilledList.Name = "btnPMFilledList";
            this.btnPMFilledList.Size = new System.Drawing.Size(75, 23);
            this.btnPMFilledList.TabIndex = 3;
            this.btnPMFilledList.Text = "체결조회";
            this.btnPMFilledList.UseVisualStyleBackColor = true;
            // 
            // btnPMOrderList
            // 
            this.btnPMOrderList.Location = new System.Drawing.Point(155, 3);
            this.btnPMOrderList.Name = "btnPMOrderList";
            this.btnPMOrderList.Size = new System.Drawing.Size(75, 23);
            this.btnPMOrderList.TabIndex = 2;
            this.btnPMOrderList.Text = "주문조회";
            this.btnPMOrderList.UseVisualStyleBackColor = true;
            // 
            // btnPMPortBalance
            // 
            this.btnPMPortBalance.Location = new System.Drawing.Point(3, 3);
            this.btnPMPortBalance.Name = "btnPMPortBalance";
            this.btnPMPortBalance.Size = new System.Drawing.Size(75, 23);
            this.btnPMPortBalance.TabIndex = 0;
            this.btnPMPortBalance.Text = "포트조회";
            this.btnPMPortBalance.UseVisualStyleBackColor = true;
            this.btnPMPortBalance.Click += new System.EventHandler(this.btnPMPortBalance_Click);
            // 
            // btnPMAccBalance
            // 
            this.btnPMAccBalance.Location = new System.Drawing.Point(79, 3);
            this.btnPMAccBalance.Name = "btnPMAccBalance";
            this.btnPMAccBalance.Size = new System.Drawing.Size(75, 23);
            this.btnPMAccBalance.TabIndex = 1;
            this.btnPMAccBalance.Text = "계좌조회";
            this.btnPMAccBalance.UseVisualStyleBackColor = true;
            this.btnPMAccBalance.Click += new System.EventHandler(this.btnPMAccBalance_Click);
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 167);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormClient";
            this.Text = "FormClient";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFMPerformance;
        private System.Windows.Forms.Button btnFMFundBalance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRMMaintenance;
        private System.Windows.Forms.Button btnRMPerformance;
        private System.Windows.Forms.Button btnRMFundBalance;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnPMPortBalance;
        private System.Windows.Forms.Button btnPMAccBalance;
        private System.Windows.Forms.Button btnFMOrderList;
        private System.Windows.Forms.Button btnFMFilledList;
        private System.Windows.Forms.Button btnPMFilledList;
        private System.Windows.Forms.Button btnPMOrderList;
    }
}

