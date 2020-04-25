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

namespace SimpleCrawler
{
    class Program
    {
        static void Main(string[] args)
        {
            string startUrl = "https://www.cnblogs.com/dstang2000";
            Crawler myCrawler = new Crawler(startUrl);

            if (args.Length >= 1){
                startUrl = args[0];
            }

            new Thread(myCrawler.Crawl).Start();
        }
    }
}
