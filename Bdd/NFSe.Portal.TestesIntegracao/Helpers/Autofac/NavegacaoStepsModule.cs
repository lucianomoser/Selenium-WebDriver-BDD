using Autofac;
using NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.AdministradorMunicipal.Steps;
using NFSe.Portal.TestesIntegracao.Navegacao.Steps;

namespace NFSe.Portal.TestesIntegracao.Helpers.Autofac
{
    public class NavegacaoStepsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AutenticacaoSteps>();
            builder.RegisterType<LoginNoPortalSteps>();
            builder.RegisterType<DeclaracaoSteps>();
            builder.RegisterType<DeclaracaoNotaServicoSteps>();
            builder.RegisterType<DeclaracaoEntregaSemServicoPrestadoTomadoSteps>();
            builder.RegisterType<DeclaracaoDeServicoTomadoOndeTomadorAdmMunicipalVinculaEmpenhoSteps>();
        }
    }
}
