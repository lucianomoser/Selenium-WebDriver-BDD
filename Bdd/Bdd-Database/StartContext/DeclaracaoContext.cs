using Bdd_Database.Contracts.StartDataBaseContext;
using System.Data.SqlClient;

namespace NFSe.Portal.TestesIntegracao.Declaracao.DeclaracaoNota.StartContext
{
    public class DeclaracaoContext : IDeclaracaoContext
    {
        public virtual void Executar(SqlCommand cmd)
        {
            Executar("DELETE FROM DECLARACAO_NOTA2_GUIA", cmd);
            Executar("DELETE FROM GUIA", cmd);
            Executar("DELETE FROM DECLARACAO_NOTA2_EMPENHO", cmd);
            Executar("DELETE FROM DECLARACAO_NOTA2", cmd);
            Executar("DELETE FROM DECLARACAO_NUMERO_INUTILIZADO", cmd);
            Executar("DELETE FROM DECLARACAO_ENTREGA2", cmd);
            Executar("DELETE FROM DECLARACAO_ABERTURA", cmd);
            Executar("DELETE FROM REGIME_APURACAO", cmd);
            Executar("DELETE FROM FATURAMENTO", cmd);
        }




        public virtual void ExecutarAR(SqlCommand cmd)
        {
            Executar("DELETE FROM CERTIDAOLEVANTAMENTO", cmd);
            Executar("DELETE FROM VALORTRIBUTOCERTIDAO", cmd);
            Executar("DELETE FROM DEBITOCERTIDAO", cmd);
            Executar("DELETE FROM DEBITOTEMPORARIO", cmd);
            Executar("DELETE FROM VALORTRIBUTOTEMPORARIO", cmd);
            Executar("DELETE FROM NOTAFISCALDEBITO", cmd);
            Executar("DELETE FROM NOTAFISCAL", cmd);

        }

        protected void Executar(string sql, SqlCommand cmd)
        {
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }


        
    }
}
