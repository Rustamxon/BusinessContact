using BusinessContact.Domain.Commons;
using BusinessContact.Domain.Configurations;
using BusinessContact.Service.Exceptions;

namespace BusinessContact.Service.Extensions
{
    public static class CollectionExtension
    {
        public static IQueryable<TEntity> ToPagedList<TEntity>(this IQueryable<TEntity> entities, PaginationParams @params)
        where TEntity : Auditable
        {
            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                entities.OrderBy(e => e.Id)
                    .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                        throw new CustomException(400, "Please, enter valid numbers");
        }
        public static IEnumerable<TEntity> ToPagedList<TEntity>(this IEnumerable<TEntity> entities, PaginationParams @params)
            where TEntity : Auditable
        {
            return @params.PageIndex > 0 && @params.PageSize > 0 ?
                entities.OrderBy(e => e.Id)
                    .Skip((@params.PageIndex - 1) * @params.PageSize).Take(@params.PageSize) :
                        throw new CustomException(400, "Please, enter valid numbers");
        }
    }
}
