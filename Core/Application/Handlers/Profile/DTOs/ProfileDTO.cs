namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;

public class ProfileDTO
{
    public string CompanyName { get; set; }
    public AddressInfoProfileDTO AddressInfo { get; set; }
    public string Sector { get; set; }
    public string Industry { get; set; }
    public string NumberEmployee { get; set; }
    public List<KeyExecutiveProfileDTO> KeyExecutives { get; set; }
    public string Description { get; set; }
    public string Governance { get; set; }

    public ProfileDTO() { }

    public ProfileDTO(string companyName, AddressInfoProfileDTO addressInfoProfileScrapingDTOs, string sector, string numberEmployee, string industry, List<KeyExecutiveProfileDTO> keyExecutiveProfileScrapingDTOs,
                      string description, string governance)
    {
        CompanyName = companyName;
        AddressInfo = addressInfoProfileScrapingDTOs;
        Sector = sector;
        Industry = industry;
        NumberEmployee = numberEmployee;
        Industry = industry;
        KeyExecutives = keyExecutiveProfileScrapingDTOs;
        Description = description;
        Governance = governance;
    }

    public virtual ProfileDTO ProfileScraping(string source)
    {
        var _profileScraping = Scraping(source);
        return _profileScraping;
    }

    public virtual Domain.Aggregates.Stock.Profile.Profile ToDomain(ProfileDTO profileDTO)
    {
        var profile = ToProfileDomain(profileDTO); 
        return profile;
    }

    public static ProfileDTO Scraping(string source)
    {
        if (source is null || source == "")
            return new ProfileDTO();

        Tools.Scrapings.Profile.Scraping _scraping = new Tools.Scrapings.Profile.Scraping();
        var _companyName = _scraping.CompanyName(source);
        var _setorAndIndustryAndNumberEmployee = _scraping.IndustryAndSector(source);
        var _description = _scraping.Description(source);
        var _governance = _scraping.Governance(source);

        ProfileDTO _profileScrapingDTO = new ProfileDTO();
        _profileScrapingDTO.CompanyName = _companyName;
        _profileScrapingDTO.AddressInfo = AddressInfoProfileDTO.Scraping(source);
        _profileScrapingDTO.Sector = _setorAndIndustryAndNumberEmployee.sector;
        _profileScrapingDTO.Industry = _setorAndIndustryAndNumberEmployee.industry;
        _profileScrapingDTO.NumberEmployee = _setorAndIndustryAndNumberEmployee.numberEmployee;
        _profileScrapingDTO.KeyExecutives = KeyExecutiveProfileDTO.Scraping(source);
        _profileScrapingDTO.Description = _description;
        _profileScrapingDTO.Governance = _governance;

        return _profileScrapingDTO;
    }

    public static Domain.Aggregates.Stock.Profile.Profile ToProfileDomain(ProfileDTO profileDTO)
    {
        if (profileDTO is null)
            return new Domain.Aggregates.Stock.Profile.Profile();

        Domain.Aggregates.Stock.Profile.Profile _profile = new Domain.Aggregates.Stock.Profile.Profile(profileDTO.CompanyName, 
                                                                                                       AddressInfoProfileDTO.ToAddressInfoDomain(profileDTO.AddressInfo), 
                                                                                                       profileDTO.Sector, profileDTO.Industry, profileDTO.NumberEmployee, 
                                                                                                       KeyExecutiveProfileDTO.ToKeyExcutiveDomain(profileDTO.KeyExecutives),
                                                                                                       profileDTO.Description, profileDTO.Governance);
        return _profile;
    }
}
