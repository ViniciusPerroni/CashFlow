using CashFlow.Application.Identification.Dtos;
using CashFlow.Application.lib;


namespace CashFlow.Application.Identification.UseCases.User.List
{
    public interface IUseCase
    {
        Task<BasePagedResponse<IList<UserDto>>> Execute(Request request);
    }
}
