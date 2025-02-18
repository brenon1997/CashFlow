using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _expensesWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ILoggedUser _loggedUser;

    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository expensesWriteOnlyRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper,
        ILoggedUser loggedUser)
    {
        _expensesWriteOnlyRepository = expensesWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _loggedUser = loggedUser;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        var loggedUser = await _loggedUser.Get();

        var entityExpense = _mapper.Map<Expense>(request);
        entityExpense.UserId = loggedUser.Id;

        await _expensesWriteOnlyRepository.Add(entityExpense);

        await _unitOfWork.Commit();

        return _mapper.Map<ResponseRegisteredExpenseJson>(entityExpense);
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpenseValidator();

        var result = validator.Validate(request);

        if (result.IsValid is false)
        {
            var errorMessages = result.Errors.Select(r => r.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}
