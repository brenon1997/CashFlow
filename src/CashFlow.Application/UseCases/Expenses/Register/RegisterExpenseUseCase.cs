using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Respositories;
using CashFlow.Domain.Respositories.Expenses;
using CashFlow.Exception.ExceptionBase;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register;
public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _expensesWriteOnlyRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegisterExpenseUseCase(
        IExpensesWriteOnlyRepository expensesWriteOnlyRepository, 
        IUnitOfWork unitOfWork,
        IMapper mapper)
    {
        _expensesWriteOnlyRepository = expensesWriteOnlyRepository;
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
        Validate(request);

        var entityExpense = _mapper.Map<Expense>(request);

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
