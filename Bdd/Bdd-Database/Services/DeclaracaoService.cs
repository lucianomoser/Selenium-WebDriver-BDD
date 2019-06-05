using Bdd_Database.Helpers;
using System;

namespace Bdd_Database.Services
{
    public class DeclaracaoService
    {
        const string FORMAT = "YYYY-MM-DD";

        public void CriarDeclaracaoAbertura(int identidadeJuridica, string protocolo, DateTime competencia)
        {
            var hoje = DateTime.Now;
            var dtAbertura = DateConverter.Converter(hoje, FORMAT);
            var dtCompetencia = DateConverter.Converter(competencia, FORMAT);

            var sql = "INSERT INTO DECLARACAO_ABERTURA (" +
                       "    PROTOCOLO, DT_COMPETENCIA, DT_ABERTURA," +
                       "    FK_IDENTIDADE_JURIDICA_NFSE_DECLARANTE" +
                       ") VALUES ('" + protocolo + "'," +
                       " CONVERT(DATE, '" + dtCompetencia + "'), CONVERT(DATE, '" + dtAbertura + "')," +
                       identidadeJuridica + ")";
 
            var database = new DatabaseConnection();
            database.Open();
            var cmd = database.Command;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            database.Close();

           
        }

        public int ObterDeclaracaoAberturaID(string protocoloAbertura)
        {
            var database = new DatabaseConnection();
            database.Open();
            var cmd = database.Command;
 
            var sql = "SELECT PKID FROM DECLARACAO_ABERTURA WHERE PROTOCOLO = '" + protocoloAbertura + "'";

            cmd.CommandText = sql;
            var aberturaID = cmd.ExecuteScalar();

            database.Close();

            return Convert.ToInt32(aberturaID);
        }

        public void EntregarDeclaracao(int declaracaoAberturaId,                                         
                                       string protocolo, 
                                       DateTime dataEntrega)
        {
            var dataAbertura = DateTime.Now;
            var prazoEntrega = dataEntrega.AddDays(30);
            var vencimento = dataEntrega.AddDays(30);          

            var dtEntrega = DateConverter.Converter(dataEntrega, FORMAT);
            var dtPrazo = DateConverter.Converter(prazoEntrega, FORMAT);
            var dtVencimento = DateConverter.Converter(vencimento, FORMAT);

            var sql = "INSERT INTO DECLARACAO_ENTREGA2 ( " +
                      "	    FL_ABERTO, PROTOCOLO, DT_ENTREGA, DT_PRAZO_ENTREGA, " +
                      "	    FL_SEM_SERVICOS_PRESTADOS, FL_SEM_SERVICOS_TOMADOS, " +
                      "	    RPAMI, RPAME, RPACAIXA_MI, RPACAIXA_ME, " +
                      "	    FK_DECLARACAO_ABERTURA_DECLARACAO_ABERTURA, " +
                      "	    FK_DECLARACAO_ENTREGA2_REGISTRO_RETIFICADOR, " +
                      "	    FATOR_R, TOTAL_ISS_DEVIDO_SERVICO_TOMAD, TOTAL_BASE_CALCULO_SERVICO_TOM, " +
                      "	    TOTAL_ISS_DEVIDO_SERVICO_PREST, TOTAL_BASE_CALCULO_SERVICO_PRE, FK_DEBITO_DEBITO, " +
                      "	    DT_VENCIMENTO, REGIME_APURACAO_ANO_CORRENTE, REGIME_APURACAO_ANO_SEGUINTE " +
                      ") VALUES ( " +
                      "	    '0', '" + protocolo + "', CONVERT(DATE, '" + dtEntrega + "'), CONVERT(DATE, '"  + dtPrazo + "'), " +
                      "	    '1', '1', '0', '0', '0', '0', '" + declaracaoAberturaId + "', NULL, '0', '0', '0', '0', '0', " +
                      "	    NULL, CONVERT(DATE, '" + dtVencimento + "'), 'PorCompetencia', NULL) ";


            var database = new DatabaseConnection();
            database.Open();
            var cmd = database.Command;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            database.Close();

        }
    }
}
