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
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnFMPerformance = new System.Windows.Forms.Button();
            this.btnFMBalance = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnRMMaintenance = new System.Windows.Forms.Button();
            this.btnRMPerformance = new System.Windows.Forms.Button();
            this.btnRMBalance = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.btnFMPerformance);
            this.panel1.Controls.Add(this.btnFMBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(341, 28);
            this.panel1.TabIndex = 0;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(3, 3);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 23);
            this.btnOrder.TabIndex = 2;
            this.btnOrder.Text = "주문";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnOrder_Click);
            // 
            // btnFMPerformance
            // 
            this.btnFMPerformance.Location = new System.Drawing.Point(153, 3);
            this.btnFMPerformance.Name = "btnFMPerformance";
            this.btnFMPerformance.Size = new System.Drawing.Size(75, 23);
            this.btnFMPerformance.TabIndex = 1;
            this.btnFMPerformance.Text = "실적조회";
            this.btnFMPerformance.UseVisualStyleBackColor = true;
            // 
            // btnFMBalance
            // 
            this.btnFMBalance.Location = new System.Drawing.Point(78, 3);
            this.btnFMBalance.Name = "btnFMBalance";
            this.btnFMBalance.Size = new System.Drawing.Size(75, 23);
            this.btnFMBalance.TabIndex = 0;
            this.btnFMBalance.Text = "잔고조회";
            this.btnFMBalance.UseVisualStyleBackColor = true;
            this.btnFMBalance.Click += new System.EventHandler(this.btnFMBalance_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnRMMaintenance);
            this.panel2.Controls.Add(this.btnRMPerformance);
            this.panel2.Controls.Add(this.btnRMBalance);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(341, 28);
            this.panel2.TabIndex = 1;
            // 
            // btnRMMaintenance
            // 
            this.btnRMMaintenance.Location = new System.Drawing.Point(155, 3);
            this.btnRMMaintenance.Name = "btnRMMaintenance";
            this.btnRMMaintenance.Size = new System.Drawing.Size(75, 23);
            this.btnRMMaintenance.TabIndex = 2;
            this.btnRMMaintenance.Text = "펀드관리";
            this.btnRMMaintenance.UseVisualStyleBackColor = true;
            // 
            // btnRMPerformance
            // 
            this.btnRMPerformance.Location = new System.Drawing.Point(79, 3);
            this.btnRMPerformance.Name = "btnRMPerformance";
            this.btnRMPerformance.Size = new System.Drawing.Size(75, 23);
            this.btnRMPerformance.TabIndex = 1;
            this.btnRMPerformance.Text = "실적조회";
            this.btnRMPerformance.UseVisualStyleBackColor = true;
            // 
            // btnRMBalance
            // 
            this.btnRMBalance.Location = new System.Drawing.Point(3, 3);
            this.btnRMBalance.Name = "btnRMBalance";
            this.btnRMBalance.Size = new System.Drawing.Size(75, 23);
            this.btnRMBalance.TabIndex = 0;
            this.btnRMBalance.Text = "잔고조회";
            this.btnRMBalance.UseVisualStyleBackColor = true;
            // 
            // FormClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 28);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.MaximizeBox = false;
            this.Name = "FormClient";
            this.Text = "펀드매니저";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnFMPerformance;
        private System.Windows.Forms.Button btnFMBalance;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnRMMaintenance;
        private System.Windows.Forms.Button btnRMPerformance;
        private System.Windows.Forms.Button btnRMBalance;
        private System.Windows.Forms.Button btnOrder;
    }
}

