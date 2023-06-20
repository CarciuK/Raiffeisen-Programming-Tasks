using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace Raiffeisen_iFrame_Problem1_version2
{
    [TestClass]
    public class iFrame_editing_text_TA
    {
        [TestMethod]
        public void IFrame_Editing_Text()
        {
            IWebDriver driver = new ChromeDriver();

            driver.Manage().Window.Maximize();
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tinymce");

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("/html/body")));

            IWebElement Field_iframe = driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[2]/div[1]/iframe"));
            driver.SwitchTo().Frame(Field_iframe);

            IWebElement Field = driver.FindElement(By.XPath("/html/body"));
            Field.Clear();

            driver.SwitchTo().DefaultContent();

            IWebElement Paragraph_Menu = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/div[1]/div[1]/div[2]/div/div[2]/button/span"));
            Paragraph_Menu.Click();

            IWebElement Headings = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[1]/div/div[1]"));
            Headings.Click();
            Thread.Sleep(2000);

            IWebElement Headings1 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]"));
            Headings1.Click();

            driver.SwitchTo().Frame(Field_iframe);
            Field.SendKeys("This is a test setup");
        
            driver.SwitchTo().DefaultContent();

            IWebElement Paragraph_menu = driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/div[1]/div[1]/div[2]/div/div[2]/button/span"));
            Paragraph_menu.Click();
            IWebElement Inline = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[1]/div/div[2]"));
            Inline.Click();
            IWebElement Inline_Bold = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]"));
            Inline_Bold.Click();

            driver.SwitchTo().Frame(Field_iframe);

            IWebElement ContentField_Inline = driver.FindElement(By.XPath("/html/body"));
            SendKeys.SendWait(@"{Enter}");
            ContentField_Inline.SendKeys("Robot testing is fun");


            String ExpectedText = "This is a test setup\r\nRobot testing is fun";
            String actualtitle = driver.FindElement(By.XPath("/html/body")).Text.ToString();
            Assert.AreEqual(ExpectedText, actualtitle);


            Thread.Sleep(4000);
            driver.Dispose();


        }
    }
}
