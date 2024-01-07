using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using winjitAssessment.Utilities;
using WinjitAssessment.com.winjitAssessment.PageObjectPages;


namespace CSharpFramework.com.cSharpFramework.PageObjectPages
{
     class SamplePagePO
    {
        private IWebDriver driver;
        
        public SamplePagePO(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        
        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'SamplePage')]/parent::li[@class='price_footer']")]
        IWebElement samplePagebtn;

        public IWebElement getsamplePagebtn()
        {
            return samplePagebtn;
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='name']")]
        IWebElement name;

        public IWebElement getname()
        {
            return name;
        }

        [FindsBy(How = How.XPath, Using = "//input[@class='email']")]
        IWebElement email;

        public IWebElement getemail()
        {
            return email;
        }

        [FindsBy(How = How.XPath, Using = "//textarea[@name='g2599-comment']")]
        IWebElement comment;

        public IWebElement getcomment()
        {
            return comment;
        }

        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        IWebElement submitbtn;

        public IWebElement getsubmitbtn()
        {
            return submitbtn;
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='contact-form-2599']/h3")]
        IWebElement cnfMsg;

        public IWebElement getcnfMsg()
        {
            return cnfMsg;
        }

        public void samplePageMethod()
        {
           
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("window.scrollBy(0,250)", "");
            samplePagebtn.Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            try
            {                
                driver.SwitchTo().Frame("aswift_2");               
                driver.FindElement(By.XPath("//div[@id='dismiss-button']/div/*")).Click();
                BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.globalsqa.com/samplepagetest/"));
                driver.SwitchTo().DefaultContent();

            }
            catch (Exception e)             
            { Console.WriteLine(e.StackTrace); }

            try
            {       
                driver.SwitchTo().Frame("ad_iframe");
                driver.FindElement(By.XPath("//div[@id='dismiss-button']/div/*")).Click();
                BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.globalsqa.com/samplepagetest/"));
                driver.SwitchTo().DefaultContent();

            }
            catch (Exception e)            
            { Console.WriteLine(e.StackTrace); }
            BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//input[@class='name']")));
            name.SendKeys(BaseClass.getJsonData("name"));

            name.SendKeys(Keys.Tab);
            email.SendKeys(BaseClass.getJsonData("email"));

            comment.SendKeys(BaseClass.getJsonData("comment"));
            
            submitbtn.Click();
            
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
                       
        }
    }
}
