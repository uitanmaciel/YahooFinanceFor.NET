using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Tools.Parsers;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TwoYears;

public class QuotationTwoYearsRequestHandle : BaseQuotationRequestHandle
{
	public QuotationTwoYearsRequestHandle() { }

	public string QuotationTwoYearsRequest(string ticker, [Optional] string frequency)
	{
        UnixDateTime _parser = new UnixDateTime();
        string start = _parser.ToDateUnix(DateTime.Now.AddYears(-2).Date);
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
