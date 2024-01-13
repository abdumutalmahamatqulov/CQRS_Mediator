using CQRS_Mediator.Dto_s;
using CQRS_Mediator.Models.RegisterViewModel;
using FluentValidation;

namespace CQRS_Mediator.FluentValidation;

public class RegisterValidation : AbstractValidator<RegisterViewModel>
{
    public RegisterValidation()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required.")
            .MinimumLength(3).WithMessage("Username must be at least 3 characters.");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage( "Email is required.")
            .EmailAddress().WithMessage("Invalid email address.");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
    }
}
