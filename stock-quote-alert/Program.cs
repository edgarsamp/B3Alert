using stock_quote_alert.Services;

StockQuoteAlert alert = new("./config.json", args);

CancellationTokenSource cancellationTokenSource = new();
CancellationToken token = cancellationTokenSource.Token;

Task task = Task.Run(async () => {
    await alert.Run(token);
}, token);

Console.WriteLine("Press 'C' to stop the task");
while (true) {
    var key = Console.ReadLine();
    if (key.ToUpperInvariant() == "C") {
        cancellationTokenSource.Cancel();
        break;
    }
}

alert.SendReportMail();