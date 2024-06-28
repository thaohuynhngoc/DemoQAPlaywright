using DemoQAFramework.Driver;

namespace DemoQAFramework.Config;

public class TestSettings
{
    public DriverType DriverType { get; set; }
        public string ApplicationUrl { get; set; }
        public string[]? Args { get; set; }
        public float? Timeout = PlaywrightDriverInitializer.DEFAULT_TIMEOUT;
        public bool? Headless { get; set; }
        public float? SlowMo { get; set; }
}

public enum DriverType
    {
        Chrome,
        Firefox,
        WebKit,
        Chromium,
        Opera
    }