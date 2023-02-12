using FluentValidation;
using todolist.Requests;

namespace todolist.Validators;

public class SignInValidator: AbstractValidator<SignInRequest>
{
    public SignInValidator()
    {
        RuleFor(u => u.Email).EmailAddress();
        RuleFor(u => u.Password).MinimumLength(8);
    }
}