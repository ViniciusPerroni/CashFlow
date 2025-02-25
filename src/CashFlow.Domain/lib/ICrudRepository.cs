using CashFlow.Domain.lib.ActionRepository;

namespace CashFlow.Domain.lib
{
    public interface ICrudRepository<T> : ICreateRepository<T>, IDeleteRepository, IGetAllRepository<T>, IGetByIdRepository<T>, IUpdateRepository<T> where T : BaseEntity
    {

    }
}
