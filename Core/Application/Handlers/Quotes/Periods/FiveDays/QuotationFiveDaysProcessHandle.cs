using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveDays;

public class QuotationFiveDaysProcessHandle : BaseQuotationProcessHandle
{
	public QuotationFiveDaysProcessHandle() { }

    public List<QuotationDTO> QuotationFiveDaysProcess(string content)
    {
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
