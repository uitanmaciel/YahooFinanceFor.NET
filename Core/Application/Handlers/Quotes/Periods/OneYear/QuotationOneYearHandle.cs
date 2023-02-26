using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.OneYear;

public class QuotationOneYearHandle
{
	public QuotationOneYearHandle() { }

	public List<Quotation> QuotationOneYear(string ticker, [Optional] string frequency)
	{
        var _request = new QuotationOneYearRequestHandle();
        var _content = _request.QuotationOneYearRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationOneYearProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationOneYearProcess(_content));

        return _quotation;
    }
}
