
namespace stock_quote_alert.Config {
    internal class MailConfig {
        public string Receiver { get; set; }
        public string Sender { get; set; }
        public string SenderPassword { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }

        public MailConfig(string receiver, string sender, string senderPassword, string host, int port) {
            Receiver = receiver;
            Sender = sender;
            SenderPassword = senderPassword;
            Host = host;
            Port = port;
        }

        public bool IsValid() {
            if (string.IsNullOrWhiteSpace(this.Receiver))
                return false;
            if (string.IsNullOrWhiteSpace(this.Sender))
                return false;
            if (string.IsNullOrWhiteSpace(this.SenderPassword))
                return false;
            if (string.IsNullOrWhiteSpace(this.Host))
                return false;
            if (Port.GetType() != typeof(Int32))
                return false;

            return true;
        }
    }
}
