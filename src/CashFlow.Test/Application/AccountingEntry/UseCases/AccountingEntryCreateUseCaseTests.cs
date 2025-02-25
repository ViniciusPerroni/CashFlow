using CashFlow.Application.Accounting.UseCases.AccountingEntry.Create;
using CashFlow.Domain.Accounting.Repositories;
using Moq;

namespace CashFlow.Tests.Application.Accounting.UseCases.AccountingEntry
{
    public class AccountingEntryCreateUseCaseTests
    {
        private readonly Mock<IAccountingEntryRepository> mockAccountingEntryRepository;
        private readonly UseCase createUseCase;

        public AccountingEntryCreateUseCaseTests()
        {
            mockAccountingEntryRepository = new Mock<IAccountingEntryRepository>();
            createUseCase = new UseCase(mockAccountingEntryRepository.Object);
        }

        [Fact]
        public async Task Execute_ReturnsResponseWithId_WhenCreationIsSuccessful()
        {
            // Arrange
            var request = new Request
            {
                Type = Domain.Accounting.EntryType.Credit,
                Amount = 100.0m,
                EntryDate = DateTime.Now,
                Description = "Test Entry",
                AccountCod = 1,
                CreationUserCod = 2
            };

            var accountingEntry = new Domain.Accounting.AccountingEntry(
                request.Type, request.Amount, request.EntryDate, request.Description, request.AccountCod, request.CreationUserCod
            );

            mockAccountingEntryRepository.Setup(repo => repo.Create(It.IsAny<Domain.Accounting.AccountingEntry>()))
                .Callback<Domain.Accounting.AccountingEntry>(entry => entry.Id = 1)
                .Returns(Task.CompletedTask);

            // Act
            var response = await createUseCase.Execute(request);

            // Assert
            Assert.True(response.Ok);
            Assert.Equal(1, response.Data);
        }

        [Fact]
        public async Task Execute_ReturnsResponseWithError_WhenExceptionIsThrown()
        {
            // Arrange
            var request = new Request
            {
                Type = Domain.Accounting.EntryType.Credit,
                Amount = 100.0m,
                EntryDate = DateTime.Now,
                Description = "Test Entry",
                AccountCod = 1,
                CreationUserCod = 2
            };

            mockAccountingEntryRepository.Setup(repo => repo.Create(It.IsAny<Domain.Accounting.AccountingEntry>()))
                .ThrowsAsync(new Exception("Exception"));

            // Act
            var response = await createUseCase.Execute(request);

            // Assert
            Assert.False(response.Ok);
            Assert.Contains("Exception", response.Errors);
        }

        [Fact]
        public async Task Execute_ReturnsValidationErrors_WhenRequestIsInvalid()
        {
            // Arrange
            var request = new Request
            {
                Type = (Domain.Accounting.EntryType)999,
                Amount = -100.0m,
                EntryDate = DateTime.MinValue,
                Description = "",
                AccountCod = 0,
                CreationUserCod = 0
            };

            // Act
            var response = await createUseCase.Execute(request);

            // Assert
            Assert.False(response.Ok);
            Assert.Contains("Parâmetro Type inválido.", response.Errors);
            Assert.Contains("Parâmetro Amount inválido.", response.Errors);
            Assert.Contains("Parâmetro EntryDate inválido.", response.Errors);
            Assert.Contains("Parâmetro Description inválido.", response.Errors);
            Assert.Contains("Parâmetro AccountCod inválido.", response.Errors);
            Assert.Contains("Parâmetro CreationUserCod inválido.", response.Errors);
        }
    }
}
