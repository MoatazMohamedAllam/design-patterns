using System.Linq.Expressions;
using Microsoft.JSInterop.Implementation;

namespace specification.Specification;

public abstract class Specification<TEntity>
{
    public Specification()
    {
    }

    public Specification(Expression<Func<TEntity, bool>> creiteria)
    {
        Creiteria = creiteria;
    }
    
    public Expression<Func<TEntity, bool>> Creiteria { get; set; }
    public List<Expression<Func<TEntity, object>>> Includes = new List<Expression<Func<TEntity, object>>>();

    public void AddInclue(Expression<Func<TEntity, object>> expression)
    {
        Includes.Add(expression);
    }
}
