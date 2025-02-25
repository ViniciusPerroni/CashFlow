namespace CashFlow.Domain.lib.ActionRepository
{
    public interface IUpdateRepository<T> where T : BaseEntity
    {
        Task Update(T entity);
    }
}
