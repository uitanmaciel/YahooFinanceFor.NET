using YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile;

public class ProfileHandle
{
	ProfileRequestHandle _profileRequestHandle => new ProfileRequestHandle();
	ProfileScrapingHandle _profileScrapingHandle => new ProfileScrapingHandle();

	public ProfileHandle() { }

	public Domain.Aggregates.Stock.Profile.Profile GetProfile(string ticker)
	{
		var _request = _profileRequestHandle.GetProfileHandle(ticker);
		var _scraping = _profileScrapingHandle.ScrapingProfile(_request);

        var _profileDTO = new ProfileDTO();
        var _profile = _profileDTO.ToDomain(_scraping);

        return _profile;
    }
}
