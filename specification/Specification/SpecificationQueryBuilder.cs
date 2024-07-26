namespace specification.Specification;
using Microsoft.EntityFrameworkCore;

public static class SpecificationQueryBuilder
{
    public static IQueryable<TEntity> GetQuery<TEntity>(IQueryable<TEntity> inputQuery, Specification<TEntity> spec)
    where TEntity : class
    {
        var query = inputQuery;
        if (spec.Creiteria != null)
        {
            query = query.Where(spec.Creiteria);
        }

        if (spec.Includes.Count != 0)
        {
            query = spec.Includes
                .Aggregate(query, (current, include) => 
                    current.Include(include));
        }

        return query;
    }
}