using DemoQAFramework.Driver;
using Microsoft.Playwright;

namespace DemoQASpecflow.Tests.Pages;

public interface IBookStorePage
{
    Task NavigateToBookStorePage();
    Task<IEnumerable<string>> GetAllBookNames();
}

public class BookStorePage : IBookStorePage
{
    private IPage _page;
    private const string BOOKSTORE_URL = "https://demoqa.com/books";
    private ILocator _lnkBookNames => _page.Locator(".rt-tbody a");

    public BookStorePage(IPlaywrightDriver playwrightDriver)
    {
        _page = playwrightDriver.Page.Result;
    }

    public async Task NavigateToBookStorePage()
    {
        await _page.GotoAsync(BOOKSTORE_URL);
    }

    public async Task<IEnumerable<string>> GetAllBookNames()
    {
        List<string> listOfBookName = new List<string>();

        var test = await _lnkBookNames.CountAsync();
        return listOfBookName;
    }

}