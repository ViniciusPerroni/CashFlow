using CashFlow.Crosscutting;
using CashFlow.Domain.lib;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Data.lib
{
    public abstract class CrudRepository<T> : BaseRepository<T>, ICrudRepository<T> where T : BaseEntity
    {
        public CrudRepository(CashFlowDbContext cashFlowDbContext) : base(cashFlowDbContext)
        {
        }
    }
}
