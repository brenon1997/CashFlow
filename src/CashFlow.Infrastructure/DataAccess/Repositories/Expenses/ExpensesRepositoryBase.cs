using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Expenses;
internal abstract class ExpensesRepositoryBase
{
    protected readonly CashFlowDbContext _dbContext;

    protected ExpensesRepositoryBase(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected IIncludableQueryable<Expense, ICollection<Tag>> GetFullExpense()
    {
        return _dbContext.Expenses.Include(expense => expense.Tags);
    }
}
