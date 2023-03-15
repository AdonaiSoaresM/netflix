using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(ProjectContext context) : base(context)
        {
        }

        public User FindByEmail(string email)
        {
            return _entityContext.AsNoTracking().FirstOrDefault(user => user.Email == email);
        }
    }
}