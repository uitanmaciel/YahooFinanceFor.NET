namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Daily;

public class QuotationDailyRequestHandle : BaseQuotationRequestHandle
{
	public QuotationDailyRequestHandle() { }

	public string QuotationDailyRequest(string ticker)
	{
        string query = $"{ticker}";
        var content = QuotationRequest(query);
        return content;
    }
}
