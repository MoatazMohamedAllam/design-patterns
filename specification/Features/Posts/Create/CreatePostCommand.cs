using MediatR;
using specification.Data;

namespace specification.Features.Posts.Create;

public record CreatePostCommand(string Title,string CreatedBy, List<Comment> comments) : IRequest<int>;
