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
    public partial class ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnteriorFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private Microsoft.VisualStudio.TestTools.UnitTesting.TestContext _testContext;
        
#line 1 "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior.feature"
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
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior", "\t\t Como um usuário do sistema\r\n\t\t Desejo declarar um nota fiscal de SERVIÇOS PRES" +
                    "TADOS\r\n\t\t Sendo eu um PRESTADOR ESTABELECIDO e OPTANTE DO SIMPLES NACIONAL\r\n\t\t E" +
                    " tendo UTRAPASSADO O SUBLIMITE de faturamento na COMPETÊNCIA MÊS ANTERIOR", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (testRunner.FeatureContext.FeatureInfo.Title != "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")))
            {
                global::NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Features.ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnteriorFeature.FeatureSetup(null);
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
#line 19
 testRunner.Given("que a empresa de CNPJ \"06864931000114\" possui os seguintes faturamentos", ((string)(null)), table2, "Given ");
#line 40
 testRunner.Given("que eu selecione a opção de Declaração de Serviços", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 41
 testRunner.Given("que eu solicite uma nova declaração para a competência \"10/2018\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo III Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoIIISemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo III Sem Retencao", null, ((string[])(null)));
#line 45
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 47
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 48
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
#line 50
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table3, "Given ");
#line 54
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 55
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table4, "And ");
#line 59
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 60
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo III Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoIIIComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo III Com Retencao", null, ((string[])(null)));
#line 65
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 67
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 68
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
#line 70
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table5, "Given ");
#line 74
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 75
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table6, "And ");
#line 79
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 80
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo IV Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoIVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo IV Sem Retencao", null, ((string[])(null)));
#line 86
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 88
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 89
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
#line 91
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table7, "Given ");
#line 95
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 96
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table8, "And ");
#line 100
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 101
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo IV Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoIVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo IV Com Retencao", null, ((string[])(null)));
#line 106
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 108
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 109
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
#line 111
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table9, "Given ");
#line 115
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 116
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table10, "And ");
#line 120
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 121
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo V Sem Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoVSemRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo V Sem Retencao", null, ((string[])(null)));
#line 127
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 129
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 130
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
#line 132
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table11, "Given ");
#line 136
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Não",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 137
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table12, "And ");
#line 141
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 142
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,90", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
            "ia Anterior Do Anexo V Com Retencao")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "ValidacaoRBALimiteExcedidoEmMais20NaCompetenciaMesAnterior")]
        public virtual void CEN_03_01_ValidacaoRBAExcedeuOSubLimiteEmMaisDe20PorcentoNaCompetenciaAnteriorDoAnexoVComRetencao()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("CEN.03.01 - Validacao RBA Excedeu o SubLimite Em Mais de 20 Porcento Na Competenc" +
                    "ia Anterior Do Anexo V Com Retencao", null, ((string[])(null)));
#line 147
 this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line 7
 this.FeatureBackground();
#line 149
 testRunner.Given("que a empresa de CNPJ \"07065385000114\" é estabelecido", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line 150
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
#line 152
 testRunner.Given("a seguinte configuração de serviços", ((string)(null)), table13, "Given ");
#line 156
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
                        "\'15/10/2018\'",
                        "\'1234\'",
                        "\'A\'",
                        "\'0\'",
                        "\'07065385000114\'",
                        "Sim",
                        "\'07.02\'",
                        "\'4212000\'",
                        "\'Cerejeiras\'",
                        "100000"});
#line 157
 testRunner.And("forneça os seguintes dados para formulário de declaracao de nota", ((string)(null)), table14, "And ");
#line 161
 testRunner.Then("o status Habilitado para o campo Alíquota deverá ser \"false\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 162
 testRunner.Then("o valor do campo Alíquota deverá ser igual a 2,9", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

