using Bdd_Database.Contracts;
using System.Data.SqlClient;

namespace Bdd_Database
{
    public class DatabaseConnectionAR
    {
        private SqlConnection cnn;
        public SqlCommand Command { get; }


        public DatabaseConnectionAR()
        {
            cnn = new SqlConnection();
            cnn.ConnectionString = @"Server=WS687\MSSQL2017DEV;User Id=PRONIM;Password=PRO2010nim;Database=AR_TST";
            Command = new SqlCommand("", cnn);
        }

        public void InicializarContexto(IDatabaseContext contexto)
        {         

            Open();
            contexto.ExecutarAR(Command);
            Close();
        }

        public void Open() => cnn.Open();
        public void Close() => cnn.Close();
    }
}
