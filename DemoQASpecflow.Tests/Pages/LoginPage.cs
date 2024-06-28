using DemoQAFramework.Driver;
using Microsoft.Playwright;

namespace DemoQASpecflow.Tests.Pages;

public interface ILoginPage
{
    Task NavigateToLoginPage();
    Task Login(string username, string password);
}

public class LoginPage : ILoginPage
{
    private IPage _page;
    private const string LOGIN_URL = "https://demoqa.com/login";
    public LoginPage(IPlaywrightDriver playwrightDriver)
    {
        _page = playwrightDriver.Page.Result;
    }

    private ILocator _txtUserName => _page.GetByLabel("UserName :");
    private ILocator _txtPassword => _page.GetByLabel("Password :");
    private ILocator _btnLogin => _page.GetByRole(AriaRole.Button, new() { Name = "Login" } );

    public async Task NavigateToLoginPage()
    {
        await _page.GotoAsync(LOGIN_URL);
    }

    public async Task Login(string username, string password)
    {
        await _txtUserName.FillAsync(username);
        await _txtPassword.FillAsync(password);

        await _btnLogin.ClickAsync();
    }
}