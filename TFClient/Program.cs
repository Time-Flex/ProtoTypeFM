using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TFClient
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if DEBUG
            // debug
            Application.Run(new FormClient(1));
#else
            // release
            if (args.Length == 0)
            {
                MessageBox.Show("로그인 하세요.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int type = Convert.ToInt32(args[0]);
            Application.Run(new FormClient(type));
#endif
        }
    }
}
