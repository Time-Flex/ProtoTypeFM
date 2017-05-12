using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace TFLogin
{
    public partial class FormTFLogin : Form
    {
        public FormTFLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void rbtnPortManager_CheckedChanged(object sender, EventArgs e)
        {
            rbtnPortManager.BackColor = rbtnPortManager.Checked ? Color.MediumPurple : Color.DimGray;
        }

        private void rbtnFundManager_CheckedChanged(object sender, EventArgs e)
        {
            rbtnFundManager.BackColor = rbtnFundManager.Checked ? Color.SteelBlue : Color.DimGray;
        }

        private void rbtnRiskManager_CheckedChanged(object sender, EventArgs e)
        {
            rbtnRiskManager.BackColor = rbtnRiskManager.Checked ? Color.IndianRed : Color.DimGray;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //IAutoUpdater autoUpdater = new AutoUpdater(program);
            //autoUpdater.Update();
            //Utils.DeleteOldFiles(Application.StartupPath + "\\" + program);
            
            string type = rbtnPortManager.Checked ? "0" : (rbtnFundManager.Checked ? "1" : (rbtnRiskManager.Checked ? "2" : ""));
            //프로그램 실행
            Process process = new Process();
            //process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + program, program + ".exe");
            process.StartInfo.FileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TFClient.exe");
            process.StartInfo.Arguments = type;
            process.Start();

            Close();
        }
    }
}
