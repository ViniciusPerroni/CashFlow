using CashFlow.Data.lib;
using CashFlow.Domain.Identification;
using CashFlow.Domain.Identification.Repositories;

using Microsoft.EntityFrameworkCore;

namespace CashFlow.Data.Identification.Repositories
{
    public class UserRepository : CrudRepository<User>, IUserRepository
    {
        public UserRepository(CashFlowDbContext cashFlowDbContext) : base(cashFlowDbContext)
        {
        }

        public async Task<User> GetByEmail(string email)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Email == email && x.Password == password);
        }
    }
}
