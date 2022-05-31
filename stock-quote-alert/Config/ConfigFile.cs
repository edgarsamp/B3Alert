using Newtonsoft.Json;

namespace stock_quote_alert.Config {
    internal class ConfigFile {
        private readonly string _path;

        public ConfigFile(string path) {
            if (!File.Exists(path))
                throw new Exception("Config file not found.");
            _path = path;
        }

        public MailConfig LoadMailConfig() {

            StreamReader r = new(_path);
            string jsonString = r.ReadToEnd();
            var mailConfig = JsonConvert.DeserializeObject<MailConfig>(jsonString);

            if (!mailConfig.IsValid())
                throw new Exception("Config file is not valid.");

            return mailConfig;
        }
    }
}
