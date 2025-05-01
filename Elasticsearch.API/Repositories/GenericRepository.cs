using System.Linq.Expressions;
using Elasticsearch.API.Context;
using Elasticsearch.API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Elasticsearch.API.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public Task<T?> GetByIdAsync(string id, bool tracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query.FirstOrDefaultAsync(entity => EF.Property<string>(entity, "Id") == id);
        }

        public Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = _dbSet.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return query.Where(method);
        }
    }
}
