using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Profile;

namespace YahooFinanceFor.NET.Core.Application.Services.Models.Profile;

public class AddressInfoApplicationModel
{
    public string Address { get; set; }    
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Url { get; set; }

    public AddressInfoApplicationModel() { }

    public AddressInfoApplicationModel(string address, string city, string state, string zipCode, string country, string url)
    {
        Address = address;        
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
        Url = url;
    }

    public virtual AddressInfoApplicationModel ToAddressInfoApplication(AddressInfo addressInfo)
    {
        var _address = ToApplication(addressInfo);
        return _address;
    }

    public virtual List<AddressInfoApplicationModel> ToAddressInfoApplication(List<AddressInfo> addressInfos)
    {
        var _address = ToApplication(addressInfos);
        return _address;
    }

    public virtual AddressInfo ToAddressInfo(AddressInfoApplicationModel addressInfoApplicationModel)
    {
        var _addressInfo = ToDomain(addressInfoApplicationModel);
        return _addressInfo;
    }

    public virtual List<AddressInfo> ToAddressInfo(List<AddressInfoApplicationModel> addressInfoApplicationModel)
    {
        var _addressInfo = ToDomain(addressInfoApplicationModel);
        return _addressInfo;
    }

    public static AddressInfoApplicationModel ToApplication(AddressInfo addressInfo)
    {
        if (addressInfo is null)
            return new AddressInfoApplicationModel();

        AddressInfoApplicationModel _address = new AddressInfoApplicationModel();
        _address.Address = addressInfo.Address;       
        _address.City = addressInfo.City;
        _address.ZipCode = addressInfo.ZipCode;
        _address.Country = addressInfo.Country;
        _address.Url = addressInfo.Url;

        return _address;
    }

    public static List<AddressInfoApplicationModel> ToApplication(List<AddressInfo> addressInfos)
    {
        List<AddressInfoApplicationModel> _addressList = new List<AddressInfoApplicationModel>();

        if (addressInfos != null)
        {
            foreach (var address in addressInfos)
            {
                AddressInfoApplicationModel _address = new AddressInfoApplicationModel();
                _address.Address = address.Address;                
                _address.City = address.City;
                _address.State = address.State;
                _address.ZipCode = address.ZipCode;
                _address.Country = address.Country;
                _address.Url = address.Url;
                _addressList.Add(_address);
            }
        }

        return _addressList;
    }

    public static AddressInfo ToDomain(AddressInfoApplicationModel addressInfoApplication)
    {
        if(addressInfoApplication is null)
            return new AddressInfo();

        AddressInfo _addressInfo = new AddressInfo(addressInfoApplication.Address, addressInfoApplication.City, addressInfoApplication.State,
                                                   addressInfoApplication.ZipCode, addressInfoApplication.Country, addressInfoApplication.Url);

        return _addressInfo;
    }

    public static List<AddressInfo> ToDomain(List<AddressInfoApplicationModel> addressInfoApplicationModels)
    {
        List<AddressInfo> _addressList = new List<AddressInfo>();

        if(addressInfoApplicationModels != null)
        {
            foreach(var address in addressInfoApplicationModels) 
            {
                AddressInfo _addressInfo = new AddressInfo(address.Address, address.City, address.State, address.ZipCode, address.Country, address.Url);
                _addressList.Add(_addressInfo);
            }
        }

        return _addressList;
    }
}
