using YahooFinanceFor.NET.Core.Application.Interfaces.Services;

namespace YahooFinanceFor.NET.Core.Application.Services.Profile;

public class ProfileService : IProfileService
{
    public dynamic GetProfile(string ticker)
    {
        var _stockProfile = new Domain.Aggregates.Stock.Profile.Profile();
        var _stock = _stockProfile.GetProfile(ticker);
        var _profile = Services.Models.Profile.ProfileApplicationModel.ToApplication(_stock);
        return _profile;
    }
}
