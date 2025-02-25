using CashFlow.Data.lib;
using CashFlow.Domain.Accounting;
using CashFlow.Domain.Accounting.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Data.Accounting.Repositories
{
    public class AccountRepository : CrudRepository<Account>, IAccountRepository
    {
        public AccountRepository(CashFlowDbContext cashFlowDbContext) : base(cashFlowDbContext)
        {
            
        }

        public async Task<Account> GetByCode(string code)
        {
            return await _dbSet.AsQueryable().FirstOrDefaultAsync(x => x.Code == code);  
        }
    }
}