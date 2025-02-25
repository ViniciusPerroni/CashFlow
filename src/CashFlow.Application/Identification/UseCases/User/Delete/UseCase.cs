using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.Delete
{
    public class UseCase : BaseUseCase<bool, Request, BaseResponse<bool>>, IUseCase
    {
        private readonly IUserRepository userRepository;

        public UseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        internal override async Task<BaseResponse<bool>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<bool>();
                response.Data = true;

                await userRepository.Delete(request.Id);

                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<bool>();
                response.AddError(ex.Message);

                response.Data = false;
                return response;
            }
        }
    }
}
