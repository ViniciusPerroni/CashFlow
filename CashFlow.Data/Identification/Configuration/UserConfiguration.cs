using CashFlow.Domain.Identification;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Data.Identification.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).ValueGeneratedOnAdd();

           var password = BCrypt.Net.BCrypt.HashPassword("senhaTeste");

            var user = new User(password, "usuario@teste.com", "Usuário", "Teste");
            user.Id = 1;

            builder.HasData(user);
        }
    }
}
