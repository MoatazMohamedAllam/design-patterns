using specification.Data;
using specification.Specification;
namespace specification.Repository;

public interface IPostsRepository
{
    public Task<List<Post>> GetAllPosts();
    public List<Post> GetAllBySpecification(Specification<Post> spec);
    public Post GetPostBySpecification(Specification<Post> spec);

}