using CashFlow.Domain.lib.ActionRepository;

namespace CashFlow.Domain.lib
{
    public interface ICrdRepository<T> : ICreateRepository<T>, IDeleteRepository, IGetAllRepository<T>, IGetByIdRepository<T> where T : BaseEntity
    {
    }
}