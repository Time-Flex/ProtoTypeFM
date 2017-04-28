using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProtoTypeFM
{
    public partial class FormTFAsset : Form
    {
        public FormTFAsset()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbtnFundManager_CheckedChanged(object sender, EventArgs e)
        {
            rbtnFundManager.BackColor = rbtnFundManager.Checked ? Color.SteelBlue : Color.DimGray;
        }

        private void rbtnRiskManager_CheckedChanged(object sender, EventArgs e)
        {
            rbtnRiskManager.BackColor = rbtnRiskManager.Checked ? Color.IndianRed : Color.DimGray;
        }
    }
}
