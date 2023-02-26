using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Custom;

public class QuotationCustomProcessHandle : BaseQuotationProcessHandle
{
	public QuotationCustomProcessHandle() { }

	public List<QuotationDTO> QuotationCustomProcess(string content)
	{        
        var _quotation = QuotationProcess(content);
        return _quotation;
    }
}
