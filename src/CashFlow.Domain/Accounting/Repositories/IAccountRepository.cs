using CashFlow.Domain.lib;

namespace CashFlow.Domain.Accounting.Repositories
{
    public interface IAccountRepository : ICrudRepository<Account>
    {
        Task<Account> GetByCode(string code);
    }
}
