namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes;

public class BaseQuotationRequestHandle : BaseRequestHandle
{
    private readonly string _url_base = "https://query1.finance.yahoo.com/v7/finance/download/";
         
    protected string QuotationRequest(string query)
    {
        string content = Request(string.Concat(_url_base, query)).Result;
        return content;
    }
}
