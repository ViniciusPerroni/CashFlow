using CashFlow.Domain.Reports;

namespace CashFlow.Application.Reports
{
    public interface IDailyConsolidatedReportService
    {
        Task<DailyConsolidatedReport> GenerateReport(DateTime filterDate);
    }
}