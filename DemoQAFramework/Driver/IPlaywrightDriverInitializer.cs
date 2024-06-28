using DemoQAFramework.Config;
using Microsoft.Playwright;

namespace DemoQAFramework.Driver;

public interface IPlaywrightDriverInitializer
{
    Task<IBrowser> GetChromeriverAsync(TestSettings testSettings);
    Task<IBrowser> GetChromiumDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetFirefoxDriverAsync(TestSettings testSettings);
    Task<IBrowser> GetWebkitDriverAsync(TestSettings testSettings);
}