namespace stock_quote_alert.Config;
public class GeneralConfig {
    public MailConfig MailConfig { get; set; }
    public ReportConfig ReportConfig { get; set; }
    public double DelayToRequest { get; set; }
    public GeneralConfig(MailConfig mailConfig, double delayToRequest, ReportConfig reportConfig) {
        MailConfig = mailConfig;
        ReportConfig = reportConfig;
        DelayToRequest = delayToRequest;
    }
}

