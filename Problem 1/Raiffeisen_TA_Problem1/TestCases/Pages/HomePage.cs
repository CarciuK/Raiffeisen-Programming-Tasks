using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Raiffeisen_TA_Problem1.TestCases.Pages
{
    public class HomePage : BasePage
    {
        #region Constructor
        public HomePage(IWebDriver driver) : base(driver)
        {

        }
        #endregion

        public IWebElement Field_iFrame => driver.FindElement(By.XPath("/html/body/div[2]/div/div/div/div[1]/div[2]/div[1]/iframe"));
        public IWebElement BodyField => driver.FindElement(By.XPath("/html/body"));
        public IWebElement Paragraph_Menu => driver.FindElement(By.XPath("//*[@id=\"content\"]/div/div/div[1]/div[1]/div[2]/div/div[2]/button/span"));
        public IWebElement Headings_item => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[1]/div/div[1]"));
        public IWebElement Heading1_item => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]"));
        public IWebElement Inline_item => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[1]/div/div[2]"));
        public IWebElement Bold_item => driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]"));


        public void iFrame_Editing_Text()

        {
            driver.SwitchTo().Frame(Field_iFrame);

            BodyField.Clear();

            driver.SwitchTo().DefaultContent();

            Paragraph_Menu.Click();

            IWebElement Headings = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[1]/div/div[1]"));
            Headings.Click();      

            IWebElement Headings1 = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[2]/div/div[1]"));
            Headings1.Click();

            driver.SwitchTo().Frame(Field_iFrame);

            BodyField.SendKeys("This is a test setup");

            driver.SwitchTo().DefaultContent();

           
            Paragraph_Menu.Click();
          
            Inline_item.Click();
            
            Bold_item.Click();

            driver.SwitchTo().Frame(Field_iFrame);

            Thread.Sleep(1000);
            BodyField.SendKeys(Keys.Enter);
            BodyField.SendKeys("Robot testing is fun");


            Thread.Sleep(2000);
        }





    }
}
