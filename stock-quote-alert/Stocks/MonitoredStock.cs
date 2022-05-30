using stock_quote_alert.Quote;

namespace stock_quote_alert.Stocks
{
    internal class MonitoredStock : Stock
    {
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public string? FullName { get; set; }    

        public MonitoredStock(string name, double sellPrice, double buyPrice) : base(name)
        {
            SellPrice = sellPrice;
            BuyPrice = buyPrice;    
        }
    }
}
