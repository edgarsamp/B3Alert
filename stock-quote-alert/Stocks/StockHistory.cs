namespace stock_quote_alert.Stocks {
    internal class StockHistory {
        private int _maxSize;
        public Queue<CurrentStock> history;
        public StockHistory(int maxSize) {
            _maxSize = Math.Max(10, maxSize);
            history = new Queue<CurrentStock>();
        }
        public void Add(CurrentStock stock) {
            history.Enqueue(stock);
            if (history.Count > _maxSize)
                history.Dequeue();
        }
        public double GetPriceAverage() {
            return history.Select(x => x.Price).ToArray().Average();
        }
        public int GetTimesAbovePurchasePrice(double purchasePrice) {
            return history.Select(x => x.Price > purchasePrice).ToArray().Length;
        }
        public int GetTimesBelowSellingPrice(double sellingPrice) {
            return history.Select(x => x.Price < sellingPrice).ToArray().Length;
        }
    }
}
