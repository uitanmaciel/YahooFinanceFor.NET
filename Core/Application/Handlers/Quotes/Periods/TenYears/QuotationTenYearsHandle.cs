using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TenYears;

public class QuotationTenYearsHandle
{
	public QuotationTenYearsHandle() { }

	public List<Quotation> QuotationTenYears(string ticker, [Optional] string frequency)
	{
        var _request = new QuotationTenYearsRequestHandle();
        var _content = _request.QuotationTenYearsRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationTenYearsProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationTenYearsProcess(_content));

        return _quotation;
    }
}
