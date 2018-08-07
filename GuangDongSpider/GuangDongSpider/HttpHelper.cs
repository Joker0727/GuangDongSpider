using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyHttp
{
    public class HttpHelper
    {
        public string IP = string.Empty;
        public int PORT = 0;
        public string refererUrl = "http://59.41.9.91/gsbm/FrmRegOpeninfoDetail.aspx";
        public string host = "59.41.9.91";

        public HttpHelper()
        {

        }
        public HttpHelper(string ip, int port)
        {
            this.IP = ip;
            this.PORT = port;
        }
        /// <summary>   
        /// 通过get方式请求页面，传递一个实例化的cookieContainer   
        /// </summary>   
        /// <param name="GetUrl"></param>   
        /// <param name="cookie"></param>   
        /// <returns></returns>   
        public ArrayList GetHtmlData(string postUrl, CookieContainer cookie)
        {
            HttpWebRequest request;
            HttpWebResponse response;
            ArrayList list = new ArrayList();
            //WebProxy proxyObject = new WebProxy(IP, PORT);// port为端口号 整数型      
            request = WebRequest.Create(postUrl) as HttpWebRequest;
            //request.Referer = refererUrl;
            //request.Proxy = proxyObject; //设置代理
            request.Method = "GET";
            request.UserAgent = "Mozilla/4.0";
            request.CookieContainer = cookie;
            request.KeepAlive = true;

            request.CookieContainer = cookie;
            try
            {
                //获取服务器返回的资源   
                using (response = (HttpWebResponse)request.GetResponse())
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        cookie.Add(response.Cookies);
                        //保存Cookies   
                        list.Add(cookie);
                        list.Add(reader.ReadToEnd());
                        list.Add(Guid.NewGuid().ToString());//图片名   
                    }
                }
            }
            catch (WebException ex)
            {
                list.Clear();
                list.Add("发生异常/n/r");
                WebResponse wr = ex.Response;
                using (Stream st = wr.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(st, Encoding.UTF8))
                    {
                        list.Add(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                list.Clear();
                list.Add("5");
                list.Add("发生异常：" + ex.Message);
            }
            return list;
        }
        /// <summary>   
        /// 下载验证码图片并保存到本地   
        /// </summary>   
        /// <param name="Url">验证码URL</param>   
        /// <param name="cookCon">Cookies值</param>   
        /// <param name="savePath">保存位置/文件名</param>   
        public byte[] DowloadCheckImg(string Url, CookieContainer cookie)
        {
            //WebProxy proxyObject = new WebProxy(IP, PORT);// port为端口号 整数型     
            HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(Url);
            webRequest.Referer = refererUrl;
            //webRequest.Proxy = proxyObject; //设置代理
            //属性配置   
            webRequest.AllowWriteStreamBuffering = true;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.MaximumResponseHeadersLength = -1;
            webRequest.Accept = "image/gif, image/x-xbitmap, image/jpeg, image/pjpeg, application/x-shockwave-flash, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
            webRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1; SV1; Maxthon; .NET CLR 1.1.4322)";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.Method = "GET";
            webRequest.Headers.Add("Accept-Language", "zh-cn");
            webRequest.Headers.Add("Accept-Encoding", "gzip,deflate");
            webRequest.KeepAlive = true;
            webRequest.CookieContainer = cookie;
            try
            {
                //获取服务器返回的资源   
                using (HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse())
                {
                    using (Stream sream = webResponse.GetResponseStream())
                    {
                        List<byte> list = new List<byte>();
                        while (true)
                        {
                            int data = sream.ReadByte();
                            if (data == -1)
                                break;
                            list.Add((byte)data);
                        }                      
                        byte[] yzmByte = list.ToArray();
                        return yzmByte;
                    }
                }
            }
            catch (WebException ex)
            {
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
        /// <summary>   
        /// 发送相关数据至页面   
        /// 进行登录操作   
        /// 并保存cookie   
        /// </summary>   
        /// <param name="postData"></param>   
        /// <param name="postUrl"></param>   
        /// <param name="cookie"></param>   
        /// <returns></returns>   
        public ArrayList PostData(string postUrl, string postData, CookieContainer cookie)
        {
            ArrayList list = new ArrayList();
            HttpWebRequest request;
            HttpWebResponse response;
            UTF8Encoding encoding = new UTF8Encoding();
            //WebProxy proxyObject = new WebProxy(IP, PORT);// port为端口号 整数型     
            request = WebRequest.Create(postUrl) as HttpWebRequest;
            request.Referer = refererUrl;
            //webRequest.Proxy = proxyObject; //设置代理
            byte[] b = encoding.GetBytes(postData);
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/65.0.3325.181 Safari/537.36";
            request.Method = "POST";
            request.Host = host;
            request.KeepAlive = true;
            request.Accept = "application/json, text/javascript, */*; q=0.01";
            request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.9");
            request.ContentType = "application/x-www-form-urlencoded";

            request.CookieContainer = cookie;
            request.ContentLength = b.Length;

            using (Stream stream = request.GetRequestStream())
            {
                stream.Write(b, 0, b.Length);
            }

            try
            {
                //获取服务器返回的资源   
                using (response = request.GetResponse() as HttpWebResponse)
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    {
                        if (response.Cookies.Count > 0)
                            cookie.Add(response.Cookies);
                        list.Add(cookie);
                        list.Add(reader.ReadToEnd());
                    }
                }
            }
            catch (WebException wex)
            {
                WebResponse wr = wex.Response;
                using (Stream st = wr.GetResponseStream())
                {
                    using (StreamReader sr = new StreamReader(st, System.Text.Encoding.UTF8))
                    {
                        list.Add(sr.ReadToEnd());
                    }
                }
            }
            catch (Exception ex)
            {
                list.Add("发生异常/n/r" + ex.Message);
            }
            return list;
        }
        /// <summary>
        /// C#使用GZIP解压缩完整读取网页内容
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public string GetHtmlWithUtf(string url, string postData, CookieContainer cookie)
        {
            UTF8Encoding encoding = new UTF8Encoding();
            byte[] b = encoding.GetBytes(postData);

            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(url);
            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; Trident/7.0; rv:11.0) like Gecko";
            req.Method = "POST";
            req.Host = "www.antppt.com";
            req.KeepAlive = true;
            req.Headers.Add("Accept-Language", "zh-CN");
            req.Headers.Add("Accept-Encoding", "gzip, deflate");
            req.ContentType = "text/xml";
            req.CookieContainer = cookie;
            req.ContentLength = b.Length;

            using (Stream stream = req.GetRequestStream())
            {
                stream.Write(b, 0, b.Length);
            }

            string sHTML = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)req.GetResponse())
            {
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
                        {
                            sHTML = reader.ReadToEnd();
                        }
                    }
                }
            }
            return sHTML;
        }
        /// <summary>
        /// post模拟登陆
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public string PostWebRequest(string url, string postData, CookieContainer cookie)
        {
            CookieContainer cc = new CookieContainer();
            byte[] byteArray = Encoding.Default.GetBytes(postData); // 转化
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest2.CookieContainer = cookie;
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            // Send the data.
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数
            newStream.Close();
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
            string text2 = sr2.ReadToEnd();
            return text2;
        }
        /// <summary>
        /// 通过GET方式发送数据 同步通过GET方式发送数据
        /// </summary>
        /// <param name="Url">url</param>
        /// <param name="postDataStr">GET数据</param>
        /// <param name="cookie">GET容器</param>
        /// <returns></returns>
        public string SendDataByGET(string Url, string postDataStr, ref CookieContainer cookie)
        {
            string retString = string.Empty;
            try
            {  //WebProxy proxyObject = new WebProxy(IP, PORT);// port为端口号 整数型     
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
                // request.Proxy = proxyObject; //设置代理
                request.Referer = refererUrl;
                if (cookie.Count == 0)
                {
                    request.CookieContainer = new CookieContainer();
                    cookie = request.CookieContainer;
                }
                else
                {
                    request.CookieContainer = cookie;
                }

                request.Method = "GET";
                request.ContentType = "text/html;charset=UTF-8";

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                using (Stream myResponseStream = response.GetResponseStream())
                {
                    using (StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8")))
                    {
                        retString = myStreamReader.ReadToEnd();
                        myStreamReader.Close();
                    }
                    myResponseStream.Close();
                }
            }
            catch (Exception ex) { }
            return retString;
        }
        /// <summary>
        /// 没有cookie的get请求
        /// </summary>
        /// <param name="Url"></param>
        /// <param name="postDataStr"></param>
        /// <returns></returns>
        public string HttpGet(string Url, string postDataStr)
        {
            //WebProxy proxyObject = new WebProxy(IP, PORT);// port为端口号 整数型    
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url + (postDataStr == "" ? "" : "?") + postDataStr);
            request.Referer = refererUrl;
            //webRequest.Proxy = proxyObject; //设置代理
            request.Method = "GET";
            request.ContentType = "text/html;charset=UTF-8";

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream myResponseStream = response.GetResponseStream();
            StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.GetEncoding("utf-8"));
            string retString = myStreamReader.ReadToEnd();
            myStreamReader.Close();
            myResponseStream.Close();

            return retString;
        }
        /// <summary>
        /// post模拟登陆
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="cookie"></param>
        /// <returns></returns>
        public string HttpPost(string url, string postData)
        {
            CookieContainer cc = new CookieContainer();
            byte[] byteArray = Encoding.Default.GetBytes(postData); // 转化
            HttpWebRequest webRequest2 = (HttpWebRequest)WebRequest.Create(new Uri(url));
            webRequest2.Method = "POST";
            webRequest2.ContentType = "application/x-www-form-urlencoded";
            webRequest2.ContentLength = byteArray.Length;
            Stream newStream = webRequest2.GetRequestStream();
            // Send the data.
            newStream.Write(byteArray, 0, byteArray.Length); //写入参数
            newStream.Close();
            HttpWebResponse response2 = (HttpWebResponse)webRequest2.GetResponse();
            StreamReader sr2 = new StreamReader(response2.GetResponseStream(), Encoding.UTF8);
            string text2 = sr2.ReadToEnd();
            return text2;
        }
    }
}
