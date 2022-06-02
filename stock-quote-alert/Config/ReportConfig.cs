namespace stock_quote_alert.Config;
public class ReportConfig {
    public bool CanSendReportEmail { get; set; }
    public int MaxQueueSize { get; set; }
    public ReportConfig(bool sendReport, int maxQueueSize) {
        CanSendReportEmail = sendReport;
        MaxQueueSize = maxQueueSize;
    }
}

