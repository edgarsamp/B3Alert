using stock_quote_alert.Services;
using stock_quote_alert.Stocks;


ApiConsumer a = new();
MonitoredStock stock = new("petr4", 4.0, 5.0);
CurrentStock currentStock = ApiConsumer.GetCurrentStock(stock);

Console.WriteLine(currentStock.Price);