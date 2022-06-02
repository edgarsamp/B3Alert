using stock_quote_alert.Config;
using stock_quote_alert.Services;

ConfigFile.LoadConfig("./config.json");
StockQuoteAlert alert = new(args);

CancellationTokenSource cancellationTokenSource = new();
CancellationToken token = cancellationTokenSource.Token;

Task task = Task.Run(async () => {
    await alert.Run(token);
}, token);

Console.WriteLine("Press 'C' to stop the stock quote alert");
while (true) {
    var key = Console.ReadLine();
    if (key.ToUpperInvariant() == "C") {
        cancellationTokenSource.Cancel();
        break;
    }
}

await alert.SendReportMail();