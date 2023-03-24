using Data.Context;
using Domain.Entities;
using Domain.Interfaces;

namespace Data.Repositories
{
    public class RepositoryMovie : RepositoryBase<Movie>, IRepositoryMovie
    {
        public RepositoryMovie(ProjectContext context) : base(context)
        {
        }
    }
}