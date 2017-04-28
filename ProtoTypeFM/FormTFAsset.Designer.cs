namespace ProtoTypeFM
{
    partial class FormTFAsset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTFAsset));
            this.rbtnFundManager = new System.Windows.Forms.RadioButton();
            this.rbtnRiskManager = new System.Windows.Forms.RadioButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // rbtnFundManager
            // 
            this.rbtnFundManager.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnFundManager.BackColor = System.Drawing.Color.DimGray;
            this.rbtnFundManager.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnFundManager.Font = new System.Drawing.Font("NanumGothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbtnFundManager.ForeColor = System.Drawing.Color.White;
            this.rbtnFundManager.Location = new System.Drawing.Point(18, 36);
            this.rbtnFundManager.Name = "rbtnFundManager";
            this.rbtnFundManager.Size = new System.Drawing.Size(125, 50);
            this.rbtnFundManager.TabIndex = 0;
            this.rbtnFundManager.Text = "펀드매니저";
            this.rbtnFundManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnFundManager.UseVisualStyleBackColor = false;
            this.rbtnFundManager.CheckedChanged += new System.EventHandler(this.rbtnFundManager_CheckedChanged);
            // 
            // rbtnRiskManager
            // 
            this.rbtnRiskManager.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbtnRiskManager.BackColor = System.Drawing.Color.DimGray;
            this.rbtnRiskManager.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.rbtnRiskManager.Font = new System.Drawing.Font("NanumGothic", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rbtnRiskManager.ForeColor = System.Drawing.Color.White;
            this.rbtnRiskManager.Location = new System.Drawing.Point(18, 97);
            this.rbtnRiskManager.Name = "rbtnRiskManager";
            this.rbtnRiskManager.Size = new System.Drawing.Size(125, 50);
            this.rbtnRiskManager.TabIndex = 1;
            this.rbtnRiskManager.Text = "리스크관리";
            this.rbtnRiskManager.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbtnRiskManager.UseVisualStyleBackColor = false;
            this.rbtnRiskManager.CheckedChanged += new System.EventHandler(this.rbtnRiskManager_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(158, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(104, 21);
            this.textBox1.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(158, 64);
            this.textBox2.Name = "textBox2";
            this.textBox2.PasswordChar = '*';
            this.textBox2.Size = new System.Drawing.Size(104, 21);
            this.textBox2.TabIndex = 3;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Gulim", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogin.Location = new System.Drawing.Point(187, 109);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 38);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "로그인";
            this.btnLogin.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.BackColor = System.Drawing.Color.Transparent;
            this.checkBox1.ForeColor = System.Drawing.Color.White;
            this.checkBox1.Location = new System.Drawing.Point(158, 91);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(84, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "아이디저장";
            this.checkBox1.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gulim", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(4, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 11);
            this.label1.TabIndex = 7;
            this.label1.Text = "TF Asset v0.1.0";
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.Red;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("HYGothic-Extra", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(263, -2);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(20, 20);
            this.btnExit.TabIndex = 8;
            this.btnExit.Text = "X";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // FormTFAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(282, 157);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rbtnRiskManager);
            this.Controls.Add(this.rbtnFundManager);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTFAsset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbtnFundManager;
        private System.Windows.Forms.RadioButton rbtnRiskManager;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExit;
    }
}

