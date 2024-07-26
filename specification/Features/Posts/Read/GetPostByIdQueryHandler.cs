using MediatR;
using Microsoft.EntityFrameworkCore;
using specification.Data;
using specification.Repository;
using specification.Specification;

namespace specification.Features.Posts.Read;

public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, Post>
{
    private readonly IPostsRepository _postsRepository;
    
    public GetPostByIdQueryHandler(IPostsRepository postsRepository)
    {
        _postsRepository = postsRepository;
    }

    public async Task<Post> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
    {
        var post = _postsRepository.GetPostBySpecification(new PostByIdSpecification(request.Id));
        return post;
    }
}