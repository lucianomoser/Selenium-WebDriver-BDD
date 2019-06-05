using System;

namespace Bdd_Database.Services
{
    public class PessoaService
    {
        public int ObterPessoaId(string cpf)
        {
            var database = new DatabaseConnection();
            var cmd = database.Command;

            var sql = "SELECT PKID FROM PESSOA WHERE CPF = '" + cpf + "'";

            cmd.CommandText = sql;
            database.Open();
            var result = cmd.ExecuteScalar();
            database.Close();

            return Convert.ToInt32(result);

        }
    }
}
