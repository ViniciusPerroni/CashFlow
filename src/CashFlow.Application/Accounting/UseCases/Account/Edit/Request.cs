using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.Edit
{
    public class Request : BaseRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            if(Id <= 0)
                Errors.Add("Parâmetro Id inválido.");

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Name) || Name.Length < 6)
                Errors.Add("Parâmetro Name inválido.");
        }
    }
}
