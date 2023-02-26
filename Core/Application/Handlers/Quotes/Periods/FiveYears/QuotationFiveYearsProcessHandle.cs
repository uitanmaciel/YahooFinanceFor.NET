using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveYears;

public class QuotationFiveYearsProcessHandle : BaseQuotationProcessHandle
{
	public QuotationFiveYearsProcessHandle() { }

	public List<QuotationDTO> QuotationFiveYearsProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
