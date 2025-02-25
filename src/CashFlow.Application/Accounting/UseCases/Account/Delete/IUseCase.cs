using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.Delete
{
    public interface IUseCase
    {
        Task<BaseResponse<bool>> Execute(Request request);
    }
}
