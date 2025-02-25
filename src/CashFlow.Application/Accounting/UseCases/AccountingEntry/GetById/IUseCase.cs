using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.GetById
{
    public interface IUseCase
    {
        Task<BaseResponse<AccountingEntryDto>> Execute(Request request);
    }
}
