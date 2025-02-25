using AutoMapper;
using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.Account.List
{
    public class UseCase : BaseUseCase<IList<AccountDto>, Request, BasePagedResponse<IList<AccountDto>>>, IUseCase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public UseCase(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        internal override async Task<BasePagedResponse<IList<AccountDto>>> BussinesRole(Request request)
        {
            try
            {
                var response = new BasePagedResponse<IList<AccountDto>>();
                var pagedResult = await accountRepository.GetAll(request.Summary.PageNumber, request.Summary.PageSize);

                response.Data = pagedResult.Rows.Count > 0 ? mapper.Map<IList<AccountDto>>(pagedResult.Rows) : new List<AccountDto>();
                response.Summary = request.Summary;
                response.Summary.TotalRows = pagedResult.RowCount;
                
                return response;
            }
            catch (Exception ex)
            {
                var response = new BasePagedResponse<IList<AccountDto>>();
                response.AddError(ex.Message);

                return response;
            }
        }
    }
}
