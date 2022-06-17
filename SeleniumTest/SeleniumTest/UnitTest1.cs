using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Demo
{
    class Selenium_Demo
    {
        String test_url = "https://1bisdevcms.azurewebsites.net/Home";

        IWebDriver driver;

        [SetUp]
        public void start_Browser()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver("C:/Users/Gordon/Downloads/chromedriver_win32");
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void US05_AC01_AC02_BSR()
        {
            driver.Url = test_url;

            // Login into OneBiosecurity Account
            IWebElement login = driver.FindElement(By.Name("p$lt$ctl03$btnLogin$btnElem$btn"));
            login.Click();
            IWebElement EmailAdd= driver.FindElement(By.Name("Ecom_User_ID"));
            EmailAdd.SendKeys("gordon.tang@chamonix.com.au");
            IWebElement password = driver.FindElement(By.Name("Ecom_Password"));
            password.SendKeys("CsmdstuoA33!");
            driver.FindElement(By.ClassName("checkmark")).Click();
            driver.FindElement(By.Name("search")).Click();

            // View BSR questionnaire
            driver.FindElement(By.LinkText("Chamonix Test")).Click();
            IWebElement ViewResults = driver.FindElement(By.Name("p$lt$ctl05$pageplaceholder$p$lt$ctl05$pageplaceholder$p$lt$ctl01$BSRSummary$btnViewResults"));
            ViewResults.Click();
            driver.FindElement(By.LinkText("PLANNING AND TRACEABILITY")).Click();

            // Test for contents table on page and if the page title is highlighted on the table
            String ContentsTable = driver.FindElement(By.Id("SideBarList")).GetAttribute("title");
            String fontWeight = driver.FindElement(By.ClassName("currentStep")).GetCssValue("font-weight");
            String colour = driver.FindElement(By.ClassName("currentStep")).GetCssValue("color");
            String underline = driver.FindElement(By.ClassName("currentStep")).GetCssValue("text-decoration");
            Assert.AreEqual("Table of Contents", ContentsTable);
            Assert.AreEqual("700", fontWeight);
            Assert.AreEqual("rgba(35, 82, 124, 1)", colour);
            Assert.AreEqual("underline solid rgb(35, 82, 124)", underline);

            System.Threading.Thread.Sleep(6000);
        }

        [Test]
        public void US05_AC01_AC02_DDR()
        {
            driver.Url = test_url;

            // Login into OneBiosecurity Account
            IWebElement login = driver.FindElement(By.Name("p$lt$ctl03$btnLogin$btnElem$btn"));
            login.Click();
            IWebElement EmailAdd = driver.FindElement(By.Name("Ecom_User_ID"));
            EmailAdd.SendKeys("gordon.tang@chamonix.com.au");
            IWebElement password = driver.FindElement(By.Name("Ecom_Password"));
            password.SendKeys("CsmdstuoA33!");
            driver.FindElement(By.ClassName("checkmark")).Click();
            driver.FindElement(By.Name("search")).Click();

            // View DDR questionnaire
            driver.FindElement(By.LinkText("Chamonix Test")).Click();
            IWebElement ViewResults = driver.FindElement(By.Name("p$lt$ctl05$pageplaceholder$p$lt$ctl05$pageplaceholder$p$lt$ctl01$DrrSummaryWebPart_for_Pestivirus$btnViewResults"));
            ViewResults.Click();
            driver.FindElement(By.LinkText("LIVESTOCK INTRODUCTIONS AND MANAGEMENT PRACTICES")).Click();

            // Test for contents table on page and if the page title is highlighted on the table
            String ContentsTable = driver.FindElement(By.Id("SideBarList")).GetAttribute("title");
            String fontWeight = driver.FindElement(By.ClassName("currentStep")).GetCssValue("font-weight");
            String colour = driver.FindElement(By.ClassName("currentStep")).GetCssValue("color");
            String underline = driver.FindElement(By.ClassName("currentStep")).GetCssValue("text-decoration");
            Assert.AreEqual("Table of Contents", ContentsTable);
            Assert.AreEqual("700", fontWeight);
            Assert.AreEqual("rgba(35, 82, 124, 1)", colour);
            Assert.AreEqual("underline solid rgb(35, 82, 124)", underline);

            System.Threading.Thread.Sleep(6000);
        }


        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}