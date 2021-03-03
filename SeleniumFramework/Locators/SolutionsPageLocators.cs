using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Locators
{
    public class SolutionsPageLocators
    {   //Multi platform section
        public static string multiPlatformSectionXPath = "//div[@id='MultiplatformSecurity']/div[@class='productS__items flex-wrap']/div[1]";
        //MUlti platform button
        public static string multiPlatformBtnXPath = "//span[.='Multiplatform']";
        //Buy multi platform premium button
        public static string buyMultiPlatformPremiumBtnXpath = "//div[@id='MultiplatformSecurity']//div[1]/a[.='Buy Now']";
        //price tag text
        public static string listPriceTextXpath = "//div[@id='MultiplatformSecurity']//span[@class='productS__newprice newprice_elite']";
    }
}
