using CashFlow.Crosscutting;
using Microsoft.AspNetCore.Mvc;
using User = CashFlow.Application.Identification.UseCases.User;

namespace CashFlow.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly User.GetByEmailAndPassword.IUseCase getByEmailAndPasswordUseCase;
        private readonly IAuthTokenService authTokenService;
        private readonly IConfiguration configuration;

        public AuthController(User.GetByEmailAndPassword.IUseCase getByEmailAndPasswordUseCase, 
            IAuthTokenService authTokenService, IConfiguration configuration)
        {
            this.getByEmailAndPasswordUseCase = getByEmailAndPasswordUseCase;
            this.authTokenService = authTokenService;
            this.configuration = configuration;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User.GetByEmailAndPassword.Request request)
        {
            var response = await getByEmailAndPasswordUseCase.Execute(request);

            if (!response.Ok)
                return Unauthorized(response);

            var userCode = response.Data.Id.ToString();
            var userEmail = response.Data.Email;
            var secretKey = configuration["AuthJwt:Key"];

            var token = authTokenService.GenerateToken(userCode, userEmail, secretKey);

            return Ok(token);
        }
    }
}
