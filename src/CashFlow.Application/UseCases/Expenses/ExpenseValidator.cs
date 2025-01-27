using CashFlow.Communication.Requests;
using CashFlow.Exception;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses;
public class ExpenseValidator : AbstractValidator<RequestExpenseJson>
{
    public ExpenseValidator()
    {
        RuleFor(ex => ex.Title)
            .NotEmpty()
            .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);

        RuleFor(ex => ex.Amount)
            .GreaterThan(0)
            .WithMessage(ResourceErrorMessages.AMOUNT_MUST_BE_GREATER_THAN_ZERO);

        RuleFor(ex => ex.Date)
            .LessThanOrEqualTo(DateTime.UtcNow)
            .WithMessage(ResourceErrorMessages.EXPANSIVE_DATE_CANNOT_FOR_THE_FUTURE);

        RuleFor(ex => ex.PaymentType)
            .IsInEnum()
            .WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}
