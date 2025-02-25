using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Delete
{
    public class Request : BaseRequest
    {
        public long Id { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            if (Id <= 0)
                Errors.Add("Parâmetro Id inválido.");
        }
    }
}
