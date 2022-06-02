namespace stock_quote_alert.ApiResults;
public class ApiResult {
    public List<ApiStock> results { get; set; }
    public DateTime requestedAt { get; set; }
}

