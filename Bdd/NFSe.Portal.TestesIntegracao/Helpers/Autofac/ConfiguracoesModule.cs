using Autofac;
using NFSe.Portal.TestesIntegracao.Declaracao.Configuracoes.Steps;
using NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.SimplesNacional.Steps;

namespace NFSe.Portal.TestesIntegracao.Helpers.Autofac
{
    public class ConfiguracoesModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConfiguracaoDosServicosPrestadosOuTomadosSteps>();
            builder.RegisterType<ConfiguracoesDosParamentrosDePrestadoresTomadoresSteps>();
            builder.RegisterType<DeclaracaoNotaSteps>();

            base.Load(builder);
        }
    }
}
