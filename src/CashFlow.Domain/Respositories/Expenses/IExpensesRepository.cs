using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Respositories.Expenses;
public interface IExpensesRepository
{
    void Add(Expense expense);
}
