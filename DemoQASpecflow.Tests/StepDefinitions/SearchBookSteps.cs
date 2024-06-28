using DemoQASpecflow.Tests.Pages;
using TechTalk.SpecFlow;

namespace DemoQASpecflow.Tests.StepDefinitions;

[Binding]
public sealed class SearchBookSteps
{
    private readonly ScenarioContext _scenarioContext;
    private readonly IBookStorePage _bookStorePage;
    public SearchBookSteps(ScenarioContext scenarioContext, ILoginPage loginPage, IBookStorePage bookStorePage)
    {
        _scenarioContext = scenarioContext;
        _bookStorePage = bookStorePage;
    }

    [Given(@"there are books named ""(.*)"" and ""(.*)""")]
    public async void GivenThereAreBooksNamedAnd(string p0, string p1)
    {
        await _bookStorePage.NavigateToBookStorePage();
        await _bookStorePage.GetAllBookNames();
    }

    [Given(@"the user is on Book Store page")]
    public void GivenTheUserIsOnBookStorePage()
    {
    }

    [When(@"the user input book name ""(.*)"" or ""(.*)""")]
    public void WhenTheUserInputBookNameOr(string design0, string design1)
    {
    }

    [Then(@"all books match with input criteria will be displayed")]
    public void ThenAllBooksMatchWithInputCriteriaWillBeDisplayed()
    {
    }
}