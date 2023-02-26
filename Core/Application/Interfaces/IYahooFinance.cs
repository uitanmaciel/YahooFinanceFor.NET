using YahooFinanceFor.NET.Core.Application.Interfaces.Services;

namespace YahooFinanceFor.NET.Core.Application.Interfaces;

public interface IYahooFinance
{
    public IProfileService Profile { get; }
    public IQuotesService Quotes { get; }
}
