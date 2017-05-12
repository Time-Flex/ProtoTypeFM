using System;
using System.Threading;
using TFobject;
using TFobject.Data;
using TFobject.Feeder;
using TFsocket;
using TFutil;

namespace TFDataServer
{
    class Program
    {
        static AsyncSocketServer server = new AsyncSocketServer();
        static FeederHyundai2 feeder = new FeederHyundai2();

        static bool readyHDMaster = false;
        static int _PORT = 9900;

        static void Main(string[] args)
        {
            PrevServer();
            InitServer();
            server.StartListening(_PORT);    // 소켓 시작
        }

        private static void PrevServer()
        {
            Utils.MakeLogFile(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\'));

            server._event_socket_client_connected += ConnectedClient;
            server._event_socket_client_disconnected += DisconnectedClient;
            server._event_socket_client_received_data += ReceivedDataClient;

            feeder._event_received_init_status += ReceivedInitStatus;
            feeder._event_received_codelist += ReceivedCodeList;
            feeder._event_received_real_price2 += ReceivedRealPrice2;
            //feeder._event_received_real_hoga2 += ReceivedRealHoga2;

        }

        private static void ReceivedDataClient(int csIndex, string msg)
        {

        }

        private static void DisconnectedClient(int csIndex)
        {

        }

        private static void ConnectedClient(int csIndex)
        {

        }

        private static void ReceivedRealHoga2(StockHogaTick tick)
        {
            string json = Utils.ConvertObjectToJSon(tick);
            Console.WriteLine(json);
        }

        private static void ReceivedRealPrice2(StockQtyTick tick)
        {

        }

        private static void ReceivedCodeList()
        {
            foreach (string code in TFobj.SymbolStockDic.Keys)
            {
                feeder.SubscribeStockCur(code);
                //feeder.SubscribeStockHoga(code);
            }
        }

        private static void ReceivedInitStatus(bool isReady)
        {
            if (isReady)
            {
                readyHDMaster = true;
            }
            else
            {
                readyHDMaster = false;
                Console.WriteLine("현대증권 마스터수신 실패 했습니다.");
            }
        }

        private static void InitServer()
        {
            //try
            //{
            //    Thread feederThread = new Thread(new ThreadStart(feeder.CheckMaster));
            //    feederThread.Start();
            //}
            //catch (Exception ex)
            //{
            //    Utils.LogError(string.Format("{0}", ex.ToString()), string.Format("{0}", "InitServer:feeder.CheckMaster"));
            //}

            feeder.CheckMaster();
            Thread.Sleep(1000);

            while (readyHDMaster)
            {
                feeder.RequestCodeList();
            }
        }
    }
}
