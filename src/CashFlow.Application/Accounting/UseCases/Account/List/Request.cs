using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.List
{
    public class Request : BasePagedRequest
    {
        internal override void Validate()
        {
            Errors = new List<string>();

            if (Summary == null)
                Errors.Add("Parâmetro Summary inválido.");
            else if(Summary.PageNumber == 0)
                Errors.Add("Parâmetro Summary.PageNumber inválido.");
            else if (Summary.PageSize == 0)
                Errors.Add("Parâmetro Summary.PageSize inválido.");
        }
    }
}
