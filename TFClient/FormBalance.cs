using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TFform;
using TFobject;
using TFobject.Order;
using TFobject.Portfolio;
using TFutil;

namespace TFClient
{
    public partial class FormBalance : Form
    {
        private BalanceType _type;

        private FormOrder _frmOrder;

        //포트폴리오
        List<PortfolioStockInfo> mPortStockInfoList;
        public List<PortfolioStockManager> mPFManagerList;
        public int ManagerIndex = 0;

        List<BalanceStock> _test_list = new List<BalanceStock>();

        public FormBalance(BalanceType type)
        {
            InitializeComponent();

            _type = type;

            InitControl();
        }

        private void InitControl()
        {
            if (_type == BalanceType.PORT)
            {
                this.Text = "포트조회";
                btnOrder.Text = "포트주문";

                listMainInfo.SetColumnHeader(new List<ColumnHeaderInfo>() {
                    new ColumnHeaderInfo() { Title = "포트", Width = 150, Align = HorizontalAlignment.Left },
                    new ColumnHeaderInfo() { Title = "순자산", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "예수금2", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "평가", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "현금", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "융자", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "손익", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "수익률", Width = 75, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "전일대비", Width = 75, Align = HorizontalAlignment.Right }
                });

                listBalanceInfo.SetColumnHeader(new List<ColumnHeaderInfo>() {
                    new ColumnHeaderInfo() { Title = "종목", Width = 150, Align = HorizontalAlignment.Left },
                    new ColumnHeaderInfo() { Title = "비율", Width = 70, Align = HorizontalAlignment.Left },
                    new ColumnHeaderInfo() { Title = "코드", Width = 60, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "평가", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "비중", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "손익", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "수익률", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "잔고", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "청산가능", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "현재가", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "전일대비", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "평단", Width = 70, Align = HorizontalAlignment.Right }
                }, 4);
                listBalanceInfo.SetComparers(new Dictionary<int, Comparison<BalanceStock>> {
                    {0, (a,b) => a.Name.CompareTo(b.Name)},
                    {1, (a,b) => Convert.ToInt32(a.Info.Split('/')[0]).CompareTo(Convert.ToInt32(b.Info.Split('/')[0]))},
                    {2, (a,b) => a.Code.CompareTo(b.Code)},
                    {3, (a,b) => a.ApprAmt.CompareTo(b.ApprAmt)},
                    {4, (a,b) => a.ApprAmtRatio.CompareTo(b.ApprAmtRatio)},
                    {5, (a,b) => a.ApprProfit.CompareTo(b.ApprProfit)},
                    {6, (a,b) => a.ApprProfitRate.CompareTo(b.ApprProfitRate)},
                    {7, (a,b) => a.Qty.CompareTo(b.Qty)},
                    {8, (a,b) => a.ExitPossQty.CompareTo(b.ExitPossQty)},
                    {9, (a,b) => a.CurPrice.CompareTo(b.CurPrice)},
                    {10, (a,b) => a.ChangePriceRate.CompareTo(b.ChangePriceRate)},
                    {11, (a,b) => a.AvgPrice.CompareTo(b.AvgPrice)}
                });

                BalanceStock bs = new BalanceStock("000250", "삼천당제약");
                bs.Info = "100/0/0";
                bs.ApprAmt = 3999;
                bs.ApprAmtRatio = 0.5413;
                bs.ApprProfit = 521;
                bs.ApprProfitRate = 0.1493;
                bs.Qty = 275774;
                bs.ExitPossQty = 275774;
                bs.CurPrice = 14500;
                bs.ChangePriceRate = 0.0136;
                bs.AvgPrice = 12611;
                _test_list.Add(bs);

                bs = new BalanceStock("008260", "NI스틸");
                bs.Info = "72/26/1";
                bs.ApprAmt = 695;
                bs.ApprAmtRatio = 0.0945;
                bs.ApprProfit = -54;
                bs.ApprProfitRate = -0.0721;
                bs.Qty = 168374;
                bs.ExitPossQty = 168374;
                bs.CurPrice = 4125;
                bs.ChangePriceRate = -0.0084;
                bs.AvgPrice = 12611;
                _test_list.Add(bs);

                //listBalanceInfo.SetDataList(new List<BalanceStock>());
                listBalanceInfo.SetDataList(_test_list);
            }
            else if (_type == BalanceType.FUND)
            {
                this.Text = "펀드조회";
                btnOrder.Text = "펀드주문";
            }
            else if (_type == BalanceType.RISK)
            {
                this.Text = "펀드조회";
                btnOrder.Visible = false;
            }
            else if (_type == BalanceType.ACCOUNT)
            {
                this.Text = "계좌조회";
                btnOrder.Text = "계좌주문";


                listMainInfo.SetColumnHeader(new List<ColumnHeaderInfo>() {
                    new ColumnHeaderInfo() { Title = "증권사", Width = 50, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "구분", Width = 35, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "계좌번호", Width = 80, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "계좌명", Width = 60, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "예수금2", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "순자산", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "평가", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "현금", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "융자", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "손익", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "수익률", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "전일대비", Width = 70, Align = HorizontalAlignment.Right }
                });

                listBalanceInfo.SetColumnHeader(new List<ColumnHeaderInfo>() {
                    new ColumnHeaderInfo() { Title = "", Width = 20, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "신용", Width = 35, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "종목", Width = 150, Align = HorizontalAlignment.Left },
                    new ColumnHeaderInfo() { Title = "코드", Width = 60, Align = HorizontalAlignment.Center },
                    new ColumnHeaderInfo() { Title = "평가", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "비중", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "손익", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "수익률", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "잔고", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "청산가능", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "현재가", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "전일대비", Width = 70, Align = HorizontalAlignment.Right },
                    new ColumnHeaderInfo() { Title = "평단", Width = 70, Align = HorizontalAlignment.Right }
                }, 4);
                listBalanceInfo.SetComparers(new Dictionary<int, Comparison<BalanceStock>> {
                    {0, (a,b) => a.Selected.CompareTo(b.Selected)},
                    {1, (a,b) => a.CreditType.CompareTo(b.CreditType)},
                    {2, (a,b) => a.Name.CompareTo(b.Name)},
                    {3, (a,b) => a.Code.CompareTo(b.Code)},
                    {4, (a,b) => a.ApprAmt.CompareTo(b.ApprAmt)},
                    {5, (a,b) => a.ApprAmtRatio.CompareTo(b.ApprAmtRatio)},
                    {6, (a,b) => a.ApprProfit.CompareTo(b.ApprProfit)},
                    {7, (a,b) => a.ApprProfitRate.CompareTo(b.ApprProfitRate)},
                    {8, (a,b) => a.Qty.CompareTo(b.Qty)},
                    {9, (a,b) => a.ExitPossQty.CompareTo(b.ExitPossQty)},
                    {10, (a,b) => a.CurPrice.CompareTo(b.CurPrice)},
                    {11, (a,b) => a.ChangePriceRate.CompareTo(b.ChangePriceRate)},
                    {12, (a,b) => a.AvgPrice.CompareTo(b.AvgPrice)}
                });
                listBalanceInfo.SetDataList(new List<BalanceStock>());
            }
        }

