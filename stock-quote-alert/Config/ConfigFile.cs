using Newtonsoft.Json;

namespace stock_quote_alert.Config;
public class ConfigFile {

    private static GeneralConfig? _config = null;
    public static GeneralConfig Config { get => _config; }

    public static void LoadConfig(string path) {
        if (_config != null) return;
        if (!File.Exists(path))
            throw new Exception("Config file not found.");

        StreamReader r = new(path);
        string jsonString = r.ReadToEnd();
        try {
            var config = JsonConvert.DeserializeObject<GeneralConfig>(jsonString);
            if (!config.MailConfig.IsValid())
                throw new Exception("Config file is not valid.");
            _config = config;
        } catch {
            throw new Exception("Config file is not valid.");
        }
    }
}
