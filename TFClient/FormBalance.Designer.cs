using TFform;
using TFform.MyListView;
using TFobject.Order;
using TFobject.Portfolio;

namespace TFClient
{
    partial class FormBalance
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnOrder = new System.Windows.Forms.Button();
            this.btnRefreshBalance = new System.Windows.Forms.Button();
            this.listBalanceInfo = new TFListView2<BalanceStock>();
            this.listMainInfo = new TFListView2<PortfolioStockInfo>();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 83.75559F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.24441F));
            this.tableLayoutPanel1.Controls.Add(this.listBalanceInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.listMainInfo, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(671, 408);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnOrder);
            this.panel1.Controls.Add(this.btnRefreshBalance);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(565, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(103, 98);
            this.panel1.TabIndex = 2;
            // 
            // btnOrder
            // 
            this.btnOrder.Location = new System.Drawing.Point(3, 26);
            this.btnOrder.Name = "btnOrder";
            this.btnOrder.Size = new System.Drawing.Size(75, 47);
            this.btnOrder.TabIndex = 1;
            this.btnOrder.Text = "펀드주문";
            this.btnOrder.UseVisualStyleBackColor = true;
            this.btnOrder.Click += new System.EventHandler(this.btnFundOrder_Click);
            // 
            // btnRefreshBalance
            // 
            this.btnRefreshBalance.Location = new System.Drawing.Point(3, 3);
            this.btnRefreshBalance.Name = "btnRefreshBalance";
            this.btnRefreshBalance.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshBalance.TabIndex = 0;
            this.btnRefreshBalance.Text = "잔고조회";
            this.btnRefreshBalance.UseVisualStyleBackColor = true;
            // 
            // listBalanceInfo
            // 
            this.listBalanceInfo.BackColor = System.Drawing.Color.Black;
            this.tableLayoutPanel1.SetColumnSpan(this.listBalanceInfo, 2);
            this.listBalanceInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBalanceInfo.FullRowSelect = true;
            this.listBalanceInfo.Location = new System.Drawing.Point(3, 107);
            this.listBalanceInfo.Name = "listBalanceInfo";
            this.listBalanceInfo.OwnerDraw = true;
            this.listBalanceInfo.Size = new System.Drawing.Size(665, 298);
            this.listBalanceInfo.TabIndex = 1;
            this.listBalanceInfo.UseCompatibleStateImageBehavior = false;
            this.listBalanceInfo.View = System.Windows.Forms.View.Details;
            this.listBalanceInfo.VirtualMode = true;
            this.listBalanceInfo.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listBalanceInfo_DrawColumnHeader);
            this.listBalanceInfo.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listBalanceInfo_DrawSubItem);
            this.listBalanceInfo.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listBalanceInfo_RetrieveVirtualItem);
            this.listBalanceInfo.ClientSizeChanged += new System.EventHandler(this.listBalanceInfo_ClientSizeChanged);
            // 
            // listMainInfo
            // 
            this.listMainInfo.BackColor = System.Drawing.Color.Black;
            this.listMainInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMainInfo.FullRowSelect = true;
            this.listMainInfo.Location = new System.Drawing.Point(3, 3);
            this.listMainInfo.Name = "listMainInfo";
            this.listMainInfo.OwnerDraw = true;
            this.listMainInfo.Size = new System.Drawing.Size(556, 98);
            this.listMainInfo.TabIndex = 0;
            this.listMainInfo.UseCompatibleStateImageBehavior = false;
            this.listMainInfo.View = System.Windows.Forms.View.Details;
            this.listMainInfo.VirtualMode = true;
            this.listMainInfo.DrawColumnHeader += new System.Windows.Forms.DrawListViewColumnHeaderEventHandler(this.listMainInfo_DrawColumnHeader);
            this.listMainInfo.DrawSubItem += new System.Windows.Forms.DrawListViewSubItemEventHandler(this.listMainInfo_DrawSubItem);
            this.listMainInfo.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.listMainInfo_RetrieveVirtualItem);
            this.listMainInfo.ClientSizeChanged += new System.EventHandler(this.listMainInfo_ClientSizeChanged);
            this.listMainInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listMainInfo_MouseClick);
            // 
            // FormBalance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 408);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.Name = "FormBalance";
            this.Text = "펀드";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBalance_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private TFListView2<BalanceStock> listBalanceInfo;
        private TFListView2<PortfolioStockInfo> listMainInfo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRefreshBalance;
        private System.Windows.Forms.Button btnOrder;
    }
}