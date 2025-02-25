using CashFlow.Crosscutting;

namespace CashFlow.Domain.lib.ActionRepository
{
    public interface IGetAllRepository<T> where T : BaseEntity
    {
        Task<PagedResult<T>> GetAll(int page, int pageSize);
    }
}