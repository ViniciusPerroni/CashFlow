using Microsoft.Data.SqlClient;
using System.Data;

namespace CashFlow.Data.lib
{
    public class DapperConnectionProvider
    {
        private readonly string _connectionString;

        public DapperConnectionProvider(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
