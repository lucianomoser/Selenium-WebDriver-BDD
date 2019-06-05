using NFSe.Portal.TestesIntegracao.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace NFSe.Portal.TestesIntegracao.Declaracao.Formularios
{
    public class FormularioDadosEmpenho
    {
        public IWebDriver Driver { get; set; }
        public WebDriverWait Aguarde { get; set; }

        public FormularioDadosEmpenho(IWebDriver driver)
        {
            Driver = driver;
        }


        public FormularioNotasDeclaradas InformarDadosEmpenho(Table table)
        {
            var tabela = table.CreateDynamicSet().First();
            var empenhoUnidadeGestora = Driver.FindElement(By.Id("Empenho_UnidadeGestora"));
            var empenhoAno = Driver.FindElement(By.Id("Empenho_Ano"));
            var empenhoNumero = Driver.FindElement(By.Id("Empenho_Numero"));
            var empenhoNumeroSubEmpenho = Driver.FindElement(By.Id("Empenho_NumeroSubEmpenho"));
            var botaoSalvarSair = Driver.FindElement(By.Id("botaoSalvarFecharEmpenho"));

            empenhoUnidadeGestora.SendKeys(tabela.UnidadeGestora.ToString());
            empenhoAno.SendKeys(tabela.EmpenhoAno.ToString());
            empenhoNumero.SendKeys(tabela.EmpenhoNumero.ToString());
            empenhoNumeroSubEmpenho.SendKeys(tabela.SubEmpenhoNumero.ToString());
            botaoSalvarSair.Click();

            return new FormularioNotasDeclaradas(Driver);
        }


        public FormularioDadosEmpenho SelecionarOperacaoGerenciarEmpenho()
        {
            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(Driver, 25);
            Thread.Sleep(1000);
            Driver.FindElement(By.XPath("//*[@id='visualizar_wrapper']/a[2]/span")).Click();
            var gerenciarEmpenho = Driver.FindElement(By.XPath("//div[@class='k-animation-container k-split-wrapper']/ul/li/a[@id='empenho']"));

            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='k-animation-container k-split-wrapper']/ul/li/a[@id='empenho']")));
            Thread.Sleep(1000);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(gerenciarEmpenho).Build().Perform();
            actions.MoveToElement(gerenciarEmpenho).Click(gerenciarEmpenho).Perform();

            return new FormularioDadosEmpenho(Driver);
        }


        public FormularioDadosEmpenho BotaoIncluirNovoEmpenho()
        {
            Driver.FindElement(By.Id("novoEmpenho")).Click();

            return new FormularioDadosEmpenho(Driver);
        }

        public FormularioDadosEmpenho BotaoGravarEmpenhos()
        {
            Driver.FindElement(By.Id("salvarFecharEmpenho")).Click();
            return new FormularioDadosEmpenho(Driver);
        }
    }
}
