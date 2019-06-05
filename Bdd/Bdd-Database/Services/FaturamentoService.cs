namespace Bdd_Database.Services
{
    public class FaturamentoService
    {
        public void ProcessarFaturamento(dynamic table, int identidadeJuridica)
        {
            var dataBase = new DatabaseConnection();
            dataBase.Open();
            var cmd = dataBase.Command;

            foreach (var item in table)
            {
                var sql = "INSERT INTO FATURAMENTO VALUES (" +
                    item.Mes + "," +
                    item.Ano + "," +
                    item.Faturamento + "," + identidadeJuridica + "," +
                    item.MercadoExterno + "," +
                    item.RegimeCaixa + "," +
                    item.RegimeCaixaME + "," +
                    item.FatorR + ", " +
                    item.AtingiuSubLimite +", " +
                    item.UltrapassouSubLimite +", " +
                    item.SubLimiteViaRba +")";

                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            dataBase.Close();
        }
    }
}
