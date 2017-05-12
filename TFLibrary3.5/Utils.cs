using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace TFLibrary3._5
{
    public static class Utils
    {

        public static class Colors
        {
            public static Color cTableText = Color.White;
            public static Color cTableBack = Color.Black;
            public static Color cTableHeader = Color.FromArgb(60, 60, 60);
            public static Color cTableSelect = Color.FromArgb(80, 255, 255, 255);
            public static Color cTableHeaderLine = Color.FromArgb(100, 100, 100);
            public static Color cSymbolKosdaq = Color.LimeGreen;
            public static Color cSymbolKospi = Color.Orange;
            public static Color cPortfolio = Color.LightGoldenrodYellow;
            public static Color cPlus = Color.OrangeRed;
            public static Color cMinus = Color.DodgerBlue;
            public static Color cZero = Color.Gray;
        }

        public static class Fonts
        {
            public static Font fTableHeader = new Font("Gulim", 9);
            public static Font fTableText = new Font("Gulim", 9);
        }

        public static void ModalessMsgBox(string title, string msg)
        {
            // Do stuff before.
            // Start the message box -thread:
            new Thread(new ThreadStart(delegate
            {
                MessageBox.Show
                (
                  msg,
                  title,
                  MessageBoxButtons.OK,
                  MessageBoxIcon.Warning
                );
            })).Start();
            // Continue doing stuff while the message box is visible to the user.
            // The message box thread will end itself when the user clicks OK.
        }
        public static DataTable ToDataTable<T>(this IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void CopyFolder(string sourceFolder, string destFolder)
        {
            if (!Directory.Exists(destFolder))
                Directory.CreateDirectory(destFolder);

            string[] files = Directory.GetFiles(sourceFolder);
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                string name = Path.GetFileName(file);
                string dest = Path.Combine(destFolder, name);
                File.Copy(file, dest);
            }

            // foreach 안에서 재귀 함수를 통해서 폴더 복사 및 파일 복사 진행 완료  
            foreach (string folder in folders)
            {
                string name = Path.GetFileName(folder);
                string dest = Path.Combine(destFolder, name);
                CopyFolder(folder, dest);
            }
        }

        public static void SetListViewRowHeight(ListView listview, int height)
        {
            ImageList imgList = new ImageList();
            imgList.ImageSize = new Size(1, height);
            listview.SmallImageList = imgList;
        }

        public static void DeleteOldFiles(string sourceFolder)
        {
            string[] files = Directory.GetFiles(sourceFolder, "*.old");
            string[] folders = Directory.GetDirectories(sourceFolder);

            foreach (string file in files)
            {
                File.Delete(file);
            }

            // foreach 안에서 재귀 함수를 통해서 폴더 복사 및 파일 복사 진행 완료  
            foreach (string folder in folders)
            {
                DeleteOldFiles(folder);
            }
        }

        public static void MakeLogFile(string path)
        {
            string folder = string.Format(@"{0}\logs", path);
            DirectoryInfo di = new DirectoryInfo(folder);
            if (di.Exists == false)
            {
                di.Create();
            }

            string today = DateTime.Now.ToString("yyyyMMdd");
            Trace.Listeners.Add(new TextWriterTraceListener(string.Format(@"{0}\{1}.log", folder, today)));
            Trace.AutoFlush = true;
            Trace.WriteLine("==============================================================================================");
            Trace.WriteLine("==========  " + DateTime.Now.ToString());
            Trace.WriteLine("==============================================================================================");
            Trace.Flush();
        }

        public static void CopyLogFile(string path)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            StringCollection file = new StringCollection();
            file.Add(string.Format(@"{0}\logs\{1}.log", path, today));
            Clipboard.SetFileDropList(file);
        }

        public static void ViewLogFile(string path)
        {
            string today = DateTime.Now.ToString("yyyyMMdd");
            string file = string.Format(@"{0}\logs\{1}.log", path, today);
            Process.Start(file);
        }

        public static void LogError(string log, string module)
        {
            WriteLog(log, "error", module);
        }

        public static void LogError(Exception ex, string module)
        {
            WriteLog(ex.Message, "error", module);
        }

        public static void LogWarning(string log, string module)
        {
            WriteLog(log, "warning", module);
        }

        public static void LogInfo(string log, string module)
        {
            WriteLog(log, "info", module);
        }

        private static void WriteLog(string log, string type, string module)
        {
            Trace.WriteLine(
                    string.Format("[{0}][{1}][{2}] {3}",
                                  DateTime.Now.ToString("HH:mm:ss"),
                                  type,
                                  module,
                                  log));
        }

        public static void InvokeIfRequired<T>(this T control, Action<T> action) where T : ISynchronizeInvoke
        {
            try
            {
                if (control.InvokeRequired)
                {
                    control.Invoke(new Action(() => action(control)), null);
                }
                else
                {
                    action(control);
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message, "MyUtil:InvokeIfRequired");
            }
        }


        public static long TimeSpanToLong6(TimeSpan ts)
        {
            long l = ts.Hours * 10000 + ts.Minutes * 100 + ts.Seconds;
            return l;
        }

        public static TimeSpan Long8ToTimeSpan(long l)
        {
            return DateTime.ParseExact(l.ToString("00:00:00:00"), "HH:mm:ss:ff", null).TimeOfDay;
        }
        public static TimeSpan Long6ToTimeSpan(long l)
        {
            return DateTime.ParseExact(l.ToString("00:00:00"), "HH:mm:ss", null).TimeOfDay;
        }


        public static string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        // String을 바이트 배열로 변환 
        public static byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.Default.GetBytes(str);
            return StrByte;
        }
        public static void StringToUTF8Byte(string str, ref byte[] dest)
        {
            byte[] sb = Encoding.UTF8.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, 0, sb.Length);
        }

        public static void StringToASCIIByte(string str, ref byte[] dest)
        {
            byte[] sb = Encoding.ASCII.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, 0, sb.Length);
        }

        public static void FillStringToASCIIByte(string str, ref byte[] dest)
        {
            StringToASCIIByte(new string(' ', dest.Length), ref dest);
            byte[] sb = Encoding.UTF8.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, 0, sb.Length);
        }

        public static void FillNumberToASCIIByte(string str, ref byte[] dest)
        {
            StringToASCIIByte(new string('0', dest.Length), ref dest);
            byte[] sb = Encoding.UTF8.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, dest.Length - sb.Length, sb.Length);
        }
        public static void FillStringToUTF8Byte(string str, ref byte[] dest)
        {
            StringToUTF8Byte(new string(' ', dest.Length), ref dest);
            byte[] sb = Encoding.UTF8.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, 0, sb.Length);
        }

        public static void FillNumberToUTF8Byte(string str, ref byte[] dest)
        {
            StringToUTF8Byte(new string('0', dest.Length), ref dest);
            byte[] sb = Encoding.UTF8.GetBytes(str);
            Buffer.BlockCopy(sb, 0, dest, dest.Length - sb.Length, sb.Length);
        }

        /// <summary>
        /// object 타입을 Byte 배열 타입으로 변환
        /// </summary>
        public static byte[] objectToByte(object obj)
        {
            int size = Marshal.SizeOf(obj);

            IntPtr buff = Marshal.AllocHGlobal(size);
            Marshal.StructureToPtr(obj, buff, false);
            byte[] Data = new byte[size];
            Marshal.Copy(buff, Data, 0, size);
            Marshal.FreeHGlobal(buff);
            return Data;
        }
        /// <summary>
        ///  Byte 배열을 object 타입으로 변환
        /// </summary>
        public static object ByteToObject(byte[] Data, Type type)
        {
            int size = Marshal.SizeOf(type);

            IntPtr buff = Marshal.AllocHGlobal(size);
            Marshal.Copy(Data, 0, buff, size);
            object obj = Marshal.PtrToStructure(buff, type);
            Marshal.FreeHGlobal(buff);
            return obj;
        }

        /// <summary>
        /// 스트링 데이터를 바이너리로 변환
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] StrToByteArray(string str)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            return encoding.GetBytes(str);
        }


        public static Dictionary<TKey, TValue> CloneDictionaryCloningValues<TKey, TValue>(Dictionary<TKey, TValue> original) where TValue : ICloneable
        {
            Dictionary<TKey, TValue> ret = new Dictionary<TKey, TValue>(original.Count, original.Comparer);
            foreach (KeyValuePair<TKey, TValue> entry in original)
            {
                ret.Add(entry.Key, (TValue)entry.Value.Clone());
            }
            return ret;
        }
        public static SortedDictionary<TKey, TValue> CloneDictionaryCloningValues<TKey, TValue>(SortedDictionary<TKey, TValue> original) where TValue : ICloneable
        {
            SortedDictionary<TKey, TValue> ret = new SortedDictionary<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> entry in original)
            {
                ret.Add(entry.Key, (TValue)entry.Value.Clone());
            }
            return ret;
        }


        public static T[] SubArray<T>(this T[] data, int index, int length)
        {
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
        public static T[] SubArrayDeepClone<T>(this T[] data, int index, int length)
        {
            T[] arrCopy = new T[length];
            Array.Copy(data, index, arrCopy, 0, length);
            using (MemoryStream ms = new MemoryStream())
            {
                var bf = new BinaryFormatter();
                bf.Serialize(ms, arrCopy);
                ms.Position = 0;
                return (T[])bf.Deserialize(ms);
            }
        }
        public static void AddRange<T>(this ICollection<T> target, IEnumerable<T> source)
        {
            if (target == null)
                throw new ArgumentNullException("target");
            if (source == null)
                throw new ArgumentNullException("source");
            foreach (var element in source)
                target.Add(element);
        }

        public static DateTime Next(this DateTime date, DayOfWeek dayOfWeek)
        {
            return date.AddDays((dayOfWeek < date.DayOfWeek ? 7 : 0) + dayOfWeek - date.DayOfWeek);
        }
        public static DateTime GetNthWeekofMonth(DateTime date, int nthWeek, DayOfWeek dayOfWeek)
        {
            return date.Next(dayOfWeek).AddDays((nthWeek - 1) * 7);
        }

        static GregorianCalendar _gc = new GregorianCalendar();
        public static int GetWeekOfMonth(this DateTime time)
        {
            DateTime first = new DateTime(time.Year, time.Month, 1);
            return time.GetWeekOfYear() - first.GetWeekOfYear() + 1;
        }

        static int GetWeekOfYear(this DateTime time)
        {
            return _gc.GetWeekOfYear(time, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
        }


        public static string Get_MyIP()
        {
            try
            {
                IPHostEntry host = Dns.GetHostByName(Dns.GetHostName());
                string myip = host.AddressList[0].ToString();
                return myip;
            }
            catch
            {
                return "";
            }
        }

        public static IniUtil SettingsIni = new IniUtil((new FileInfo(Application.ExecutablePath)).Directory.FullName.ToString() + @"\setting.ini");

        public static string GetProperty(string property)
        {
            try
            {
                return SettingsIni.GetIniValue("Property", property);
            }
            catch
            {
                return "";
            }
        }
        public static Point GetFormLocation(string form)
        {
            try
            {
                return new Point(Convert.ToInt32(SettingsIni.GetIniValue(form, "x")),
                                Convert.ToInt32(SettingsIni.GetIniValue(form, "y")));
            }
            catch
            {
                return new Point(0, 0);
            }
        }
        public static void SaveFormLocation(string form, Point location)
        {
            SettingsIni.SetIniValue(form, "x", location.X.ToString());
            SettingsIni.SetIniValue(form, "y", location.Y.ToString());
        }
        public static Size GetFormSize(string form)
        {
            try
            {
                return new Size(Convert.ToInt32(SettingsIni.GetIniValue(form, "width")),
                                Convert.ToInt32(SettingsIni.GetIniValue(form, "height")));
            }
            catch
            {
                return new Size(0, 0);
            }
        }
        public static void SaveFormSize(string form, Size size)
        {
            SettingsIni.SetIniValue(form, "width", size.Width.ToString());
            SettingsIni.SetIniValue(form, "height", size.Height.ToString());
        }



        public static void ArrayStableSort<T>(this T[] values, Comparison<T> comparison)
        {
            var keys = new KeyValuePair<int, T>[values.Length];
            for (var i = 0; i < values.Length; i++)
                keys[i] = new KeyValuePair<int, T>(i, values[i]);
            Array.Sort(keys, values, new StabilizingComparer<T>(comparison));
        }

        private sealed class StabilizingComparer<T> : IComparer<KeyValuePair<int, T>>
        {
            private readonly Comparison<T> _comparison;

            public StabilizingComparer(Comparison<T> comparison)
            {
                _comparison = comparison;
            }

            public int Compare(KeyValuePair<int, T> x,
                               KeyValuePair<int, T> y)
            {
                var result = _comparison(x.Value, y.Value);
                return result != 0 ? result : x.Key.CompareTo(y.Key);
            }
        }

        public static void ListStableSort<T>(this List<T> list, ListView listview, SortOrder sortOrder, Comparison<T> comparison)
        {
            T[] arr = list.ToArray();
            arr.ArrayStableSort((a, b) =>
            {
                int lret = comparison(a, b);
                if (sortOrder == SortOrder.Descending)
                {
                    lret *= -1;
                }
                return lret;
            });
            //list = arr.ToList();
            list.Clear();
            list.AddRange(arr);
            if (listview != null) listview.InvokeIfRequired(lv => lv.Invalidate());
        }

        public static void ListStableRegionSort<T>(this List<T> list, ListView listview, int rowIdx, SortOrder order, Comparison<T> comparer)
        {
            listview.InvokeIfRequired(lv =>
            {
                int stdSort = order == SortOrder.Ascending ? 1 : -1;
                int start = 0;
                int end = list.Count - 1;
                for (int i = rowIdx - 1; i >= start; i--)
                {
                    int result = comparer(list[rowIdx], list[i]);
                    if (result == 0 || result == stdSort)
                    {
                        start = i + 1;
                        break;
                    }
                }

                for (int i = rowIdx + 1; i <= end; i++)
                {
                    int result = comparer(list[i], list[rowIdx]);
                    if (result == 0 || result == stdSort)
                    {
                        end = i - 1;
                        break;
                    }
                }

                int visibleStart = listview.TopItemIndex();
                int visibleEnd = listview.BottomItemIndex();

                if (start == end)
                {
                    if (visibleStart > end || visibleEnd < start) return;
                    listview.RedrawItems(start, end, true);
                    return;
                }

                List<T> range1 = list.GetRange(0, start);
                List<T> range2 = list.GetRange(start, end - start + 1);
                List<T> range3 = list.GetRange(end + 1, list.Count - end - 1);

                try
                {
                    range2.ListStableSort(null, order, comparer);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }


                list.Clear();
                list.AddRange(range1);
                list.AddRange(range2);
                list.AddRange(range3);

                if (visibleStart > end || visibleEnd < start) return;

                visibleStart = Math.Max(visibleStart, start);
                visibleEnd = Math.Min(visibleEnd, end);

                listview.RedrawItems(visibleStart, visibleEnd, true);
            });
        }


        public static int TopItemIndex(this ListView listview)
        {
            return listview.TopItem.Index;
        }

        public static int BottomItemIndex(this ListView listview)
        {
            for (int i = listview.TopItemIndex() + 1; i < listview.Items.Count; i++)
            {
                if (!listview.ClientRectangle.Contains(listview.Items[i].Bounds))
                {
                    return i - 1;
                }
            }

            return listview.Items.Count - 1;
        }

        public static Image DrawText(string text, int top, int left, Font font, Color textColor, Color backColor)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(1, 1);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, font);

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width + left, (int)textSize.Height + top);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(backColor);

            //create a brush for the text
            Brush textBrush = new SolidBrush(textColor);

            drawing.DrawString(text, font, textBrush, left, top);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            return img;
        }

        public static string ConvertObjectToJSon<T>(T obj)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, obj);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static T ConvertJSonToObject<T>(string jsonString)
        {
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(jsonString));
            T obj = (T)serializer.ReadObject(ms);
            return obj;
        }
        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }


        public static bool IsInteger(string str, out int result, string err = "")
        {
            bool ret = int.TryParse(str, out result);
            if (!ret && err.Length > 0) MessageBox.Show(err);
            return ret;
        }

        public static bool IsDouble(string str, out double result, string err = "")
        {
            bool ret = double.TryParse(str, out result);
            if (!ret && err.Length > 0) MessageBox.Show(err);
            return ret;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref WndMessage.PURPLE_COPYDATA lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref WndMessage.PURPLE_COPYDATA lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref WndMessage.PURPLE_COND_DATA lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref WndMessage.PURPLE_CODE_DATA lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, StringBuilder lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, ref WndMessage.COPYDATA lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPStr)] string lParam);

        [DllImport("user32.dll", EntryPoint = "SendMessageW")]
        public static extern IntPtr SendMessageW(IntPtr hWnd, UInt32 Msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)] string lParam);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, UInt32 Msg, Int32 wParam, Int32 lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        public static extern IntPtr SendMessage(HandleRef hWnd, UInt32 Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr FindWindow(string strClassName, string strWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string lclassName, string windowTitle);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern void Keybd_event(byte vk, byte scan, int flags, ref int extrainfo);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr WindowFromPoint(Point pnt);


        public static long GetLoanDate()
        {
            DateTime loan = DateTime.Now.AddDays(2);
            if (loan.DayOfWeek == DayOfWeek.Saturday)
                loan = loan.AddDays(2);
            else if (loan.DayOfWeek == DayOfWeek.Sunday)
                loan = loan.AddDays(1);

            return Convert.ToInt64(loan.ToString("yyyyMMdd"));
        }

        static Random rand = new Random();
        public static double RandomNormal(double mean, double stdDev)
        {
            double u1 = 1.0 - rand.NextDouble(); //uniform(0,1] random doubles
            double u2 = 1.0 - rand.NextDouble();
            double randStdNormal = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Sin(2.0 * Math.PI * u2); //random normal(0,1)
            return (mean + stdDev * randStdNormal); //random normal(mean,stdDev^2)
        }
    }

    public class IniUtil
    {
        private string iniPath;

        public IniUtil(string path)
        {
            this.iniPath = path;  //INI 파일 위치를 생성할때 인자로 넘겨 받음
        }

        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // GetIniValue 를 위해
            String section,
            String key,
            String def,
            StringBuilder retVal,
            int size,
            String filePath);

        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // SetIniValue를 위해
            String section,
            String key,
            String val,
            String filePath);

        // INI 값을 읽어 온다. 
        public String GetIniValue(String Section, String Key)
        {
            StringBuilder temp = new StringBuilder(255);
            int i = GetPrivateProfileString(Section, Key, "", temp, 255, iniPath);
            return temp.ToString();
        }

        // INI 값을 셋팅
        public void SetIniValue(String Section, String Key, String Value)
        {
            WritePrivateProfileString(Section, Key, Value, iniPath);
        }
    }

    public static class WndMessage
    {
        public const int WM_COMMAND = 0x0111;
        public const int BN_CLICKED = 245;
        public const int IDOK = 1;
        public const int BM_CLICK = 0x00F5;

        public const int WM_NOTIFY = 0x004e;
        public const int WM_INITDIALOG = 0x0110;
        public const int PSM_ISDIALOGMESSAGE = 0x0475;
        public const int WM_SHOWWINDOW = 0x0018;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_ACTIVATEAPP = 0x001C;
        public const int WM_CANCELMODE = 0x001F;
        public const int SC_CLOSE = 0xF060;

        public const Int32 WM_USER = 0x0400;
        public const Int32 CCM_FIRST = 0x2000;
        public const Int32 PBM_SETBARCOLOR = WM_USER + 9;
        public const Int32 PBM_SETBKCOLOR = CCM_FIRST + 1;

        public const int WM_COPYDATA = 0x004A;
        public const int WM_PURPLE_REQUEST = 6024;
        public const int WM_PURPLE_CLICK = 6025;
        public const int WM_PURPLE_IN = 6026;
        public const int WM_PURPLE_OUT = 6027;
        public const int WM_PURPLE_UPDATE = 6028;
        public const int WM_KW_CODE = 7788;
        public const int WM_HB_CLICK = 8800;
        public const int WM_HB_IN = 8801;
        public const int WM_HB_OUT = 8802;
        public const int WM_HB_REQUEST = 8803;
        public const int WM_HB_UPDATE = 8804;

        public const int WM_HD_NEXT_CODE = 8801;
        public const int WM_HD_NEXT_AVG = 8802;

        public struct COPYDATA
        {
            public int dwData;
            public int cbData;
            public string lpData;
        }

        public struct PURPLE_CODE_DATA
        {
            public IntPtr dwData;
            public int cbData;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string lpData;
        }
        public struct PURPLE_COPYDATA
        {
            public int dwData;
            public int cbData;
            //[MarshalAs(UnmanagedType.LPWStr)]
            //public string lpData;
            public IntPtr lpData;
        }
        //[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct PURPLE_COND_DATA
        {
            //public IntPtr dwData;
            //public int cbData;
            //[MarshalAs(UnmanagedType.LPWStr)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] cndName;
            //[MarshalAs(UnmanagedType.LPWStr, SizeConst = 64)]
            //public string cndName;
            //[MarshalAs(UnmanagedType.LPWStr)]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 14)]
            public byte[] code;
            //[MarshalAs(UnmanagedType.LPWStr, SizeConst = 7)]
            //public string code;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5000)]
            public byte[] data;
        }
    }

    public class MyFileInfo
    {
        public string Path { get; set; }
        public string Url { get; set; }
        public string LastVer { get; set; }
        public string Size { get; set; }
    }

    //텔레그램 메시지 클래스

    public static class TeleMessage
    {
        static string[] chatIDs = { "51271702", "102850833" };
        static string token = "374139913:AAFE3J-Xy09fDHRz907cNFfR1XrtZFxG14g";
        static string TelegramAPI = "https://api.telegram.org/bot{0}/sendMessage";

        public static void Send(string msg)
        {
            string result = string.Empty;

            foreach (string id in chatIDs)
            {
                HttpPost(string.Format(TelegramAPI, token)
                        , new Dictionary<string, string>
                        {
                        { "chat_id", id }  , { "text", msg }
                        }, out result);
            }
        }

        public static bool HttpPost(string url, Dictionary<string, string> paramList, out string Msg)
        {

            bool _flag = false;
            Msg = "";

            HttpWebRequest req = WebRequest.Create(new Uri(url)) as HttpWebRequest;
            req.Method = "POST";
            req.ContentType = "application/json";

            // Build a string with all the params, properly encoded.
            // We assume that the arrays paramName and paramVal are
            // of equal length:

            StringBuilder paramz = new StringBuilder();
            paramz.Append("{");

            foreach (KeyValuePair<string, string> param in paramList)
            {
                paramz.AppendFormat("\"{0}\" : \"{1}\", ", param.Key, param.Value);
            }

            paramz = paramz.Remove(paramz.Length - 2, 2);
            paramz.Append("}");

            // Encode the parameters as form data:
            byte[] formData = UTF8Encoding.UTF8.GetBytes(paramz.ToString());
            req.ContentLength = formData.Length;

            // Send the request:
            using (Stream post = req.GetRequestStream())
            {
                post.Write(formData, 0, formData.Length);
                post.Flush();
            }

            try
            {
                // Pick up the response:
                using (HttpWebResponse resp = req.GetResponse() as HttpWebResponse)
                {
                    if (resp.StatusCode == HttpStatusCode.OK)
                    {
                        _flag = true;
                    }

                    StreamReader reader = new StreamReader(resp.GetResponseStream(), Encoding.GetEncoding("UTF-8"));
                    Msg = reader.ReadToEnd();
                }

            }
            catch { }

            return _flag;
        }
    }

}
