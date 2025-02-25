using AutoMapper;
using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.Account.GetById
{
    public class UseCase : BaseUseCase<AccountDto, Request, BaseResponse<AccountDto>>, IUseCase
    {
        private readonly IAccountRepository accountRepository;
        private readonly IMapper mapper;

        public UseCase(IAccountRepository accountRepository, IMapper mapper)
        {
            this.accountRepository = accountRepository;
            this.mapper = mapper;
        }

        internal override async Task<BaseResponse<AccountDto>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<AccountDto>();
                var account = await accountRepository.GetById(request.Id);

                if (account == null)
                {
                    response.AddError("Conta não encontrada");
                    response.Data = null;
                    return response;
                }

                response.Data = mapper.Map<AccountDto>(account);
                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<AccountDto>();
                response.AddError(ex.Message);

                response.Data = null;
                return response;
            }
        }
    }
}
