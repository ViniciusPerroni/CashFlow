using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.Edit
{
    public interface IUseCase
    {
        Task<BaseResponse<bool>> Execute(Request request);
    }
}
