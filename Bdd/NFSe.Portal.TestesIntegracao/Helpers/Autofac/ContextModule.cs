using Autofac;
using Bdd_Database.Contracts.StartDataBaseContext;
using NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.StartContext;

namespace NFSe.Portal.TestesIntegracao.Helpers.Autofac
{
    public class ContextModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DeclaracaoContext>().As<IDeclaracaoContext>();
            base.Load(builder);
        }
    }
}
