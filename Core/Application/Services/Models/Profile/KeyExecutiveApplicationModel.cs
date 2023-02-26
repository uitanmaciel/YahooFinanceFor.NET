using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Profile;

namespace YahooFinanceFor.NET.Core.Application.Services.Models.Profile;

public class KeyExecutiveApplicationModel
{
    public string Name { get; set; }
    public string Title { get; set; }
    public string Pay { get; set; }
    public string Exercised { get; set; }
    public string YearBorn { get; set; }

    public KeyExecutiveApplicationModel() { }

    public KeyExecutiveApplicationModel(string name,string title, string pay, string exercised, string yearBorn)
    {
        Name = name;
        Title = title;
        Pay = pay;
        Exercised = exercised;
        YearBorn = yearBorn;
    }

    public virtual KeyExecutiveApplicationModel ToKeyExecutiveApplication(KeyExecutive keyExecutive)
    {
        var _keyExecutive = ToApplication(keyExecutive);
        return _keyExecutive;
    }

    public virtual List<KeyExecutiveApplicationModel> ToKeyExecutiveApplication(List<KeyExecutive> keyExecutives)
    {
        var _keyExecutives = ToApplication(keyExecutives);
        return _keyExecutives;
    }

    public virtual KeyExecutive ToKeyExecutive(KeyExecutiveApplicationModel keyExecutiveApplicationModel)
    {
        var _keyExecutive = ToDomain(keyExecutiveApplicationModel);
        return _keyExecutive;
    }

    public virtual List<KeyExecutive> ToKeyExecutive(List<KeyExecutiveApplicationModel> keyExecutiveApplicationModel)
    {
        var _keyExecutive = ToDomain(keyExecutiveApplicationModel);
        return _keyExecutive;
    }

    public static KeyExecutiveApplicationModel ToApplication(KeyExecutive keyExecutive)
    {
        if (keyExecutive is null)
            return new KeyExecutiveApplicationModel();

        KeyExecutiveApplicationModel _keyExecutive = new KeyExecutiveApplicationModel();
        _keyExecutive.Name = keyExecutive.Name;
        _keyExecutive.Title = keyExecutive.Title;
        _keyExecutive.Pay = keyExecutive.Pay;
        _keyExecutive.Exercised = keyExecutive.Exercised;
        _keyExecutive.YearBorn = keyExecutive.YearBorn;

        return _keyExecutive;
    }

    public static List<KeyExecutiveApplicationModel> ToApplication(List<KeyExecutive> keyExecutives)
    {
        List<KeyExecutiveApplicationModel> _keyExecutivesList = new List<KeyExecutiveApplicationModel>();
        if(keyExecutives != null)
        {
            foreach(var keyExecutive in keyExecutives) 
            {
                KeyExecutiveApplicationModel _keyExecutive = new KeyExecutiveApplicationModel();
                _keyExecutive.Name = keyExecutive.Name;
                _keyExecutive.Title = keyExecutive.Title;
                _keyExecutive.Pay = keyExecutive.Pay;
                _keyExecutive.Exercised = keyExecutive.Exercised;
                _keyExecutive.YearBorn = keyExecutive.YearBorn;
                _keyExecutivesList.Add(_keyExecutive);
            }
        }
        return _keyExecutivesList;
    }

    public static KeyExecutive ToDomain(KeyExecutiveApplicationModel keyExecutiveApplication)
    {
        if (keyExecutiveApplication is null)
            return new KeyExecutive();

        KeyExecutive _keyExecutive = new KeyExecutive(keyExecutiveApplication.Name, keyExecutiveApplication.Title, keyExecutiveApplication.Pay, 
                                                      keyExecutiveApplication.Exercised, keyExecutiveApplication.YearBorn);
    
        return _keyExecutive;
    }

    public static List<KeyExecutive> ToDomain(List<KeyExecutiveApplicationModel> keyExecutiveApplicationModels)
    {
        List<KeyExecutive> _keyExecutiveList = new List<KeyExecutive>();

        if(keyExecutiveApplicationModels != null)
        {
            foreach(var keyExecutive in keyExecutiveApplicationModels)
            {
                KeyExecutive _keyExecutive = new KeyExecutive(keyExecutive.Name, keyExecutive.Title, keyExecutive.Pay, keyExecutive.Exercised, keyExecutive.YearBorn);
                _keyExecutiveList.Add(_keyExecutive);
            }
        }

        return _keyExecutiveList;
    }
}
