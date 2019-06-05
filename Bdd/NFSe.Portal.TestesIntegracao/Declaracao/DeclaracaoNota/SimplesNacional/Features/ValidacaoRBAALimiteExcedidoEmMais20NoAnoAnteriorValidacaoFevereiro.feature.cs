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
    public partial class ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiroFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro", @"         Como um usuário do sistema
		 Desejo declarar um nota fiscal de SERVIÇOS PRESTADOS
		 Sendo eu um PRESTADOR ESTABELECIDO e OPTANTE DO SIMPLES NACIONAL
		 E tendo UTRAPASSADO O SUBLIMITE EM MAIS DE 20 PORCENTO de faturamento no EXERCICIO ANTERIOR DECLARADO EM FEVEREIRO", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")))
            {
                global::NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Features.ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiroFeature.FeatureSetup(null);
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
#line 7
 #line 8
 testRunner.Given("que eu esteja executando a declaração de serviços pela primeira vez", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Usuario",
                        "Senha"});
            table1.AddRow(new string[] {
                        "\'01977364918\'",
                        "123"});
#line 9
 testRunner.Given("que eu logue no portal com os seguintes dados", ((string)(null)), table1, "Given ");
#line 13
 testRunner.And("realize a autenticação no cnpj \"06864931000114\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line 16
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 17
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
                        "06",
                        "2017",
                        "100000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "07",
                        "2017",
                        "100000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "08",
                        "2017",
                        "50000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "09",
                        "2017",
                        "100000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "10",
                        "2017",
                        "145000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "11",
                        "2017",
                        "150000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "12",
                        "2017",
                        "265000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "01",
                        "2018",
                        "700000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "02",
                        "2018",
                        "50000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "03",
                        "2018",
                        "120000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "04",
                        "2018",
                        "80000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "05",
                        "2018",
                        "111500",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "06",
                        "2018",
                        "135000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "07",
                        "2018",
                        "1160000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "08",
                        "2018",
                        "9650000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "09",
                        "2018",
                        "1000000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "1",
                        "1",
                        "0"});
            table2.AddRow(new string[] {
                        "10",
                        "2018",
                        "100000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "11",
                        "2018",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "12",
                        "2018",
                        "30000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "01",
                        "2019",
                        "15000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0",
                        "0"});
            table2.AddRow(new string[] {
                        "02",
                        "2019",
                        "10000",
                        "0",
                        "0",
                        "0",
                        "0",
                        "1",
                        "0",
                        "1"});
#line 19
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" possui os seguintes faturamentos", ((string)(null)), table2, "Given ");
#line 44
 testRunner.Given("que eu selecione a opção de Declaração de Serviços", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 45
 testRunner.Given("que eu solicite uma nova declaração para a competência \"02/2019\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo III Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoIIISemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo III Sem Retencao", null, ((string[])(null)));
#line 49
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 51
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 52
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoIII",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 54
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table3, "Given ");
#line 58
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 59
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table4, "And ");
#line 63
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 64
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo III Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoIIIComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo III Com Retencao", null, ((string[])(null)));
#line 69
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 71
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 72
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoIII",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 74
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table5, "Given ");
#line 78
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 79
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table6, "And ");
#line 83
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 84
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo IV Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoIVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo IV Sem Retencao", null, ((string[])(null)));
#line 89
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 91
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 92
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoIV",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 94
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table7, "Given ");
#line 98
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 99
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table8, "And ");
#line 103
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 104
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo IV Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoIVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo IV Com Retencao", null, ((string[])(null)));
#line 109
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 111
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 112
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoIV",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 114
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table9, "Given ");
#line 118
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 119
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table10, "And ");
#line 123
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 124
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo V Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo V Sem Retencao", null, ((string[])(null)));
#line 130
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 132
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 133
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoV",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 135
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table11, "Given ");
#line 139
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 140
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table12, "And ");
#line 144
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 145
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
            "o Anterior Validacao em Fevereiro Do Anexo V Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBAALimiteExcedidoEmMais20NoAnoAnteriorValidacaoFevereiro")]
        public virtual void CEN_03_04_ValidacaoRBAAExcedeuOSubLimiteEmMaisDe20PorcentoDoExercicioAnteriorValidacaoEmFevereiroDoAnexoVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.04 - Validacao RBAA Excedeu o SubLimite Em Mais de 20 Porcento Do Exercici" +
                    "o Anterior Validacao em Fevereiro Do Anexo V Com Retencao", null, ((string[])(null)));
#line 150
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 152
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 153
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é optante do Simples Nacional", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
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
                        "\'07.02\'",
                        "\'4212000\'",
                        "AnexoV",
                        "Não",
                        "Não",
                        "Não",
                        "2.9"});
#line 155
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table13, "Given ");
#line 159
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
                        "\'15/02/2019\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 160
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table14, "And ");
#line 164
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 165
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
