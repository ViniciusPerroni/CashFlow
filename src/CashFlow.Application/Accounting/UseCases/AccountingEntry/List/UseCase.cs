using AutoMapper;
using CashFlow.Application.Accounting.Dtos;
using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.List
{
    public class UseCase : BaseUseCase<IList<AccountingEntryDto>, Request, BasePagedResponse<IList<AccountingEntryDto>>>, IUseCase
    {
        private readonly IAccountingEntryRepository accountingEntryRepository;
        private readonly IMapper mapper;

        public UseCase(IAccountingEntryRepository accountingEntryRepository, IMapper mapper)
        {
            this.accountingEntryRepository = accountingEntryRepository;
            this.mapper = mapper;
        }

        internal override async Task<BasePagedResponse<IList<AccountingEntryDto>>> BussinesRole(Request request)
        {
            try
            {
                var response = new BasePagedResponse<IList<AccountingEntryDto>>();
                var pagedResult = await accountingEntryRepository.GetAll(request.Summary.PageNumber, request.Summary.PageSize);

                response.Data = pagedResult.Rows.Count > 0 ? mapper.Map<IList<AccountingEntryDto>>(pagedResult.Rows) : new List<AccountingEntryDto>();
                response.Summary = request.Summary;
                response.Summary.TotalRows = pagedResult.RowCount;
                
                return response;
            }
            catch (Exception ex)
            {
                var response = new BasePagedResponse<IList<AccountingEntryDto>>();
                response.AddError(ex.Message);

                return response;
            }
        }
    }
}
