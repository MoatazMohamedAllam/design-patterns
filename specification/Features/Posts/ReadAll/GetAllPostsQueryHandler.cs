using MediatR;
using specification.Data;
using specification.Repository;

namespace specification.Features.Posts.ReadAll;

public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, List<Post>>
{
    private readonly IPostsRepository _postsRepository;
    
    public GetAllPostsQueryHandler(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }
    public async Task<List<Post>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
    {
        return await _postsRepository.GetAllPosts();
    }
}