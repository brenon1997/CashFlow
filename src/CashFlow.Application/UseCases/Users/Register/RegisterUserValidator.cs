using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Users.Register;
public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
{
    public RegisterUserValidator()
    {
        RuleFor(ex => ex.Name)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.NAME_EMPTY);

        RuleFor(ex => ex.Email)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.EMAIL_EMPTY);

        RuleFor(ex => ex.Password)
            .SetValidator(new PasswordValidator<RequestRegisterUserJson>());
    }
}
