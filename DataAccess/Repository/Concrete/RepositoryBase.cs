using DataAccess.Repository.Abstract;
using Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DataAccess.Repository.Concrete
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly AppDbContext _db;
        internal DbSet<TEntity> _dbSet;
        public RepositoryBase(AppDbContext db)
        {
            _db = db; 
            _dbSet = _db.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>>filter = null, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
                query = query.Where(filter);
            query = AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(query, includeProperties);

            return query.ToList();
        }

        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> filter, string? includeProperties = null)
        {
            IQueryable<TEntity> query = _dbSet;
            query = query.Where(filter);
            query = AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(query, includeProperties);

            return query.FirstOrDefault();
        }

        static IQueryable<TEntity> AddIncludeOperationToQueryIfIncludePropertiesIsNotNull(IQueryable<TEntity> query, string? includeProperties)
        {
            if (includeProperties != null)
            {
                foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                    query = query.Include(prop);
            }
            return query;
        }
    }
}
