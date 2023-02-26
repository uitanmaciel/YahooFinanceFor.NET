namespace YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Profile;

public class KeyExecutive
{
    public string Name { get; private set; }
    public string Title { get; private set; }
    public string Pay { get; private set; }
    public string Exercised { get; private set; }
    public string YearBorn { get; private set; }

    public KeyExecutive() { }

    public KeyExecutive(string name, string title, string pay, string exercised, string yearBorn)
    {
        Name = name;
        Title = title;
        Pay = pay;
        Exercised = exercised;
        YearBorn = yearBorn;
    }
}
