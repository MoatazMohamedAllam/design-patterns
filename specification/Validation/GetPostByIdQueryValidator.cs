using FluentValidation;
using specification.Features.Posts.Read;

namespace specification.Validation;

public class GetPostByIdQueryValidator : AbstractValidator<GetPostByIdQuery>
{
    public GetPostByIdQueryValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("id should be greater than Zero!");
    }
}