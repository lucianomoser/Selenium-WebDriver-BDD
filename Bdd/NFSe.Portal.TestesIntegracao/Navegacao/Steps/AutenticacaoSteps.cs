using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class AutenticacaoSteps
    {
        IWebDriver driver;

        public AutenticacaoSteps(IWebBrowser driver)
        {
            this.driver = driver.Current;
        }

        [Given(@"realize a autenticação no cnpj ""(.*)""")]
        public void DadoRealizeAAuteticacaoParaOCnpj(string cnpj)
        {            

            WebDriverWait aguarde = new WebDriverWait(driver, TimeSpan.FromSeconds(20));

            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.ClassName("ContainerGeral")));
            
            var linhaTabela = driver.FindElement(By.XPath("//td[contains(text(),'" + cnpj + "')]"));        
            linhaTabela.Click();

            var btnAutenticar = driver.FindElement(By.XPath("//input[@value='Autenticar']"));
            btnAutenticar.Click();
            
            aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//label[@class='Mensagem-Dialog']")));
            
            try
            {
                var btnModal = driver.FindElement(By.ClassName("Botao-Fechar-Modal"));
                btnModal.Click();
            }
            catch { }

        }

    }
}
