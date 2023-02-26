using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes;

public class BaseQuotationProcessHandle
{
	public BaseQuotationProcessHandle() { }

	protected List<QuotationDTO> QuotationProcess(string content)
	{
		List<QuotationDTO> _quotationList = new List<QuotationDTO>();

		if(!string.IsNullOrEmpty(content))
		{
			string[] rows = content.Split("\n");

            for (int i = 1; i <= rows.Length - 1; i++)
            {
                if (!string.IsNullOrEmpty(rows[i]))
                {
                    string[] cols = rows[i].Split(",");
                    QuotationDTO _quotation = new QuotationDTO();
                    if (!string.IsNullOrEmpty(cols[0]))
                        _quotation.Date = Convert.ToDateTime(cols[0]).Date;
                    if (cols[1] != "null")
                        _quotation.Open = Convert.ToDecimal(cols[1].Replace(".", ","));
                    if (cols[2] != "null")
                        _quotation.High = Convert.ToDecimal(cols[2].Replace(".", ","));
                    if (cols[3] != "null")
                        _quotation.Low = Convert.ToDecimal(cols[3].Replace(".", ","));
                    if (cols[4] != "null")
                        _quotation.Close = Convert.ToDecimal(cols[4].Replace(".", ","));
                    if (cols[5] != "null")
                        _quotation.AdjClose = Convert.ToDecimal(cols[5].Replace(".", ","));
                    if (cols[6] != "null")
                        _quotation.Volume = Convert.ToDecimal(cols[6].Replace(".", ","));

                    _quotationList.Add(_quotation);
                }
            }
        }
        return _quotationList;
	}
}
