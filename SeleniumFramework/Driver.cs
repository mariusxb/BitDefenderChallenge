using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;

namespace SeleniumFramework
{
    public class SeleniumDriver
    {
        public  IWebDriver Instance { get; set; }
        private void Initialize()
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
