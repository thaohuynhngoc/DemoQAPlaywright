using DemoQAFramework.Config;
using DemoQAFramework.Driver;
using Microsoft.Playwright;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Infrastructure;

namespace DemoQASpecflow.Tests.Hooks;

[Binding]
public class Hooks
{
    private readonly Task<IPage> _page;
    private readonly Task<IAPIRequestContext> _apiRequestContext;
    private readonly Task<IBrowserContext> _browserContext;
    private readonly TestSettings _testSettings;
    private readonly ISpecFlowOutputHelper _outputHelper;

    public Hooks(IPlaywrightDriver playwrightDriver, TestSettings testSettings, ISpecFlowOutputHelper outputHelper)
    {
        _page = playwrightDriver.Page;
        _apiRequestContext = playwrightDriver.APIRequestContext;
        _browserContext = playwrightDriver.BrowserContext;
        _testSettings = testSettings;
        _outputHelper = outputHelper;
    }

    // [BeforeScenario("LoginAPI")]
    [BeforeScenario]
    public async Task BeforeScenario()
    {
        await Login();
        await (await _page).GotoAsync(_testSettings.ApplicationUrl, new() {Timeout = _testSettings.Timeout * 1000});
    }

    private async Task Login()
    {
        var credentialData = new Dictionary<string, object>() 
        {
            {"userName", "thaolearningplaywright"},
            {"password", "Pl@ywright123"}
        };

        var response = await (await _apiRequestContext).PostAsync("https://demoqa.com/Account/v1/Login", new() {DataObject = credentialData});
        var responseBody = await response.JsonAsync();
        
        string? token = responseBody?.GetProperty("token").ToString();
        string? userId = responseBody?.GetProperty("userId").ToString();
        string? username = responseBody?.GetProperty("username").ToString();
        string? expires = responseBody?.GetProperty("expires").ToString();

        var statusCode = response.Status;

        if (statusCode == 200)
        {
            await (await _page).Context.AddCookiesAsync(new []{
                new Cookie()
                {
                    Name = "userName",
                    Value = username,
                    Domain = "demoqa.com",
                    Path = "/"
                },
                new Cookie()
                {
                    Name = "userID",
                    Value = userId,
                    Domain = "demoqa.com",
                    Path = "/"
                },
                new Cookie()
                {
                    Name = "token",
                    Value = token,
                    Domain = "demoqa.com",
                    Path = "/"
                },
                new Cookie()
                {
                    Name = "expires",
                    Value = expires,
                    Domain = "demoqa.com",
                    Path = "/"
                }
            }
            );
        }

        _outputHelper.WriteLine($"Status code: {statusCode}");
    }

}