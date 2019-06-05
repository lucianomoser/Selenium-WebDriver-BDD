using System.Data.SqlClient;

namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.StartContext
{
    public class DeclaracaoEntregueContext: DeclaracaoBaseContext
    {
        public override void Executar(SqlCommand cmd)
        {
            base.Executar(cmd);
            
        }
    }
}
