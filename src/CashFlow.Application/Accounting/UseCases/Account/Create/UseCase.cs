using CashFlow.Application.lib;
using CashFlow.Domain.Accounting.Repositories;

namespace CashFlow.Application.Accounting.UseCases.Account.Create
{
    public class UseCase : BaseUseCase<long, Request, BaseResponse<long>>, IUseCase
    {
        private readonly IAccountRepository accountRepository;

        public UseCase(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        internal override async Task<BaseResponse<long>> BussinesRole(Request request)
        {
            try
            {
                var response = new BaseResponse<long>();

                var codeExist = await accountRepository.GetByCode(request.Code) != null;
                if (codeExist)
                {
                    response.Errors.Add("Parâmetro Code já utilizado");
                    return response;
                }

                var account = new Domain.Accounting.Account(request.Code, request.Name, request.Description);
                await accountRepository.Create(account);
                response.Data = account.Id;

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
