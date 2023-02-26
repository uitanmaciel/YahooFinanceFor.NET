using YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;


namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile;

public class ProfileScrapingHandle
{
	public ProfileScrapingHandle() { }

	public ProfileDTO ScrapingProfile(string source)
	{        
        var _scraping = new ProfileDTO();
        var _profileScraped = _scraping.ProfileScraping(source);
        
        return _profileScraped;
    }
}
