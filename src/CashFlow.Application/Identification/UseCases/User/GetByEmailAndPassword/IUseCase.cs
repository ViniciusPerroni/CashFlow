using CashFlow.Application.Identification.Dtos;
using CashFlow.Application.lib;

namespace CashFlow.Application.Identification.UseCases.User.GetByEmailAndPassword
{
    public interface IUseCase
    {
        Task<BaseResponse<UserDto>> Execute(Request request);
    }
}
