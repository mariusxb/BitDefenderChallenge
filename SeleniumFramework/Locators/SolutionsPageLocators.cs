using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Locators
{
    public class SolutionsPageLocators
    {
        public static string multiPlatformSectionXPath = "//div[@id='MultiplatformSecurity']/div[@class='productS__items flex-wrap']/div[1]";
        public static string multiPlatformBtnXPath = "//span[.='Multiplatform']";
        public static string buyMultiPlatformPremiumBtnXpath = "//div[@id='MultiplatformSecurity']//div[1]/a[.='Buy Now']";
        public static string listPriceTextXpath = "//div[@id='MultiplatformSecurity']//span[@class='productS__newprice newprice_elite']";
    }
}
