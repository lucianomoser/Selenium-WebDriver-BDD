using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bdd_Database.Contracts
{
    public class IdentidadeJuridicaService
    {
        public int ObterID (string documento)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql =
                "SELECT A.PKID  FROM IDENTIDADE_JURIDICA A " +
                "	LEFT JOIN EMPRESA B ON B.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = A.PKID " +
                "	LEFT JOIN PESSOA C ON C.FK_IDENTIDADE_JURIDICA_IDENTIDADE_JURIDICA = A.PKID " +
                "WHERE B.CNPJ = '" + documento + "' OR C.CPF = '" + documento + "'";


            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);
        }
    }
}
