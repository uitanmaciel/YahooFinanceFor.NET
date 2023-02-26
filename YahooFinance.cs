using YahooFinanceFor.NET.Core.Application.Interfaces;
using YahooFinanceFor.NET.Core.Application.Interfaces.Services;
using YahooFinanceFor.NET.Core.Application.Services.Profile;
using YahooFinanceFor.NET.Core.Application.Services.Quotes;

namespace YahooFinanceFor.NET;

public class YahooFinance : IYahooFinance
{
    public IProfileService Profile => new ProfileService();
    public IQuotesService Quotes => new QuotesService();
}