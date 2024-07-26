using MediatR;
using specification.Data;

namespace specification.Features.Posts.Create;

public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, int>
{
    private readonly AppDataContext _context;
    
    public CreatePostCommandHandler(AppDataContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var post = new Post()
        {
            Title = request.Title,
            CreatedBy = request.CreatedBy,
            Comments = request.comments
        };
        await _context.Posts.AddAsync(post);
        await _context.SaveChangesAsync();

        return post.Id;
    }
}