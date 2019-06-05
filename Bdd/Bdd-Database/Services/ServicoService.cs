using System;

namespace Bdd_Database.Services
{
    public class ServicoService
    {
        public enum Anexo
        {
            AnexoIII = 3,
            AnexoIV = 4,
            AnexoV = 5
        }
        public void AlterarAnexo(Anexo anexo, string servicoMunicipal)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;

            var idServMunicipal = ObterServicoClassificacaoID(servicoMunicipal);

            var sql = "UPDATE ANEXO_SERVICO_CLASSIFICACAO SET ANEXO = " + Convert.ToInt32(anexo)  + 
                  "  WHERE FK_SERVICO_CLASSIFICACAO_SERVICO_CLASSIFICACAO = " + idServMunicipal;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void AlterarSujeitoFatorR (bool value, string servicoMunicipal)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;

            var idServMunicipal = ObterServicoClassificacaoID(servicoMunicipal);
            var sujeitoAFotorR = value == true ? 1 : 0;

            var sql = " UPDATE ANEXO_SERVICO_CLASSIFICACAO SET FL_FATOR_R = " + sujeitoAFotorR +
                      " WHERE FK_SERVICO_CLASSIFICACAO_SERVICO_CLASSIFICACAO = " + idServMunicipal;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void AlterarRetencaoPeloTomador(bool value, string servicoMunicipal)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;
            var retTomador = value == true ? 1 : 0;
            var sql = " UPDATE SERVICO_CLASSIFICACAO SET FL_RETENCAO_TOMADOR = " + retTomador +
                      " WHERE CD_SERVICO_CLASSIFICACAO = " + servicoMunicipal;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void AlterarRetencaoNoLocalDaPrestacao(bool value, string servicoMunicipal, string servicoFederal)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;
            var noLocal = value == true ? 1 : 0;

            var sql = " UPDATE SERVICO_CLASSIFICACAO SET FL_RETENCAO_LOCAL_SERVICO = " + noLocal +
                      " WHERE CD_SERVICO_CLASSIFICACAO in (" + servicoMunicipal + "," + servicoFederal + ")";

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        public void AlterarAliquotaMunicipio(decimal valor, string servicoMunicipal)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;

            var servicoId = ObterServicoClassificacaoID(servicoMunicipal);

            string strValor = valor.ToString().Replace(".", ",");
            strValor = strValor.Replace(",", ".");

            var sql = " UPDATE SERVICO_ALIQUOTA SET VL_ALIQUOTA = '" + strValor +
                      "' WHERE FK_SERVICO_CLASSIFICACAO_SERVICO = " + servicoId;

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
        }

        private int ObterServicoClassificacaoID(string servico)
        {
            var dataBase = new DatabaseConnection();
            var cmd = dataBase.Command;

            dataBase.Open();

            var sql = "SELECT PKID FROM SERVICO_CLASSIFICACAO WHERE CD_SERVICO_CLASSIFICACAO = " + servico;
            cmd.CommandText = sql;

            var idServico = cmd.ExecuteScalar();

            dataBase.Close();

            return Convert.ToInt32(idServico);
        }

        public void AlteraEmpresaParaAdmMunicipal(int idAdmMunicipal)
        {
            var dataBase = new DatabaseConnection();
            var cmd = dataBase.Command;

            dataBase.Open();

            var sql = $"UPDATE EMPRESA SET FL_ADM_MUNICIPAL = 1 WHERE PKID = {idAdmMunicipal}";

            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            dataBase.Close();
        }



    }
}
