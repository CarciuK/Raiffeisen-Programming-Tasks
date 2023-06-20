using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiffeisen_TA_Problem1
{
    public abstract class BasePage
    {
        protected IWebDriver driver;


        protected BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        protected BasePage()
            : this(new ChromeDriver($@"{Path.GetDirectoryName(Path.GetDirectoryName(TestContext.CurrentContext.TestDirectory))}\Debug\netcoreapp2.1"))
        {


        }
    }
}
