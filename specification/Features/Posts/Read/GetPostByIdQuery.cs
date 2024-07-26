using MediatR;
using specification.Data;

namespace specification.Features.Posts.Read;

public class GetPostByIdQuery : IRequest<Post>
{
    public GetPostByIdQuery(int id)
    {
        Id = id;
    }
    public int Id { get; set; }
}