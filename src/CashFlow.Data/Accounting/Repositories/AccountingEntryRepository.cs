using CashFlow.Data.lib;
using CashFlow.Domain.Accounting;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Data.Accounting.Repositories
{
    public class AccountingEntryRepository : CrdRepository<AccountingEntry>, IAccountingEntryRepository
    {
        public AccountingEntryRepository(CashFlowDbContext cashFlowDbContext) : base(cashFlowDbContext)
        {
        }
    }
}
