using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class RepositoryUser : RepositoryBase<User>, IRepositoryUser
    {
        public RepositoryUser(ProjectContext context) : base(context)
        {
        }
    }
}