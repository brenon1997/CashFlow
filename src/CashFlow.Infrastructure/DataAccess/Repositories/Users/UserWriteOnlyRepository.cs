using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Users;
internal class UserWriteOnlyRepository : IUserWriteOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public UserWriteOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(User user)
    {
        await _dbContext.Users.AddAsync(user);
    }

    public async Task Delete(User user)
    {
        var userToRemove = await _dbContext.Users.FindAsync(user.Id);
        _dbContext.Users.Remove(userToRemove!);
    }
}
