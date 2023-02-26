using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveDays;

public class QuotationFiveDaysHandle
{
	public QuotationFiveDaysHandle() { }

    public List<Quotation> QuotationFiveDays(string ticker)
    {
        var _request = new QuotationFiveDaysRequestHandle();
        var _content = _request.QuotationFiveDaysRequest(ticker);

        var _dto = new QuotationDTO();
        var _process = new QuotationFiveDaysProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationFiveDaysProcess(_content));

        return _quotation;
    }
}
