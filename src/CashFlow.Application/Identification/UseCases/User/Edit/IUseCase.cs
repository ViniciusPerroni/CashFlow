using CashFlow.Application.lib;

namespace CashFlow.Application.Identification.UseCases.User.Edit
{
    public interface IUseCase
    {
        Task<BaseResponse<bool>> Execute(Request request);
    }
}
