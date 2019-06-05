using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace NFSe.Portal.TestesIntegracao.Base
{
    public class WebBrowser: IWebBrowser
    {
        public IWebDriver Current
        {
            get
            {              
                if (!FeatureContext.Current.ContainsKey("browser"))
                    FeatureContext.Current["browser"] = new ChromeDriver();

                return FeatureContext.Current["browser"] as IWebDriver;
            }
        }        
    }
}
