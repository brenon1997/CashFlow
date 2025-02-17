using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Expenses;
internal class ExpensesReadOnlyRepository : IExpensesReadOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public ExpensesReadOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Expense>> GetAll(User user)
    {
        return await _dbContext.Expenses.AsNoTracking().Where(e => e.UserId == user.Id).ToListAsync();
    }

    public async Task<Expense?> GetById(User user, long id)
    {
        return await _dbContext.Expenses.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
    }

    public async Task<List<Expense>> FilterByMonth(User user, DateOnly date)
    {
        return await _dbContext
            .Expenses
            .AsNoTracking()
            .Where(e => e.Date.Year == date.Year && e.Date.Month == date.Month && e.UserId == user.Id)
            .OrderBy(e => e.Date)
            .OrderBy(e => e.Title)
            .ToListAsync();
    }
}
