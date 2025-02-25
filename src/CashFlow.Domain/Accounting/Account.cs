using CashFlow.Domain.lib;

namespace CashFlow.Domain.Accounting
{
    public class Account(string code, string name, string description) : BaseEntity
    {
        public string Code { get; private set; } = code;
        public string Name { get; private set; } = name;
        public string Description { get; private set; } = description;

        public void Edit(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
