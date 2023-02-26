using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Tools.Parsers;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Custom;

public class QuotationCustomRequestHandle : BaseQuotationRequestHandle
{
	public QuotationCustomRequestHandle()	{ }

	public string QuotationCustomRequest(string ticker, DateTime start, DateTime end, [Optional] string frequency)
	{
        UnixDateTime _parser = new UnixDateTime();        
        string period1 = _parser.ToDateUnix(start);
		string period2 = _parser.ToDateUnix(end);

        string query;

        switch (frequency)
		{
			case "Weekly":
                query = $"{ticker}?period1={period1}&period2={period2}&interval=1wk";
                break;
			case "Monthly":
                query = $"{ticker}?period1={period1}&period2={period2}&interval=1mo";
                break;
			default:
                query = $"{ticker}?period1={period1}&period2={period2}&interval=1d";
                break;
        }
        
        var content = QuotationRequest(query);
		return content;
    }
}
