using CashFlow.Application.lib;

namespace CashFlow.Application.Identification.UseCases.User.GetById
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
