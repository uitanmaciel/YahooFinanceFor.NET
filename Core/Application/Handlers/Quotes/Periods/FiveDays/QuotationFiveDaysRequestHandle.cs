using YahooFinanceFor.NET.Tools.Parsers;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveDays;

public class QuotationFiveDaysRequestHandle : BaseQuotationRequestHandle
{
	public QuotationFiveDaysRequestHandle() { }

    public string QuotationFiveDaysRequest(string ticker)
    {
        UnixDateTime _parser = new UnixDateTime();
        string start = _parser.ToDateUnix(DateTime.Now.AddDays(-5).Date);
        string end = _parser.ToDateUnix(DateTime.Now.Date);

        string query = $"{ticker}?period1={start}&period2={end}&interval=1d";

        var content = QuotationRequest(query);
        return content;
    }
}
