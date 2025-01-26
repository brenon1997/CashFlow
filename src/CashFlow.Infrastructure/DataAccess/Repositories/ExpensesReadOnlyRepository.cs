using CashFlow.Domain.Entities;
using CashFlow.Domain.Respositories.Expenses;
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
}
