using YahooFinanceFor.NET.Tools.Scrapings.Profile;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;

public class AddressInfoProfileDTO
{
    public string Address { get; set; }
    public string Complement { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Url { get; set; }

    public AddressInfoProfileDTO() { }

    public AddressInfoProfileDTO(string address, string complement, string state, string zipCode, string country, string url)
    {
        Address = address;
        Complement = complement;
        State = state;
        ZipCode = zipCode;
        Country = country;
        Url = url;
    }

    public virtual AddressInfoProfileDTO ToAddressInfoProfileDTO(string source)
    {
        var _address = Scraping(source);
        return _address;
    }

    public virtual Domain.Aggregates.Stock.Profile.AddressInfo ToDomain(AddressInfoProfileDTO addressInfoProfileDTO)
    {
        var _addressInfo = ToAddressInfoDomain(addressInfoProfileDTO);
        return _addressInfo;
    }

    public static AddressInfoProfileDTO Scraping(string source)
    {
        if (source is null)
            return new AddressInfoProfileDTO();

        Scraping _Scraping = new Scraping();
        var address = _Scraping.AddressInfo(source);

        AddressInfoProfileDTO _addressInfoProfile = new AddressInfoProfileDTO();
        _addressInfoProfile.Address = address[0];
        _addressInfoProfile.Complement = address[1];
        _addressInfoProfile.State = address[2];
        _addressInfoProfile.ZipCode = address[3];
        _addressInfoProfile.Country = address[4];
        _addressInfoProfile.Url = address[5];

        return _addressInfoProfile;
    }

    public static Domain.Aggregates.Stock.Profile.AddressInfo ToAddressInfoDomain(AddressInfoProfileDTO addressInfoProfileDTO)
    {
        if (addressInfoProfileDTO is null)
            return new Domain.Aggregates.Stock.Profile.AddressInfo();

        Domain.Aggregates.Stock.Profile.AddressInfo _addressInfo = new Domain.Aggregates.Stock.Profile.AddressInfo(addressInfoProfileDTO.Address,
                                                                                                                   addressInfoProfileDTO.Complement,
                                                                                                                   addressInfoProfileDTO.State,
                                                                                                                   addressInfoProfileDTO.ZipCode,
                                                                                                                   addressInfoProfileDTO.Country,
                                                                                                                   addressInfoProfileDTO.Url);
        return _addressInfo;
    }
}
