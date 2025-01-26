using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Respositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
    private IExpensesReadOnlyRepository _expensesReadOnlyRepository;
    private readonly IMapper _mapper;
    public GetAllExpensesUseCase(
        IExpensesReadOnlyRepository expensesReadOnlyRepository,
        IMapper mapper)
    {
        _expensesReadOnlyRepository = expensesReadOnlyRepository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesJson> Execute()
    {
        var expenses = await _expensesReadOnlyRepository.GetAll();
        return new ResponseExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(expenses)
        };
    }
}
