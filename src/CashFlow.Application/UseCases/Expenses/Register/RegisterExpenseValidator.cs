using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpenseJson>
{
    public RegisterExpenseValidator()
    {
        RuleFor(ex => ex.Title)
            .NotEmpty()
            .WithMessage("The title is required.");

        RuleFor(ex => ex.Amount)
            .GreaterThan(0)
            .WithMessage("The amount must be greater than zero.");

        RuleFor(ex => ex.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage("The expense date must be less than or equal to the current date.");

        RuleFor(ex => ex.PaymentType)
            .IsInEnum()
            .WithMessage("The payment type is invalid.");
    }
}
