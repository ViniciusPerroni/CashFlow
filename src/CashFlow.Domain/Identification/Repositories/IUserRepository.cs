using CashFlow.Domain.lib;

namespace CashFlow.Domain.Identification.Repositories
{
    public interface IUserRepository : ICrudRepository<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByEmailAndPassword(string email, string password);
    }
}
