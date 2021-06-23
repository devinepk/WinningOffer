using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace LightningOffer.Tests
{
    public class Testing123
    {
        [Fact]
        public void OpenChrome()
        {
            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44359/");
            driver.FindElementByLinkText("Login");
            Screenshot screenshot = (driver as ITakesScreenshot).GetScreenshot();
            screenshot.SaveAsFile("Login.png", ScreenshotImageFormat.Png);
        }


    }
}
