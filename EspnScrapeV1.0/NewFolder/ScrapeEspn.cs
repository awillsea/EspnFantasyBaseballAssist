using HtmlAgilityPack;
using System.Data;
using System.Reflection.Emit;
using System;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V119.Network;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using EspnScrapeV1._0.Models;
//using OpenQA.Selenium.Support.UI.ExpectedConditions;
//using OpenQA.Selenium

namespace EspnScrapeV1._0.NewFolder
{
    public class ScrapeEspn
    {
        //private By Login = By.CssSelector("#InputIdentityFlowValue");
        public static void Scrape()
        {

            List<HtmlNode> nodes = new List<HtmlNode>();

            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://fantasy.espn.com/baseball/team?leagueId=1255227256&teamId=2&seasonId=2024");
     
            WebDriverWait wait = new WebDriverWait(webDriver, TimeSpan.FromSeconds(10));


            wait.Until(ExpectedConditions.ElementExists(By.CssSelector("#oneid-wrapper")));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.XPath("/html/body/div[2]/iframe")));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/label/div/input")));
            WebElement emailFeild = (WebElement)webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/label/div/input"));
            WebElement continueBox = (WebElement)webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/div[2]/button"));
            emailFeild.SendKeys("themvpaj@yahoo.com");
            continueBox.Click();
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/div[2]/label/div/input")));
            WebElement passwordBox = (WebElement)webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/div[2]/label/div/input"));
            WebElement login = (WebElement)webDriver.FindElement(By.XPath("/html/body/div[1]/div[3]/div/div[2]/div/div/form/div[3]/div/button"));
            passwordBox.SendKeys("Goangels27!");
            login.Click();

            webDriver.SwitchTo().DefaultContent();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("/html/body/div[1]/div[1]/div/div/div[5]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/table/tbody/tr[1]/td[3]/div/span")));

            var name = webDriver.FindElement(By.XPath("/html/body/div[1]/div[1]/div/div/div[5]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/table/tbody/tr[1]/td[3]/div/span")).Text;
            var names = webDriver.FindElements(By.XPath("//*[@id=\"fitt-analytics\"]/div/div[5]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/table/tbody/tr/td[3]/div/span"));
            
            TeamNames tm = new TeamNames();
            tm.listOfNames.Add(name);
            foreach (var n in names)
            {
                tm.listOfNames.Add(n.Text);
            }

            foreach(string n in tm.listOfNames)
            {
                Console.WriteLine(n);
            }
            //*[@id="fitt-analytics"]/div/div[5]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/table/tbody/tr[1]/td[3]/div/span
            //*[@id="fitt-analytics"]/div/div[5]/div/div[2]/div/div/div[2]/div/div[2]/div/div/div/div[2]/table/tbody/tr[2]/td[3]/div/span
        }


    }
}
