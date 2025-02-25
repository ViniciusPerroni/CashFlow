using CashFlow.Application.lib;
using CashFlow.Domain.Accounting;

namespace CashFlow.Application.Accounting.UseCases.AccountingEntry.Create
{
    public class Request : BaseRequest
    {
        public EntryType Type { get; set; }
        public decimal Amount { get; set; }
        public DateTime EntryDate { get; set; }
        public string Description { get; set; }
        public long AccountCod { get; set; }
        public long CreationUserCod { get; set; }
        public DateTime CreationDate { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();
                
            if (!Enum.IsDefined(typeof(EntryType), Type))
                Errors.Add("Parâmetro Type inválido.");

            if (Amount <= 0)
                Errors.Add("Parâmetro Amount inválido.");

            if (EntryDate == DateTime.MinValue)
                Errors.Add("Parâmetro EntryDate inválido.");

            if (string.IsNullOrEmpty(Description))
                Errors.Add("Parâmetro Description inválido.");

            if (AccountCod <= 0)
                Errors.Add("Parâmetro AccountCod inválido.");

            if (CreationUserCod <= 0)
                Errors.Add("Parâmetro CreationUserCod inválido.");
        }
    }
}
