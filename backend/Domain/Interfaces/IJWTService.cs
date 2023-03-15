using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IJWTService
    {
        public string GenerateToken(User user);
    }
}