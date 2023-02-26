using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Custom;

public class QuotationCustomHandle
{
	public QuotationCustomHandle() { }

	public List<Quotation> QuotationCustom(string ticker, DateTime start, DateTime end, [Optional] string frequency)
	{
		var _request = new QuotationCustomRequestHandle();
		var _content = _request.QuotationCustomRequest(ticker, start, end, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationCustomProcessHandle();		
		var _quotation = _dto.ToQuotation(_process.QuotationCustomProcess(_content));

		return _quotation;
	}
}
