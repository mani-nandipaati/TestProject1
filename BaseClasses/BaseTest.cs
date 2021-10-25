using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System.Collections.Specialized;
using TestProject1.Commons;

namespace TestProject1.BaseClasses
{
    public class BaseTest
    {
        public IWebDriver driver; 

        [OneTimeSetUp]
        public void Open()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Url = "https://regression-crowd-client.downinglabs.co.uk/";
            driver.Manage().Window.Maximize();
            Helper.findElementAndClick(driver, "//a[@href='/account/login']");
            Helper.findElementAndSendData(driver, "//input[@type='email']", "27965@downing.co.uk");
            Helper.findElementAndSendData(driver, "//input[@type='password']", "Password1!");
            Helper.findElementAndClick(driver, "//button[text()=' Log in ']");
            Helper.findElementAndClick(driver, "//*[@class='dropdown-toggle btn secondary-btn']");
            Helper.findElementAndClick(driver, "//a[@href='/account/profile']");

        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            //driver.Quit();
        }
    }
}
