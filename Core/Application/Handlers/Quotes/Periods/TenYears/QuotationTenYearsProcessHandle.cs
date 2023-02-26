using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TenYears;

public class QuotationTenYearsProcessHandle : BaseQuotationProcessHandle
{
	public QuotationTenYearsProcessHandle() { }

	public List<QuotationDTO> QuotationTenYearsProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
