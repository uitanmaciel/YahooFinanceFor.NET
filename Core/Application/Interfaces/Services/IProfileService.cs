using YahooFinanceFor.NET.Core.Application.Services.Models.Profile;

namespace YahooFinanceFor.NET.Core.Application.Interfaces.Services;

public interface IProfileService
{
    dynamic GetProfile(string ticker);
}
