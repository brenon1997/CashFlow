using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Respositories.Expenses;
public interface IExpensesWriteOnlyRepository
{
    Task Add(Expense expense);
}
