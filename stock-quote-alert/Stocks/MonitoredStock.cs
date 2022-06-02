using stock_quote_alert.Quote;

namespace stock_quote_alert.Stocks {
    internal class MonitoredStock : Stock {
        public double SellPrice { get; set; }
        public double BuyPrice { get; set; }
        public MonitoredStock(string name, double sellPrice, double buyPrice) : base(name) {
            SellPrice = sellPrice;
            BuyPrice = buyPrice;
        }
        public MonitoredStock(string[] args) : base(args[0]) {
            try { // Colocar no construtor da classe Stock (???)
                SellPrice = Convert.ToDouble(args[1]);
                BuyPrice = Convert.ToDouble(args[2]);
            } catch (Exception) {
                throw new Exception("Parameters is not valid.");
            }
        }
    }
}
