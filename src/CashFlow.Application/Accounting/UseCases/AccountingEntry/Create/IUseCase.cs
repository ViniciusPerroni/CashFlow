using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Create
{
    public interface IUseCase
    {
        Task<BaseResponse<long>> Execute(Request request);
    }
}
