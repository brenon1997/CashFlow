using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests;
public class RequestRegisterExpenseJsonBuilder
{
    public static RequestExpenseJson Build()
    {
        return new Faker<RequestExpenseJson>()
            .RuleFor(ex => ex.Title, faker => faker.Lorem.Sentence())
            .RuleFor(ex => ex.Description, faker => faker.Lorem.Paragraph())
            .RuleFor(ex => ex.Amount, faker => faker.Random.Decimal(min: 1, max: 1000))
            .RuleFor(ex => ex.Date, faker => faker.Date.Past())
            .RuleFor(ex => ex.PaymentType, faker => faker.PickRandom<PaymentType>());
    }
}
