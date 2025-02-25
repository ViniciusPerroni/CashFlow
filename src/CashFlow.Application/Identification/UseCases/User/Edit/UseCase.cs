using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.Edit
{
    public class UseCase : BaseUseCase<bool, Request, BaseResponse<bool>>, IUseCase
    {
        private readonly IUserRepository userRepository;

        public UseCase(IUserRepository accountRepository)
        {
            this.userRepository = userRepository;
        }

        internal override async Task<BaseResponse<bool>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<bool>();
                response.Data = true;

                var user = await userRepository.GetById(request.Id);
                if (user == null)
                {
                    response.AddError("User não localizado para o Id informado.");
                    response.Data = false;
                    return response;
                }

                user.Edit(request.FirstName, request.LastName);
                await userRepository.Update(user);

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
