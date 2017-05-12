using System.Windows.Forms;

namespace TFLibrary.MyListView
{
    public class ListViewVirtual : ListView
    {
        public ListViewVirtual()
        {
            //Activate double buffering
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);

            //Enable the OnNotifyMessage event so we get a chance to filter out 
            // Windows messages before they get to the form's WndProc
            this.SetStyle(ControlStyles.EnableNotifyMessage, true);

            this.OwnerDraw = true;
            this.VirtualMode = true;
            this.View = View.Details;
            this.FullRowSelect = true;
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }
    }
}
