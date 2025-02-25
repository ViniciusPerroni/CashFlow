using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.Create
{
    public class UseCase : BaseUseCase<long, Request, BaseResponse<long>>, IUseCase
    {
        private readonly IUserRepository userRepository;

        public UseCase(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        internal override async Task<BaseResponse<long>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<long>();

                var user = await userRepository.GetByEmail(request.Email);
                if (user != null)
                {
                    response.Errors.Add("Email já utilizado");
                    return response;
                }

                request.Password = BCrypt.Net.BCrypt.HashPassword(request.Password);
                user = new Domain.Identification.User(request.Password, request.Email, request.FirstName, request.LastName);
                await userRepository.Create(user);
                response.Data = user.Id;

                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<long>();
                response.AddError(ex.Message);

                return response;
            }
        }
    }
}
