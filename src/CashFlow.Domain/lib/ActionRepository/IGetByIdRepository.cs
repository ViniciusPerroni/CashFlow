namespace CashFlow.Domain.lib.ActionRepository
{
    public interface IGetByIdRepository<T> where T : BaseEntity
    {
        Task<T> GetById(long id);
    }
}
