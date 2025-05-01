using System.Linq.Expressions;

namespace Elasticsearch.API.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll(bool tracking = true);
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T?> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);
        Task<T?> GetByIdAsync(string id, bool tracking = true);      
    }
}
