using OpenQA.Selenium;
using NFSe.Portal.TestesIntegracao.Helpers;
using OpenQA.Selenium.Support.UI;
using System;

namespace NFSe.Portal.TestesIntegracao.Declaracao
{
    public class FormularioConsultaDeclaracao
    {
        private WebDriverWait Aguarde { get; set; }
        private IWebDriver Driver { get; set; }

        public FormularioConsultaDeclaracao(IWebDriver driver)
        {
            Driver = driver;
        }

        public FormularioConsultaDeclaracao BotaoImprimirBoletoNotaFiscalComRetencao()
        {            
            Driver.FindElement(By.Id("imprimirBoletos")).Click();
            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("dataVencimentoModal")));
            return this;
        }

        public FormularioConsultaDeclaracao BotaoPesquisarNotaFiscalEletronica()
        {
            Driver.FindElement(By.Id("consultaDeclaracaoNotasBotaoPesquisar")).Click();
            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(Driver, 15);
            return this;
        }


        public FormularioConsultaDeclaracao OpcaoMarcarTodasNotasDeclaradas()
        {
            Driver.FindElement(By.Id("checkbox-todos")).Click();
            return this;
        }        

        public FormularioConsultaDeclaracao InformarNumeroDaNotaFiscal(string numeroNotaFiscal)
        {
            Driver.FindElement(By.Id("NumeroNota")).SendKeys(numeroNotaFiscal);
            return new FormularioConsultaDeclaracao(Driver);
        }

        public string ObterSituacaoDaNotaFiscal()
        {
            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("gridNotas")));

            return Driver.FindElement(By.XPath("//*[@id='gridNotas']/table/tbody/tr/td[10]")).Text;
        }
    }
}
