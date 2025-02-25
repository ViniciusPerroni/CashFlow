using CashFlow.Domain.Reports;

namespace CashFlow.Data.Reports
{
    public interface IDailyConsolidatedReportRepository
    {
        Task<DailyConsolidatedReport> GetDailyConsolidatedReport(DateTime filterDate);
    }
}