        private void btnFundOrder_Click(object sender, EventArgs e)
        {
            if (_frmOrder == null || !_frmOrder.Created)
            {
                _frmOrder = new FormOrder(_type);
                _frmOrder.Show();
            }
            else
            {
                _frmOrder.ViewForm();

                _frmOrder.Activate();
                _frmOrder.BringToFront();
            }
        }

        public void ViewForm()
        {
            this.WindowState = FormWindowState.Normal;
            this.Visible = true;
        }


        private void listMainInfo_ClientSizeChanged(object sender, EventArgs e)
        {
            listMainInfo.OnClientSizeChanged(sender, e);
        }

        private void listMainInfo_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            listMainInfo.OnDrawColumnHeader(sender, e);
        }

        private void listMainInfo_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                    case HorizontalAlignment.Left:
                        sf.Alignment = StringAlignment.Near;
                        break;
                }

                sf.LineAlignment = StringAlignment.Far;
                Brush fontBrush = Brushes.White;

                if (_type == BalanceType.PORT)
                {
                    PortfolioStockInfo pi = mPortStockInfoList[e.ItemIndex];

                    switch (e.ColumnIndex)
                    {
                        case 0:
                            fontBrush = Brushes.Yellow;
                            break;
                        case 6:
                        case 7:
                            fontBrush = listBalanceInfo.GetPlusMinusBrush(pi.ApprProfit);
                            break;
                        case 8:
                            fontBrush = listBalanceInfo.GetPlusMinusBrush(pi.NetAssetChangedRate);
                            break;
                    }
                }

                e.Graphics.DrawString(e.SubItem.Text, this.Font, fontBrush, e.Bounds, sf);

                listMainInfo.OnDrawSubItem(sender, e);
            }
        }

        private void listMainInfo_MouseClick(object sender, MouseEventArgs e)
        {
            int row = listMainInfo.HitTest(e.X, e.Y).Item.Index;
            if (row < 0) return;
            ManagerIndex = row;
            ViewAccountManager(row);
        }

        private void ViewAccountManager(int pmIndex)
        {
            //if (dgvPortfolioInfo.Rows.Count <= pmIndex) return;
            if (listMainInfo.Items.Count <= pmIndex) return;

            ManagerIndex = pmIndex;

            // 증권사 잔고 및 스펙트럼 주문 초기화
            ResetBalanceStockList(pmIndex);
        }

        private void ResetBalanceStockList(int pmIndex)
        {
            if (pmIndex != ManagerIndex) return;

            List<BalanceStock> balList = mPFManagerList[pmIndex].BalList;
            for (int i = 0; i < balList.Count; i++)
            {
                balList[i].ApprAmtRatio = balList[i].ApprAmt / mPFManagerList[pmIndex].PortStockInfo.ApprAmt;
            }
            
            RefreshSizeLB();
            listBalanceInfo.SmartSort();
        }

        private void RefreshSizeLB()
        {
            listBalanceInfo.InvokeIfRequired(lc =>
            {
                lc.VirtualListSize = mPFManagerList[ManagerIndex].BalList.Count;
                lc.Columns[0].Text = string.Format("종목({0})", mPFManagerList[ManagerIndex].BalList.Count);
            });
        }

        private void listMainInfo_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                if (e.ItemIndex >= listMainInfo.VirtualListSize || e.ItemIndex >= listMainInfo.DataList.Count) return;

                PortfolioStockInfo pi = listMainInfo.DataList[e.ItemIndex];

                e.Item = new ListViewItem(new string[]
                     {
                     string.Format("{0:c}", pi.Name),
                     string.Format("{0:c}", pi.NetAssetApprAmt),
                     string.Format("{0:c}", pi.Deposit2),
                     string.Format("{0:c}", pi.ApprAmt),
                     string.Format("{0:c}", pi.OrderAmt),
                     string.Format("{0:c}", pi.CreditAmt),
                     string.Format("{0:c}", pi.ApprProfit),
                     string.Format("{0:p2}", pi.ApprProfitRate),
                     string.Format("{0:p2}", pi.NetAssetChangedRate)
                     })
                {
                    Tag = pi
                };
            }
            catch
            {
                Utils.LogError("error", "listViewPortInfo_RetrieveVirtualItem");
            }
        }

        private void listBalanceInfo_ClientSizeChanged(object sender, EventArgs e)
        {
            listBalanceInfo.OnClientSizeChanged(sender, e);
        }
        
        private void listBalanceInfo_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            try
            {
                if (e.ItemIndex >= listBalanceInfo.VirtualListSize || e.ItemIndex >= listBalanceInfo.DataList.Count) return;

                BalanceStock b = listBalanceInfo.DataList[e.ItemIndex];
                e.Item = new ListViewItem(new string[]
                     {
                     b.Name,
                     b.Info,
                     b.Code,
                     string.Format("{0:c}", b.ApprAmt),
                     string.Format("{0:p2}", b.ApprAmtRatio),
                     string.Format("{0:c}", b.ApprProfit),
                     string.Format("{0:p2}", b.ApprProfitRate),
                     b.Qty.ToString(),
                     b.ExitPossQty.ToString(),
                     string.Format("{0:n0}", b.CurPrice),
                     string.Format("{0:p2}", b.ChangePriceRate),
                     string.Format("{0:n0}", b.AvgPrice)
                     })
                {
                    Tag = b
                };
            }
            catch
            {
                Utils.LogError("error", "listviewBalance_RetrieveVirtualItem");
            }
        }

        private void listBalanceInfo_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            listBalanceInfo.OnDrawColumnHeader(sender, e);
        }

        private void listBalanceInfo_DrawSubItem(object sender, DrawListViewSubItemEventArgs e)
        {
            using (StringFormat sf = new StringFormat())
            {
                switch (e.Header.TextAlign)
                {
                    case HorizontalAlignment.Center:
                        sf.Alignment = StringAlignment.Center;
                        break;
                    case HorizontalAlignment.Right:
                        sf.Alignment = StringAlignment.Far;
                        break;
                    case HorizontalAlignment.Left:
                        sf.Alignment = StringAlignment.Near;
                        break;
                }

                sf.LineAlignment = StringAlignment.Far;

                BalanceStock b = listBalanceInfo.DataList[e.ItemIndex];
                Brush fontBrush = Brushes.White;

                switch (e.ColumnIndex)
                {
                    case 0:
                    case 2:
                        //fontBrush = listBalanceInfo.GetCodeBrush(b.Code);
                        break;
                    case 5:
                    case 6:
                        fontBrush = listBalanceInfo.GetPlusMinusBrush(b.ApprProfit);
                        break;
                    case 10:
                        fontBrush = listBalanceInfo.GetPlusMinusBrush(b.ChangePriceRate);
                        break;
                }

                e.Graphics.DrawString(e.SubItem.Text, this.Font, fontBrush, e.Bounds, sf);

                listBalanceInfo.OnDrawSubItem(sender, e);
            }
        }

        private void FormBalance_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_frmOrder != null)
                _frmOrder.Close();
        }
    }
}
