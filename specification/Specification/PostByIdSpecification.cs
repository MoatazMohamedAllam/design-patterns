using specification.Data;

namespace specification.Specification;

public class PostByIdSpecification : Specification<Post>
{
    public PostByIdSpecification(int id): base(x=>x.Id == id)
    {
        AddInclue(x=>x.Comments);
    }
}