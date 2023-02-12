using FluentValidation;
using todolist.Requests;

namespace todolist.Validators;

public class SignUpValidator: AbstractValidator<SignUpRequest>
{
    public SignUpValidator()
    {
        RuleFor(u => u.Name).NotNull();
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password).MinimumLength(8);

    }
}