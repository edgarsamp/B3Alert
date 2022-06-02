using stock_quote_alert.Quote;

namespace stock_quote_alert.Stocks;
public class MonitoredStock : Stock {
    public double SellPrice { get; set; }
    public double BuyPrice { get; set; }
    public MonitoredStock(string[] args) : base(args[0]) {
        SellPrice = Convert.ToDouble(args[1]);
        BuyPrice = Convert.ToDouble(args[2]);
    }
}

