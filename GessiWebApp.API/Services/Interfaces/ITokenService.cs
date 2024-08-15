using Shared.Models;

namespace API.Interfaces
{
    public interface ITokenService
    {
        string GenerateJwtToken(User user);
        bool ValidateToken(string token);
        int? GetUserIdFromToken(string token);
    }
}