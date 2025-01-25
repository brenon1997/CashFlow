using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Respositories.Expenses;
public interface IExpensesRepository
{
    Task Add(Expense expense);
}
