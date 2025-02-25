using AutoMapper;
using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.GetById
{
    public class UseCase : BaseUseCase<AccountingEntryDto, Request, BaseResponse<AccountingEntryDto>>, IUseCase
    {
        private readonly IAccountingEntryRepository accountingEntryRepository;
        private readonly IMapper mapper;

        public UseCase(IAccountingEntryRepository accountingEntryRepository, IMapper mapper)
        {
            this.accountingEntryRepository = accountingEntryRepository;
            this.mapper = mapper;
        }

        internal override async Task<BaseResponse<AccountingEntryDto>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<AccountingEntryDto>();
                var account = await accountingEntryRepository.GetById(request.Id);

                if (account == null)
                {
                    response.AddError("Lançamento não encontrado");
                    response.Data = null;
                    return response;
                }

                response.Data = mapper.Map<AccountingEntryDto>(account);
                return response;
            }
            catch (Exception ex)
            {
                var response = new BaseResponse<AccountingEntryDto>();
                response.AddError(ex.Message);

                response.Data = null;
                return response;
            }
        }
    }
}
