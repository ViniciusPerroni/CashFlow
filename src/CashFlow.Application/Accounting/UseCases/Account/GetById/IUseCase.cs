using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.GetById
{
    public interface IUseCase
    {
        Task<BaseResponse<AccountDto>> Execute(Request request);
    }
}
