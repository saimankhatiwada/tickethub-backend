using FluentValidation;
using TicketHub.Domain.Users;

namespace TicketHub.Application.Users.RegisterUser;

internal sealed class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(c => c.FirstName)
            .NotEmpty()
            .WithMessage("Firstname cannot be empty.");

        RuleFor(c => c.LastName)
            .NotEmpty()
            .WithMessage("Lastname cannot be empty.");

        RuleFor(c => c.Email)
            .EmailAddress()
            .WithMessage("Email is invalid.");

        RuleFor(c => c.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty.")
            .Matches(@"^(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$")
            .WithMessage("Password must contain at least one uppercase letter, one digit, one special character, and be at least 8 characters long.");
        
        RuleFor(c => c.MobileNumber)
            .NotEmpty()
            .WithMessage("Mobile number cannot be empty.")
            .Matches(@"^\+977[9][6-9]\d{8}$")
            .WithMessage("Mobile number must be in format +9779[6-9]XXXXXXXX (10 digits after +977)")
            .Length(14)
            .WithMessage("Mobile number must be exactly 14 characters long including +977");
        
        RuleFor(c => c.Role)
            .NotEmpty()
            .WithMessage("Role cannot be empty.")
            .Must(CheckRoleExist)
            .WithMessage("Role is invalid.");

        RuleFor(c => c.IsTermsAndConditions)
            .Must(isTermAndCondition => isTermAndCondition || !isTermAndCondition)
            .WithMessage("Terms and condition can either be true  or false.");
    }

    public static bool CheckRoleExist(string value)
    {
        return !string.IsNullOrWhiteSpace(Role.CheckRole(value).Name);
    }
}
