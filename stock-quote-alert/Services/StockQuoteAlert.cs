using stock_quote_alert.Config;
using stock_quote_alert.Stocks;

namespace stock_quote_alert.Services {
    internal class StockQuoteAlert {
        private readonly ConfigFile _configFile;
        private readonly MailConfig _mailConfig;
        private readonly ReportConfig _reportConfig;
        private readonly MailSender _mailSenderService;
        private readonly ApiConsumer _apiConsumerService;
        private readonly MonitoredStock _monitoredStock;
        private readonly TimeSpan _delayToRequest;
        private readonly StockHistory _stockHistory;

        public StockQuoteAlert(string path, string[] args) {
            _configFile = new ConfigFile(path);
            _apiConsumerService = new ApiConsumer();
            _mailConfig = _configFile.LoadConfig().MailConfig;
            _reportConfig = _configFile.LoadConfig().ReportConfig;
            _stockHistory = new(_reportConfig.MaxQueueSize);
            _delayToRequest = TimeSpan.FromMinutes(_configFile.LoadConfig().DelayToRequest);
            _mailSenderService = new MailSender(_mailConfig);
            _monitoredStock = new MonitoredStock(args);
        }

        private CurrentStock GetCurrentStock() {
            CurrentStock currentStock = _apiConsumerService.GetCurrentStock(_monitoredStock);
            return currentStock;
        }
        private void RecommendToBuy(CurrentStock currentStock) {
            var subject = $"Recommendation to sale of stock.";
            var message = $"Maybe it's a good time to buy the stock {currentStock.FullName}({currentStock.Name}), " +
                          $"the market price is R$ {currentStock.Price}.";

            _mailSenderService.SendAsync(subject, message).Wait();
        }
        private void RecommendToSell(CurrentStock currentStock) {
            var subject = $"Recommendation to purchase of stock.";
            var message = $"Maybe it's a good time to sell the stock {currentStock.FullName}({currentStock.Name}), " +
                          $"the market price is R$ {currentStock.Price}.";

            _mailSenderService.SendAsync(subject, message).Wait();
        }

        private void SendReportMail() {
            ReportCreator creator = new();
            var subject = $"Report about {_monitoredStock.Name} stock";
            var message = creator.GenerateMessage(_stockHistory, _monitoredStock);
            var imagePath = creator.GenerateAverageGraph(_stockHistory, _monitoredStock);

            _mailSenderService.SendWithImageAsync(subject, message, imagePath).Wait();
        }

        public async Task Run(CancellationToken token) {
            //while (!token.IsCancellationRequested) {
            var i = 0;
            while (i < 4) {
                var currentStock = GetCurrentStock();
                _stockHistory.Add(currentStock);
                if (currentStock.Price > _monitoredStock.BuyPrice)
                    RecommendToSell(currentStock);
                else if (currentStock.Price < _monitoredStock.SellPrice)
                    RecommendToBuy(currentStock);

                await Task.Delay(_delayToRequest, token);
                i++;
            }

            if (_reportConfig.CanSendReportEmail)
                SendReportMail();
        }
    }
}
