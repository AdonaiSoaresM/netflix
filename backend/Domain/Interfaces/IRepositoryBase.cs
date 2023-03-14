using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : EntityBase
    {
        public void Create(TEntity entity);

        public void Update(TEntity entity);

        public IEnumerable<TEntity> List();

        public TEntity Find(Guid id);

        public void Delete(TEntity entity);

        public void Commit();
    }
}