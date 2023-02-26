using YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Services.Models.Quotes;

public class QuotesModel
{
    public DateTime Date { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal AdjClose { get; set; }
    public decimal Volume { get; set; }

    public QuotesModel() { }

    public QuotesModel(DateTime date, decimal open, decimal high, decimal low, decimal close, decimal adjClose, decimal volume)
    {
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        AdjClose = adjClose;
        Volume = volume;
    }

    public virtual QuotesModel ToQuotesModel(Quotation quotation)
    {
        var _quotesModel = ToApplication(quotation); 
        return _quotesModel;
    }

    public virtual List<QuotesModel> ToQuotesModel(List<Quotation> quotations)
    {
        var _quotesModel = ToApplication(quotations);
        return _quotesModel;
    }

    public static QuotesModel ToApplication(Quotation quotation)
    {
        if(quotation is null)
            return new QuotesModel();

        QuotesModel _quotesModel = new QuotesModel();
        _quotesModel.Date = quotation.Date;
        _quotesModel.Open = quotation.Open;
        _quotesModel.High = quotation.High;
        _quotesModel.Low = quotation.Low;
        _quotesModel.Close = quotation.Close;
        _quotesModel.AdjClose = quotation.AdjClose;
        _quotesModel.Volume = quotation.Volume;

        return _quotesModel;
    }

    public static List<QuotesModel> ToApplication(List<Quotation> quotations) 
    {
        List<QuotesModel> _quotesModelList = new List<QuotesModel>();

        if(quotations != null)
        {
            foreach(var quotes in quotations)
            {
                QuotesModel _quotesModel = new QuotesModel();
                _quotesModel.Date = quotes.Date;
                _quotesModel.Open = quotes.Open;
                _quotesModel.High = quotes.High;
                _quotesModel.Low = quotes.Low;
                _quotesModel.Close = quotes.Close;
                _quotesModel.AdjClose = quotes.AdjClose;
                _quotesModel.Volume = quotes.Volume;
                _quotesModelList.Add(_quotesModel);
            }
        }

        return _quotesModelList;
    }
}
