using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumLearning
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string driverPath = @"C:\SeleniumDrivers\chromedriver.exe";
            ChromeOptions options = new ChromeOptions
            {
                //BinaryLocation = @"C:\Users\Andrey\AppData\Local\Yandex\YandexBrowser\Application\browser.exe",
                //BinaryLocation = @"D:\yandexPortable\Browser\browser.exe",

                BinaryLocation = @"D:\GoogleChromePortable\GoogleChromePortable.exe",
                //BinaryLocation = @"D:\GoogleChromePortable\App\Chrome-bin\chrome.exe",
            };

            var dirPath = Path.GetDirectoryName(driverPath);
            var exePath = Path.GetFileName(driverPath);

            var service = ChromeDriverService.CreateDefaultService(dirPath, exePath);
            IWebDriver webDriver = new ChromeDriver(service, options);
            
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://yandex.ru");

            var textStr = webDriver.FindElement(By.Id("text"));
            textStr.SendKeys("керамогранит");

            var button = webDriver.FindElement(By.CssSelector(".search2__button > button"));
            button.Click();

            Console.ReadLine();

            webDriver.Quit();

            Console.ReadLine();
        }
    }
}