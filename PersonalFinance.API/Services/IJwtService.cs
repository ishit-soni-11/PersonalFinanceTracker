using PersonalFinanceTracker.Models.Entities;

namespace PersonalFinanceTracker.API.Services
{
    public interface IJwtService
    {
        string GenerateToken(User user);
    }
}