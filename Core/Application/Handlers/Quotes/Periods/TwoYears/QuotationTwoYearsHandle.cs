using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TwoYears;

public class QuotationTwoYearsHandle
{
	public QuotationTwoYearsHandle() { }

	public List<Quotation> QuotationTwoYears(string ticker, [Optional] string frequency)
	{
        var _request = new QuotationTwoYearsRequestHandle();
        var _content = _request.QuotationTwoYearsRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationTwoYearsProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationTwoYearsProcess(_content));

        return _quotation;
    }
}
