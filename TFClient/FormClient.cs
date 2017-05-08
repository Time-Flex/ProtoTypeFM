using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFClient
{
    public partial class FormClient : Form
    {
        public FormClient(int type)
        {
            InitializeComponent();

            if (type == 1)
            {
                this.Text = "펀드매니저";
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (type == 2)
            {
                this.Text = "리스크매니저";
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }

        private void btnFMBalance_Click(object sender, EventArgs e)
        {
            FormFMBalance form = new FormFMBalance();
            form.Show();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            FormOrder form = new FormOrder();
            form.Show();
        }
    }
}
