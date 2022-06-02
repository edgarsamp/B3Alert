namespace stock_quote_alert.ApiResults;
public class ApiStock {
    public string symbol { get; set; }
    public string shortName { get; set; }
    public string longName { get; set; }
    public string currency { get; set; }
    public double regularMarketPrice { get; set; }
    public double regularMarketDayHigh { get; set; }
    public double regularMarketDayLow { get; set; }
    public string regularMarketDayRange { get; set; }
    public double regularMarketChange { get; set; }
    public double regularMarketChangePercent { get; set; }
    public DateTime regularMarketTime { get; set; }
    public long marketCap { get; set; }
    public int regularMarketVolume { get; set; }
    public double regularMarketPreviousClose { get; set; }
    public double regularMarketOpen { get; set; }
    public int averageDailyVolume10Day { get; set; }
    public int averageDailyVolume3Month { get; set; }
    public double fiftyTwoWeekLowChange { get; set; }
    public double fiftyTwoWeekLowChangePercent { get; set; }
    public string fiftyTwoWeekRange { get; set; }
    public double fiftyTwoWeekHighChange { get; set; }
    public double fiftyTwoWeekHighChangePercent { get; set; }
    public double fiftyTwoWeekLow { get; set; }
    public double fiftyTwoWeekHigh { get; set; }
    public double twoHundredDayAverage { get; set; }
    public double twoHundredDayAverageChange { get; set; }
    public double twoHundredDayAverageChangePercent { get; set; }
}

