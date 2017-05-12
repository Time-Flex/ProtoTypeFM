using System.Windows.Forms;
using TFobject;

namespace TFClient
{
    public partial class FormOrder : Form
    {
        public FormOrder(BalanceType type)
        {
            InitializeComponent();

            if (type == BalanceType.ACCOUNT)
            {
                //계좌주문
                this.Text = "계좌주문";
            }
            else if (type == BalanceType.PORT)
            {
                //포트주문
                this.Text = "포트주문";
            }
            else if (type == BalanceType.FUND)
            {
                //펀드주문
                this.Text = "펀드주문";
            }
        }


        public void ViewForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }

    }
}
