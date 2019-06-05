using Bdd_Database;
using System;
using System.Data.SqlClient;

namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.StartContext
{
    public class EntregaSimplesNacionalContext : DeclaracaoBaseContext
    {
        private SqlCommand cmd;

        public override void Executar(SqlCommand cmd)
        {
            base.Executar(cmd);
            this.cmd = cmd;
        }
               
    }
}
