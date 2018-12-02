using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Webdriver3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IWebDriver driver = new ChromeDriver();
                driver.Url = "https://www.wikipedia.org/"; //Go to Wiki page
                driver.Manage().Window.Maximize(); //Maximize window
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); //Set timeout to 10 sec
                driver.FindElement(By.Id("js-link-box-en")).Click(); //Choose english language
                driver.FindElement(By.Id("searchInput")).SendKeys("Test Automation" + Keys.Enter); //Search for Test Automation and press enter

                //Start unittest of text, only part of the text is tested
                Console.WriteLine("Start of text unittest.");
                if (driver.PageSource.Contains("Test automation can automate some repetitive but necessary tasks"))
                {
                    Console.ForegroundColor = ConsoleColor.Green; //Set colors for better visibility if part of the test passed or failed
                    Console.WriteLine("Unittest of text passed!");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unittest of text failed!");
                }

                //Check if Test Automation Interface Model picture exist
                try
                {
                    //driver.FindElement(By.CssSelector(".thumbimage")); //one possible way to check if pic exist
                    driver.FindElement(By.XPath("/html/body/div[3]/div[3]/div[4]/div/div[4]/div/a/img")); //other way to check if pic exist
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Test Automation Interface Model picture exist!");
                }

                catch
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Test Automation Interface Model picture does'not exist!");
                }

                driver.FindElement(By.LinkText("Behavior driven development")).Click(); //Go to Behaviour driven link on page
                Console.ResetColor();
                Console.WriteLine("Test finished! Press any key to close.");
                Console.ReadKey();
                driver.Quit();
            }
            //Exception handling
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Exception found. One element we tried to catch does on exist.");
            }
        }
    }
}
