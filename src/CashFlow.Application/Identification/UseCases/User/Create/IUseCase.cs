using CashFlow.Application.lib;

namespace CashFlow.Application.Identification.UseCases.User.Create
{
    public interface IUseCase
    {
        Task<BaseResponse<long>> Execute(Request request);
    }
}
