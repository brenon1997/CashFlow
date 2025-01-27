using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Respositories.Expenses;
public interface IExpensesUpdateOnlyRepository
{
    void Update(Expense expense);
}
