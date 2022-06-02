using stock_quote_alert;
using stock_quote_alert.Config;
using stock_quote_alert.Services;

namespace unit_test_stock_quote_alert;
[TestClass]
public class StockQuoteAlertTests {

    [TestMethod]
    public void TestSizeArgsParameters() {
        var path = "./configs/configRight.json";

        string[] argsTest = { "petr4", "10" };
        var Throws = Assert.ThrowsException<Exception>(() => {
            ConfigFile.LoadConfig(path);
            var alert = new StockQuoteAlert(argsTest);
        });

        Assert.AreEqual(Throws.Message, "Parameters is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutConfigFile() {
        var path = "./configs/dontExist.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file not found.");
    }

    [TestMethod]
    public void TestConfigWithoutSender() {
        var path = "./configs/configWithoutSender.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutSenderPassword() {
        var path = "./configs/configWithoutSenderPassword.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutHost() {
        var path = "./configs/configWithoutHost.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutPort() {
        var path = "./configs/configWithoutPort.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }


    [TestMethod]
    public void TestConfigWithoutCanSendReportEmail() {
        var path = "./configs/configWithoutCanSendReportEmail.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutReceiver() {
        var path = "./configs/configWithoutReceiver.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }

    [TestMethod]
    public void TestConfigWithoutConfigWithoutDelayToRequest() {
        var path = "./configs/configWithoutDelayToRequest.json";
        var Throws = Assert.ThrowsException<Exception>(() => ConfigFile.LoadConfig(path));

        Assert.AreEqual(Throws.Message, "Config file is not valid.");
    }


}
