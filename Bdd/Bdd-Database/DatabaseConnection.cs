using Bdd_Database.Contracts;
using System.Data.SqlClient;

namespace Bdd_Database
{
    public class DatabaseConnection
    {
        private SqlConnection cnn;
        public SqlCommand Command { get; }


        public DatabaseConnection()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = @"Server=WS687\MSSQL2017DEV;User Id=PRONIM;Password=PRO2010nim;Database=NFSE_TST";
            Command = new SqlCommand("", cnn);
        }

        public void InicializarContexto(IDatabaseContext contexto)
        {
            Open();            
            contexto.Executar(Command);            
            Close();            
        }

        public void Open() => cnn.Open();
        public void Close() => cnn.Close();
    }
}
