using System.Text.RegularExpressions;
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
        string[] broken = source.Substring(localizeP1Start, localizeP1End - localizeP1Start).Split("<br/>");

        switch (broken.Length)
        {
            case 5:
                for (int i = 0; i < broken.Length; i++)
                {
                    Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
                    string text = regex.Replace(broken[i], string.Empty);

                    if (i == 1)
                    {
                        var _split = text.Split(",");
                        address.Add(_split[0].Replace(",", string.Empty).Trim());


                        var _stateAndCity = _split[1].Split(" ");
                        for (int j = 0; j < _stateAndCity.Length; j++)
                        {
                            if (_stateAndCity[j] != "")
                                address.Add(_stateAndCity[j].Trim());
                        }
                    }
                    else
                        address.Add(text);
                }
                address.RemoveAt(5);
                break;
            default:
                for (int i = 0; i < broken.Length; i++)
                {
                    Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
                    string text = regex.Replace(broken[i], string.Empty);

                    if (i == 2)
                    {
                        var _split = text.Split(",");
                        address.Add(_split[0].Replace(",", string.Empty).Trim());

                        var _stateAndCity = _split[1].Split(" ");
                        for(int j = 0; j < _stateAndCity.Length; j++)
                        {
                            if (_stateAndCity[j] != "")
                                address.Add(_stateAndCity[j].Trim());
                        }
                    }
                    else
                        address.Add(text);
                }
                address.RemoveAt(1);
                address.RemoveAt(5);
                break;
        }        
        return address;
    }

    public (string sector, string industry, string numberEmployee) IndustryAndSector(string source)
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
                        _sector = broken[i].Replace("</span", "").Trim();
                        break;
                    case 9:
                        _industry = broken[i].Replace("</span", "").Replace("&amp", string.Empty).Trim();
                        break;
                    case 15:
                        _numberEmployee = broken[i].Replace("</span", "").Trim();
                        break;
                }
            }
            return (sector: _sector, industry: _industry, numberEmployee: _numberEmployee);
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
            string _text = source.Substring(localizePStart, localizePEnd - localizePStart);

            Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
            
            return _description = regex.Replace(_text, string.Empty);
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
            string _textPart1 = source.Substring(localizePStart, localizePEnd - localizePStart);

            int localizeDivStart = source.IndexOf("<div class=\"Mt(20px)\"", localizePEnd);
            int localizeDivEnd = source.IndexOf("</div>", localizeDivStart, StringComparison.CurrentCultureIgnoreCase);
            string _textPart2 = source.Substring(localizeDivStart, localizeDivEnd - localizeDivStart);

            Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
            string text = regex.Replace(_textPart1, string.Empty);

            return _governance = string.Concat(regex.Replace(_textPart1, string.Empty), regex.Replace(_textPart2, string.Empty));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
