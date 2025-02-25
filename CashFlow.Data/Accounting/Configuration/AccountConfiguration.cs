using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Accounting;

namespace CashFlow.Data.Accounting.Configuration
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            var account = new Account("A001", "Folha de Pagamento", "");
            account.Id = 1;
            var account2 = new Account("A002", "Fornecedores", "");
            account2.Id = 2;
            var account3 = new Account("A002", "Projetos", "");
            account3.Id = 3;

            builder.HasData(account);
            builder.HasData(account2);
            builder.HasData(account3);
        }
    }
}
