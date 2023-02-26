namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile;

public class ProfileRequestHandle : BaseRequestHandle
{
    private readonly string _url_base = "https://finance.yahoo.com/quote";

    public ProfileRequestHandle() { }

    public string GetProfileHandle(string ticker)
    {        
        string _query = $"/{ticker}/profile?p={ticker}";
        string _source = Request(string.Concat(_url_base, _query)).Result;       

        if(_source != "404")
            return _source;

        return _source;
    }
}
