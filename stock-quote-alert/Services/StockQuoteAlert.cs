using stock_quote_alert.Config;
using stock_quote_alert.Stocks;

namespace stock_quote_alert.Services {
    internal class StockQuoteAlert {
        private readonly ConfigFile _configFile;
        private readonly MailConfig _mailConfig;
        private readonly MailSender _mailSenderService;
        private readonly ApiConsumer _apiConsumerService;
        private readonly MonitoredStock _monitoredStock;
        private readonly TimeSpan _delayToRequest;


        public StockQuoteAlert(string path, string[] args) {
            _configFile = new ConfigFile(path);
            _apiConsumerService = new ApiConsumer();
            _mailConfig = _configFile.LoadMailConfig();
            _mailSenderService = new MailSender(_mailConfig);
            _monitoredStock = new MonitoredStock(args);
            _delayToRequest = TimeSpan.FromMinutes(15);
        }

        public CurrentStock GetCurrentStock() {
            CurrentStock currentStock = _apiConsumerService.GetCurrentStock(_monitoredStock);
            return currentStock;
        }
        public void RecommendToBuy(CurrentStock currentStock) {
            var subject = $"Recommendation to sale of stock.";
            var message = $"Maybe it's a good time to buy the stock {currentStock.FullName}({currentStock.Name}), the market price is R$ {currentStock.Price}.";

            _mailSenderService.SendAsync(subject, message).Wait();
        }
        public void RecommendToSell(CurrentStock currentStock) {
            var subject = $"Recommendation to purchase of stock.";
            var message = $"Maybe it's a good time to sell the stock {currentStock.FullName}({currentStock.Name}), the market price is R$ {currentStock.Price}.";

            _mailSenderService.SendAsync(subject, message).Wait();
        }

        public async Task Run(CancellationToken token) {
            while (!token.IsCancellationRequested) {
                var currentStock = GetCurrentStock();
                if (currentStock.Price > _monitoredStock.BuyPrice)
                    RecommendToSell(currentStock);
                else if (currentStock.Price < _monitoredStock.SellPrice)
                    RecommendToBuy(currentStock);

                Console.WriteLine($"{currentStock.Name} - {currentStock.Price}");

                await Task.Delay(_delayToRequest, token);
            }

            Console.WriteLine("saiu1");
        }
    }
}
