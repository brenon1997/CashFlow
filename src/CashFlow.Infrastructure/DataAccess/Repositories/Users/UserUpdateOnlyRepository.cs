using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess.Repositories.Users;
internal class UserUpdateOnlyRepository : IUserUpdateOnlyRepository
{
    private readonly CashFlowDbContext _dbContext;
    public UserUpdateOnlyRepository(CashFlowDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<User> GetById(long id)
    {
        return await _dbContext.Users.FirstAsync(user => user.Id == id);
    }
    public void Update(User user)
    {
        _dbContext.Users.Update(user);
    }
}
