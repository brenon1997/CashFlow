using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace Validators.Test.Expenses.Register;
public class RegisterExpenseValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arrange
        var request = new RequestRegisterExpenseJson
        {
            Title = "Test",
            Description = "Test",
            Amount = 10,
            Date = DateTime.Now,
            PaymentType = PaymentType.Cash
        };
        var validator = new RegisterExpenseValidator();

        // Act
        var result = validator.Validate(request);

        // Assert
        Assert.True(result.IsValid);
    }
}
