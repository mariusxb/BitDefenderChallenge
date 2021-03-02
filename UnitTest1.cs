using Microsoft.VisualStudio.TestTools.UnitTesting;
using SeleniumFramework;
using SeleniumFramework.Locators;
using OpenQA.Selenium;
using System;
using System.Threading;
using BitDefenderChallenge.Utils;

namespace BitDefenderChallenge
{   // 
    // The test results can be found in ..\..\BitDefenderChallenge\bin\Debug\Test Reports\ folder
    //
    [TestClass]
    public class UnitTest1 : BaseTestClass
    {
        public TestContext TestContext { get; set; }
        SeleniumDriver driver = new SeleniumDriver();

        [TestInitialize]
        public void TestInitialize()
        {
            IncrementTests();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            Cleanup(TestContext, this.driver);
        }

        [TestMethod]
        [TestCategory("Challenge 1")]
        public void TestFlow1()
        {
            driver.Start();
            driver.Instance.Navigate().GoToUrl("https://bitdefender.com");
            //accept cookies
            Thread.Sleep(1000);
            driver.Instance.FindElement(By.Id(MainPageLocators.acceptAllCookiesID)).Click();
            
            //press the home solutions button
            driver.Instance.FindElement(By.XPath(MainPageLocators.homeSolutionBtnXPath)).Click();
            
            //press the multiPlatform button
            driver.Instance.FindElement(By.XPath(SolutionsPageLocators.multiPlatformBtnXPath)).Click();
            
            //wait for page to finish scrolling
            Thread.Sleep(3000);
            
            //find and store the list price
            string listPrice = driver.Instance.FindElement(By.XPath(SolutionsPageLocators.listPriceTextXpath)).Text;
            
            //press buy button
            driver.Instance.FindElement(By.XPath(SolutionsPageLocators.buyMultiPlatformPremiumBtnXpath)).Click();
            
            //find the price dropdown and select $USD
            driver.Instance.FindElement(By.XPath(OrderCheckout.currencySelectorXpath)).Click();
            driver.Instance.FindElement(By.XPath(OrderCheckout.currencyUSDXpath)).Click();
            
            //store the price value
            string checkOutPrice = driver.Instance.FindElement(By.XPath(OrderCheckout.checkOutPriceTextXpath)).Text;
            
            //Assert the 2 prices
            Assert.AreEqual(checkOutPrice, listPrice);
            
        }

        [TestMethod]
        [TestCategory("Challenge 2")]
        public void TestFlow2()
        {
            driver.Start();
            driver.Instance.Navigate().GoToUrl("https://bitdefender.com");
            //accept cookies
            Thread.Sleep(1000);
            driver.Instance.FindElement(By.Id(MainPageLocators.acceptAllCookiesID)).Click();

            //press the home solutions button
            driver.Instance.FindElement(By.XPath(MainPageLocators.homeSolutionBtnXPath)).Click();

            //press the multiPlatform button
            driver.Instance.FindElement(By.XPath(SolutionsPageLocators.multiPlatformBtnXPath)).Click();

            //wait for page to finish scrolling
            Thread.Sleep(3000);

            //press buy button
            driver.Instance.FindElement(By.XPath(SolutionsPageLocators.buyMultiPlatformPremiumBtnXpath)).Click();

            //find the price dropdown and select $USD
            driver.Instance.FindElement(By.XPath(OrderCheckout.currencySelectorXpath)).Click();
            driver.Instance.FindElement(By.XPath(OrderCheckout.currencyUSDXpath)).Click();

            //store the price value
            string checkOutPrice = driver.Instance.FindElement(By.XPath(OrderCheckout.checkOutPriceTextXpath)).Text;

            //update the price
            IWebElement quantityField = driver.Instance.FindElement(By.CssSelector(OrderCheckout.quantityFieldCSS));
            quantityField.SendKeys(Keys.Backspace);
            quantityField.SendKeys("2");
            driver.Instance.FindElement(By.CssSelector(OrderCheckout.quantityUpdateBtnCSS)).Click();

            //store value of the updated price
            string finalCheckoutPrice = driver.Instance.FindElement(By.XPath(OrderCheckout.checkOutPriceTextXpath)).Text;

            //Convert values to float
            float qt1Value = 0;
            float qt2Value = 0;
            float.TryParse(checkOutPrice.TrimStart('$'), out qt1Value);
            float.TryParse(finalCheckoutPrice.TrimStart('$'), out qt2Value);

            //Remove item from cart
            driver.Instance.FindElement(By.CssSelector(OrderCheckout.deleteBtnCSS)).Click();
            
            //Logs the Assert exception into log file
            try
            {
                Assert.AreEqual(qt1Value * 2, qt2Value);
            }
            catch (Exception ex)
            {
                assertMessage = ex.ToString();
                throw ex;
            }
        }
    }
}

