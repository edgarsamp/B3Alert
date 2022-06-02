using stock_quote_alert.Config;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;

namespace stock_quote_alert.Services {
    internal class MailSender {
        private readonly MailConfig _config;
        public MailSender(MailConfig config) {
            _config = config;
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
            } catch (Exception) {
                throw;
            }
        }
        public async Task SendWithImageAsync(string subject, string message, string imagePath) {
            try {
                MailMessage mail = new(_config.Sender, _config.Receiver, subject, message) {
                    IsBodyHtml = true
                };
                if (File.Exists(imagePath)) {
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(
                                               message,
                                               Encoding.UTF8,
                                               MediaTypeNames.Text.Html);

                    string mediaType = MediaTypeNames.Image.Jpeg;
                    LinkedResource img = new(imagePath, mediaType);
                    img.ContentId = "GraphStockPrice";
                    img.ContentType.MediaType = mediaType;
                    img.TransferEncoding = TransferEncoding.Base64;
                    img.ContentType.Name = img.ContentId;
                    img.ContentLink = new Uri("img:" + img.ContentId);

                    htmlView.LinkedResources.Add(img);


                    mail.AlternateViews.Add(htmlView);
                }

                SmtpClient client = new(_config.Host, _config.Port) {
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.Sender, _config.SenderPassword),
                    EnableSsl = true
                };

                await client.SendMailAsync(mail);
            } catch (Exception) {
                throw;
            }
        }
    }
}

