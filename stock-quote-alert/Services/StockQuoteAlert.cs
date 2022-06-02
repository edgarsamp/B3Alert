using stock_quote_alert.Config;
using stock_quote_alert.Stocks;

namespace stock_quote_alert.Services;
public class StockQuoteAlert {
    private readonly MailConfig _mailConfig;
    private readonly ReportConfig _reportConfig;
    private readonly MailSender _mailSenderService;
    private readonly ApiConsumer _apiConsumerService;
    private readonly MonitoredStock _monitoredStock;
    private readonly TimeSpan _delayToRequest;
    private readonly StockHistory _stockHistory;
    public StockQuoteAlert(string[] args) {
        if (args.Length != 3) throw new Exception("Parameters is not valid.");

        _apiConsumerService = new ApiConsumer();
        _mailConfig = ConfigFile.Config.MailConfig;
        _reportConfig = ConfigFile.Config.ReportConfig;
        _stockHistory = new(_reportConfig.MaxQueueSize);
        _delayToRequest = TimeSpan.FromMinutes(ConfigFile.Config.DelayToRequest);
        _mailSenderService = new MailSender(_mailConfig);
        _monitoredStock = new MonitoredStock(args);
    }

    private async Task<CurrentStock> GetCurrentStock() => await _apiConsumerService.GetCurrentStock(_monitoredStock);
    private async Task RecommendToBuy(CurrentStock currentStock) {
        var subject = $"Recommendation to sale of stock.";
        var message = $"<p> Maybe it's a good time to buy the stock {currentStock.FullName}({currentStock.Name}), " +
                      $"the market price is R$ {currentStock.Price}. </p>";

        await _mailSenderService.SendAsync(subject, message);
    }
    private async Task RecommendToSell(CurrentStock currentStock) {
        var subject = $"Recommendation to purchase of stock.";
        var message = $"<p> Maybe it's a good time to sell the stock {currentStock.FullName}({currentStock.Name}), " +
                      $"the market price is R$ {currentStock.Price}.</p>";

        await _mailSenderService.SendAsync(subject, message);
    }

    public async Task SendReportMail() {
        if (!_reportConfig.CanSendReportEmail)
            return;

        ReportCreator creator = new();
        var subject = $"Report about {_monitoredStock.Name} stock";
        var message = creator.GenerateMessage(_stockHistory, _monitoredStock);
        var imagePath = ReportCreator.GenerateAverageGraph(_stockHistory, _monitoredStock);

        await _mailSenderService.SendWithImageAsync(subject, message, imagePath);
    }

    public async Task Run(CancellationToken token) {
        while (!token.IsCancellationRequested) {
            var currentStock = await GetCurrentStock();
            _stockHistory.Add(currentStock);
            if (currentStock.Price > _monitoredStock.BuyPrice)
                await RecommendToSell(currentStock);
            else if (currentStock.Price < _monitoredStock.SellPrice)
                await RecommendToBuy(currentStock);

            await Task.Delay(_delayToRequest, token);
        }
    }
}

