using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace automation_task1
{
    [TestFixture]
    public class skyscanner_search
    {
        IWebDriver firefox;
        [SetUp]

        public void initialize()
        {
            firefox = new FirefoxDriver(@"C:\Users\zas\Downloads\chromedriver_win32\geckodriver-v0.26.0-win64");
            firefox.Url = "https://www.skyscanner.net";
            firefox.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            firefox.Manage().Window.Maximize();
        }

       [TearDown]
        public void End()
        {
            firefox.Quit();
           
        }
       

        [Test]
        public void TC001_search_cheapest_flights()
        {
            //search_flights
            firefox.FindElement(By.Id("fsc-origin-search")).SendKeys("cairo");
            firefox.FindElement(By.Id("fsc-origin-search")).SendKeys(Keys.Enter);
            firefox.FindElement(By.Id("fsc-destination-search")).SendKeys("berlin");
            firefox.FindElement(By.Id("react-autowhatever-fsc-destination-search--item-1")).Click();

            firefox.FindElement(By.Id("depart-fsc-datepicker-button")).Click();
            firefox.FindElement(By.XPath("//*[@aria-label='Monday, 20 January 2020']")).Click();

            firefox.FindElement(By.Id("return-fsc-datepicker-button")).Click();
            firefox.FindElement(By.XPath("//*[@aria-label='Friday, 31 January 2020']")).Click();
            firefox.FindElement(By.XPath("//*[@name='directOnly']")).Click();

            firefox.FindElement(By.XPath("//*[@class='BpkButtonBase_bpk-button__1pnhi BpkButtonBase_bpk-button--large__24bi- App_submit-button__3OawW App_submit-button-oneline__23Etl']")).Click();
            firefox.FindElement(By.XPath("//*[@class='BpkButton_bpk-button__32HxR DirectDays_flexAlignEnd__1CPAu DirectDays_rightAlign__2VVxV DirectDays_bottomMargin__3K1IE']")).Click();
            //cheapest_flights
            firefox.FindElement(By.Id("secondarySort")).Click();
            firefox.FindElement(By.XPath("//*[@value='CHEAPEST']")).Click();
            System.Threading.Thread.Sleep(5 * 1000);

           //idea is pass 
            IWebElement result = firefox.FindElement(By.XPath("//*[@class='Button_container__2DXv- Button_enabled__1T59l FqsTabs_fqsTabWithSparkle__1PIoz']"));
            Assert.IsFalse(result.Selected);
            

/*  another idea
        IWebElement result1 = firfox.FindElement(By.XPath("//*[@class='Button_container__2DXv- Button_enabled__1T59l FqsTabs_fqsTabWithSparkle__1PIoz FqsTabs_fqsTabWithSparkleSelected__1ztbg']"));
          System.Threading.Thread.Sleep(5 * 1000);

      Assert.IsTrue(result1.Selected);
          */
            
        }

        [Test]
        public void TC002_search_shortest_flights()
        {
            firefox.FindElement(By.Id("fsc-origin-search")).SendKeys("cairo");
            firefox.FindElement(By.Id("fsc-origin-search")).SendKeys(Keys.Enter);
            firefox.FindElement(By.Id("fsc-destination-search")).SendKeys("berlin");
            firefox.FindElement(By.Id("react-autowhatever-fsc-destination-search--item-1")).Click();

            firefox.FindElement(By.Id("depart-fsc-datepicker-button")).Click();
            firefox.FindElement(By.XPath("//*[@aria-label='Monday, 20 January 2020']")).Click();

            firefox.FindElement(By.Id("return-fsc-datepicker-button")).Click();
            firefox.FindElement(By.XPath("//*[@aria-label='Friday, 31 January 2020']")).Click();
            firefox.FindElement(By.XPath("//*[@name='directOnly']")).Click();

            firefox.FindElement(By.XPath("//*[@class='BpkButtonBase_bpk-button__1pnhi BpkButtonBase_bpk-button--large__24bi- App_submit-button__3OawW App_submit-button-oneline__23Etl']")).Click();
            firefox.FindElement(By.XPath("//*[@class='BpkButton_bpk-button__32HxR DirectDays_flexAlignEnd__1CPAu DirectDays_rightAlign__2VVxV DirectDays_bottomMargin__3K1IE']")).Click();
            //shortest_flights
            firefox.FindElement(By.Id("secondarySort")).Click();
            firefox.FindElement(By.XPath("//*[@value='FASTEST']")).Click();

            IWebElement result = firefox.FindElement(By.XPath("//*[@class='Button_container__2DXv- Button_enabled__1T59l FqsTabs_fqsTabWithSparkle__1PIoz']"));
            Assert.IsFalse(result.Selected);

        }

       
    }
}
