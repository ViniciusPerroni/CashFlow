using CashFlow.Application.lib;

namespace CashFlow.Application.Accounting.UseCases.Account.Create
{
    public class Request : BaseRequest
    {
        public string Code { get;set; }
        public string Name { get; set; }
        public string Description { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            if (string.IsNullOrEmpty(Code) || string.IsNullOrEmpty(Code) || Code.Length != 6)
                Errors.Add("Parâmetro Code inválido.");

            if (string.IsNullOrEmpty(Name) || string.IsNullOrEmpty(Name) || Name.Length < 6 || Name.Length < 20)
                Errors.Add("Parâmetro Name inválido.");
        }
    }
}
