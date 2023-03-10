using YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Interfaces.Tools;

public interface IProfileScraping
{
    string CompanyName(string source);
    (string locate, string city, string state, string zipCode, string country, string url) AddressInfo(string source);
    (string sector, string industry, string numberEmployee) IndustryAndSector(string source);
    List<KeyExecutiveProfileDTO> KeyExecutives(string source);
    string Description(string source);
    string Governance(string source);
}
