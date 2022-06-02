using Newtonsoft.Json;
using stock_quote_alert.ApiResults;
using stock_quote_alert.Stocks;
using System.Net.Http.Headers;

namespace stock_quote_alert.Services;
public class ApiConsumer {
    private static readonly string _url = "https://brapi.ga/api/";
    public async Task<CurrentStock> GetCurrentStock(MonitoredStock stock) {
        using var client = new HttpClient();
        client.BaseAddress = new Uri(_url);
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        HttpResponseMessage response = await client.GetAsync(_url + "quote/" + stock.Name);

        if (!response.IsSuccessStatusCode)
            throw new Exception($"Stock {stock.Name} not found.");

        var data = JsonConvert.DeserializeObject<ApiResult>(await response.Content.ReadAsStringAsync()).results.First();
        return new CurrentStock(stock.Name, data.longName, data.regularMarketPrice, data.regularMarketTime);
    }
}

