using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Interfaces.Services;
using YahooFinanceFor.NET.Core.Application.Services.Models.Quotes;

namespace YahooFinanceFor.NET.Core.Application.Services.Quotes;

public class QuotesService : IQuotesService
{    
    public List<QuotesModel> GetQuotationCustom(string ticker, DateTime start, DateTime end, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationCustom(ticker, start, end, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }
    
    public QuotesModel GetQuotationDaily(string ticker)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationDaily(ticker);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationFiveDays(string ticker)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationFiveDays(ticker);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationFiveYears(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationFiveYears(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationHistorical(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationHistorical(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationOneYear(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationOneYear(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationTenYears(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationTenYears(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationMonthly(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationMonthly(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }

    public List<QuotesModel> GetQuotationTwoYears(string ticker, [Optional] string frequency)
    {
        var _quotesDomain = new Domain.Aggregates.Stock.Quotes.Quotation();
        var _quotationDomain = _quotesDomain.GetQuotationTwoYears(ticker, frequency);
        var _quotation = Services.Models.Quotes.QuotesModel.ToApplication(_quotationDomain);
        return _quotation;
    }
}
