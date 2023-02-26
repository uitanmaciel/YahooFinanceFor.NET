using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Handlers.Quotes.DTOs;

public class QuotationDTO
{
    public DateTime Date { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal AdjClose { get; set; }
    public decimal Volume { get; set; }

    public QuotationDTO() { }

    public QuotationDTO(DateTime date, decimal open, decimal high, decimal low, decimal close, decimal adjClose, decimal volume)
    {
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        AdjClose = adjClose;
        Volume = volume;
    }

    public virtual Quotation ToQuotation(QuotationDTO quotationDTO)
    {
        var _quotation = ToDomain(quotationDTO);
        return _quotation;
    }

    public virtual List<Quotation> ToQuotation(List<QuotationDTO> quotationDTOs)
    {
        var _quotations = ToDomain(quotationDTOs);
        return _quotations;
    }

    public virtual Quotation ToQuotationSingle(List<QuotationDTO> quotationDTOs)
    {
        var _quotations = ToDomainSingle(quotationDTOs);
        return _quotations;
    }


    public static Quotation ToDomain(QuotationDTO quotationDTO)
    {
        if(quotationDTO is null)
            return new Quotation();

        Quotation _quotation = new Quotation(quotationDTO.Date, quotationDTO.Open, quotationDTO.High, quotationDTO.Low, quotationDTO.Close, quotationDTO.AdjClose, quotationDTO.Volume);
        return _quotation;
    }

    public static List<Quotation> ToDomain(List<QuotationDTO> quotationDTOs)
    {
        List<Quotation> _quotationList = new List<Quotation>();

        if(quotationDTOs != null)
        {
            foreach(var quotation in quotationDTOs)
            {
                Quotation _quotation = new Quotation(quotation.Date, quotation.Open, quotation.High, quotation.Low, quotation.Close, quotation.AdjClose, quotation.Volume);
                _quotationList.Add(_quotation);
            }
        }

        return _quotationList;
    }

    public static Quotation ToDomainSingle(List<QuotationDTO> quotationDTOs)
    {
        Quotation _quotation = new Quotation(quotationDTOs[0].Date, quotationDTOs[0].Open, quotationDTOs[0].High, quotationDTOs[0].Low,
                                             quotationDTOs[0].Close, quotationDTOs[0].AdjClose, quotationDTOs[0].Volume);
        return _quotation;
    }
}
