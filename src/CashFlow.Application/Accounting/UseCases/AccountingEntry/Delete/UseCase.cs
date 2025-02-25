using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Delete
{
    public class UseCase : BaseUseCase<bool, Request, BaseResponse<bool>>, IUseCase
    {
        private readonly IAccountingEntryRepository accountingEntryRepository;

        public UseCase(IAccountingEntryRepository accountingEntryRepository)
        {
            this.accountingEntryRepository = accountingEntryRepository;
        }

        internal override async Task<BaseResponse<bool>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<bool>();
                response.Data = true;

                await accountingEntryRepository.Delete(request.Id);

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
