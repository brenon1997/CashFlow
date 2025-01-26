using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Respositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private IExpensesRepository _expensesRepository;
    private readonly IMapper _mapper;
    public GetExpenseByIdUseCase(
        IExpensesRepository expensesRepository,
        IMapper mapper)
    {
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var expense = await _expensesRepository.GetById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseExpenseJson>(expense);
    }
}
