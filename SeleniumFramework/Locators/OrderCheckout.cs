using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumFramework.Locators
{
    public static class OrderCheckout
    {
        //Currency dropdown
        public static string currencySelectorXpath = "//*[@id=\"storeApp\"]/div[1]/div[2]/section[1]/div/div[3]/span[2]/select";
        //USD Xpath
        public static string currencyUSDXpath = "//*[@id=\"storeApp\"]/div[1]/div[2]/section[1]/div/div[3]/span[2]/select/option[2]";
        //Price locator
        public static string checkOutPriceTextXpath = "//*[@id=\"section8\"]/div/div[2]/div[2]/span";
        //Quantiy field
        public static string quantityFieldCSS = "[ng-model='i.p_qty']";
        //Update button
        public static string quantityUpdateBtnCSS = "[ng-click='updateQTY(i.p_qty, i.p_id)']";
        //Delete button
        public static string deleteBtnCSS = ".fa-trash-o";

    }
}
