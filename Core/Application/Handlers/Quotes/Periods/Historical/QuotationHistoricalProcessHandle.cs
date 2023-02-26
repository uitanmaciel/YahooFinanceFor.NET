using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Historical;

public class QuotationHistoricalProcessHandle : BaseQuotationProcessHandle
{
	public QuotationHistoricalProcessHandle() { }

	public List<QuotationDTO> QuotationHistoricalProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
