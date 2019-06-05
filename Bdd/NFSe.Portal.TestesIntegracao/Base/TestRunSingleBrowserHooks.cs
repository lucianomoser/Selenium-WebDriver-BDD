using Autofac;
using NFSe.Portal.TestesIntegracao.Contracts;
using NFSe.Portal.TestesIntegracao.Helpers.Autofac;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using NFSe.Portal.TestesIntegracao.Helpers;

namespace NFSe.Portal.TestesIntegracao.Base
{
    [Binding]
    public sealed class TestRunSingleBrowserHooks
    {
        static IWebDriver driver;
        private static IWebBrowser webBrowser;


        private const string urlBase = "http://localhost/NFSe.Portal/";
        private const string urlSair = "http://localhost/NFSe.Portal/Autenticacao/Sair";
        private const string codMunicipio = "1100056";
        


        [BeforeFeature]
        public static  void BeforeFeature()
        { 
            var builder = AutofacBuilder.CreateContainerBuilder();

            var scope = builder.Build();
            webBrowser = scope.Resolve<IWebBrowser>();
            driver = webBrowser.Current;
        }

        [AfterFeature]
        public static  void AfterFeature()
        {
            driver.Quit();            
        }

        [BeforeScenario]
        public static void BeforeScenario()
        {
            driver.Navigate().GoToUrl(urlBase);
            driver.Manage().Window.Maximize();            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            

        }

        [AfterScenario]
        public static void AfterScenario()
        {
            if (ScenarioContext.Current.TestError != null)
            {
                ScreenShot.Foto(driver);   
            }

            driver.Navigate().GoToUrl(urlSair);                 
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
        }

    }
}
