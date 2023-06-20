global using NUnit.Framework;
using OpenQA.Selenium;
using Raiffeisen_TA_Problem1.TestCases.Pages;

namespace Raiffeisen_TA_Problem1.TestCases
{
    public class TestCases : BaseTestPage
    {

        [Test, Order(1)]
        public void IFrame_Editing_Text()
        {
            this.OpenBrowser();
            HomePage homePage = new HomePage(driver);

            homePage.iFrame_Editing_Text();

            String ExpectedText = "This is a test setup\r\nRobot testing is fun";
            String actualtitle = driver.FindElement(By.XPath("/html/body")).Text.ToString();
            Assert.AreEqual(ExpectedText, actualtitle);

           
        }
    }
}