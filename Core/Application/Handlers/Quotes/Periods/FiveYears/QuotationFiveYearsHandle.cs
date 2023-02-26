using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveYears;

public class QuotationFiveYearsHandle
{
	public QuotationFiveYearsHandle() { }

	public List<Quotation> QuotationFiveYears(string ticker, [Optional] string frequency)
	{
        var _request = new QuotationFiveYearsRequestHandle();
        var _content = _request.QuotationFiveYearsRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationFiveYearsProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationFiveYearsProcess(_content));

        return _quotation;
    }
}
