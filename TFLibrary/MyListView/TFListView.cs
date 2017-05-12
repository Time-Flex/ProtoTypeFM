using System.Drawing;
using System.Windows.Forms;

namespace TFLibrary.MyListView
{
    public class TFListView : ListView
    {
        public TFListView()
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
            this.BackColor = Utils.Colors.cTableBack;

            Utils.SetListViewRowHeight(this, 17);
        }

        protected override void OnNotifyMessage(Message m)
        {
            //Filter out the WM_ERASEBKGND message
            if (m.Msg != 0x14)
            {
                base.OnNotifyMessage(m);
            }
        }


        public Brush GetPlusMinusBrush(double value)
        {
            return value == 0 ? Brushes.LightGray : (value > 0 ? Brushes.OrangeRed : Brushes.DodgerBlue);
        }

        public Brush GetCodeBrush(string code)
        {
            SymbolStock ss = TFobj.SymbolStockDic[code];
            return ss.Type == StockType.KOSPI ? Brushes.Orange : (ss.Type == StockType.KOSDAQ ? Brushes.LimeGreen : Brushes.LightGray);
        }

        public Brush GetCreditBrush(CreditTypeCode type)
        {
            return type == CreditTypeCode.NONE ? Brushes.White : Brushes.Yellow;
        }

        public Brush GetSellBuyBrush(SellBuy sb)
        {
            return sb == SellBuy.SELL ? Brushes.DodgerBlue : (sb == SellBuy.BUY ? Brushes.OrangeRed : Brushes.LightGray);
        }


        public void OnClientSizeChanged(object sender, EventArgs e)
        {
            this.BeginUpdate();

            int otherColWidth = -this.Columns[this.Columns.Count - 1].Width;
            foreach (ColumnHeader col in this.Columns)
            {
                otherColWidth += col.Width;
            }
            this.Columns[this.Columns.Count - 1].Width = this.ClientRectangle.Width - otherColWidth;

            this.EndUpdate();
        }

        public void OnDrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            using (var sf = new StringFormat())
            {
                sf.LineAlignment = StringAlignment.Center;
                sf.Alignment = StringAlignment.Center;

                e.Graphics.FillRectangle(new SolidBrush(Utils.Colors.cTableHeader), e.Bounds);
                e.Graphics.DrawString(e.Header.Text, Utils.Fonts.fTableHeader, new SolidBrush(Utils.Colors.cTableText), e.Bounds, sf);

                if (e.ColumnIndex > 0)
                    e.Graphics.DrawLine(new Pen(Utils.Colors.cTableHeaderLine), e.Bounds.X, e.Bounds.Y, e.Bounds.X, e.Bounds.Y + e.Bounds.Height);
            }
        }

        public void OnDrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            if (e.Item.Selected)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(80, 255, 255, 255)), e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
            }

            // gridline
            e.Graphics.DrawLine(new Pen(Utils.Colors.cTableHeader), e.Bounds.X, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y);
            e.Graphics.DrawLine(new Pen(Utils.Colors.cTableHeader), e.Bounds.X, e.Bounds.Y, e.Bounds.X, e.Bounds.Y + e.Bounds.Height);
            e.Graphics.DrawLine(new Pen(Utils.Colors.cTableHeader), e.Bounds.X + e.Bounds.Width, e.Bounds.Y, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
            e.Graphics.DrawLine(new Pen(Utils.Colors.cTableHeader), e.Bounds.X, e.Bounds.Y + e.Bounds.Height, e.Bounds.X + e.Bounds.Width, e.Bounds.Y + e.Bounds.Height);
        }

    }
}
