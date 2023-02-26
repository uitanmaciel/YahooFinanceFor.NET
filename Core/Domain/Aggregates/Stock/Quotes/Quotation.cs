using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Custom;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Daily;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveDays;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.FiveYears;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Historical;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.Monthly;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.OneYear;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TenYears;
using YahooFinanceFor.NET.Core.Application.Handlers.Quotes.Periods.TwoYears;

namespace YahooFinanceFor.NET.Core.Domain.Aggregates.Stock.Quotes;

public class Quotation
{
    public DateTime Date { get; private set; }
    public decimal Open { get; private set; }
    public decimal High { get; private set; }
    public decimal Low { get; private set; }
    public decimal Close { get; private set; }
    public decimal AdjClose { get; private set; }
    public decimal Volume { get; private set; }

    public Quotation() { }

    public Quotation(DateTime date, decimal open, decimal high, decimal low, decimal close, decimal adjClose, decimal volume)
    {
        Date = date;
        Open = open;
        High = high;
        Low = low;
        Close = close;
        AdjClose = adjClose;
        Volume = volume;
    }

    public Quotation GetQuotationDaily(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new Quotation();

        var _handle = new QuotationDailyHandle();
        var _quotation = _handle.QuotationDaily(ticker);

        return _quotation;
    }

    public List<Quotation> GetQuotationFiveDays(string ticker)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationFiveDaysHandle();
        var _quotation = _handle.QuotationFiveDays(ticker);

        return _quotation;
    }

    public List<Quotation> GetQuotationMonthly(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationMonthlyHandle();
        var _quotation = _handle.QuotationMonthly(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationOneYear(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationOneYearHandle();
        var _quotation = _handle.QuotationOneYear(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationTwoYears(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationTwoYearsHandle();
        var _quotation = _handle.QuotationTwoYears(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationFiveYears(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationFiveYearsHandle();
        var _quotation = _handle.QuotationFiveYears(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationTenYears(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationTenYearsHandle();
        var _quotation = _handle.QuotationTenYears(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationHistorical(string ticker, [Optional] string frequency)
    {
        if (string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationHistoricalHandle();
        var _quotation = _handle.QuotationHistorical(ticker, frequency);

        return _quotation;
    }

    public List<Quotation> GetQuotationCustom(string ticker, DateTime start, DateTime end, [Optional] string frequency)
    {
        if(string.IsNullOrWhiteSpace(ticker))
            return new List<Quotation>();

        var _handle = new QuotationCustomHandle();
        var _quotation = _handle.QuotationCustom(ticker, start, end, frequency);

        return _quotation;
    }
}
