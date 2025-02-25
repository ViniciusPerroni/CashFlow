using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.Account.Edit
{
    public class UseCase : BaseUseCase<bool, Request, BaseResponse<bool>>, IUseCase
    {
        private readonly IAccountRepository accountRepository;

        public UseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        internal override async Task<BaseResponse<bool>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<bool>();
                response.Data = true;

                var account = await accountRepository.GetById(request.Id);
                if (account == null)
                {
                    response.AddError("Account não localizada para o Id informado.");
                    response.Data = false;
                    return response;
                }

                account.Edit(request.Name, request.Description);
                await accountRepository.Update(account);

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
