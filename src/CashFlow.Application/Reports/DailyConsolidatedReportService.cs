using CashFlow.Data.Reports;
using CashFlow.Domain.Reports;

namespace CashFlow.Application.Reports
{
    public class DailyConsolidatedReportService : IDailyConsolidatedReportService
    {
        private readonly IDailyConsolidatedReportRepository dailyConsolidatedReportRepository;

        public DailyConsolidatedReportService(IDailyConsolidatedReportRepository dailyConsolidatedReportRepository)
        {
            this.dailyConsolidatedReportRepository = dailyConsolidatedReportRepository;
        }

        public async Task<DailyConsolidatedReport> GenerateReport(DateTime filterDate)
        {
            var report = await dailyConsolidatedReportRepository.GetDailyConsolidatedReport(filterDate);

            return report;
        }
    }
}
