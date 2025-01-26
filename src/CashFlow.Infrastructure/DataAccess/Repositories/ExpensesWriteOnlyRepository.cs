using CashFlow.Domain.Entities;
using CashFlow.Domain.Respositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesWriteOnlyRepository : IExpensesWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesWriteOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task Add(Expense expense)
    {
        await _dbContext.Expenses.AddAsync(expense);
    }
}
