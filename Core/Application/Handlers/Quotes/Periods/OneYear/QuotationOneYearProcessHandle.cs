using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.OneYear;

public class QuotationOneYearProcessHandle : BaseQuotationProcessHandle
{
	public QuotationOneYearProcessHandle() { }

	public List<QuotationDTO> QuotationOneYearProcess(string content)
	{
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
