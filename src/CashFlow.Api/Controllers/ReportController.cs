using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExpensesReportExcelUseCase _useCase,
        [FromHeader] DateOnly month)
    {
        byte[] file = await _useCase.Execute(month);

        if (file.Length > 0)
        {
            var fileName = $"ExpensesReport_{month:yyyyMM}.xlsx";

            return File(file, MediaTypeNames.Application.Octet, fileName);
        }

        return NoContent();
    }
}
