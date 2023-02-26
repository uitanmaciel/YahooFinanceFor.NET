using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;
using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Monthly;

public class QuotationMonthlyHandle
{
	public QuotationMonthlyHandle() { }

    public List<Quotation> QuotationMonthly(string ticker, [Optional] string frequency)
    {
        var _request = new QuotationMonthlyRequestHandle();
        var _content = _request.QuotationMonthlyRequest(ticker, frequency);

        var _dto = new QuotationDTO();
        var _process = new QuotationMonthlyProcessHandle();
        var _quotation = _dto.ToQuotation(_process.QuotationMonthlyProcess(_content));

        return _quotation;
    }
}
