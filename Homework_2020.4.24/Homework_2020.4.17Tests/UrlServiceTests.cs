using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimpleCrawler;

namespace SimpleCrawerTests
{
    [TestClass()]
    public class UrlServiceTests
    {
        [TestMethod()]
        public void FindRootTest()
        {
            string current = "https://www.cnblogs.com/dstang2000/zhong/sheng.html";
            string expectedResult = "https://www.cnblogs.com";

            string testResult = UrlService.FindRoot(current);

            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod()]
        public void DropProtocolTest()
        {
            string url = "https://www.cnblogs.com/dstang2000/zhong/sheng";
            string expectedResult = "www.cnblogs.com/dstang2000/zhong/sheng";

            string testResult = UrlService.DropProtocol(url);

            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod()]
        public void FindLayerLengthTest()
        {
            string url = "https://www.cnblogs.com/dstang2000/zhong/sheng.html/";
            int expectedResult = 3;

            int testResult = UrlService.FindLayerLength(url);

            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod()]
        public void GoToTest()
        {
            string url = "https://www.cnblogs.com/dstang2000/zhong/sheng/haha/bibi.html";
            int layer = 3;
            string expectedResult = "https://www.cnblogs.com/dstang2000/zhong/sheng";

            string testResult = UrlService.GoTo(url, layer);

            Assert.AreEqual(expectedResult, testResult);
        }

        [TestMethod()]
        public void IsHtmlTest()
        {
            string[] urls = new string[6] {
            "https://www.cnblogs.com/dstang20000",
            "https://www.cnblogs.com/dstang20000html",
            "https://www.cnblogs.com/dstang20000.html",
            "https://www.cnblogs.com/dstang20000.htm",
            "https://www.cnblogs.com/dstang20000.htm#id=123",
            "https://www.cnblogs.com/dstang20000.htm?id=123"
            };

            bool[] expectedResults = new bool[6] { false, false, true, true, true, true };

            for (int i = 0; i < 6; i++)
            {
                bool testResult = UrlService.IsHtml(urls[i]);

                Assert.AreEqual(expectedResults[i], testResult);
            }

        }

        [TestMethod()]
        public void FindAbsolutePathTest()
        {
            string current = "https://www.cnblogs.com/dstang/zong/test.html";

            string[] urls = new string[6] {
            "./test1.html",
            "../test2.html",
            "/test3.html",
            "test4.html",
            "//www.baidu.com",
            "../../../../../../../test5.html"
            };

            string[] expectedResults = new string[6] {
            "https://www.cnblogs.com/dstang/zong/test1.html",
            "https://www.cnblogs.com/dstang/test2.html",
            "https://www.cnblogs.com/test3.html",
            "https://www.cnblogs.com/dstang/zong/test4.html",
            "https://www.baidu.com",
            "https://www.cnblogs.com/test5.html"
            };

            for (int i = 0; i < 6; i++)
            {
                string testResult = UrlService.FindAbsolutePath(current, urls[i]);

                Assert.AreEqual(expectedResults[i], testResult);
            }
        }
    }
}