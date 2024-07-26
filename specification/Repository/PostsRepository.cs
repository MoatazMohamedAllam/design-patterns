using Microsoft.EntityFrameworkCore;
using specification.Data;
using specification.Specification;

namespace specification.Repository;

public class PostsRepository : IPostsRepository
{
    private readonly AppDataContext _context;

    public PostsRepository(AppDataContext context)
    {
        _context = context;
    }

    public async Task<List<Post>> GetAllPosts()
    {
        return await _context.Posts.Include(x=>x.Comments).ToListAsync();
    }


    public List<Post> GetAllBySpecification(Specification<Post> spec)
    {
        var result = SpecificationQueryBuilder.GetQuery(_context.Posts, spec);
        return result.ToList();
    }

    public Post GetPostBySpecification(Specification<Post> spec)
    {
        var post = SpecificationQueryBuilder.GetQuery(_context.Posts, spec).FirstOrDefault();
        return post;
    }
}