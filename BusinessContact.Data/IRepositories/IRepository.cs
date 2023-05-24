using BusinessContact.Domain.Commons;
using System.Linq.Expressions;

namespace BusinessContact.Data.IRepositories
{
    public interface IRepository<TEntity> where TEntity : Auditable
    {
        Task<TEntity> InsertAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
        Task<bool> DeleteAsync(TEntity entity);
        Task SaveChangesAsync();
        IQueryable<TEntity> SelectAll(
            Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true);
        Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null);
    }
}
