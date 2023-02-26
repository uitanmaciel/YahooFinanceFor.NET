using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Daily;

public class QuotationDailyProcessHandle : BaseQuotationProcessHandle
{
    public List<QuotationDTO> QuotationDailyProcess(string content)
    {
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
