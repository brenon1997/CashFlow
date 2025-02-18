using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Expenses;
internal class ExpensesUpdateOnlyRepository : ExpensesRepositoryBase, IExpensesUpdateOnlyRepository
{
    public ExpensesUpdateOnlyRepository(CashFlowDbContext dbContext) : base(dbContext) { }

    public async Task<Expense?> GetById(User user, long id)
    {
        return await GetFullExpense()
            .FirstOrDefaultAsync(e => e.Id == id && e.UserId == user.Id);
    }

    public void Update(Expense expense)
    {
        _dbContext.Expenses.Update(expense);
    }
}
