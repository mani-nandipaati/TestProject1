using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Specialized;
using TestProject1.BaseClasses;

namespace TestProject1.Commons
{
    class Helper
    {
        public static void findElementAndClick(IWebDriver driver, String path)
        {
            IWebElement element = findElement(driver, path);
            element.Click();
        }

        public static void findElementAndSendData(IWebDriver driver, String path, String data)
        {
            IWebElement element = findElement(driver, path);
            element.SendKeys(data);
        }
        public static String findElementAndGetData(IWebDriver driver, String path)
        {
            IWebElement element = findElement(driver, path);
            return element.Text;
        }


        public static IWebElement findElement(IWebDriver driver, String path)
        {
            return driver.FindElement(By.XPath(path));
        }


        public static void clearData(IWebElement element)
        {
            element.SendKeys(Keys.Control + "a" + Keys.Control);
            element.SendKeys(Keys.Backspace);
        }

        public static void focusAndClick(IWebDriver driver, String path)
        {
            IWebElement phone = findElement(driver, path);
            Actions actions = new Actions(driver);
            actions.MoveToElement(phone).Click().Build().Perform();
            phone.Click();
            clearData(phone);
        }
    }
}
