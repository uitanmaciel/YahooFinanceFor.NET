using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Monthly;

public class QuotationMonthlyProcessHandle : BaseQuotationProcessHandle
{
	public QuotationMonthlyProcessHandle() { }

	public List<QuotationDTO> QuotationMonthlyProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
