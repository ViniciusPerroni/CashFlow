using CashFlow.Data;
using CashFlow.Data.Identification.Repositories;
using CashFlow.Domain.Identification;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Test.Repositories
{
    public class UserRepositoryTests
    {
        private readonly UserRepository repository;
        private readonly CashFlowDbContext dbContext;

        public UserRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<CashFlowDbContext>()
                .UseInMemoryDatabase(databaseName: "CashFlowTestDb")
                .Options;

            dbContext = new CashFlowDbContext(options);
            repository = new UserRepository(dbContext);
        }

        [Fact]
        public async Task Create_AddsNewUser()
        {
            // Arrange
            var user = new User("password", "email", "firstName", "lastName");

            // Act
            await repository.Create(user);

            // Assert
            var createdUser = await repository.GetById(user.Id);
            Assert.NotNull(createdUser);
            Assert.Equal(user.Email, createdUser.Email);
            Assert.Equal(user.Password, createdUser.Password);
            Assert.Equal(user.FirstName, createdUser.FirstName);
            Assert.Equal(user.LastName, createdUser.LastName);
        }

        [Fact]
        public async Task GetById_ReturnsUserById()
        {
            // Arrange
            var user = new User("password", "email", "firstName", "lastName");
            await repository.Create(user);

            // Act
            var retrievedUser = await repository.GetById(user.Id);

            // Assert
            Assert.NotNull(retrievedUser);
            Assert.Equal(user.Email, retrievedUser.Email);
            Assert.Equal(user.Password, retrievedUser.Password);
            Assert.Equal(user.FirstName, retrievedUser.FirstName);
            Assert.Equal(user.LastName, retrievedUser.LastName);
        }

        [Fact]
        public async Task Update_ModifiesExistingUser()
        {
            // Arrange
            var user = new User("password", "email", "firstName", "lastName");
            await repository.Create(user);

            // Act
            user.Edit("firstName2", "lastName2");
            repository.Update(user);

            // Assert
            var updatedUser = await repository.GetById(user.Id);
            Assert.NotNull(updatedUser);
            Assert.Equal("firstName2", updatedUser.FirstName);
            Assert.Equal("lastName2", updatedUser.LastName);
        }

        [Fact]
        public async Task Delete_RemovesUser()
        {
            // Arrange
            var user = new User("password", "email", "firstName", "lastName");
            await repository.Create(user);

            // Act
            await repository.Delete(user.Id);

            // Assert
            var deletedUser = await repository.GetById(user.Id);
            Assert.Null(deletedUser);
        }
    }
}
