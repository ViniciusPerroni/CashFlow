namespace CashFlow.Crosscutting
{
    public interface IAuthTokenService
    {
        string GenerateToken(string userEmail, string userCode, string secretKey);
    }
}