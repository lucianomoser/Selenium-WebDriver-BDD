using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using FluentAssertions;
using NFSe.Portal.TestesIntegracao.Helpers;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class DeclaracaoEntregaSemServicoPrestadoTomadoSteps
    {
        IWebDriver driver;

        private WebDriverWait aguardeProcesso;

        public DeclaracaoEntregaSemServicoPrestadoTomadoSteps(IWebBrowser driver)
        {
            this.driver = driver.Current;
        }                      


        [Given(@"que eu selecione a opção de declaração de Entrega")]
        public void GivenQueEuSelecioneAOpcaoDeDeclaracaoDeEntrega()
        {
            Thread.Sleep(4000);            

            WebDriverHelper.AguardeMsgAtualizacaoAutomatica(driver, 25);

            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(30));           
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("tab-entrega")));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id("tab-entrega")));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("tab-entrega")));

            var linkEntrega = driver.FindElement(By.Id("tab-entrega"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("window.scrollTo(" + linkEntrega.Location.X + "," + linkEntrega.Location.Y + ")");
            executor.ExecuteScript("arguments[0].click();", linkEntrega);            
        }


        [Given(@"forneça os seguintes dados para formulário de declaracao de Entrega")]
        public void GivenFornecaOsSeguintesDadosParaFormularioDeDeclaracaoDeEntrega(Table table)
        {
            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("DeclaracaoEntrega_RPACompetenciaMI")));

            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;            
            
            var tabela = table.CreateDynamicSet().First();
            var cbRegimeApuracao = driver.FindElement(By.XPath("//div[@id='DeclaracaoEntrega_RegimeApuracaoAnoCorrente-list']/ul[@id ='DeclaracaoEntrega_RegimeApuracaoAnoCorrente_listbox']"));
            var editEntregaMercadoInterno = driver.FindElement(By.Id("DeclaracaoEntrega_RPACompetenciaMI"));
            var editEntregaMercadoExterno = driver.FindElement(By.Id("DeclaracaoEntrega_RPACompetenciaME"));
            var editEntregaFatorR = driver.FindElement(By.Id("DeclaracaoEntrega_FatorR"));
            var checkDeclaraNaoTerPrestadoServico = driver.FindElement(By.Id("semServicosPrestados"));
            var checkDeclaraNaoTerTomadoServico = driver.FindElement(By.Id("semServicosTomados"));
            var botaoEntregarDeclaracao = driver.FindElement(By.XPath("//*[@id='dvFooter']/div/div[1]/button[@class='Botao btn-next']"));

            if (cbRegimeApuracao.Enabled == true)
            {                
                var cbRegimeApuracaoElements = cbRegimeApuracao.FindElements(By.XPath("//div[@id='DeclaracaoEntrega_RegimeApuracaoAnoCorrente-list']/ul[@id ='DeclaracaoEntrega_RegimeApuracaoAnoCorrente_listbox']/li[@class='k-item']"));

                foreach (var item in cbRegimeApuracaoElements)
                {
                    try
                    {
                        executor.ExecuteScript("if (arguments[0].innerHTML=='" + tabela.RegimeApuracao + "') { arguments[0].click(); }", item);
                    }
                    catch { }
                }
            }

            editEntregaMercadoInterno.SendKeys($"'{tabela.ReceitaInterno}'");
            editEntregaMercadoExterno.SendKeys($"'{tabela.ReceitaExterno}'");
            editEntregaFatorR.SendKeys($"'{tabela.FatorR}'");
            checkDeclaraNaoTerPrestadoServico.Click();
            checkDeclaraNaoTerTomadoServico.Click();
            botaoEntregarDeclaracao.Click();

            
        }


        [Then(@"A mensagem de validação de entrega da declaração deve ser igual a ""(.*)""")]
        public void ThenMensagemApresentadaDeveSer(string mensagemInformada)
        {
            aguardeProcesso = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            aguardeProcesso.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@id='Janela-Modal']/div[@class='Alinhar-Centro']/label[@class='Mensagem-Dialog']")));

            var mensagemAtual = driver.FindElement(By.XPath("//div[@id='Janela-Modal']/div[@class='Alinhar-Centro']/label[@class='Mensagem-Dialog']")).Text;
            mensagemAtual.Should().Be(mensagemInformada, "Ocorreu algum problema no registro de entrega ou a mensagem não está igual a esperada!");
        }

        [Given(@"que eu clique no Botao ok da mensagem de validação de entrega de declaracao")]
        public void GivenClicarNoBotaoOkDaMensagemDeValidacaoDeEntregaDeDeclaracao()
        {
            var botaoFecharMensagem = driver.FindElement(By.XPath("//*[@id='Janela-Modal']/div/button"));
            botaoFecharMensagem.Click();
            
        }


    }




}
