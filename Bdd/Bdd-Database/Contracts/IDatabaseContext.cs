using System.Data.SqlClient;

namespace Bdd_Database.Contracts
{
    public interface IDatabaseContext
    {
        void Executar(SqlCommand command);

        void ExecutarAR(SqlCommand command);
    }
}
