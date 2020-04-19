using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace Homework_2020._4._17
{
    public delegate void PageDownloadEventHandler(string url);
    public delegate void PageDownloadErrorEventHandler(Exception e);

    public class Crawler
    {
        private Hashtable urls = new Hashtable();
        public Hashtable URLs { get => urls; set => urls = value; }

        private int count;
        private string current;

        private string startUrl;
        public string StartUrl { get => startUrl; set => startUrl = value; }

        public event PageDownloadEventHandler PageDownloaded;
        public event PageDownloadErrorEventHandler PageDownloadError;

        public Crawler()
        {
            count = 0;
        }

        public Crawler(string startUrl)
        {
            count = 0;

            AddStartUrl(startUrl);
        }

        public void AddStartUrl(string startUrl)
        {
            urls.Clear();
            count = 0;

            startUrl = UrlService.FindAbsolutePath("", startUrl);   // 如果没有https，则加上
            this.startUrl = startUrl;

            urls.Add(startUrl, false);
        }

        public void Crawl()
        {
            while (true)
            {
                current = null;

                foreach (string url in urls.Keys)
                {
                    if ((bool)urls[url]){
                        continue;
                    }

                    current = url;
                }

                if (current == null || count > 20)
                {
                    Exception endException = new Exception($"爬取结束，共爬取到{count - 1}个网站。");
                    PageDownloadError(endException);

                    break;
                }

                if (count > 0) 
                    PageDownloaded(current);

                string html = "";

                try
                {
                    html = DownLoad(current);      // 下载
                }
                catch(Exception ex)
                {
                    html = "";
                    PageDownloadError(ex);
                }
                finally
                {
                    urls[current] = true;
                    count++;

                    Parse(html);    //解析,并加入新的链接
                } 
            }
        }

        private string DownLoad(string url)
        {
            try
            {
                WebClient webClient = new WebClient();
                webClient.Encoding = Encoding.UTF8;

                string html = webClient.DownloadString(url);
                string fileName = count.ToString();

                File.WriteAllText(fileName, html, Encoding.UTF8);
                return html;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Parse(string html)
        {
            string strRef = @"(href|HREF)[ ]*=[ ]*[""'][^""'#>]+[""']";
            MatchCollection matches = new Regex(strRef).Matches(html);

            foreach (Match match in matches)
            {
                strRef = match.Value.Substring(match.Value.IndexOf('=') + 1)    //从=后开始，取子串
                          .Trim('"', '\"', '#', '>');   //去掉首位的空格和特殊符号

                if (strRef.Length == 0)
                {
                    continue;
                }
                
                if(!UrlService.IsHtml(strRef))       // 如果不是html文档
                {
                    continue;
                }

                string absolutePath = UrlService.FindAbsolutePath(current, strRef);

                if(!absolutePath.StartsWith(startUrl))    // 如果不是起始网页上的网页
                {
                    continue;
                }

                if (urls[absolutePath] == null)
                {
                    urls[absolutePath] = false;
                }
            }
        }
    }
}
