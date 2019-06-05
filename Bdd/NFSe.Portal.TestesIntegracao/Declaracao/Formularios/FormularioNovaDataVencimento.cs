using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace NFSe.Portal.TestesIntegracao.Declaracao
{
    class FormularioNovaDataVencimento
    {
        private WebDriverWait Aguarde { get; set; }

        private IWebDriver Driver { get; set; }
    
        public FormularioNovaDataVencimento(IWebDriver driver)
        {            
            Driver = driver;
        }

        public FormularioNovaDataVencimento InformarNovaDataVencimento(string novaDataVencimento)
        {
            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));            
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("NovaDataVencimento")));

            
            Driver.FindElement(By.Id("NovaDataVencimento")).SendKeys(novaDataVencimento);            
            Driver.FindElement(By.Id("novaDataVencimentoConfirmar")).Click();           
            Thread.Sleep(3000);       


            return this;

        }
    }
}
