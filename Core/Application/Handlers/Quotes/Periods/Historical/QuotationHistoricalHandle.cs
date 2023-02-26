using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Historical;

public class QuotationHistoricalHandle
{
	public QuotationHistoricalHandle() { }

	public List<Quotation> QuotationHistorical(string ticker, [Optional] string frequency)
	{
        var _request = new QuotationHistoricalRequestHandle();
        var _content = _request.QuotationHistoricalRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationHistoricalProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationHistoricalProcess(_content));

        return _quotation;
    }
}
