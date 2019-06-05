using Bdd_Database.Services;
using NFSe.Portal.TestesIntegracao.Contracts;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using FluentAssertions;
using System;
using NFSe.Portal.TestesIntegracao.Declaracao.Formularios;


namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.AdministradorMunicipal.Steps
{
    [Binding]
    public class DeclaracaoDeServicoTomadoOndeTomadorAdmMunicipalVinculaEmpenhoSteps    
    {
        WebDriverWait Aguarde;       

        IWebDriver Driver;

        public DeclaracaoDeServicoTomadoOndeTomadorAdmMunicipalVinculaEmpenhoSteps(IWebBrowser driver)
        {
            Driver = driver.Current;
        }


        [Given(@"que eu desejo declarar as notas de serviço cujo Tomador \{(.*)} e Administrador Municipal")]
        public void GivenQueEuDesejoDeclararAsNotasDeServicoCujoTomadorEAdministradorMunicipal(string cnpj)
        {
            var empresaService = new EmpresaService();
            var serviceService = new ServicoService();
            int admMunicipal = empresaService.ObterEmpresaId(cnpj);

            serviceService.AlteraEmpresaParaAdmMunicipal(admMunicipal);            
        }

        [Given(@"que eu desejo consultar a declaração de servico tomado")]
        public void GivenQueEuDesejoConsultarADeclaracaoDeServicoTomado()
        {
            new FormularioPrincipalAdmMunicipal(Driver).MenuConsultarDeclaracaoServicoTomado();         
        }

        [Given(@"que eu solicite a gravação da nota fiscal eletrônica")]
        public void GivenQueEuRegistreANotaFiscalEletronica()
        {
            new FormularioNotasDeclaradas(Driver).GravarNotasFiscaisESair();            
        }


        [Given(@"que eu selecione a Operação no grid de Gerenciar Empenho")]
        public void GivenQueEuSelecioneAOperacaoNoGridDeGerenciarEmpenho()
        {
            new FormularioDadosEmpenho(Driver).SelecionarOperacaoGerenciarEmpenho();                       
        }


        [Given(@"que eu solicite um novo empenho")]
        public void GivenEuSolicitarUmNovoEmpenho()
        {
            new FormularioDadosEmpenho(Driver).BotaoIncluirNovoEmpenho();
        }

        [Given(@"que utilizamos a operação para gerenciar empenho, podemos vincular um empenho a uma nota fiscal eletrônica emitida")]
        public void GivenUtilizamosAOperacaoParaGerenciarEmpenho()
        {
            new FormularioDadosEmpenho(Driver).SelecionarOperacaoGerenciarEmpenho();
            new FormularioDadosEmpenho(Driver).BotaoIncluirNovoEmpenho();                     
        }


        [Then(@"que eu desejo gravar os empenhos na anota fiscal eletrônica emitida.")]
        public void ThenQueEuDesejoGravarOsEmpenhosNAnotaFiscalEletronicaEmitida()
        {
            new FormularioDadosEmpenho(Driver).BotaoGravarEmpenhos();
        }




        [Given(@"forneça os seguintes dados para formulário de Adicionar Empenho")]
        public void GivenFornecaOsSeguintesDadosParaFormularioDeAdicionarEmpenho(Table table)
        {
            new FormularioDadosEmpenho(Driver).InformarDadosEmpenho(table);           
        }

        [Given(@"eu pesquisar o número da nota fiscal ""(.*)""\.")]
        public void GivenEuPesquisarONumeroDaNotaFiscal(string numeroNotaFiscal)
        {
            new FormularioConsultaDeclaracao(Driver).InformarNumeroDaNotaFiscal(numeroNotaFiscal);
            new FormularioConsultaDeclaracao(Driver).BotaoPesquisarNotaFiscalEletronica();
        }



        [Then(@"o campo Dados do Empenho está visivel no formulario de Declaração de Nota Fiscal ""(.*)""")]
        public void ThenOSCampoDadosDoEmpenhoEstaVisivel(bool gridEmpenhoVisibilidadeEsperada)
        {
            bool gridEmpenhoVisibilidadeAtual = Driver.FindElement(By.Id("gridEmpenho")).Displayed;       
            gridEmpenhoVisibilidadeAtual.Should().Be(gridEmpenhoVisibilidadeEsperada, "O grid Dados de Empenho não está presente.");
        }


        [Then(@"será gravado a nota fiscal eletrônica e fechado o formulário de Declaração de Nota Fiscal.")]
        public void ThenSeraGravadoANotaFiscalEletronica()
        {
            new FormularioNotasDeclaradas(Driver).GravarNotasFiscaisESair();            
        }
        

        /// <param name="situacaoDaNotaEsperado">Exemplo: Normal ou Cancelada</param>
        
        [Then(@"a situação da nota fiscal eletrônica está ""(.*)""")]
        public void ThenASituacaoDaNotaFiscalEletronicaEsta(string situacaoDaNotaEsperado)
        {
            string situacaoDaNotaAtual = new FormularioConsultaDeclaracao(Driver).ObterSituacaoDaNotaFiscal();                             
            situacaoDaNotaAtual.Should().Be(situacaoDaNotaEsperado,"A nota fiscal eletrônica não está registrada corretamente.");
        }

        


        /// <param name="valorISSEsperado">Exemplo: 38,00</param>

        [Then(@"o valor da nota fiscal eletrônica fica ""(.*)""")]
        public void ThenOValorDaNotaFiscalEletronicaFica(string valorISSEsperado)
        {
            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(15));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.PresenceOfAllElementsLocatedBy(By.Id("gridNotas")));

            string valorISSAtual = Driver.FindElement(By.XPath("//*[@id='gridNotas']/table/tbody/tr/td[8]")).Text;           
            valorISSAtual.Should().Be(valorISSEsperado, "O valor da Nota Fiscal eletrônica não está registrada corretamente.");            
        }


        
        /// <param name="situacaoDeRetencaoEsperado">Utilizar: Sim ou Não</param>
        
        [Then(@"a situação da retenção da nota fiscal eletrônica deverá ser ""(.*)"".")]
        public void ThenASituacaoDaRetencaoDaNotaFiscalEletronicaDeveraSer(string situacaoDeRetencaoEsperado)
        {
            string situacaoRetencaoAtual = Driver.FindElement(By.XPath("//*[@id='gridNotas']/table/tbody/tr/td[9]")).Text;           
            situacaoRetencaoAtual.Should().Be(situacaoDeRetencaoEsperado,"A situação da retenção da nota fiscal está errada.");
        }        
                          

        /// <param name="visibilidadeDoBotaoEsperada">Utilizar: Visivel = true, Invisivel = false</param>     

        [Then(@"a visibilidade do botão imprimir boleto com retenção deverá ser igual a ""(.*)"".")]
        public void ThenAVisibilidadeDoBotaoImprimirBoletoComRetencaoDeveraSerIgualA(bool visibilidadeDoBotaoEsperada)
        {
            new FormularioConsultaDeclaracao(Driver).OpcaoMarcarTodasNotasDeclaradas();

            Aguarde = new WebDriverWait(Driver, TimeSpan.FromSeconds(2));
            Aguarde.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("imprimirBoletos")));

            bool botaoRetencaoVisivel = Driver.FindElement(By.Id("imprimirBoletos")).Displayed;
            botaoRetencaoVisivel.Should().Be(visibilidadeDoBotaoEsperada);
        }
                          

        /// <summary>
        //Valida se o checkBox que para marcar todas as notas fiscais no gird está desabilitado quando não existir nota fiscal com retenção.
        /// </summary>

        [Then(@"a opção para marcar todas notas permanece desabilitada.")]
        public void ThenMarcandoUmaNotaFiscalSemRetencaoOBotaoParaImprimirBoletoDeveraEstarInvisivel()
        {
            bool checkBoxRetencao = Driver.FindElement(By.Id("checkbox-todos")).Enabled;
            checkBoxRetencao.Should().Be(true);
        }
                             
    
        /// <param name="checkboxServicoTomadosEsperado">Selecionado = true, Não Selecionado = false</param>
        
        [Then(@"o valor do campo Declarar como serviço tomado deverá estar selecionado igual a ""(.*)""")]
        public void ThenOValorDoCampoDeclararComoServicoTomadoDeveraEstarSelecionadoIgualA(bool checkboxServicoTomadosEsperado)
        {
            bool checkboxServicoTomadosAtual = Driver.FindElement(By.Id("DeclaracaoNota_ServicoTomado")).Selected;
            checkboxServicoTomadosAtual.Should().Be(checkboxServicoTomadosEsperado, "O campo checkBox Declaração de Serviços Tomados Não está selecionado corretamente.");                
        }


        /// <param name="checkboxServicoTomadosEsperado">Habilitado = true, Desailitado = false</param>

        [Then(@"o status Habilitado para o campo Declarar como serviço tomado deverá ser ""(.*)""")]
        public void ThenOStatusHabilitadoParaOCampoDeclararDeveraSer(bool checkboxServicoTomadosEsperado)
        {
            bool checkboxServicoTomadosAtual = Driver.FindElement(By.Id("DeclaracaoNota_ServicoTomado")).Enabled;
            checkboxServicoTomadosAtual.Should().Be(checkboxServicoTomadosEsperado, "O status de habilitado e desabilitado para o campo checkBox Declaração de Serviços Tomados não está correto.");
        }


        [Then(@"será impresso o boleto de retenção de iss com a nova data de vencimento ""(.*)""")]
        public void ThenSeraImpressoOBoletoDeRetencaoDeIssComANovaDataDeVencimento(string novaDataVencimento)
        {
            new FormularioConsultaDeclaracao(Driver).BotaoImprimirBoletoNotaFiscalComRetencao();                        
            new FormularioNovaDataVencimento(Driver).InformarNovaDataVencimento(novaDataVencimento);               
        }

        [Then(@"será registrado o pagamento a guia de retenção de Issqn emitida pela empresa ""(.*)""\.")]
        public void ThenSeraAlteradoAGuiaDeRetencaoParaPagoDaEmpresa(string cnpj)
        {
            var pagamentoBoletoRetenção = new BoletoRetencaoService();
            pagamentoBoletoRetenção.ALteraSituacaoDaGuia(cnpj);
            pagamentoBoletoRetenção.AlteraSituacaoDebito(cnpj);
            pagamentoBoletoRetenção.AlteraSituacaoPagamentoDeclaracao(cnpj);
        }


        [Then(@"a empresa com o cnpj ""(.*)"" gerou o débito no sistema tributário para o cadastro ""(.*)""")]
        public void ThenAEmpresaComOCnpjGerouODebitoNoSistemaTributarioParaOCadastro(string cnpj, string cadastroEsperado)
        {
            var boleto = new BoletoRetencaoService();

            string cadastroAtual = boleto.ObterCadastroQueFoiConstituidoDebitoNoPronimAR(cnpj);

            cadastroAtual.Should().Be(cadastroEsperado);
        }






    }
}
