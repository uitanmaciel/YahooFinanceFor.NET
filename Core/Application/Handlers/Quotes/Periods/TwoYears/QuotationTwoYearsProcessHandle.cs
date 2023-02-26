using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TwoYears;

public class QuotationTwoYearsProcessHandle : BaseQuotationProcessHandle
{
	public QuotationTwoYearsProcessHandle() { }

	public List<QuotationDTO> QuotationTwoYearsProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
