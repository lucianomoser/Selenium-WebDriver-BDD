using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class LoginNoPortalSteps
    {
        IWebDriver driver;

        public LoginNoPortalSteps(IWebBrowser driver)
        {
            this.driver = driver.Current;
        }

        [Given(@"que eu logue no portal com os seguintes dados")]
        public void DadoQueEuLogueNoPortalComOsSeguintesDados(Table table)
        {         
            var tabela = table.CreateDynamicSet();
            var usuario = driver.FindElement(By.Name("Usuario"));
            var senha = driver.FindElement(By.Name("Senha"));
            var btnEntrar = driver.FindElement(By.Id("Botao-Entrar"));

            usuario.SendKeys(tabela.First().Usuario.ToString());
            senha.SendKeys(tabela.First().Senha.ToString());
            btnEntrar.Click();
            WebDriverWait msgAguarde = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            msgAguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//div[@class='Corpo']//div[@id='grid']")));         
        }


        [Given(@"que eu logue no portal como administrador")]
        public void DadoQueEuLogueNoPortalComoAdministrador(Table table)
        {
            var tabela = table.CreateDynamicSet();
            var usuario = driver.FindElement(By.Name("Usuario"));
            var senha = driver.FindElement(By.Name("Senha"));
            var btnEntrar = driver.FindElement(By.Id("Botao-Entrar"));

            usuario.SendKeys(tabela.First().Usuario.ToString());
            senha.SendKeys(tabela.First().Senha.ToString());
            btnEntrar.Click();

            WebDriverWait msgAguarde = new WebDriverWait(driver, TimeSpan.FromSeconds(25));
            msgAguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("/html/body/div[2]/div[4]/div/ul/li[3]/a")));
        }

    }
}
