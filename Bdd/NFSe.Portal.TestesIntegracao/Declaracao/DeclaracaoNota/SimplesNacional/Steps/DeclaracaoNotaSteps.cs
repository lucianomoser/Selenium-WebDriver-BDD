using Bdd_Database;
using NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.StartContext;
using TechTalk.SpecFlow;

namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Steps
{
    [Binding]
    public class DeclaracaoNotaSteps
    {
        [Given(@"que eu esteja executando a declaração de serviços pela primeira vez")]
        public void GivenQueEuEstejaExecutandoADeclaracaoDeServicosPelaPrimeiraVez()
        {
            var cnn = new DatabaseConnection();
            cnn.InicializarContexto(new DeclaracaoContext());

            var cnnAR = new DatabaseConnectionAR();
            cnnAR.InicializarContexto(new DeclaracaoContext());
        }
    }
}
