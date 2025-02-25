namespace CashFlow.Domain.lib.ActionRepository
{
    public interface IDeleteRepository
    {
        Task Delete(long id);
    }
}
