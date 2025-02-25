using CashFlow.Application.lib;

namespace CashFlow.Application.Identification.UseCases.User.Edit
{
    public class Request : BaseRequest
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            if(Id <= 0)
                Errors.Add("Parâmetro Id inválido.");

            if (string.IsNullOrEmpty(FirstName) || string.IsNullOrEmpty(FirstName))
                Errors.Add("Parâmetro FirstName inválido.");

            if (string.IsNullOrEmpty(LastName) || string.IsNullOrEmpty(LastName))
                Errors.Add("Parâmetro LastName inválido.");
        }
    }
}
