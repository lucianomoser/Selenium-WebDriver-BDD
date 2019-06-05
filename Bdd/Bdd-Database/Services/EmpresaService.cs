using Bdd_Database.Helpers;
using System;

namespace Bdd_Database.Services
{
    public class EmpresaService
    {
        const string FORMAT = "YYYY-MM-DD";

        public int ObterEmpresaId(string cnpj)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql = "SELECT PKID FROM EMPRESA WHERE CNPJ = '" + cnpj + "'";

            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);

        }

        public int ObterIdentidadeJuridicaId(string documento)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql =
                $@"SELECT A.PKID FROM IDENTIDADE_JURIDICA A 
                          INNER JOIN EMPRESA B 
                                  ON B.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = A.PKID 
                               WHERE B.CNPJ = '{documento}' ";

            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);

        }

        public int ObterContribuinteId(string documento)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql =
                   @"SELECT c.PKID
                    FROM CONTRIBUINTE c
                        LEFT JOIN IDENTIDADE_JURIDICA i
                            ON c.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = i.PKID
                        LEFT JOIN EMPRESA e
                            ON e.PKID = i.FK_EMPRESA_EMPRESA
                    WHERE e.CNPJ = '" + documento + "'";

            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);
        }

        public int ObterPessoaEmpresaId(int pessoaId, int empresaId)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql =
                "SELECT PKID FROM PESSOA_EMPRESA " +
                "WHERE FK_PESSOA_PESSOA = " + pessoaId + " AND FK_EMPRESA_EMPRESA = " + empresaId;

            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);
        }

        public void AlterarDataAbertura(DateTime data, string cnpj)
        {
            var database = new DatabaseConnection();
           
            var cmd = database.Command;
            var dtAbertura = DateConverter.Converter(data, FORMAT);

            var sql = "UPDATE EMPRESA SET DT_ABERTURA = CONVERT(DATE, '" + dtAbertura + "') WHERE CNPJ = '" + cnpj + "'";

            cmd.CommandText = sql;

            database.Open();
            cmd.ExecuteNonQuery();
            database.Close();

        }       

        public void DefinirComoOptanteSimplesNacional(string cnpj, DateTime? dataAbertura = null)
        {
            var database = new DatabaseConnection();

            DateTime data = new DateTime(2001, 01, 01);

            if (dataAbertura != null)
                data = dataAbertura.Value;


            var identidadeJuridicaId = ObterIdentidadeJuridicaId(cnpj);
            var contribuinteId = ObterContribuinteId(cnpj);

            var cmd = database.Command;
            var dtAbertura = DateConverter.Converter(data, FORMAT);
                       
            database.Open();

            var sql = "UPDATE EMPRESA SET DT_ABERTURA = CONVERT(DATE, '" + dtAbertura + "'), DT_FECHAMENTO = NULL WHERE CNPJ = '" + cnpj + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            
            sql = "UPDATE ENQUADRAMENTO SET TP_ENQUADRAMENTO = 5 WHERE FK_CONTRIBUINTE_CONTRIBUINTE = " + contribuinteId;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            database.Close();

        }

        public void DefinirComoOptanteSimplesNacionalEmpresaNaoEstabelecido(string cnpj, DateTime? dataAbertura = null)
        {         

            var database = new DatabaseConnection();

            DateTime data = new DateTime(2001, 01, 01);

            if (dataAbertura != null)
                data = dataAbertura.Value;


            var identidadeJuridicaId = ObterIdentidadeJuridicaId(cnpj);
            var contribuinteId = ObterContribuinteId(cnpj);

            var cmd = database.Command;
            var dtAbertura = DateConverter.Converter(data, FORMAT);

            database.Open();

            var sql = "UPDATE EMPRESA SET DT_ABERTURA = CONVERT(DATE, '" + dtAbertura + "'), DT_FECHAMENTO = NULL WHERE CNPJ = '" + cnpj + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "UPDATE ENQUADRAMENTO SET TP_ENQUADRAMENTO = 5 WHERE FK_CONTRIBUINTE_CONTRIBUINTE = " + contribuinteId;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();


            sql = $"UPDATE EMPRESA SET FL_OPTANTE_SIMPLES_NACIONAL = 1 WHERE CNPJ =  '{cnpj}'";            
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();            

            database.Close();

        }

        public void DefinirComoHomologado(string cnpj, DateTime? dataAbertura = null)
        {
            var database = new DatabaseConnection();

            DateTime data = new DateTime(2001, 01, 01);

            if (dataAbertura != null)
                data = dataAbertura.Value;


            var identidadeJuridicaId = ObterIdentidadeJuridicaId(cnpj);
            var contribuinteId = ObterContribuinteId(cnpj);

            var cmd = database.Command;
            var dtAbertura = DateConverter.Converter(data, FORMAT);

            database.Open();

            var sql = "UPDATE EMPRESA SET DT_ABERTURA = CONVERT(DATE, '" + dtAbertura + "'), DT_FECHAMENTO = NULL WHERE CNPJ = '" + cnpj + "'";
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            sql = "UPDATE ENQUADRAMENTO SET TP_ENQUADRAMENTO = 16 WHERE FK_CONTRIBUINTE_CONTRIBUINTE = " + contribuinteId;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            database.Close();

        }

        public void DefinirComoEstabelecido(string cnpj)
        {
            var identidadeJuridicaId = ObterIdentidadeJuridicaId(cnpj);

            var database = new DatabaseConnection();
            var cmd = database.Command;

            database.Open();

            var sql = "UPDATE IDENTIDADE_JURIDICA SET ORIGEM = 1 WHERE PKID = " + identidadeJuridicaId;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            database.Close();
        }

        public void DefinirComoNaoEstabelecido(string cnpj)
        {
            var identidadeJuridicaId = ObterIdentidadeJuridicaId(cnpj);

            var database = new DatabaseConnection();
            var cmd = database.Command;

            database.Open();

            var sql = "UPDATE IDENTIDADE_JURIDICA SET ORIGEM = 2 WHERE PKID = " + identidadeJuridicaId;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            database.Close();
        }

        public void DefinirEmpresaCadastradaComoPrestadora(string cnpjPrestador, string cnpjTomador)
        {

            var identidadeJuridicaPrestadorId = ObterIdentidadeJuridicaId(cnpjPrestador);

            var identidadeJuridicaTomadorId = ObterIdentidadeJuridicaId(cnpjTomador);


            var database = new DatabaseConnection();
            var cmd = database.Command;

            database.Open();

            var sql = $@"UPDATE IDENTIDADE_JURIDICA 
                            SET FK_IDENTIDADE_JURIDICA_USUARIO_ORIGEM_IDENTIDADE_JURI = {identidadeJuridicaTomadorId} 
                          WHERE PKID =  {identidadeJuridicaPrestadorId}";

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();

            database.Close();


        }
    }
}
