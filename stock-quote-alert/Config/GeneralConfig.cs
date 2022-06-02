using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stock_quote_alert.Config {
    internal class GeneralConfig {
        public MailConfig MailConfig { get; set; }
        public ReportConfig ReportConfig { get; set; }
        public int DelayToRequest { get; set; }
        public GeneralConfig(MailConfig mailConfig, int delayToRequest, ReportConfig reportConfig) {
            MailConfig = mailConfig;
            ReportConfig = reportConfig;
            DelayToRequest = delayToRequest;
        }
    }
}
