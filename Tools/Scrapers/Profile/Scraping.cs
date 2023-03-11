using System.Net;
using System.Text.RegularExpressions;
using YahooFinanceFor.NET.Core.Application.Handlers.Profile.DTOs;
using YahooFinanceFor.NET.Core.Application.Interfaces.Tools;

namespace YahooFinanceFor.NET.Tools.Scrapings.Profile;

public class Scraping : IProfileScraping
{
    public string CompanyName(string source)
    {
        string name = string.Empty;

        if (source == "404")
            return name;

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeTagH3Start = source.IndexOf("<h3", localizeTagMain);

            if (localizeTagH3Start == -1)
                return string.Empty;

            int localizeTagH3End = source.IndexOf("</h3>", localizeTagMain, StringComparison.CurrentCultureIgnoreCase);
            string[] broken = source.Substring(localizeTagH3Start, localizeTagH3End - localizeTagH3Start).Split(">");

            return name = broken[1];
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public (string locate, string city, string state, string zipCode, string country, string url) AddressInfo(string source)
    {
        string _locate = string.Empty, _city = string.Empty, _state = string.Empty, _zipCode = string.Empty, _country = string.Empty, _url = string.Empty;
        int comma = 0;

        if (source == "404")
            return (locate: _locate, city: _city, state: _state, zipCode: _zipCode, country: _country, url: _url);

        try
        {
            List<string> address = new List<string>();

            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeP1Start = source.IndexOf("<p", localizeTagMain);
            int localizeP1End = source.IndexOf("</p>", localizeP1Start, StringComparison.CurrentCultureIgnoreCase);

            if (localizeP1End == -1)
                return (locate: _locate, city: _city, state: _state, zipCode: _zipCode, country: _country, url: _url);

            string[] broken = source.Substring(localizeP1Start, localizeP1End - localizeP1Start).Split("<br/>");

            for (int i = 0; i < broken.Length; i++)
            {
                Regex regex = new Regex("<.*?>", RegexOptions.Compiled);
                address.Add(regex.Replace(broken[i], string.Empty));
            }

            switch (address.Count)
            {
                case 1:
                    return (locate: _locate, city: _city, state: _state, zipCode: _zipCode, country: _country, url: _url);

                case 5:
                    _locate = address[0].Trim();

                    comma = address[1].IndexOf(',');
                    if (comma != -1)
                    {
                        var _split = address[1].Split(",");
                        _city = _split[0].Trim();

                        var _stateAndCity = _split[1].Split(" ");
                        if (_stateAndCity.Length > 2)
                        {
                            _state = _stateAndCity[1].Trim();
                            _zipCode = _stateAndCity[2].Trim();
                        }
                        else
                        {
                            _city = _split[0].Trim();
                            _state = _split[1].Trim();
                            _zipCode = string.Empty;
                        }
                        _country = address[2].Trim();
                        _url = address[4].Trim();
                    }
                    else
                    {
                        var _split = address[1].Split(" ");
                        if (_split.Length > 2)
                        {
                            _city = _split[0].Trim();
                            var _stateAndCity = _split[1].Split(" ");
                            if (_stateAndCity.Length > 1)
                            {

                            }
                            else
                            {
                                _state = _split[2].Trim();
                                _zipCode = string.Empty;
                            }
                        }
                        else
                        {
                            _city = _split[0].Trim();
                            _state = string.Empty;
                            _zipCode = string.Empty;
                        }
                        _country = address[2].Trim();
                        _url = address[4].Trim();
                    }
                    break;
                case 6:
                    _locate = string.Concat(address[0], " ", address[1]);
                    address.RemoveAt(1);

                    comma = address[1].IndexOf(',');
                    if (comma != -1)
                    {
                        var _split = address[1].Split(",");
                        switch (_split.Length)
                        {
                            case 2:
                                _city = _split[0].Replace(",", string.Empty).Trim();
                                var _stateAndZipCode = _split[1].Split(" ");
                                if (_stateAndZipCode.Length > 2)
                                {
                                    _state = _stateAndZipCode[1].Trim();
                                    _zipCode = _stateAndZipCode[2].Trim();
                                }
                                else
                                {
                                    for (int i = 0; i < _stateAndZipCode.Length; i++)
                                    {
                                        if (!string.IsNullOrEmpty(_stateAndZipCode[i]))
                                        {
                                            if (i != 0)
                                                _state = _stateAndZipCode[i].Trim();
                                        }
                                    }
                                    _zipCode = string.Empty;
                                }
                                break;
                        }
                        _country = address[2].Trim();
                        _url = address[4].Trim();
                    }
                    else
                    {
                        var _split = address[1].Split(" ");
                        if (_split.Length > 2)
                        {
                            _city = _split[0].Trim();
                            var _stateAndCity = _split[1].Split(" ");
                            if (_stateAndCity.Length > 1)
                            {
                                for (int j = 0; j < _stateAndCity.Length; j++)
                                {
                                    if (_stateAndCity[j] != "")
                                        address.Add(_stateAndCity[j].Trim());
                                }
                            }
                        }
                        else
                        {
                            _city = _split[0].Trim();
                            _state = string.Empty;
                            _zipCode = string.Empty;
                            _country = address[2].Trim();
                            _url = address[4].Trim();
                        }
                    }
                    break;
            }

            return (locate: _locate, city: _city, state: _state, zipCode: _zipCode, country: _country, url: _url);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public (string sector, string industry, string numberEmployee) IndustryAndSector(string source)
    {
        string _sector = string.Empty, _industry = string.Empty, _numberEmployee = string.Empty;
        List<string> text = new List<string>();

        if(source == "404")
            return (sector: _sector, industry: _industry, numberEmployee: _numberEmployee);

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeP1Start = source.IndexOf("<p", localizeTagMain);
            int localizeP1End = source.IndexOf("</p>", localizeP1Start, StringComparison.CurrentCultureIgnoreCase);

            if (localizeP1End == -1)
                return (sector: _sector, industry: _industry, numberEmployee: _numberEmployee);

            int localizeP2Start = source.IndexOf("<p", localizeP1End);
            int localizeP2End = source.IndexOf("</p>", localizeP2Start, StringComparison.CurrentCultureIgnoreCase);

            if (localizeP2End == -1)
                return (sector: _sector, industry: _industry, numberEmployee: _numberEmployee);

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
        string _name = string.Empty, _title = string.Empty, _pay = string.Empty, _exercised = string.Empty, _yearBorn = string.Empty;
        List<KeyExecutiveProfileDTO> keyExecutiveList = new List<KeyExecutiveProfileDTO>();
        int control = 1;

        if (source == "404")
            return keyExecutiveList;

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"Bxz", localizeTagMain);

            if (localizeSection == -1)
                return new List<KeyExecutiveProfileDTO>();

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

           
            for (int i = 0; i < broken.GetUpperBound(0); i++)
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
        string _description = string.Empty;

        if(source == "404")
            return _description;

        try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"quote-sub-section", localizeTagMain);

            if (localizeSection == -1)
                return _description;

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
        string _governance = string.Empty;

        if (source == "404")
            return _governance;

            try
        {
            int localizeTagMain = source.IndexOf("<div id=\"Main\"");
            int localizeSection = source.IndexOf("<section class=\"Mt(30px) corporate-governance-container", localizeTagMain);

            if(localizeSection == -1)
                return _governance;

            int localizePStart = source.IndexOf("<p", localizeSection, StringComparison.CurrentCultureIgnoreCase);
            int localizePEnd = source.IndexOf("</p>", localizePStart, StringComparison.CurrentCultureIgnoreCase);
            string _textPart1 = source.Substring(localizePStart, localizePEnd - localizePStart);

            int localizeDivStart = source.IndexOf("<div class=\"Mt(20px)\"", localizePEnd);
            int localizeDivEnd = source.IndexOf("</div>", localizeDivStart, StringComparison.CurrentCultureIgnoreCase);
            string _textPart2 = source.Substring(localizeDivStart, localizeDivEnd - localizeDivStart);

            Regex regex = new Regex("<.*?>", RegexOptions.Compiled);           

            return _governance = string.Concat(regex.Replace(_textPart1, string.Empty), regex.Replace(_textPart2, string.Empty));
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
