using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Tools.Parsers;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Historical;

public class QuotationHistoricalRequestHandle : BaseQuotationRequestHandle
{
	public QuotationHistoricalRequestHandle() { }

	public string QuotationHistoricalRequest(string ticker, [Optional] string frequency)
	{
        UnixDateTime _parser = new UnixDateTime();
        string start = _parser.ToDateUnix(Convert.ToDateTime("03/01/2000").Date);
        string end = _parser.ToDateUnix(DateTime.Now.Date);

        string query;

        switch (frequency)
        {
            case "Weekly":
                query = $"{ticker}?period1={start}&period2={end}&interval=1wk";
                break;
            case "Monthly":
                query = $"{ticker}?period1={start} &period2= {end}&interval=1mo";
                break;
            default:
                query = $"{ticker}?period1={start} &period2= {end}&interval=1d";
                break;
        }

        var content = QuotationRequest(query);
        return content;
    }
}
