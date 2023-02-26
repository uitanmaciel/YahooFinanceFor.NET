using YahooFinanceFor.NET.Core.Application.Handlers.Profile;

namespace YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Profile;

public class Profile
{
    public string CompanyName { get; private set; }
    public AddressInfo AddressInfo { get; private set; }
    public string Sector { get; private set; }
    public string Industry { get; private set; }
    public decimal NumberEmployee { get; private set; }
    public List<KeyExecutive> KeyExecutives { get; private set; }
    public string Description { get; private set; }
    public string Governance { get; private set; }

    public Profile() { }

    public Profile(string companyName, AddressInfo addresses, string sector, string industry, decimal numberEmployee, List<KeyExecutive> keyExecutives, 
                   string description, string governance)
    {
        CompanyName = companyName;
        AddressInfo = addresses;
        Sector = sector;
        Industry = industry;
        NumberEmployee = numberEmployee;
        KeyExecutives = keyExecutives;
        Description = description;
        Governance = governance;
    }

    public Profile GetProfile(string ticker)
    {
        if(string.IsNullOrEmpty(ticker)) 
            return null;

        var _getProfile = new ProfileHandle();
        var _profile = _getProfile.GetProfile(ticker);

        return _profile;
    }
}
