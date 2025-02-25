using CashFlow.Data.lib;
using CashFlow.Domain.Accounting;
using CashFlow.Domain.Reports;
using Dapper;

namespace CashFlow.Data.Reports
{
    public class DailyConsolidatedReportRepository : BaseReportRepository, IDailyConsolidatedReportRepository
    {
        public DailyConsolidatedReportRepository(DapperConnectionProvider connectionProvider) : base(connectionProvider)
        {

        }

        public async Task<DailyConsolidatedReport> GetDailyConsolidatedReport(DateTime filterDate)
        {
            using (var connection = CreateConnection())
            {
                string sqlQuery = @"
                    SELECT
	                     ae.Type,
	                     ae.Amount,
	                     ae.EntryDate,
	                     ae.Description,
	                     a.Code AS AccountCode,
	                     u.FirstName + ' ' + u.LastName AS CreationUserCompletName
                    FROM
	                    dbo.AccountingEntries ae
	                    INNER JOIN dbo.Accounts a ON a.Id = ae.AccountId
	                    INNER JOIN dbo.Users u ON u.Id = ae.CreationUserId
                    WHERE
	                    CONVERT(DATE, ae.EntryDate) = CONVERT(DATE, @filterDate) 
                    ORDER BY
	                    ae.EntryDate";

                var result = await connection.QueryAsync<DailyConsolidatedDetailReport>(sqlQuery, new { filterDate });

                var report = new DailyConsolidatedReport
                {
                    TotalCredit = result.Sum(r => r.Type == EntryType.Credit ? r.Amount : 0),
                    TotalDebit = result.Sum(r => r.Type == EntryType.Debit ? r.Amount : 0),
                    Details = result.ToList()
                };

                return report;
            }
        }
    }
}
