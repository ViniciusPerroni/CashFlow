using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Create
{
    public class UseCase : BaseUseCase<long, Request, BaseResponse<long>>, IUseCase
    {
        private readonly IAccountingEntryRepository accountingEntryRepository;

        public UseCase(IAccountingEntryRepository accountingEntryRepository)
        {
            this.accountingEntryRepository = accountingEntryRepository;
        }

        internal override async Task<BaseResponse<long>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<long>();

                var accountingEntry = new Domain.Accounting.AccountingEntry(request.Type, request.Amount, request.EntryDate, 
                    request.Description, request.AccountCod, request.CreationUserCod);

                await accountingEntryRepository.Create(accountingEntry);
                response.Data = accountingEntry.Id;

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
