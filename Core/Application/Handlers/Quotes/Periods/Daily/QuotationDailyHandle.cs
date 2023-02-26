using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Daily;

public class QuotationDailyHandle
{
	public QuotationDailyHandle() { }

	public Quotation QuotationDaily(string ticker)
	{
		var _request = new QuotationDailyRequestHandle();
		var _content = _request.QuotationDailyRequest(ticker);

		var _dto = new QuotationDTO();
		var _process = new QuotationDailyProcessHandle();
		var _quotation = _dto.ToQuotationSingle(_process.QuotationDailyProcess(_content));

		return _quotation;
	}
}
