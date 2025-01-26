using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Respositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.GetById;
public class GetExpenseByIdUseCase : IGetExpenseByIdUseCase
{
    private IExpensesReadOnlyRepository _expensesReadOnlyRepository;
    private readonly IMapper _mapper;
    public GetExpenseByIdUseCase(
        IExpensesReadOnlyRepository expensesReadOnlyRepository,
        IMapper mapper)
    {
        _expensesReadOnlyRepository = expensesReadOnlyRepository;
        _mapper = mapper;
    }
    public async Task<ResponseExpenseJson> Execute(long id)
    {
        var expense = await _expensesReadOnlyRepository.GetById(id);

        if (expense is null)
        {
            throw new NotFoundException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
        }

        return _mapper.Map<ResponseExpenseJson>(expense);
    }
}
