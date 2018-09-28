using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuangDongSpider
{
    public partial class Form1 : Form
    {
        public string basePath = AppDomain.CurrentDomain.BaseDirectory;
        public string keyWordsPath = AppDomain.CurrentDomain.BaseDirectory + "DefaultKeyWords.ini";
        public string BrowserPathini = AppDomain.CurrentDomain.BaseDirectory + "DefaultBrowserPath.ini";
        public Form1()
        {
            InitializeComponent();
            System.Net.ServicePointManager.DefaultConnectionLimit = 64;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
            ToConfigure();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ToGrantAuthorization("ww-0001"))
                return;
            string keyStr = this.textBox1.Text;
            string acc = this.textBox2.Text;
            string pwd = this.textBox3.Text;
            string browserPath = this.textBox4.Text;

            if (string.IsNullOrEmpty(keyStr))
            {
                MessageBox.Show("请填写行业关键词！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(browserPath))
            {
                MessageBox.Show("请选择浏览器路径！", "提示");
                return;
            }
            if (!browserPath.Contains("firefox.exe"))
            {
                MessageBox.Show("请选择火狐浏览器！", "提示");
                return;
            }
            if (string.IsNullOrEmpty(acc) || string.IsNullOrEmpty(pwd))
            {
                MessageBox.Show("请输入打码平台的账号密码！", "提示");
                return;
            }

            string shortTimeStr = dateTimePicker1.Value.ToShortDateString();

            File.WriteAllText(keyWordsPath, keyStr);
            File.WriteAllText(BrowserPathini, browserPath);
            StartSpider ss = new StartSpider(keyStr, shortTimeStr, acc, pwd, browserPath, this.listBox1, this.label6, this.label7);
            Thread th = new Thread(ss.ToDownLoad);
            th.IsBackground = true;
            th.Start();
        }
        private void BrowserPath(object sender, EventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();//首先，实例化对话框类实例
            openDialog.Filter = "firefox.exe|*.exe";
            if (DialogResult.OK == openDialog.ShowDialog())//然后，判断如果当前用户在对话框里点击的是OK按钮的话。
            {
                string filename = openDialog.FileName; //将打开文件对话框的FileName属性传递到你的字符串进行处理
                this.textBox4.Text = filename;
            }
        }

        public void ToConfigure()
        {
            if (File.Exists(keyWordsPath))
            {
                string keyWordsStr = File.ReadAllText(keyWordsPath);
                this.textBox1.Text = keyWordsStr;
            }
            if (File.Exists(BrowserPathini))
            {
                string browserPath = File.ReadAllText(BrowserPathini);
                this.textBox4.Text = browserPath;
            }
        }
        public bool ToGrantAuthorization(string workId)
        {
            string conStr = "Data Source=;Initial Catalog=MyDB;Integrated Security=False;User ID=sa;Password=;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

            string sqlStr = "SELECT dbo.MyWork.PassState FROM dbo.MyWork WHERE dbo.MyWork.WorkId = '" + workId + "'";

            using (SqlConnection con = new SqlConnection(conStr))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStr, con))
                {
                    bool state = false;
                    try
                    {
                        con.Open();
                        object obj = cmd.ExecuteScalar();
                        state = (bool)obj;
                    }
                    catch (Exception ex)
                    {
                    }
                    if (!state)
                    {
                        MessageBox.Show("软件未授权，请及时qq联系1610779207处理！", "提示");
                        return false;
                    }
                    return true;
                }
            }
        }

    }
}
