using CashFlow.Domain.lib;

namespace CashFlow.Data.lib
{
    public class CrdRepository<T> : BaseRepository<T>, ICrdRepository<T> where T : BaseEntity
    {
        public CrdRepository(CashFlowDbContext cashFlowDbContext) : base(cashFlowDbContext)
        {
        }
    }
}
