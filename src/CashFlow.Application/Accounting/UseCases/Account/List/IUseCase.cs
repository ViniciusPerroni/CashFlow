using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;


namespace CashFlow.Application.Accounting.UseCases.Account.List
{
    public interface IUseCase
    {
        Task<BasePagedResponse<IList<AccountDto>>> Execute(Request request);
    }
}
