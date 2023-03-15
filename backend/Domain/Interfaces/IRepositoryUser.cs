using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepositoryUser : IRepositoryBase<User>
    {
        public User FindByEmail(string email);
    }
}