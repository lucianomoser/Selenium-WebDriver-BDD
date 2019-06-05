
using System;
using System.Data.SqlClient;

namespace Bdd_Database.Services
{
    public class BoletoRetencaoService
    {      


        public void ALteraSituacaoDaGuia(string cnpj)
        {
            DatabaseConnection DataBase = new DatabaseConnection();
            DataBase.Open();
            SqlCommand cmd = DataBase.Command;

            string Sql = $@"UPDATE GUIA SET GUIA.SITUACAO = 2	   
                             	   FROM EMPRESA
                                   JOIN IDENTIDADE_JURIDICA ON
                                        IDENTIDADE_JURIDICA.FK_EMPRESA_EMPRESA = EMPRESA.PKID
                                   JOIN IDENTIDADE_JURIDICA_NFSE ON
                                        IDENTIDADE_JURIDICA_NFSE.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = IDENTIDADE_JURIDICA.PKID
                                   JOIN DECLARACAO_NOTA2 ON 
                                        DECLARACAO_NOTA2.FK_IDENTIDADE_JURIDICA_NFSE_PESSOA = IDENTIDADE_JURIDICA_NFSE.PKID
                                   JOIN DECLARACAO_NOTA2_GUIA ON
                                        DECLARACAO_NOTA2_GUIA.FK_DECLARACAO_NOTA2_DECLARACAO_NOTA = DECLARACAO_NOTA2.PKID
                                   JOIN GUIA ON
                                        GUIA.PKID = DECLARACAO_NOTA2_GUIA.FK_GUIA_GUIA
                                   JOIN DEBITO ON
                                        DEBITO.PKID = GUIA.FK_DEBITO_DEBITO
                                  WHERE EMPRESA.CNPJ = '{cnpj}'
                                    AND GUIA.PKID IN (SELECT MAX(PKID) FROM GUIA)";

            cmd.CommandText = Sql;

            cmd.ExecuteNonQuery();

            DataBase.Close();
        }


        public void AlteraSituacaoDebito(string cnpj)
        {
            DatabaseConnection DataBase = new DatabaseConnection();
            DataBase.Open();
            SqlCommand cmd = DataBase.Command;           

            try
            {
                string Sql = $@"UPDATE DEBITO SET DEBITO.SITUACAO = 3
                                         FROM EMPRESA
                                  JOIN IDENTIDADE_JURIDICA ON
                                       IDENTIDADE_JURIDICA.FK_EMPRESA_EMPRESA = EMPRESA.PKID
                                  JOIN IDENTIDADE_JURIDICA_NFSE ON
                                       IDENTIDADE_JURIDICA_NFSE.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = IDENTIDADE_JURIDICA.PKID
                                  JOIN DECLARACAO_NOTA2 ON
                                       DECLARACAO_NOTA2.FK_IDENTIDADE_JURIDICA_NFSE_PESSOA = IDENTIDADE_JURIDICA_NFSE.PKID
                                  JOIN DECLARACAO_NOTA2_GUIA ON
                                       DECLARACAO_NOTA2_GUIA.FK_DECLARACAO_NOTA2_DECLARACAO_NOTA = DECLARACAO_NOTA2.PKID
                                  JOIN GUIA ON
                                       GUIA.PKID = DECLARACAO_NOTA2_GUIA.FK_GUIA_GUIA
                                  JOIN DEBITO  on
                                       DEBITO.PKID = GUIA.FK_DEBITO_DEBITO
                                  WHERE EMPRESA.CNPJ = '{cnpj}'
                                        AND GUIA.PKID IN(SELECT MAX(PKID) FROM GUIA)";

                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Não foi possível alterar a situação do Débito" + ex.Message);
            }

            DataBase.Close();
        }

