using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Services.LoggedUser;
using ClosedXML.Excel;
using System.Globalization;

namespace CashFlow.Application.UseCases.Expenses.Reports.Excel;
public class GenerateExpensesReportExcelUseCase : IGenerateExpensesReportExcelUseCase
{
    private IExpensesReadOnlyRepository _expensesReadOnlyRepository;
    private readonly ILoggedUser _loggedUser;
    public GenerateExpensesReportExcelUseCase(
        IExpensesReadOnlyRepository expensesReadOnlyRepository,
        ILoggedUser loggedUser)
    {
        _expensesReadOnlyRepository = expensesReadOnlyRepository;
        _loggedUser = loggedUser;
    }
    public async Task<byte[]> Execute(DateOnly month)
    {
        var loggedUser = await _loggedUser.Get();

        var expenses = await _expensesReadOnlyRepository.FilterByMonth(loggedUser, month);
        if (expenses.Count == 0)
            return [];

        return GenerateReport(loggedUser.Name, expenses, month);
    }

    private byte[] GenerateReport(string userName, IEnumerable<Expense> expenses, DateOnly month)
    {
        using var workbook = new XLWorkbook();
        workbook.Author = userName;
        workbook.Properties.Title = $"Expenses Report {month:Y}";

        var worksheet = workbook.Worksheets.Add($"{month:Y}");
        InsertHeader(worksheet);

        var row = 2;
        var currencySymbol = CultureInfo.CurrentCulture.NumberFormat.CurrencySymbol;
        foreach (var expense in expenses)
        {
            worksheet.Cell($"A{row}").Value = expense.Title;
            worksheet.Cell($"B{row}").Value = expense.Date;
            worksheet.Cell($"C{row}").Value = ConvertPaymentType(expense.PaymentType);
            worksheet.Cell($"D{row}").Value = $"{currencySymbol} {expense.Amount.ToString("N2", CultureInfo.CurrentCulture)}";
            worksheet.Cell($"E{row}").Value = expense.Description;
            row++;
        }

        worksheet.Columns("A:E").AdjustToContents();
        var file = new MemoryStream();
        workbook.SaveAs(file);

        return file.ToArray();
    }



    private void InsertHeader(IXLWorksheet worksheet)
    {
        worksheet.Cell("A1").Value = ResourceReportGenerationMessages.TITLE;
        worksheet.Cell("B1").Value = ResourceReportGenerationMessages.DATE;
        worksheet.Cell("C1").Value = ResourceReportGenerationMessages.PAYMENT_TYPE;
        worksheet.Cell("D1").Value = ResourceReportGenerationMessages.AMOUNT;
        worksheet.Cell("E1").Value = ResourceReportGenerationMessages.DESCRIPTION;

        worksheet.Cells("A1:E1").Style.Font.Bold = true;

        worksheet.Cells("A1:E1").Style.Fill.BackgroundColor = XLColor.FromHtml("#F5C2B6");

        worksheet.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        worksheet.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }

    private string ConvertPaymentType(PaymentType paymentType)
    {
        return paymentType switch
        {
            PaymentType.Cash => ResourceReportGenerationMessages.CASH,
            PaymentType.CreditCard => ResourceReportGenerationMessages.CREDIT_CARD,
            PaymentType.DebitCard => ResourceReportGenerationMessages.DEBIT_CARD,
            PaymentType.ElectronicTransfer => ResourceReportGenerationMessages.ELETRONIC_TRANSFER,
            _ => string.Empty
        };
    }
}
