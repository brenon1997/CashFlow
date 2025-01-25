namespace CashFlow.Domain.Respositories;
public interface IUnitOfWork
{
    Task Commit();
}
