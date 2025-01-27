using CashFlow.Domain.Entities;
using CashFlow.Domain.Respositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesUpdateOnlyRepository : IExpensesUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesUpdateOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Expense?> GetById(long id)
    {
        return await _dbContext.Expenses.FirstOrDefaultAsync(e => e.Id == id);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
