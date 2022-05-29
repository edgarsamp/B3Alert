using stock_quote_alert.Config;
using System.Net;
using System.Net.Mail;

namespace stock_quote_alert.Services {
    internal class MailSender {
        private readonly MailConfig _config;

        public MailSender(MailConfig config) {
            _config = config;
        }

        public void teste() {
            Console.WriteLine(_config.Sender);
            Console.WriteLine(_config.SenderPassword);
            Console.WriteLine(_config.Receiver);
            Console.WriteLine(_config.Host);
            Console.WriteLine(_config.Port);
        }
        public async Task SendAsync(string subject, string message) {
            try {
                MailMessage mail = new(_config.Sender, _config.Receiver, subject, message);

                SmtpClient client = new(_config.Host, _config.Port) {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Sender, _config.SenderPassword),
                    EnableSsl = true
                };
                await client.SendMailAsync(mail);


            } catch (Exception ex) {
                throw ex;
            }
        }
    }
}

