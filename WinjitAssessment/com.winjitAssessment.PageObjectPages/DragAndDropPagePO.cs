using Microsoft.CodeAnalysis;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V117.Page;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using winjitAssessment.Utilities;


namespace WinjitAssessment.com.winjitAssessment.PageObjectPages
{
    class DragAndDropPagePO       
    {
        private IWebDriver driver;
        
        public DragAndDropPagePO(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }     
        

        [FindsBy(How = How.XPath, Using = "//iframe[@class='demo-frame lazyloaded']")]
        IWebElement frame;

        public IWebElement getframe()
        { return frame; }


        [FindsBy(How = How.XPath, Using = "//img[@src='images/high_tatras_min.jpg']")]
        IWebElement FirstImage;  
       
        
        public IWebElement getFirstImage()
        {
            return FirstImage;
        }

        [FindsBy(How = How.XPath, Using = "//div[@id='trash']//h5/following-sibling::img")]
        IWebElement trashImage;

        public IWebElement getTrashImage()
        {
            return trashImage;
        }       

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'DragAndDrop')]")]
        IWebElement dragAndDropBtn;

        public IWebElement getdragAndDropBtn()
        { return dragAndDropBtn; }  


        [FindsBy(How = How.XPath, Using = "//*[@id='trash']")]
        IWebElement destination;

        [FindsBy(How = How.XPath, Using = "//a[contains(text(),'Recycle image')]")]
        IWebElement trashItem;   

        public IWebElement getdestination()
        { return destination; }


        public void dragAndDropMethod()
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            getdragAndDropBtn().Click();
            try
            {               
                driver.SwitchTo().Frame("aswift_2");                
                driver.FindElement(By.XPath("//div[@id='dismiss-button']/div/*")).Click();
                BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.globalsqa.com/demo-site/draganddrop/"));
                driver.SwitchTo().DefaultContent();
                
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }

            try
            {                
                driver.SwitchTo().Frame("ad_iframe");                
                driver.FindElement(By.XPath("//div[@id='dismiss-button']/div/*")).Click();
                BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.UrlToBe("https://www.globalsqa.com/demo-site/draganddrop/"));
                driver.SwitchTo().DefaultContent();             
            }
            catch (Exception e)
            { Console.WriteLine(e.StackTrace); }
            BaseClass.wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.XPath("//iframe[@class='demo-frame lazyloaded']")));
            driver.SwitchTo().Frame(getframe());            
            Actions ac = new Actions(driver);           
            ac.DragAndDrop(FirstImage, destination).Build().Perform();            
           
           
        }
    }
}
