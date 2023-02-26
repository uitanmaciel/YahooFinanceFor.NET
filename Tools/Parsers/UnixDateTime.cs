using TimHanewich.Toolkit;
using YahooFinanceFor.NET.Core.Application.Interfaces.Tools;

namespace YahooFinanceFor.NET.Tools.Parsers;

public class UnixDateTime : IUnixDateTime
{
    public string ToDateUnix(DateTime dateTime)
    {
        string dateUnix = UnixToolkit.GetUnixTime(dateTime).ToString();
        return dateUnix;
    }
}
