using AutoMapper;
using CashFlow.Application.Identification.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Identification.Repositories;

namespace CashFlow.Application.Identification.UseCases.User.List
{
    public class UseCase : BaseUseCase<IList<UserDto>, Request, BasePagedResponse<IList<UserDto>>>, IUseCase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UseCase(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        internal override async Task<BasePagedResponse<IList<UserDto>>> BussinesRole(Request request)
        {
            try
            {
                var response = new BasePagedResponse<IList<UserDto>>();
                var pagedResult = await userRepository.GetAll(request.Summary.PageNumber, request.Summary.PageSize);

                response.Data = pagedResult.Rows.Count > 0 ? mapper.Map<IList<UserDto>>(pagedResult.Rows) : new List<UserDto>();
                response.Summary = request.Summary;
                response.Summary.TotalRows = pagedResult.RowCount;
                
                return response;
            }
            catch (Exception ex)
            {
                var response = new BasePagedResponse<IList<UserDto>>();
                response.AddError(ex.Message);

                return response;
            }
        }
    }
}
