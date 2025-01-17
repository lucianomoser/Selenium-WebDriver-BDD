﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Features
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class CalculoISSEmpresaNoMesDeAberturaFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "CalculoISSEmpresaNoMesDeAbertura.feature"
#line hidden
        
        public virtual Microsoft.VisualStudio.TestTools.UnitTesting.TestContext TestContext
        {
            get
            {
                return this._testContext;
            }
            set
            {
                this._testContext = value;
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner(null, 0);
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "CalculoISSEmpresaNoMesDeAbertura", @"         Como um usuário do sistema
		 Desejo declarar uma nota fiscal de SERVIÇOS PRESTADOS afim de aferir o Calculo do ISSQN
		 Sendo eu uma EMPRESA ESTABELECIDA 
		 E OPTANTE DO SIMPLES NACIONAL
		 E desejo declarar a Prestação de Serviço no MESMO MÊS DA DATA DE ABERTURA DA EMPRESA		 ", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((testRunner.FeatureContext != null) 
                        && (testRunner.FeatureContext.FeatureInfo.Title != "CalculoISSEmpresaNoMesDeAbertura")))
            {
                global::NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Features.CalculoISSEmpresaNoMesDeAberturaFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Microsoft.VisualStudio.TestTools.UnitTesting.TestContext>(_testContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 9
 #line 10
 testRunner.Given("que eu esteja executando a declaração de serviços pela primeira vez", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Usuario",
                        "Senha"});
            table1.AddRow(new string[] {
                        "\'01977364918\'",
                        "123"});
#line 11
 testRunner.Given("que eu logue no portal com os seguintes dados", ((string)(null)), table1, "Given ");
#line 15
 testRunner.And("realize a autenticação no cnpj \"06864931000114\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 17
 testRunner.Given("que a data de abertura da empresa de CNPJ \"06864931000114\" seja \"01/09/2018\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 18
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 19
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Mes",
                        "Ano",
                        "Faturamento",
                        "MercadoExterno",
                        "RegimeCaixa",
                        "RegimeCaixaME",
                        "FatorR",
                        "AtingiuSubLimite",
                        "UltrapassouSubLimite",
                        "SubLimiteViaRba"});
            table2.AddRow(new string[] {
                        "09",
                        "2018",
                        "100000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
#line 21
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" possui os seguintes faturamentos", ((string)(null)), table2, "Given ");
#line 26
 testRunner.Given("que eu selecione a opção de Declaração de Serviços", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 27
 testRunner.Given("que eu solicite uma nova declaração para a competência \"09/2018\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoIIISemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Sem Retencao", null, ((string[])(null)));
#line 30
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table3.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoIII",
                        "Não",
                        "Não",
                        "Não",
                        "16.0"});
#line 32
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table3, "Given ");
#line 36
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table4.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Não",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 38
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table4, "And ");
#line 42
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 4,2347500000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoIIIComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo III Com Retencao", null, ((string[])(null)));
#line 47
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table5.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoIII",
                        "Sim",
                        "Não",
                        "Não",
                        "0.0"});
#line 49
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table5, "Given ");
#line 53
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table6.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Sim",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 55
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table6, "And ");
#line 59
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,0000000000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoIVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Sem Retencao", null, ((string[])(null)));
#line 65
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table7 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table7.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoIV",
                        "Não",
                        "Não",
                        "Não",
                        "14.0"});
#line 67
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table7, "Given ");
#line 71
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table8 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table8.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Não",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 73
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table8, "And ");
#line 77
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 4,2740000000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoIVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo IV Com Retencao", null, ((string[])(null)));
#line 83
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table9 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table9.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoIV",
                        "Sim",
                        "Não",
                        "Não",
                        "0.0"});
#line 85
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table9, "Given ");
#line 89
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table10 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table10.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Sim",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 91
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table10, "And ");
#line 95
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,0000000000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Sem Retencao", null, ((string[])(null)));
#line 100
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table11 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table11.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoV",
                        "Não",
                        "Não",
                        "Não",
                        "20.50"});
#line 102
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table11, "Given ");
#line 106
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table12 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table12.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Não",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 108
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table12, "And ");
#line 112
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 4,0057500000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "CalculoISSEmpresaNoMesDeAbertura")]
        public virtual void CEN_02_02_CalculoISSEmpresaNoMesDeAberturaDoAnexoVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.02.02 - Calculo ISS Empresa no mes de abertura Do Anexo V Com Retencao", null, ((string[])(null)));
#line 117
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 9
 this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table13 = new TechTalk.SpecFlow.Table(new string[] {
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "Anexo",
                        "RetencaoTomador",
                        "SujeitoFatoR",
                        "DevidoNoLocal",
                        "Aliquota"});
            table13.AddRow(new string[] {
                        "\'01.01\'",
                        "\'6202300\'",
                        "AnexoIV",
                        "Sim",
                        "Não",
                        "Não",
                        "0.0"});
#line 119
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table13, "Given ");
#line 123
 testRunner.Given("que eu solicite uma nova declaração de nota de serviço", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table14 = new TechTalk.SpecFlow.Table(new string[] {
                        "Modalidade",
                        "Emissao",
                        "Numero",
                        "Serie",
                        "Aliquota",
                        "TomadorPrestador",
                        "Retido",
                        "ServicoFederal",
                        "ServicoMunicipal",
                        "MunicipioPrestacao",
                        "Valor"});
            table14.AddRow(new string[] {
                        "Prestado",
                        "\'01/09/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'10306984000197\'",
                        "Sim",
                        "\'01.01\'",
                        "\'6202300\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 125
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table14, "And ");
#line 129
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,0000000000", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

