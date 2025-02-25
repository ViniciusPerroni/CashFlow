using System.Data;

namespace CashFlow.Data.lib
{
    public abstract class BaseReportRepository
    {
        private readonly DapperConnectionProvider _connectionProvider;

        protected BaseReportRepository(DapperConnectionProvider connectionProvider)
        {
            _connectionProvider = connectionProvider;
        }

        protected IDbConnection CreateConnection()
        {
            return _connectionProvider.CreateConnection();
        }
    }
}
