using Autofac;
using NFSe.Portal.TestesIntegracao.Base;
using NFSe.Portal.TestesIntegracao.Contracts;
using NFSe.Portal.TestesIntegracao.Navegacao.Steps;
using SpecFlow.Autofac;

namespace NFSe.Portal.TestesIntegracao.Helpers.Autofac
{
    public class AutofacBuilder
    {
        [ScenarioDependencies]        
        public static ContainerBuilder CreateContainerBuilder()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<WebBrowser>().As<IWebBrowser>().SingleInstance();

            builder.RegisterModule<NavegacaoStepsModule>();
            builder.RegisterModule<ContextModule>();
            builder.RegisterModule<ConfiguracoesModule>();
            
            return builder;
        }
    }
}
