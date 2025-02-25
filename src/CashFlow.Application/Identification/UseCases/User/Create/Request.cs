using CashFlow.Application.lib;
using System.Text.RegularExpressions;

namespace CashFlow.Application.Identification.UseCases.User.Create
{
    public class Request : BaseRequest
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            var regexEmail = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            if (!Regex.IsMatch(Email, regexEmail))
                Errors.Add("Parâmetro Email inválido.");

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
                Errors.Add("Parâmetro Password inválido.");

            if (string.IsNullOrEmpty(FirstName))
                Errors.Add("Parâmetro FirstName inválido.");

            if (string.IsNullOrEmpty(LastName))
                Errors.Add("Parâmetro LastName inválido.");
        }
    }
}