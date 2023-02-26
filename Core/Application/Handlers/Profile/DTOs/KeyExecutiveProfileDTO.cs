using YahooFinanceFor.NET.Tools.Scrapings.Profile;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;

public class KeyExecutiveProfileDTO
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Pay { get; set; }
    public string Execised { get; set; }
    public string YearBorn { get; set; }

    public KeyExecutiveProfileDTO() { }

    public KeyExecutiveProfileDTO(string name, string title, string pay, string execised, string yearBorn)
    {
        Name = name;
        Title = title;
        Pay = pay;
        Execised = execised;
        YearBorn = yearBorn;
    }

    public virtual List<Domain.Aggregates.Stock.Profile.KeyExecutive> ToDomain(List<KeyExecutiveProfileDTO> keyExecutiveProfileDTOs)
    {
        var _keyExecutive = ToKeyExcutiveDomain(keyExecutiveProfileDTOs);
        return _keyExecutive;
    }


    public static List<KeyExecutiveProfileDTO> Scraping(string source)
    {
        List<KeyExecutiveProfileDTO> _keyExecutiveList = new List<KeyExecutiveProfileDTO>();

        if (source != null)
        {
            Scraping _Scraping = new Scraping();
            var _keyExecutiveScraping = _Scraping.KeyExecutives(source);

            foreach (var keyExecutive in _keyExecutiveScraping)
            {
                KeyExecutiveProfileDTO _keyExecutive = new KeyExecutiveProfileDTO();
                _keyExecutive.Name = keyExecutive.Name;
                _keyExecutive.Title = keyExecutive.Title;
                _keyExecutive.Pay = keyExecutive.Pay;
                _keyExecutive.Execised = keyExecutive.Execised;
                _keyExecutive.YearBorn = keyExecutive.YearBorn;
                _keyExecutiveList.Add(_keyExecutive);
            }
        }

        return _keyExecutiveList;
    }

    public static List<Domain.Aggregates.Stock.Profile.KeyExecutive> ToKeyExcutiveDomain(List<KeyExecutiveProfileDTO> keyExecutiveProfileDTOs)
    {
        List<Domain.Aggregates.Stock.Profile.KeyExecutive> _keyExecutiveList = new List<Domain.Aggregates.Stock.Profile.KeyExecutive>();

        if(keyExecutiveProfileDTOs != null)
        {
            foreach(var keyexecutive in keyExecutiveProfileDTOs) 
            {
                Domain.Aggregates.Stock.Profile.KeyExecutive _keyExecutive = new Domain.Aggregates.Stock.Profile.KeyExecutive(keyexecutive.Name, keyexecutive.Title,
                                                                                                                              keyexecutive.Pay, keyexecutive.Execised,
                                                                                                                              keyexecutive.YearBorn);
                _keyExecutiveList.Add(_keyExecutive);
            }
        }

        return _keyExecutiveList;
    }
}
