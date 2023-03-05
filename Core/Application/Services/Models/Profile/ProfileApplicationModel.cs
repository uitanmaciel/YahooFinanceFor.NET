namespace YahooFinanceFor.NET.Core.Application.Services.Models.Profile;

public class ProfileApplicationModel
{
    public string CompanyName { get; set; }
    public AddressInfoApplicationModel AddressInfo { get; set; }
    public string Sector { get; set; }
    public string Industry { get; set; }
    public string NumberEmployee { get; set; }
    public List<KeyExecutiveApplicationModel> KeyExecutives { get; set; }
    public string Description { get; set; }
    public string Governance { get; set; }

    public ProfileApplicationModel() { }

    public ProfileApplicationModel(string companyName, 
                                   AddressInfoApplicationModel addresses, 
                                   string sector, 
                                   string industry, 
                                   string numberEmployee,
                                   List<KeyExecutiveApplicationModel> keyExecutives,
                                   string description,
                                   string governance)
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

    public virtual ProfileApplicationModel ToProfileApplication(Domain.Aggregates.Stock.Profile.Profile profile)
    {
        var _profile = ToApplication(profile);
        return _profile;
    }

    public virtual List<ProfileApplicationModel> ToProfileApplication(List<Domain.Aggregates.Stock.Profile.Profile> profiles)
    {
        var _profile = ToApplication(profiles);
        return _profile;
    }

    public virtual Domain.Aggregates.Stock.Profile.Profile ToProfile(ProfileApplicationModel profileApplicationModel)
    {
        var _profile = ToDomain(profileApplicationModel);
        return _profile;
    }

    public virtual List<Domain.Aggregates.Stock.Profile.Profile> ToProfile(List<ProfileApplicationModel> profileApplicationModel)
    {
        var _profile = ToDomain(profileApplicationModel);
        return _profile;
    }

    public static ProfileApplicationModel ToApplication(Domain.Aggregates.Stock.Profile.Profile profile)
    {
        if (profile is null)
            return new ProfileApplicationModel();

        ProfileApplicationModel _profileApplicationModel = new ProfileApplicationModel();
        _profileApplicationModel.CompanyName = profile.CompanyName;
        _profileApplicationModel.AddressInfo = AddressInfoApplicationModel.ToApplication(profile.AddressInfo);
        _profileApplicationModel.Sector = profile.Sector;
        _profileApplicationModel.Industry = profile.Industry;
        _profileApplicationModel.NumberEmployee = profile.NumberEmployee;
        _profileApplicationModel.KeyExecutives = KeyExecutiveApplicationModel.ToApplication(profile.KeyExecutives);
        _profileApplicationModel.Description = profile.Description;
        _profileApplicationModel.Governance = profile.Governance;

        return _profileApplicationModel;
    }

    public static List<ProfileApplicationModel> ToApplication(List<Domain.Aggregates.Stock.Profile.Profile> profileScrapingDTOs)
    {
        List<ProfileApplicationModel> _profileApplicationModelList = new List<ProfileApplicationModel>();

        if(profileScrapingDTOs.Count > 0)
        {
            foreach(var profile in profileScrapingDTOs) 
            {
                ProfileApplicationModel _profile = new ProfileApplicationModel();
                _profile.CompanyName = profile.CompanyName;
                _profile.AddressInfo = AddressInfoApplicationModel.ToApplication(profile.AddressInfo);
                _profile.Sector = profile.Sector;
                _profile.Industry = _profile.Industry;
                _profile.NumberEmployee = profile.NumberEmployee;
                _profile.KeyExecutives = KeyExecutiveApplicationModel.ToApplication(profile.KeyExecutives);
                _profile.Description = profile.Description;
                _profile.Governance = _profile.Governance;
            }
        }

        return _profileApplicationModelList;
    }

    public static Domain.Aggregates.Stock.Profile.Profile ToDomain(ProfileApplicationModel profileApplicationModel)
    {
        if (profileApplicationModel is null)
            return new Domain.Aggregates.Stock.Profile.Profile();

        Domain.Aggregates.Stock.Profile.Profile _profile = new Domain.Aggregates.Stock.Profile.Profile(profileApplicationModel.CompanyName, 
                                                                                                       AddressInfoApplicationModel.ToDomain(profileApplicationModel.AddressInfo),
                                                                                                       profileApplicationModel.Sector, profileApplicationModel.Industry,
                                                                                                       profileApplicationModel.NumberEmployee, 
                                                                                                       KeyExecutiveApplicationModel.ToDomain(profileApplicationModel.KeyExecutives),
                                                                                                       profileApplicationModel.Description, profileApplicationModel.Governance);

        return _profile;
    }

    public static List<Domain.Aggregates.Stock.Profile.Profile> ToDomain(List<ProfileApplicationModel> profileApplicationModels)
    {
        List<Domain.Aggregates.Stock.Profile.Profile> _profileList = new List<Domain.Aggregates.Stock.Profile.Profile>();

        if(profileApplicationModels != null)
        {
            foreach(var profile in profileApplicationModels)
            {
                Domain.Aggregates.Stock.Profile.Profile _profile = new Domain.Aggregates.Stock.Profile.Profile(profile.CompanyName,
                                                                                                               AddressInfoApplicationModel.ToDomain(profile.AddressInfo),
                                                                                                               profile.Sector, profile.Industry, profile.NumberEmployee,
                                                                                                               KeyExecutiveApplicationModel.ToDomain(profile.KeyExecutives),
                                                                                                               profile.Description, profile.Governance);
                _profileList.Add(_profile);
            }
        }

        return _profileList;
    }
}
