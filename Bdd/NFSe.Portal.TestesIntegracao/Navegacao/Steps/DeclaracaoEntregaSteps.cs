using System;
using TechTalk.SpecFlow;

namespace NFSe.Portal.TestesIntegracao.Navegacao.Steps
{
    [Binding]
    public class DeclaracaoEntregaSteps
    {
        [Given(@"que eu selecione a opção de entrega")]
        public void DadoQueEuSelecioneAOpcaoDeEntrega()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"informe que o regime de apuração será por ""(.*)""")]
        public void DadoInformeQueORegimeDeApuracaoSeraPor(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"Informe os seguintes dados para o regime de Competência")]
        public void DadoInformeOsSeguintesDadosParaORegimeDeCompetencia(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
