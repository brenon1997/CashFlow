using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete;
public class DeleteExpenseUseCase : IDeleteExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _expensesReadOnlyRepository;
    private readonly IExpensesWriteOnlyRepository _expensesWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILoggedUser _loggedUser;
    public DeleteExpenseUseCase(
        IExpensesReadOnlyRepository expensesReadOnlyRepository,
        IExpensesWriteOnlyRepository expensesWriteOnlyRepository,
        IUnitOfWork unitOfWork,
        ILoggedUser loggedUser)
    {
        _expensesReadOnlyRepository = expensesReadOnlyRepository;
        _expensesWriteOnlyRepository = expensesWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _loggedUser = loggedUser;
    }

    public async Task Execute(long id)
    {
        var loggedUser = await _loggedUser.Get();

        var expense = await _expensesReadOnlyRepository.GetById(loggedUser, id);
        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        await _expensesWriteOnlyRepository.Delete(id);

        await _unitOfWork.Commit();
    }
}