        public void AlteraSituacaoPagamentoDeclaracao(string cnpj)
        {

            DatabaseConnection DataBase = new DatabaseConnection();
            DataBase.Open();
            SqlCommand cmd = DataBase.Command;           

            try
            {
                string Sql = $@"UPDATE DECLARACAO_NOTA2 SET SITUACAO_PAGAMENTO = 3		
                              	   FROM EMPRESA
                              JOIN IDENTIDADE_JURIDICA ON
                                   IDENTIDADE_JURIDICA.FK_EMPRESA_EMPRESA = EMPRESA.PKID
                              JOIN IDENTIDADE_JURIDICA_NFSE ON
                                   IDENTIDADE_JURIDICA_NFSE.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = IDENTIDADE_JURIDICA.PKID
                              JOIN DECLARACAO_NOTA2 ON 
                                   DECLARACAO_NOTA2.FK_IDENTIDADE_JURIDICA_NFSE_PESSOA = IDENTIDADE_JURIDICA_NFSE.PKID
                              JOIN DECLARACAO_NOTA2_GUIA ON
                                   DECLARACAO_NOTA2_GUIA.FK_DECLARACAO_NOTA2_DECLARACAO_NOTA = DECLARACAO_NOTA2.PKID                            
                             WHERE EMPRESA.CNPJ = '{cnpj}'";

                cmd.CommandText = Sql;
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw new Exception("Não foi possível alterar a situação de pagamento da declaração."+ ex.Message);
            }            
            DataBase.Close();
        }


        public string ObterCadastroQueFoiConstituidoDebitoNoPronimAR(string cnpj)
        {
            DatabaseConnectionAR DataBase = new DatabaseConnectionAR();
            SqlCommand cmd = DataBase.Command;
            DataBase.Open();
          
                string Sql = $@" SELECT TOP 1 CADASTRO.NRCADASTRO                                   
                              FROM CADASTRO
                              JOIN DEBITOTEMPORARIO ON 
                                   DEBITOTEMPORARIO.CDTIPOCADASTRO = CADASTRO.CDTIPOCADASTRO
                               AND DEBITOTEMPORARIO.NRCADASTRO = CADASTRO.NRCADASTRO
                              JOIN VALORTRIBUTOTEMPORARIO ON 
                                   VALORTRIBUTOTEMPORARIO.CDTIPOCADASTRO = DEBITOTEMPORARIO.CDTIPOCADASTRO
                               AND VALORTRIBUTOTEMPORARIO.NRCADASTRO = DEBITOTEMPORARIO.NRCADASTRO
                               AND VALORTRIBUTOTEMPORARIO.DTANODEBITO = DEBITOTEMPORARIO.DTANODEBITO
                               AND VALORTRIBUTOTEMPORARIO.CDDIVIDA = DEBITOTEMPORARIO.CDDIVIDA
                               AND VALORTRIBUTOTEMPORARIO.CDSUBDIVIDA = DEBITOTEMPORARIO.CDSUBDIVIDA
                               AND VALORTRIBUTOTEMPORARIO.NRPARCELA = DEBITOTEMPORARIO.NRPARCELA
                              JOIN PARGUIANFSETIPOCADASTRO ON 
                                   PARGUIANFSETIPOCADASTRO.CDTIPOCADASTRO = VALORTRIBUTOTEMPORARIO.CDTIPOCADASTRO
                               AND PARGUIANFSETIPOCADASTRO.CDDIVIDA = VALORTRIBUTOTEMPORARIO.CDDIVIDA
                               AND ((PARGUIANFSETIPOCADASTRO.CDTRIBUTOIMPOSTO = VALORTRIBUTOTEMPORARIO.CDTRIBUTO)
                                OR (PARGUIANFSETIPOCADASTRO.CDTRIBUTOTAXA = VALORTRIBUTOTEMPORARIO.CDTRIBUTO))
                             WHERE CADASTRO.NRCGCCPF = '{cnpj}'";

            cmd.CommandText = Sql;
            var result = cmd.ExecuteScalar();       
            
            DataBase.Close();

            return Convert.ToString(result);

        }
    }

}
