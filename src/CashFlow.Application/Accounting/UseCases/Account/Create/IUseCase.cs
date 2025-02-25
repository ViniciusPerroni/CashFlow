using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.Create
{
    public interface IUseCase
    {
        Task<BaseResponse<long>> Execute(Request request);
    }
}
