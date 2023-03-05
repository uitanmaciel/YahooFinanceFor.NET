namespace YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Profile;

public class AddressInfo
{
    public string Address { get; set; }    
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }
    public string Country { get; set; }
    public string Url { get; set; }

    public AddressInfo() { }

    public AddressInfo(string address, string city, string state, string zipCode, string country, string url)
    {
        Address = address;       
        City = city;
        State = state;
        ZipCode = zipCode;
        Country = country;
        Url = url;
    }
}
