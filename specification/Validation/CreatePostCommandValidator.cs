using FluentValidation;
using specification.Features.Posts.Create;

namespace specification.Validation;

public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
{
    public CreatePostCommandValidator()
    {
        RuleFor(x => x.Title).NotEmpty().WithMessage("title is required");
    }
}