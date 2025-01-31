using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories;
internal class ExpensesReadOnlyRepository : IExpensesReadOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesReadOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Expense>> GetAll()
    {
        return await _dbContext.Expenses.AsNoTracking().ToListAsync();
    }

    public async Task<Expense?> GetById(long id)
    {
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }

    public async Task<List<Expense>> FilterByMonth(DateOnly date)
    {
        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(e => e.Date.Year == date.Year && e.Date.Month == date.Month)
            .OrderBy(e => e.Date)
            .OrderBy(e => e.Title)
            .ToListAsync();
    }
}
