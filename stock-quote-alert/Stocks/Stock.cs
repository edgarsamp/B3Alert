namespace stock_quote_alert.Quote {
    internal abstract class Stock {
        public string Name;
        public Stock(string name) {
            Name = name.ToLower();
        }
    }
}
