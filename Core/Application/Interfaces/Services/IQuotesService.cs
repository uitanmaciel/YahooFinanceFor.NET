using System.Runtime.InteropServices;
using YahooFinanceFor.NET.Core.Application.Services.Models.Quotes;


namespace YahooFinanceFor.NET.Core.Application.Interfaces.Services;

public interface IQuotesService
{
    /// <summary>
    /// Collects an asset's market quote data for a custom period.    
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="start">Start date of the period to be collected.</param>
    /// <param name="end">End date of the period to be collected.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns market quote data for an asset for a custom period.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationCustom(string ticker, DateTime start, DateTime end, [Optional] string frequency);

    /// <summary>
    /// Collects market quote data for an asset in D-1.    
    /// <param name="ticker">Asset trading symbol.</param>    
    /// <returns>Returns market quote data for an asset in D-1.</returns>
    /// </summary>
    QuotesModel GetQuotationDaily(string ticker);

    /// <summary>
    /// Collects an asset's market quote data for the last 5 days.    
    /// <param name="ticker">Asset trading symbol.</param>    
    /// <returns>Returns the market quote data for an asset for the last 5 days.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationFiveDays(string ticker);

    /// <summary>
    /// Collects an asset's market quote data for the last month.    
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns the market quote data for an asset for the last month.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationMonthly(string ticker, [Optional] string frequency);

    /// <summary>
    /// Collects an asset's market quote data for the last 1 year.
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns the market quote data for an asset for the last 1 year.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationOneYear(string ticker, [Optional] string frequency);

    /// <summary>
    /// Collects an asset's market quote data for the last 2 years.    
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns the market quote data for an asset for the last 2 years.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationTwoYears(string ticker, [Optional] string frequency);

    /// <summary>
    /// Collects an asset's market quote data for the last 5 years.    
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns the market quote data for an asset for the last 5 years.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationFiveYears(string ticker, [Optional] string frequency);

    /// <summary>
    /// Collects an asset's market quote data for the last 10 years.    
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns the market quote data for an asset for the last 10 years.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationTenYears(string ticker, [Optional] string frequency);

    /// <summary>
    /// Collects historical market quote data for an asset. The period starts in 03/01/2000. 
    /// <param name="ticker">Asset trading symbol.</param>
    /// <param name="frequency">Indicates the range for the set of prices to be returned. It can be: Daily, Weekly and Monthly. By default the range is Daily.</param>
    /// <returns>Returns historical market quote data for an asset.</returns>
    /// </summary>
    List<QuotesModel> GetQuotationHistorical(string ticker, [Optional] string frequency);
}
