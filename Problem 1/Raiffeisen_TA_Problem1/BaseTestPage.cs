using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiffeisen_TA_Problem1
{
   
        public class BaseTestPage
        {
            protected IWebDriver driver;


            [SetUp]
            protected virtual void Setup()
            {
                this.driver = new ChromeDriver(
                    $@"{Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory))}\Debug\netcoreapp2.1");
            }


            [TearDown]
            protected virtual void EndTest()
            {
                this.driver.Close();
                this.driver.Dispose();
            }


            public void OpenBrowser(string url)
            {
                this.driver.Manage().Cookies.DeleteAllCookies();
                this.driver.Navigate().GoToUrl(url);
                this.driver.Manage().Window.Maximize();
            }



            public void OpenBrowser()
            {
                this.OpenBrowser("https://the-internet.herokuapp.com/tinymce");
            }
        }
    
}
