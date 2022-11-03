 using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess.Repository.Abstract
{
    public interface IRepository<TEntity> where TEntity : class, IEntity
    {
        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter, string? includeProperties = null );
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null, string? includeProperties = null);
        void Add(TEntity entity);
        void Delete(TEntity entity);
    }
}
