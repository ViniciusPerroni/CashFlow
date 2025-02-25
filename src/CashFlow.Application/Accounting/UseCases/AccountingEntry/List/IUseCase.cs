using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;


namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.List
{
    public interface IUseCase
    {
        Task<BasePagedResponse<IList<AccountingEntryDto>>> Execute(Request request);
    }
}
