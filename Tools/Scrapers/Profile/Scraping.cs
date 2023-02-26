using YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;
using YahooFinanceFor.NET.Core.Application.Interfaces.Tools;

namespace YahooFinanceFor.NET.Tools.Scrapings.Profile;

public class Scraping : IProfileScraping
{
    public string CompanyName(string source)
    {
        string name;

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeTagH3Start = source.IndexOf("<h3", localizeTagMain);
            int localizeTagH3End = source.IndexOf("</h3>", localizeTagMain, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizeTagH3Start, localizeTagH3End - localizeTagH3Start).Split(">");

            return name = broken[1];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<string> AddressInfo(string source)
    {
        List<string> address = new List<string>();

        int localizeTagMain = source.IndexOf("<div id=\"Main\"");
        int localizeP1Start = source.IndexOf("<p", localizeTagMain);
        int localizeP1End = source.IndexOf("</p>", localizeP1Start, StringComparison.CurrentCultureIgnoreCase);
        string[] broken = source.Substring(localizeP1Start, localizeP1End - localizeP1Start).Split(">");

        for (int i = 1; i < broken.Length; i++)
        {
            if (i >= 1 && i <= 4 || i == 9)
            {
                if (i == 3)
                {
                    string[] items = broken[i].Split(",");
                    string[] cep = items[1].Split(" ");
                    for (int j = 1; j <= cep.Length - 1; j++)
                    {
                        address.Add(cep[j].Replace("<br/", ""));
                    }
                }
                address.Add(broken[i].Replace("<br/", "").Replace("</a", ""));
            }
        }
        address.RemoveAt(4);
        return address;
    }

    public (string sector, string industry, decimal numberEmployee) IndustryAndSector(string source)
    {
        string _sector = "", _industry = "", _numberEmployee = "";

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeP1Start = source.IndexOf("<p", localizeTagMain);
            int localizeP1End = source.IndexOf("</p>", localizeP1Start, StringComparison.CurrentCultureIgnoreCase);
            int localizeP2Start = source.IndexOf("<p", localizeP1End);
            int localizeP2End = source.IndexOf("</p>", localizeP2Start, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizeP2Start, localizeP2End - localizeP2Start).Split(">");

            for (int i = 0; i <= broken.Length; i++)
            {
                switch (i)
                {
                    case 4:
                        _sector = broken[i].Replace("</span", "");
                        break;
                    case 9:
                        _industry = broken[i].Replace("</span", "");
                        break;
                    case 15:
                        _numberEmployee = broken[i].Replace("</span", "");
                        break;
                }
            }
            return (sector: _sector, industry: _industry, numberEmployee: Convert.ToDecimal(_numberEmployee));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public List<KeyExecutiveProfileDTO> KeyExecutives(string source)
    {
        string _name = "", _title = "", _pay = "", _exercised = "", _yearBorn = "";
        List<KeyExecutiveProfileDTO> keyExecutiveList = new List<KeyExecutiveProfileDTO>();
        int control = 1;
        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"Bxz", localizeTagMain);
            int localizeTBodyStart = source.IndexOf("<tbody", localizeSection, StringComparison.CurrentCultureIgnoreCase);
            int localizeTBodyEnd = source.IndexOf("</tbody>", localizeTBodyStart, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizeTBodyStart, localizeTBodyEnd - localizeTBodyStart)
                                .Replace(" class=\"\"", "")
                                .Replace("&amp;", "")
                                .Replace("</td><td class=\"Ta(end)\"", "")
                                .Replace("</td><td class=\"Ta(start)\"", "")
                                .Replace("</sapn>", "")
                                .Replace("<span", "")
                                .Replace("</span", "")
                                .Replace("<td class=\"Ta(start) W(45%)\"", "")
                                .Replace("<tr class=\"C($primaryColor) BdB Bdc($seperatorColor) H(36px)\"", "")
                                .Replace("<td class=\"Ta(start)\"", "")
                                .Replace("</td", "")
                                .Replace("</tr", "")
                                .Replace("<tbody", "")
                                .Replace("</tbody", "")
                                .Split(">");

            for (int i = 0; i < broken.Length; i++)
            {
                if (broken[i] != "")
                {
                    switch (control)
                    {
                        case 1:
                            _name = broken[i].ToString();
                            control++;
                            break;
                        case 2:
                            _title = broken[i].ToString();
                            control++;
                            break;
                        case 3:
                            _pay = broken[i].ToString();
                            control++;
                            break;
                        case 4:
                            _exercised = broken[i].ToString();
                            control++;
                            break;
                        case 5:
                            _yearBorn = broken[i].ToString();
                            KeyExecutiveProfileDTO keyExecutive = new KeyExecutiveProfileDTO();
                            keyExecutive.Name = _name;
                            keyExecutive.Title = _title;
                            keyExecutive.Pay = _pay;
                            keyExecutive.Execised = _exercised;
                            keyExecutive.YearBorn = _yearBorn;
                            keyExecutiveList.Add(keyExecutive);
                            control = 1;
                            break;
                    }
                }
            }
            return keyExecutiveList;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public string Description(string source)
    {
        string _description = "";

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"quote-sub-section", localizeTagMain);
            int localizePStart = source.IndexOf("<p", localizeSection, StringComparison.CurrentCultureIgnoreCase);
            int localizePEnd = source.IndexOf("</p>", localizePStart, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizePStart, localizePEnd - localizePStart).Split(">");

            return _description = broken[1].Replace("</p>", "");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public string Governance(string source)
    {
        string _governance = "";

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"Mt(30px) corporate-governance-container", localizeTagMain);
            int localizePStart = source.IndexOf("<p", localizeSection, StringComparison.CurrentCultureIgnoreCase);
            int localizePEnd = source.IndexOf("</p>", localizePStart, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizePStart, localizePEnd - localizePStart)
                                    .Replace("<p class=\"Fz(s)\"", "")
                                    .Replace("<span", "")
                                    .Replace("</span", "")
                                    .Split(">");

            for (int i = 0; i < broken.Length; i++)
            {
                if (broken[i] != "")
                {
                    _governance = string.Concat(_governance, broken[i]);
                }
            }

            int localizeDivStart = source.IndexOf("<div class=\"Mt(20px)\"", localizePEnd);
            int localizeDivEnd = source.IndexOf("</div>", localizeDivStart, StringComparison.CurrentCultureIgnoreCase);
            string[] broken1 = source.Substring(localizeDivStart, localizeDivEnd - localizeDivStart)
                                     .Replace("<div class=\"Mt(20px)\"", "")
                                     .Replace("<span", "")
                                     .Replace("</span", "")
                                     .Replace("<a href=", "")
                                     .Replace("target=\"_blank\" rel=\"noopener noreferrer\" title=", "")
                                     .Replace(" <span", "")
                                     .Replace("\"Institutional Shareholder Services (ISS)\"", "")
                                     .Replace("</a", "")
                                     .Replace("\"", "")
                                     .Split(">");

            for (int j = 0; j < broken1.Length; j++)
            {
                if (broken[j] != "")
                {
                    _governance = string.Concat(_governance, broken1[j]);
                }
            }
            return _governance;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
