using AutoMapper;
using CashFlow.Application.Identification.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.GetById
{
    public class UseCase : BaseUseCase<UserDto, Request, BaseResponse<UserDto>>, IUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UseCase(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        internal override async Task<BaseResponse<UserDto>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<UserDto>();
                var user = await userRepository.GetById(request.Id);

                if (user == null)
                {
                    response.AddError("Usuário não encontrado");
                    response.Data = null;
                    return response;
                }

                response.Data = mapper.Map<UserDto>(user);
                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<UserDto>();
                response.AddError(ex.Message);

                response.Data = null;
                return response;
            }
        }
    }
}
