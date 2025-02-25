using CashFlow.Domain.Identification;
using CashFlow.Domain.lib;

namespace CashFlow.Domain.Accounting
{
    public class AccountingEntry(EntryType type, decimal amount, DateTime entryDate, string description, long accountId, long creationUserId) : BaseEntity
    {
        public EntryType Type { get; private set; } = type;
        public decimal Amount { get; private set; } = amount;
        public DateTime EntryDate { get; private set; } = entryDate;
        public string Description { get; private set; } = description;

        public long AccountId { get; private set; } = accountId;
        public virtual Account Account { get; private set; }

        public long CreationUserId { get; private set; } = creationUserId;
        public virtual User CreationUser { get; private set; }
    }
}
