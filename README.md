# YahooFinanceFor.NET
------

This is a library to help .NET developers to collect financial market information from Yahoo Finance (unofficial api).
The current version 2.0.0 has been modified and improved:

1. General structure of the library;
2. Correction of bugs in the frequency of quotations data;
3. Implemented asset profile information collection;


#### Features
--

1. Asset quote data collection (completed);
2. Profile Assets (completed);
3. Equity data collection (in development);

#### How to use
--

To use the library you must add it to your project via nuget [**click here**](https://www.nuget.org/packages/YahooFinanceFor.NET).
If you want to collect data from the last trading day of an asset, you can do it according to the example below:


 	using YahooFinance.NET;
			
	class Program
	{
		static void Main(string[] args)
		{
			string symbol = "AAPL";
			var yf = new YahooFinance();			
			var quotes = yf.Quotes.GetQuotationDaily(symbol);
					
			foreach(var quote in quotes)
			{
				Console.WriteLine($"--> Data:{quote.Date}");
				Console.WriteLine($"Open:{quote.Open}");
				Console.WriteLine($"High:{quote.High}");
				Console.WriteLine($"Low:{quote.Low}");
				Console.WriteLine($"Close:{quote.Close}");
				Console.WriteLine($"Volume:{quote.Volume}","\n");
			}
		}
	}			


For other predefined periods you can follow the same concept.
If you wanted a more personalized period, you could do:


 	using YahooFinance.NET;
			
	class Program
	{
		static void Main(string[] args)
		{
			string symbol = "AAPL";
			DataTime start = Convert.ToDecimal("02/03/2016").Date;
			DataTime end = Convert.ToDecimal("28/07/2017").Date;
			var yf = new YahooFinance();			
			var quotes = yf.Quotes.GetQuotationCustom(symbol, start, end);
		}
		// Return: List quote data
	}

This will return a list of data. You will need to implement a class to map the information and use it as your project needs.
You can specify a frequency for returning the data set. By default, data is returned on a daily basis. You can change this output by entering the Weekly or Monthly options.

    using YahooFinance.NET;
			
	class Program
	{
		static void Main(string[] args)
		{
			string symbol = "AAPL";
			DataTime start = Convert.ToDecimal("02/03/2016").Date;
			DataTime end = Convert.ToDecimal("28/07/2017").Date;
			var yf = new YahooFinance();			
			var quotes = yf.Quotes.GetQuotationCustom(symbol, start, end, DataFrequency.Monthly);
		}
		// Return: List quote data
	}

If you have any questions, suggestions or criticisms, please contact us at uitan.s.maciel@gmail.com or open an issue on github.