namespace YahooFinanceFor.NET.Core.Application.Handlers;

public class BaseRequestHandle
{
	public BaseRequestHandle() { }

	protected async Task<string> Request(string url)
	{
        string content = "404";

        try
        {
            if (!string.IsNullOrEmpty(url))
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                    content = await response.Content.ReadAsStringAsync();
            }
            return content;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
