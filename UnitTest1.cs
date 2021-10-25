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
using TestProject1.Commons;

namespace TestProject1
{
    public class Tests : BaseTest  
    {

        [Test]
        public void EmptyPhoneNumberCheck()
        {

            //EMPTY PHONE NUMBER
            /*IWebElement phone = CommonHandlers.findElement(driver, "//input[@type='tel']");
            Actions actions = new Actions(driver);
            actions.MoveToElement(phone).Click().Build().Perform();
            phone.Click();
            CommonHandlers.clearData(phone);*/
            Helper.focusAndClick(driver, "//input[@type='tel']");



            Helper.findElementAndClick(driver, "//*[@class='btn primary-btn']");

            String actualError = Helper.findElementAndGetData(driver, "//*[@class='alert__list-item__text']");
            String expectedError = "Phone number is a required field";
            Assert.AreEqual(expectedError, actualError);
        }

        [Test]
        public void AlphabetPhoneNumberCheck() {

            Helper.findElementAndClick(driver, "//*[@class='btn edit-btn edit-btn--corner']");

            //ALPHABET PHONE NUMBER
            IWebElement phone = Helper.findElement(driver, "//input[@type='tel']");
            phone.Click();
            phone.SendKeys("abcdef");
            Helper.findElementAndClick(driver, "//*[@class='btn primary-btn']");
            String actualError = Helper.findElementAndGetData(driver, "//*[@class='alert__list-item__text']");
            String expectedError = "Phone number is not valid";
            Assert.AreEqual(expectedError, actualError);
        }

        [Test]
        public void CheckReadOnlyFieldsAreEditable()
        {
            //CHECK READONLY FIELDS ARE EDITABLE 
            ReadOnlyCollection<IWebElement> readonlyElement = driver.FindElements(By.XPath("//*[@class='edit-form']//*[@class='input-container']"));
            foreach (WebElement parentElement in readonlyElement)
            {
                IWebElement labelElement = parentElement.FindElement(By.TagName("label"));
                if (labelElement != null && labelElement.Text.Contains("name"))
                {
                    IWebElement textElement = parentElement.FindElement(By.TagName("input"));
                    Assert.IsTrue(textElement.GetAttribute("readonly").Equals("true"), "Few of the name fields are not readonly");
                }
            }
        }


        [Test]
        public void PerformUpdate()
        {
            //findElementAndClick("//*[@class='btn edit-btn edit-btn--corner']");

            //PHONE NUMBER IS NUMBERIC
            /*IWebElement phone = CommonHandlers.findElement(driver, "//input[@type='tel']");
            Actions actions = new Actions(driver);
            actions.MoveToElement(phone).Click().Build().Perform();
            phone.Click();
            CommonHandlers.clearData(phone);
            
            phone.SendKeys("07123456789");
*/
            Helper.focusAndClick(driver, "//input[@type='tel']");
            Helper.findElementAndSendData(driver, "//input[@type='tel']", "07123456789");
            Helper.findElementAndClick(driver, "//*[@class='btn primary-btn']");
            driver.FindElement(By.XPath("//*[@class='updated-feedback']"));
            Helper.findElement(driver, "//*[@class='updated-feedback']");
            String actualSuccessMsg = Helper.findElementAndGetData(driver, "//*[@class='alert-heading alert__heading']");
            var expectedSuccessMsg = "Thank you, your personal details have been updated.";
            Assert.AreEqual(expectedSuccessMsg, actualSuccessMsg);
        }

        [Test]
        public void UploadSupportedDocument()
        {
            // UPLOAD SUPPORTED DOC
            Helper.findElementAndSendData(driver, "//*[@class='visibly-hidden-file-upload']", "I:\\welcome.PNG");
            String actualFileUploadSuccessMsg = Helper.findElementAndGetData(driver, "//*[@class='text-div-success']");
            var expectedFileUploadSuccessMsg = "Thank you. Your upload was successful.";
            Assert.AreEqual(expectedFileUploadSuccessMsg, actualFileUploadSuccessMsg);
        }

        [Test]
        public void UploadUnSupportedDocument()
        {
            // UPLOAD INVALID DOC
            Helper.findElementAndSendData(driver, "//*[@class='visibly-hidden-file-upload']", "I:\\hydlandperosnal.zip");
            String actualFileUploadErrorMsg = Helper.findElementAndGetData(driver, "//*[@class='text-div-error']");
            var expectedFileUploadErrorMsg = "Sorry, this file type is not allowed. Please select a Word, PDF, Excel, Text files, PNG, or JPEG document.";
            Assert.AreEqual(expectedFileUploadErrorMsg, actualFileUploadErrorMsg);
        }

    }
}