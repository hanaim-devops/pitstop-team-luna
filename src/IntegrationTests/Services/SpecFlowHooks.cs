using BoDi;
using TechTalk.SpecFlow;

namespace IntegrationTests.Services;

[Binding]
public class SpecFlowHooks(IObjectContainer objectContainer)
{
    [BeforeScenario]
    public void RegisterServices()
    {
        objectContainer.RegisterInstanceAs(new MockDataService());
    }
}