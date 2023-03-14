using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class RepositoryBase<TEntity> where TEntity : EntityBase
    {
        private readonly ProjectContext _context;
        private readonly DbSet<TEntity> _entityContext;

        public RepositoryBase(ProjectContext context)
        {
            _context = context;
            _entityContext = context.Set<TEntity>();
        }
    }
}