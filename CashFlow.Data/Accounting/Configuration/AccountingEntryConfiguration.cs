using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using CashFlow.Domain.Accounting;

namespace CashFlow.Data.Accounting.Configuration
{
    public class AccountingEntryConfiguration : IEntityTypeConfiguration<AccountingEntry>
    {
        public void Configure(EntityTypeBuilder<AccountingEntry> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

            builder.Property(e => e.Amount)
                  .HasColumnType("decimal(18,2)");

            var accountingEntry = new AccountingEntry(EntryType.Credit, 100, new DateTime(2025, 2, 24), "Teste", 1, 1);
            accountingEntry.Id = 1;
            var accountingEntry2 = new AccountingEntry(EntryType.Debit, 100, new DateTime(2025, 2, 24), "Teste", 1, 1);
            accountingEntry2.Id = 2;
            var accountingEntry3 = new AccountingEntry(EntryType.Credit, 100, new DateTime(2025, 2, 24), "Teste", 1, 1);
            accountingEntry3.Id = 3;
            var accountingEntry4 = new AccountingEntry(EntryType.Debit, 100, new DateTime(2025, 2, 24), "Teste", 1, 1);
            accountingEntry4.Id = 4;
            var accountingEntry5 = new AccountingEntry(EntryType.Credit, 100, new DateTime(2025, 2, 24), "Teste", 1, 1);
            accountingEntry5.Id = 5;

            builder.HasData(accountingEntry);
            builder.HasData(accountingEntry2);
            builder.HasData(accountingEntry3);
            builder.HasData(accountingEntry4);
            builder.HasData(accountingEntry5);
        }
    }
}
