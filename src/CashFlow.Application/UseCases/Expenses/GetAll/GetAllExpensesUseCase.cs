﻿using AutoMapper;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Respositories.Expenses;

namespace CashFlow.Application.UseCases.Expenses.GetAll;
public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
    private IExpensesRepository _expensesRepository;
    private readonly IMapper _mapper;
    public GetAllExpensesUseCase(
        IExpensesRepository expensesRepository,
        IMapper mapper)
    {
        _expensesRepository = expensesRepository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesJson> Execute()
    {
        var expenses = await _expensesRepository.GetAll();
        return new ResponseExpensesJson
        {
            Expenses = _mapper.Map<List<ResponseShortExpenseJson>>(expenses)
        };
    }
}
