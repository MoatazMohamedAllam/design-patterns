using specification.Data;

namespace specification.Specification;

public class PostsForSpecificUserSpecification : Specification<Post>
{
    public PostsForSpecificUserSpecification(string userName): base(p => p.CreatedBy == userName)
    {
        AddInclue(x=>x.Comments);
    }
}