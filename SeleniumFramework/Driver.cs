using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumFramework
{
    public class SeleniumDriver
    {
        public  IWebDriver Instance { get; set; }
        public  void Initialize()
        {
            string path = Environment.CurrentDirectory.ToString();
            Instance = new ChromeDriver(path);
            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
        }
        public IWebDriver Start()
        {
            Initialize();
            return Instance;
        }

    }
}
