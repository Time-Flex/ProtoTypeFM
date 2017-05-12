using System;
using System.Drawing;
using System.Windows.Forms;
using TFobject;

namespace TFClient
{
    public partial class FormClient : Form
    {
        private BalanceType _type;

        private FormBalance _frmGroupBalance;
        private FormBalance _frmAccBalance;

        public FormClient(BalanceType type)
        {
            InitializeComponent();

            _type = type;

            InitControl();
        }

        private void InitControl()
        {
            if (_type == BalanceType.PORT)
            {
                this.Text = "포트매니저";
                panel3.Location = new Point(0, 0);
                panel1.Enabled = false;
                panel2.Enabled = false;
            }
            else if (_type == BalanceType.FUND)
            {
                this.Text = "펀드매니저";
                panel1.Location = new Point(0, 0);
                panel3.Enabled = false;
                panel2.Enabled = false;
            }
            else if (_type == BalanceType.RISK)
            {
                this.Text = "리스크매니저";
                panel2.Location = new Point(0, 0);
                panel1.Enabled = false;
                panel3.Enabled = false;
            }

            this.Size = new Size(350, 67);
        }

        private void btnFMBalance_Click(object sender, EventArgs e)
        {
            if (_frmGroupBalance == null || !_frmGroupBalance.Created)
            {
                _frmGroupBalance = new FormBalance(_type);
                _frmGroupBalance.Show();
            }
            else
            {
                _frmGroupBalance.ViewForm();

                _frmGroupBalance.Activate();
                _frmGroupBalance.BringToFront();
            }
        }
        
        private void btnFMOrderList_Click(object sender, EventArgs e)
        {

        }

        private void btnFMFilledList_Click(object sender, EventArgs e)
        {

        }

        private void btnFMPerformance_Click(object sender, EventArgs e)
        {

        }

        private void btnRMMaintenance_Click(object sender, EventArgs e)
        {

        }

        private void btnRMFundBalance_Click(object sender, EventArgs e)
        {
            if (_frmGroupBalance == null || !_frmGroupBalance.Created)
            {
                _frmGroupBalance = new FormBalance(_type);
                _frmGroupBalance.Show();
            }
            else
            {
                _frmGroupBalance.ViewForm();

                _frmGroupBalance.Activate();
                _frmGroupBalance.BringToFront();
            }
        }

        private void btnRMPerformance_Click(object sender, EventArgs e)
        {

        }

        private void btnPMPortBalance_Click(object sender, EventArgs e)
        {
            if (_frmGroupBalance == null || !_frmGroupBalance.Created)
            {
                _frmGroupBalance = new FormBalance(_type);
                _frmGroupBalance.Show();
            }
            else
            {
                _frmGroupBalance.ViewForm();

                _frmGroupBalance.Activate();
                _frmGroupBalance.BringToFront();
            }
        }

        private void btnPMAccBalance_Click(object sender, EventArgs e)
        {
            if (_frmAccBalance == null || !_frmAccBalance.Created)
            {
                _frmAccBalance = new FormBalance(BalanceType.ACCOUNT);
                _frmAccBalance.Show();
            }
            else
            {
                _frmAccBalance.ViewForm();

                _frmAccBalance.Activate();
                _frmAccBalance.BringToFront();
            }
        }
    }
}
