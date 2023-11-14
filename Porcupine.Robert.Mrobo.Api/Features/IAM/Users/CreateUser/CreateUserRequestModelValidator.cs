using FluentValidation;

namespace Porcupine.Robert.Mrobo.Api.Features.IAM.Users.CreateUser;

/// <inheritdoc />
public class CreateUserRequestModelValidator : AbstractValidator<CreateUserRequestModel>
{
    /// <inheritdoc />
    public CreateUserRequestModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .MinimumLength(3);
        
        RuleFor(x => x.ProfileImage)
            .Must(x => Uri.IsWellFormedUriString(x, UriKind.Absolute))
            .When(x => !string.IsNullOrWhiteSpace(x.ProfileImage));
    }
}