using User = CashFlow.Application.Identification.UseCases.User;
using CashFlow.Crosscutting;
using CashFlow.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Moq;
using CashFlow.Application.lib;
using CashFlow.Application.Identification.Dtos;

namespace CashFlow.Tests.WebAPI.Controllers
{
    public class AuthControllerTests
    {
        private readonly Mock<User.GetByEmailAndPassword.IUseCase> mockGetByEmailAndPasswordUseCase;
        private readonly Mock<IAuthTokenService> mockAuthTokenService;
        private readonly Mock<IConfiguration> mockConfiguration;
        private readonly AuthController authController;

        public AuthControllerTests()
        {
            mockGetByEmailAndPasswordUseCase = new Mock<User.GetByEmailAndPassword.IUseCase>();
            mockAuthTokenService = new Mock<IAuthTokenService>();
            mockConfiguration = new Mock<IConfiguration>();

            mockConfiguration.Setup(config => config["AuthJwt:Key"]).Returns("test_secret_key");

            authController = new AuthController(
                mockGetByEmailAndPasswordUseCase.Object,
                mockAuthTokenService.Object,
                mockConfiguration.Object
            );
        }

        [Fact]
        public async Task Login_ReturnsUnauthorized_WhenResponseNotOk()
        {
            // Arrange
            var request = new User.GetByEmailAndPassword.Request { Email = "test@example.com", Password = "password" };
            var response = new BaseResponse<UserDto>();
            response.AddError("Usuário não localizado");
            mockGetByEmailAndPasswordUseCase.Setup(useCase => useCase.Execute(request)).ReturnsAsync(response);

            // Act
            var result = await authController.Login(request);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            Assert.Equal(response, unauthorizedResult.Value);
        }

        [Fact]
        public async Task Login_ReturnsOk_WithToken_WhenResponseOk()
        {
            // Arrange
            var request = new User.GetByEmailAndPassword.Request { Email = "test@example.com", Password = "password" };
            var userData = new UserDto
            {
                Id = 1,
                Email = "test@example.com"
            };
            var response = new BaseResponse<UserDto>{ Data = userData };
            var token = "generated_token";

            mockGetByEmailAndPasswordUseCase.Setup(useCase => useCase.Execute(request)).ReturnsAsync(response);
            mockAuthTokenService.Setup(service => service.GenerateToken(userData.Id.ToString(), userData.Email, "test_secret_key")).Returns(token);

            // Act
            var result = await authController.Login(request);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var resultValue = Assert.IsType<string>(okResult.Value);
            Assert.Equal(token, resultValue);
        }
    }
}
