using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using Homework_2020._4._17;

namespace WinForm
{
    public partial class MainForm : Form
    {
        Crawler crawler = new Crawler();

        Thread crawelThread;

        private void AddUrl(string url)
        {
            urlListBox.Items.Add(url);
        }

        private void Crawler_PageDownloaded(string url)
        {
            if (this.urlListBox.InvokeRequired)
            {
                Action<String> action = this.AddUrl;
                this.Invoke(action, new object[] { url });
            }
            else
            {
                AddUrl(url);
            }
        }

        private void AddErrorMessage(Exception e)
        {
            messageListBox.Items.Add(e.Message);
        }

        private void Crawler_Error(Exception e)
        {
            if (this.messageListBox.InvokeRequired)
            {
                Action<Exception> action = this.AddErrorMessage;
                this.Invoke(action, new object[] { e });
            }
            else
            {
                AddErrorMessage(e);
            }
        }

        public MainForm()
        {
            InitializeComponent();
            crawler.PageDownloaded += Crawler_PageDownloaded;
            crawler.PageDownloadError += Crawler_Error;

            crawelThread = new Thread(crawler.Crawl);
        }

        private void crawlButton_Click(object sender, EventArgs e)
        {
            crawler.AddStartUrl(txtStartUrl.Text);

            urlListBox.Items.Clear();
            messageListBox.Items.Clear();

            messageListBox.Items.Add("开始爬取。");

            crawelThread = new Thread(crawler.Crawl);
            crawelThread.Start();
        }
    }
}
