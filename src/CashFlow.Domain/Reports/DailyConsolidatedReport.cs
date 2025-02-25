using CashFlow.Domain.Accounting;

namespace CashFlow.Domain.Reports
{
    public class DailyConsolidatedReport
    {
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public List<DailyConsolidatedDetailReport> Details { get; set; }
    }

    public class DailyConsolidatedDetailReport
    {
        public EntryType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime EntryDate { get; set; } 
        public string Description { get; set; }
        public string AccountCode { get; set; }
        public string CreationUserCompletName { get; set; }
    }
}
