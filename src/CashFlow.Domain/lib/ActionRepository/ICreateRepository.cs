namespace CashFlow.Domain.lib.ActionRepository
{
    public interface ICreateRepository<T> where T : BaseEntity
    {
        Task Create(T entity);
    }
}
