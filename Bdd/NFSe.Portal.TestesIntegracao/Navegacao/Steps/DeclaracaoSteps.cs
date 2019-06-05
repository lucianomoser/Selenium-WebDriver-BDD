using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using NFSe.Portal.TestesIntegracao.Helpers;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class DeclaracaoSteps
    {
        IWebDriver driver;

        private WebDriverWait aguardeProcesso;

        public DeclaracaoSteps(IWebBrowser driver)
        {
            this.driver = driver.Current;
        }

        

        [Given(@"que eu selecione a opção de Declaração de Serviços")]
        public void DadoQueEuSelecioneAOpcaoDeDeclaracaoDeServicos()
        {

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("Menu")));
            aguardeProcesso = null;

            var menuDeclaracaoServico = driver.FindElement(By.LinkText("Declaração de Serviço"));
            menuDeclaracaoServico.Click();
        }

        [Given(@"que eu solicite uma nova declaração para a competência ""(.*)""")]
        public void DadoQueSoliciteUmaNovaDeclaracaoParaACompetencia(string competencia)
        {           
            var btnNovaDeclaracao = driver.FindElement(By.Id("novaDeclaracao"));           
            btnNovaDeclaracao.Click();

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("Janela-Modal")));
            

             var txtData = driver.FindElement(By.Id("Abertura_Competencia"));
            txtData.SendKeys(competencia);
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("btnAberturaDeclaracao")));
       

            var btnIniciarDeclaracao = driver.FindElement(By.Id("btnAberturaDeclaracao"));
            btnIniciarDeclaracao.Click();
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("tabstrip-1")));
            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(driver, 30);

        }

        [Given(@"que eu solicite uma nova declaração de nota de serviço")]
        public void DadoQueEuSoliciteUmaNovaDeclaracaoDeNotaDeServico()
        {     
            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(driver, 30);

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("notaAdicionar")));
            

            var btnAdicionar = driver.FindElement(By.Id("notaAdicionar"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollTo(" + btnAdicionar.Location.X + ", " + btnAdicionar.Location.Y + ")");          
            executor.ExecuteScript("arguments[0].click();", btnAdicionar);
        }

        [Given(@"que eu solicite retiticação da declaração de nota de serviço")]
        public void GivenQueEuSoliciteRetiticacaoDaDeclaracaoDeNotaDeServico()           
        {
            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("abrir")));

            var botaoRetificar = driver.FindElement(By.XPath("//div[@id='gridDeclaracoes']//a[@id='abrir']"));
            botaoRetificar.Click();

            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(driver, 25);
        }



    }
}
