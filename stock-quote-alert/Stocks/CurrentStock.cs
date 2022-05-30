using stock_quote_alert.Quote;


namespace stock_quote_alert.Stocks
{
    internal class CurrentStock : Stock
    {
        public double Price { get; set; }
        public string FullName { get; set; }
        public CurrentStock(string name, string fullName, double price) : base(name)
        {
            FullName = fullName;
            Price = price;
        }
    }
}
