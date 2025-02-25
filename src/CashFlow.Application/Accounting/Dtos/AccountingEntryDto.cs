using CashFlow.Domain.Accounting;

namespace CashFlow.Application.Accounting.Dtos
{
    public class AccountingEntryDto
    {
        public EntryType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public string Description { get; set; }
        public long AccountId { get; set; }
        public long CreationUserId { get; set; }
    }
}
