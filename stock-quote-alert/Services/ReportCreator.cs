using stock_quote_alert.Stocks;
using System.Drawing;

namespace stock_quote_alert.Services {
    internal class ReportCreator {
        public string GenerateMessage(StockHistory history, MonitoredStock monitoredStock) {
            var message = $"<p>The following data was obtained according to the last {history.history.Count} {monitoredStock.Name} stock price checks.</p>";
            message += "<ul>";
            message += $"<li>Price average: R${history.GetPriceAverage()}</li>";
            message += $"<li>Number of times below the selling price({monitoredStock.SellPrice}): {history.GetTimesBelowSellingPrice(monitoredStock.SellPrice)}</li>";
            message += $"<li>Number of times above the purchase price({monitoredStock.BuyPrice}): {history.GetTimesAbovePurchasePrice(monitoredStock.BuyPrice)}</li>";
            message += "</ul>";
            message += $"<p>The following graph shows the stock price change:</p>";
            message += $"<img src='img:GraphStockPrice' />";

            return message;
        }
        public static string GenerateAverageGraph(StockHistory history, MonitoredStock stock) {
            double[] dataX = history.history.Select(x => x.RequestAt.ToOADate()).ToArray();
            double[] dataY = history.history.Select(x => x.Price).ToArray();
            var plt = new ScottPlot.Plot(400, 300);

            plt.AddScatter(dataX, dataY);

            plt.AddVerticalSpan(stock.SellPrice, stock.BuyPrice, Color.FromArgb(120, 0, 0, 0));
            plt.AddHorizontalLine(stock.BuyPrice, Color.Blue, 3);
            plt.AddHorizontalLine(stock.SellPrice, Color.Red, 3);

            plt.XAxis.DateTimeFormat(true);
            plt.SaveFig("averageGraph.jpeg");

            return "./averageGraph.jpeg";
        }
    }
}
