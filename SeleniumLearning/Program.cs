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
            };

            var dirPath = Path.GetDirectoryName(driverPath);
            var exePath = Path.GetFileName(driverPath);

            IWebDriver webDriver = new ChromeDriver(ChromeDriverService.CreateDefaultService(dirPath, exePath), options);
            
            webDriver.Manage().Window.Maximize();
            webDriver.Navigate().GoToUrl("https://yandex.ru");

            Console.ReadLine();

            webDriver.Quit();

            Console.ReadLine();
        }
    }
}