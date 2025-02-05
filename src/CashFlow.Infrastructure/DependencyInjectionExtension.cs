using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Cryptography;
using CashFlow.Infrastructure.DataAccess;
using CashFlow.Infrastructure.DataAccess.Repositories.Expenses;
using CashFlow.Infrastructure.DataAccess.Repositories.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CashFlow.Infrastructure;
public static class DependencyInjectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext(configuration);
        services.AddRepositories();

        services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
    }

    private static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesReadOnlyRepository>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesWriteOnlyRepository>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesUpdateOnlyRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserReadOnlyRepository>();
    }

    private static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("Connection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 40));

        services.AddDbContext<CashFlowDbContext>(config => config.UseMySql(connectionString, serverVersion));
    }
}
