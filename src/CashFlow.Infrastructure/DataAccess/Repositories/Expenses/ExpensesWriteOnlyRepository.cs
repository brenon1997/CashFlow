using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Expenses;
internal class ExpensesWriteOnlyRepository : ExpensesRepositoryBase, IExpensesWriteOnlyRepository
{
    public ExpensesWriteOnlyRepository(CashFlowDbContext dbContext) : base(dbContext) { }

    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }

    public async Task Delete(long id)
    {
        var expense = await _dbContext.Expenses.FirstAsync(e => e.Id == id);

        _dbContext.Expenses.Remove(expense);
    }
}
