using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V118.CSS;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winjitAssessment.Utilities;

namespace WinjitAssessment.com.winjitAssessment.PageObjectPages
{
     class DropDownPO
    {
        private IWebDriver driver;
        public DropDownPO(IWebDriver driver) {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'DropDown')]/parent::li[@class='price_footer']")]
        IWebElement dropDownLink;

        [FindsBy(How = How.XPath, Using = "//p/select")]
        IWebElement dropDown;

        public IWebElement getdropDown()
        { return dropDown; }

        public void dropDownMethod() {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            dropDownLink.Click();
            try
            {                
                driver.SwitchTo().Frame("aswift_2");
              
                driver.FindElement(By.XPath("//div[@id='dismiss-button']/div/*")).Click();
                driver.SwitchTo().DefaultContent();
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }

            try
            {                
                driver.SwitchTo().Frame("ad_iframe");               
                BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.globalsqa.com/demo-site/select-dropdown-menu/"));
                driver.SwitchTo().DefaultContent();

            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }

            BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//p/select")));
            SelectElement se = new SelectElement(dropDown);
            se.SelectByValue(BaseClass.getJsonData("country"));                      
        
        }

    }
}
