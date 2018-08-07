using Demo;
using GTR;
using HtmlAgilityPack;
using MyHttp;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace GuangDongSpider
{
    public class StartSpider
    {
        public string url = "http://59.41.9.91/GZAIC_Portal/WebUI/service/zcdjxx.htm";
        public string addUrl = "https://crm.alibaba-inc.com/noah/platform/customer/createCustomer.xul?&from=caenir";
        public List<string> detailsList = new List<string>();
        public string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public string cutPicPath = @"C:\Users\Joker\Desktop\";
        public string keyWordsStr = string.Empty;
        public string downloadTime = string.Empty;
        public string account = string.Empty;
        public string password = string.Empty;
        public string browserPath = string.Empty;
        public string softId = "1";
        public string softKey = "b40ffbee5c1cf4e38028c197eb2fc751";
        public string yzmStyle = "3040";
        public int totalLen = 0;
        public static int flag = 0;
        public ListBox listBox = null;
        public Label label6, label7 = null;

        public StartSpider() { }
        public StartSpider(string keyStr, string time, string acc, string pwd, string brwPath, ListBox listBox, Label label6, Label label7)
        {

            string[] timeArr = time.Split('/');
            string mounth = string.Empty;
            string day = string.Empty;
            if (int.Parse(timeArr[1]) < 10)
                mounth = "0" + timeArr[1];
            else
                mounth = timeArr[1];
            if (int.Parse(timeArr[2]) < 10)
                day = "0" + timeArr[2];
            else
                day = timeArr[2];
            string newTimeStr = timeArr[0] + "-" + mounth + "-" + day;
            this.keyWordsStr = keyStr;
            this.downloadTime = newTimeStr;
            this.account = acc;
            this.password = pwd;
            this.browserPath = brwPath;
            this.listBox = listBox;
            this.label6 = label6;
            this.label7 = label7;
        }

        /// <summary>
        /// 下载公司信息
        /// </summary>
        public void ToDownLoad()
        {
            string mainUrl = "http://59.41.9.91/gsbm/FrmRegOpeninfoDetail.aspx";

            CookieContainer cookie = new CookieContainer();
            HttpHelper hh = new HttpHelper();
            ArrayList getList = hh.GetHtmlData(mainUrl, cookie);

            string postData = "__EVENTTARGET=QueryButton&__EVENTARGUMENT=&__VIEWSTATE=%2FwEPDwUJNTY3MzA5NTY4D2QWAgIDD2QWBAIFDzwrAA0BAA8WBB4LXyFEYXRhQm91bmRnHgtfIUl0ZW1Db3VudAIBZBYCZg9kFgZmDw9kFgIeBXN0eWxlBStiYWNrZ3JvdW5kLWltYWdlOnVybCgnaW1hZ2VzL2xpbmVfYmczLmdpZicpZAIBD2QWBmYPZBYCAgEPDxYCHgRUZXh0ZWRkAgEPZBYCAgEPDxYCHwNlZGQCAg9kFgICAQ8PFgIfA2VkZAICDw8WAh4HVmlzaWJsZWhkZAIHDw9kDxAWAWYWARYCHg5QYXJhbWV0ZXJWYWx1ZQUKMjAxOC0wNi0zMBYBAgJkZBgBBQlHcmlkVmlldzEPPCsACgIDZggCAWRwcuktNFj5IPyK507jjVIEiQzWnQ%3D%3D&__VIEWSTATEGENERATOR=8CC5AC98&__EVENTVALIDATION=%2FwEWBAKx8pXKAgK8%2B7r%2FDwKAp%2BrKBAKrg7q%2BDEeCQmvahLccIRyNXdmhGxWloWyO&txtDT=" + downloadTime + "";

            ArrayList postList = hh.PostData(mainUrl, postData, cookie);
            if (postList.Count != 2)
                return;
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(postList[1].ToString());

            HtmlNodeCollection trList = doc.DocumentNode.SelectNodes(("//table[@id='GridView1']/tr"));
            label6.Invoke(new Action(() => { label6.Text = "总条数：" + trList.Count; }));

            string[] keyWordArr = keyWordsStr.Split(',');
            string tdName = string.Empty;

            for (int i = 0; i < trList.Count; i++)
            {
                string trText = trList[i].InnerText;
                if (trText.Contains("已开业"))
                {
                    HtmlNodeCollection tdList = trList[i].ChildNodes;
                    tdName = tdList[2].InnerText.Replace("\r\n", " ").Trim();

                    for (int k = 0; k < keyWordArr.Length; k++)
                    {
                        if (tdName.Contains(keyWordArr[k]))
                        {
                            detailsList.Add(tdName);
                        }
                    }
                }

            }
            detailsList = detailsList.Distinct().ToList();
            listBox.Invoke(new Action(() => { listBox.Items.Clear(); }));
            for (int i = 0; i < detailsList.Count; i++)
            {
                listBox.Invoke(new Action(() => { listBox.Items.Add(detailsList[i]); }));
                label7.Invoke(new Action(() => { label7.Text = "可用条数：" + (i + 1); }));
            }
            if (detailsList.Count == 0 || detailsList == null)
            {
                MessageBox.Show("没有符合条件的公司，请重新设置筛选日期和关键字！", "提示");
                return;
            }
            ToAdd();
        }
        /// <summary>
        /// 添加信息
        /// </summary>
        public void ToAdd()
        {
            if (detailsList.Count > 0)
            {
                KillProcess("firefox");
                Process.Start(browserPath, addUrl);
                string title = "手工新增客户 - Mozilla Firefox";
                string className = "MozillaWindowClass";
                IntPtr m_hGameWnd = IntPtr.Zero;

                MessageBoxButtons message = MessageBoxButtons.OKCancel;
                DialogResult dr = MessageBox.Show("-------------------------请自行登录-------------------------\r\n“手工新增客户”页面加载完毕才可以点击确认，取消则终止！", "提示(请不要改变浏览器窗口大小)", message);
                if (dr == DialogResult.OK)
                {
                    Thread.Sleep(1000);
                    m_hGameWnd = User32API.FindWindow(className, title);
                    if (m_hGameWnd != IntPtr.Zero)
                    {
                        User32API.SwitchToThisWindow(m_hGameWnd, true);
                        Thread.Sleep(500);
                        User32API.MoveWindow(m_hGameWnd, 0, 0, 1300, 700, true);
                    }
                    else
                    {
                        MessageBox.Show("没有检测到“手工新增客户”界面，请重试！", "提示");
                        return;
                    }
                    ClickAndInPut();
                }
                else { return; }
            }
            else
            {
                MessageBox.Show("没有符合条件的公司，请重新设置筛选日期和关键字！", "提示");
                return;
            }
        }
        /// <summary>
        /// 模拟点击输入保存
        /// </summary>
        public void ClickAndInPut()
        {
            if (detailsList.Count > 0)
            {
                int timesYzm = 0;

                #region  不需要变动的三个值
                MouseClick(325, 175);//来源
                MouseClick(280, 240);

                MouseClick(410, 210);//申请人
                SendKeys.SendWait("坤");
                Thread.Sleep(500);

                MouseClick(690, 210);//电话
                SendKeys.SendWait("020");
                Thread.Sleep(500);

                MouseClick(780, 210);
                SendKeys.SendWait("83748494");
                Thread.Sleep(500);
                #endregion
                for (int i = 0; i < detailsList.Count; i++)
                {
                    LeftMouseClick(410, 138, 2);//公司            
                    User32API.Keybd_event(VirtualKey.BACK, 0, KeyEvent.KEYEVENTF_EXTENDEDKEY, 0);
                    SendKeys.SendWait(detailsList[i]);

                    //SendKeys.SendWait("{BACKSPACE}");

                    while (GetPixs())//判断是否有验证码，存在则调用验证码识别接口，并点击输入
                    {
                        if (timesYzm >= 2)
                        {
                            MessageBox.Show("验证码已经输错两次，为确保不被封号，请自行输入正确验证码后点击确认！", "警告");
                            Thread.Sleep(1000 * 2);
                            break;
                        }
                        string yzmPath = basePath + "yzm.png";
                        Bitmap bitmap = new Bitmap(yzmPath);
                        string yzm = yzmDistinguish(bitmap);
                        LeftMouseClick(435, 610, 2);//验证码         
                        User32API.Keybd_event(VirtualKey.BACK, 0, KeyEvent.KEYEVENTF_EXTENDEDKEY, 0);
                        SendKeys.SendWait(yzm);
                        MouseClick(348, 596);//保存
                        if (GetPixs())
                        {
                            timesYzm++;
                            continue;
                        }
                        else
                        {
                            break;
                        }
                    }
                    MouseClick(348, 596);//保存
                    Thread.Sleep(1000);
                    MouseClick(668, 340);
                }
            }
            KillProcess("firefox");
        }
        #region 上传答题
        private string yzmDistinguish(Bitmap bitmap)
        {
            byte[] data = null;
            using (MemoryStream stream = new MemoryStream())
            {
                bitmap.Save(stream, ImageFormat.Png);
                data = new byte[stream.Length];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(data, 0, Convert.ToInt32(stream.Length));
            }
            //必要的参数
            var param = new Dictionary<object, object>
                        {
                            {"username",account},
                            {"password",password},
                            {"typeid",yzmStyle},
                            {"timeout","90"},
                            {"softid",softId},
                            {"softkey",softKey}
                        };
            //提交服务器
            string httpResult = RuoKuaiHttp.Post("http://api.ruokuai.com/create.xml", param, data);
            XmlDocument xmlDoc = new XmlDocument();
            try
            {
                xmlDoc.LoadXml(httpResult);
            }
            catch
            {
            }
            XmlNode idNode = xmlDoc.SelectSingleNode("Root/Id");
            XmlNode resultNode = xmlDoc.SelectSingleNode("Root/Result");
            XmlNode errorNode = xmlDoc.SelectSingleNode("Root/Error");
            string result = string.Empty;
            string topidid = string.Empty;
            if (resultNode != null && idNode != null)
            {
                topidid = idNode.InnerText;
                result = resultNode.InnerText;
            }
            bitmap.Dispose();
            return result;
        }
        #endregion
        /// <summary>
        /// 获取屏幕指定区域的像素
        /// </summary>
        /// <returns></returns>
        public bool GetPixs()
        {
            bool isyz = false;
            Bitmap bit = new Bitmap(100, 40);
            Graphics g = Graphics.FromImage(bit);
            g.CopyFromScreen(new Point(490, 580), new Point(0, 0), bit.Size);
            bit.Save(basePath + "yzm.png");
            isyz = IsYzm(bit);
            bit.Dispose();
            g.Dispose();
            return isyz;
        }
        /// <summary>
        /// 判断是否是验证码
        /// </summary>
        /// <param name="bit"></param>
        /// <returns></returns>
        public bool IsYzm(Bitmap bit)
        {
            bool isyz = false;
            int blueCount = 0;
            for (int i = 0; i < bit.Width; i++)
            {
                for (int j = 0; j < bit.Height; j++)
                {
                    Color pixelColor = bit.GetPixel(i, j);

                    int r = pixelColor.R;//颜色的 RED 分量值                
                    int g = pixelColor.G;//颜色的 GREEN 分量值                   
                    int b = pixelColor.B;//颜色的 BLUE 分量值
                    if (r < 50 && g < 50 && b > 200)
                        blueCount++;
                }
            }
            if (blueCount > 40)
                isyz = true;
            return isyz;
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="option">1：鼠标左键点击，2：鼠标右键点击</param>
        public void MouseClick(int x, int y, int option = 1)
        {
            User32API.SetCursorPos(x, y);//设置鼠标位置（相对于整个桌面）；
            Thread.Sleep(100);
            switch (option)
            {
                case 1:
                    {
                        User32API.MouseEvent(MouseEventType.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                        Thread.Sleep(100);
                        User32API.MouseEvent(MouseEventType.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                        Thread.Sleep(100);
                        break;
                    }
                case 2:
                    {
                        User32API.MouseEvent(MouseEventType.MOUSEEVENTF_RIGHTDOWN, x, y, 0, 0);
                        Thread.Sleep(100);
                        User32API.MouseEvent(MouseEventType.MOUSEEVENTF_RIGHTUP, x, y, 0, 0);
                        Thread.Sleep(100);
                        break;
                    }
                default:
                    break;
            }
            Thread.Sleep(500);
        }
        /// <summary>
        /// 鼠标点击
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="index">点击次数</param>
        public void LeftMouseClick(int x, int y, int index = 1)
        {
            User32API.SetCursorPos(x, y);//设置鼠标位置（相对于整个桌面）；
            Thread.Sleep(100);
            for (int i = 0; i < index; i++)
            {
                User32API.MouseEvent(MouseEventType.MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
                Thread.Sleep(100);
                User32API.MouseEvent(MouseEventType.MOUSEEVENTF_LEFTUP, x, y, 0, 0);
                Thread.Sleep(100);
            }
        }
        /// <summary>
        /// 杀死进程
        /// </summary>
        /// <param name="pName">进程名</param>
        public void KillProcess(string pName)
        {
            Process[] process;//创建一个PROCESS类数组
            process = Process.GetProcesses();//获取当前任务管理器所有运行中程序
            foreach (Process proces in process)//遍历
            {
                try
                {
                    if (proces.ProcessName == pName)
                    {
                        proces.Kill();
                    }
                }
                catch (Exception ex) { }
            }
        }
        /// <summary>
        /// 从大图中截取一部分图片
        /// </summary>
        /// <param name="fromImagePath">来源图片地址</param>        
        /// <param name="offsetX">从偏移X坐标位置开始截取</param>
        /// <param name="offsetY">从偏移Y坐标位置开始截取</param>
        /// <param name="toImagePath">保存图片地址</param>
        /// <param name="width">保存图片的宽度</param>
        /// <param name="height">保存图片的高度</param>
        /// <returns></returns>
        public void CaptureImage(string fromImagePath, int offsetX, int offsetY, string toImagePath, int width, int height)
        {
            //原图片文件
            Image fromImage = Image.FromFile(fromImagePath);
            //创建新图位图
            Bitmap bitmap = new Bitmap(width, height);
            //创建作图区域
            Graphics graphic = Graphics.FromImage(bitmap);
            //截取原图相应区域写入作图区
            graphic.DrawImage(fromImage, 0, 0, new Rectangle(offsetX, offsetY, width, height), GraphicsUnit.Pixel);
            //从作图区生成新图
            Image saveImage = Image.FromHbitmap(bitmap.GetHbitmap());
            //保存图片
            saveImage.Save(toImagePath, ImageFormat.Png);
            //释放资源   
            saveImage.Dispose();
            graphic.Dispose();
            bitmap.Dispose();
        }
        /// <summary>
        /// 用字符串来分割成数组
        /// </summary>
        /// <param name="originalString">原字符串</param>
        /// <param name="strKey">以strKey作为分割符</param>
        /// <returns></returns>
        public string[] SplitByString(string originalString, string strKey)
        {
            string[] sArray = Regex.Split(originalString, strKey, RegexOptions.IgnoreCase);
            return sArray;
        }
    }
}
