using IntegrationTests.Services;
using TechTalk.SpecFlow;

namespace IntegrationTests.Steps;

[Binding]
public class CustomerSupportSteps(MockDataService mockDataService)
{
    private IEnumerable<Rejection> _rejections = [];

    [Given("I have a customer support data repository")]
    public void GivenIHaveACustomerSupportDataRepository()
    {
        // No setup needed as the mock data service is already provided
    }

    [When("I request all rejections")]
    public async Task WhenIRequestAllRejections()
    {
        _rejections = await mockDataService.GetRejectionsAsync();
    }

    [Then("I should receive a list of rejections")]
    public void ThenIShouldReceiveAListOfRejections()
    {
        Assert.NotNull(_rejections);
        Assert.NotEmpty(_rejections);
    }
}