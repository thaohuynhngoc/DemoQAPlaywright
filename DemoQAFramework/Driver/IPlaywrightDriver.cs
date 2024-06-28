using Microsoft.Playwright;

namespace DemoQAFramework.Driver;

public interface IPlaywrightDriver
{
    Task<IBrowser> Browser { get; }
    Task<IBrowserContext> BrowserContext { get; }
    Task<IPage> Page { get; }
    Task<IAPIRequestContext> APIRequestContext { get; }
}