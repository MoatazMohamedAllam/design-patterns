using MediatR;
using specification.Data;

namespace specification.Features.Posts.ReadAll;

public record GetAllPostsQuery : IRequest<List<Post>>;
