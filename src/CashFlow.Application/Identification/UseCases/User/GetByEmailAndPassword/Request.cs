using CashFlow.Application.lib;
using System.Text.RegularExpressions;

namespace CashFlow.Application.Identification.UseCases.User.GetByEmailAndPassword
{
    public class Request : BaseRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }

        internal override void Validate()
        {
            Errors = new List<string>();

            var regexEmail = @"^[^\s@]+@[^\s@]+\.[^\s@]+$";
            if (!Regex.IsMatch(Email, regexEmail))
                Errors.Add("Parâmetro Email inválido.");

            if (string.IsNullOrEmpty(Password) || Password.Length < 6)
                Errors.Add("Parâmetro Password inválido.");
        }
    }
}
