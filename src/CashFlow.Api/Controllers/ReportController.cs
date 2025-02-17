using CashFlow.Application.UseCases.Expenses.Reports.Excel;
using CashFlow.Application.UseCases.Expenses.Reports.Pdf;
using CashFlow.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace CashFlow.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = Roles.ADMIN)]
public class ReportController : ControllerBase
{
    [HttpGet("excel")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetExcel(
        [FromServices] IGenerateExpensesReportExcelUseCase _useCase,
        [FromQuery] DateOnly month)
    {
        byte[] file = await _useCase.Execute(month);

        if (file.Length > 0)
        {
            var fileName = $"ExpensesReport_{month:yyyyMM}.xlsx";

            return File(file, MediaTypeNames.Application.Octet, fileName);
        }

        return NoContent();
    }

    [HttpGet("pdf")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> GetPdf(
        [FromServices] IGenerateExpensesReportPdfUseCase _useCase,
        [FromQuery] DateOnly month)
    {
        byte[] file = await _useCase.Execute(month);

        if (file.Length > 0)
        {
            var fileName = $"ExpensesReport_{month:yyyyMM}.pdf";
            return File(file, MediaTypeNames.Application.Pdf, fileName);
        }

        return NoContent();
    }
}
