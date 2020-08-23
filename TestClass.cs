using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomateJabaTalks
{
    [TestFixture]
    public class TestClass
    {

        [Test]
        public void AutomateJabaTalks()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://jt-dev.azurewebsites.net/#/SignUp";

            IList<IWebElement> dropdownList = driver.FindElements(By.CssSelector("#language > div.ui-select-match.ng-scope > span > span.ui-select-match-text.pull-left"));
            foreach (IWebElement i in dropdownList)

                Assert.AreEqual(i.Text, "English", "Dutch");

            //Entering the name in the name textbox.
            IWebElement name = driver.FindElement(By.Id("name"));
            name.SendKeys("Shadab Hasan Khan");

            //Entering the name in the organization name textbox.
            IWebElement orgName = driver.FindElement(By.Id("orgName"));
            orgName.SendKeys("Shadab Hasan Khan");

            //Entering the email in the email textbox.
            IWebElement email = driver.FindElement(By.Id("singUpEmail"));
            email.SendKeys("mshadab.hk@gmail.com");

            //clicking on agree - terms and condition checkbox.
            IWebElement agree = driver.FindElement(By.CssSelector("#content > div > div.main-body > div > section > div.form-container > form > fieldset > div:nth-child(4) > label > span"));
            agree.Click();

            IWebElement signUp = driver.FindElement(By.CssSelector("#content > div > div.main-body > div > section > div.form-container > form > fieldset > div:nth-child(5) > button"));
            signUp.Click();
        }

        [Test]
        public void ValidateGmail()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://accounts.google.com/signin/v2/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2F&service=mail&sacu=1&rip=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin");

            driver.FindElement(By.Id("identifierId")).SendKeys("xyz@gmail.com");
            driver.FindElement(By.CssSelector("#identifierNext > div > button > div.VfPpkd-RLmnJb")).Click();

            driver.FindElement(By.CssSelector("#password > div.aCsJod.oJeWuf > div > div.Xb9hP > input")).SendKeys("XyZ");
            driver.FindElement(By.CssSelector("#passwordNext > div > button > div.VfPpkd-RLmnJb")).Click();

            driver.FindElement(By.Id(":25")).Click();
            IWebElement subjectline = driver.FindElement(By.Id(":m1"));
            subjectline.Equals("Jaba Talks");

            Console.WriteLine(subjectline);
        }
    }
}
