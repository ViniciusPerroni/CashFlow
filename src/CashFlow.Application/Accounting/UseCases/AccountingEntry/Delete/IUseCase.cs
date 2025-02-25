using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Delete
{
    public interface IUseCase
    {
        Task<BaseResponse<bool>> Execute(Request request);
    }
}
