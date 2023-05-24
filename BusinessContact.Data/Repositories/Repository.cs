using BusinessContact.Data.Contexts;
using BusinessContact.Data.IRepositories;
using BusinessContact.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BusinessContact.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }

        public Task<bool> DeleteAsync(TEntity entity)
        {
            var existEntity = await this.dbSet.FirstOrDefaultAsync(t => t.Id.Equals(entity.Id));
            if (existEntity is null) return false;
            return true;
        }

        public Task<TEntity> InsertAsync(TEntity entity)
            => (await this.dbSet.AddAsync(entity)).Entity;

        public Task SaveChangesAsync()
            => await this.dbContext.SaveChangesAsync();

        public IQueryable<TEntity> SelectAll(Expression<Func<TEntity, bool>> expression = null, string[] includes = null, bool isTracking = true)
        {
            IQueryable<TEntity> query = expression is null ? dbSet : dbSet.Where(expression);
            if (includes is not null)
                foreach (var include in includes)
                    query = query.Include(include);

            if (!isTracking)
                query = query.AsNoTracking();

            return query;
        }

        public Task<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression, string[] includes = null)
            => await this.SelectAll(expression, includes).FirstOrDefaultAsync();


        public Task<TEntity> UpdateAsync(TEntity entity)
            => (this.dbSet.Update(entity)).Entity;
    }
}
