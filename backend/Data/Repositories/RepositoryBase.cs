using Data.Context;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        protected readonly ProjectContext _context;
        protected readonly DbSet<TEntity> _entityContext;

        public RepositoryBase(ProjectContext context)
        {
            _context = context;
            _entityContext = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _entityContext.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _entityContext.Update(entity);
        }

        public IEnumerable<TEntity> List()
        {
            return _entityContext.AsEnumerable();
        }

        public TEntity Find(Guid id)
        {
            return _entityContext.Find(id);
        }

        public void Delete(TEntity entity)
        {
            _entityContext.Remove(entity);
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}