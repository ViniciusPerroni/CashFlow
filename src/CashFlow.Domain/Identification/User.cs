using CashFlow.Domain.lib;

namespace CashFlow.Domain.Identification
{
    public class User(string password, string email, string firstName, string lastName) : BaseEntity
    {
        public string Password { get; private set; } = password;
        public string Email { get; private set; } = email;
        public string FirstName { get; private set; } = firstName;
        public string LastName { get; private set; } = lastName;

        public void Edit(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
