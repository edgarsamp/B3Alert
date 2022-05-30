﻿using Newtonsoft.Json;
using stock_quote_alert.ApiResults;
using stock_quote_alert.Quote;
using stock_quote_alert.Stocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace stock_quote_alert.Services
{
    internal class ApiConsumer
    {
        private static string _url = "https://brapi.ga/api/";

        public ApiConsumer()
        {
        }
        public static CurrentStock GetCurrentStock(MonitoredStock stock)
        {
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(_url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync(_url + "quote/" + stock.Name).Result;

                if (!response.IsSuccessStatusCode)
                    throw new Exception($"Stock {stock.Name} not found.");


                var data = JsonConvert.DeserializeObject<ApiResult>(response.Content.ReadAsStringAsync().Result);
                return new CurrentStock(stock.Name, data.results[0].longName, data.results[0].regularMarketPrice);
            }
        }
    }
}
