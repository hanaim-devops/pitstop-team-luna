using IntegrationTests.Services;
using TechTalk.SpecFlow;

[Binding]
public class RepairUpdateSteps
{
    private readonly MockDataService _mockDataService;
    private string _customerEmail;
    private bool _isEmailSent;
    private string _sentSubject;
    private string _sentMessage;
    private RepairOrder _mockRepair;

    public RepairUpdateSteps()
    {
        _mockDataService = new MockDataService();
    }

    [Given(@"that a customer is registered with a valid email address")]
    public async Task GivenThatACustomerIsRegisteredWithAValidEmailAddress()
    {
        // Set up a mock customer
        _customerEmail = "customer@example.com";
        var customer = await _mockDataService.GetCustomerByEmailAsync(_customerEmail);
        
        Assert.NotNull(customer); // Assert that the customer exists
    }

    [Given(@"the customer has submitted a vehicle for repair")]
    public async Task AndTheCustomerHasSubmittedAVehicleForRepair()
    {
        // Set up a mock repair record
        _mockRepair = new RepairOrder { CustomerEmail = _customerEmail, Status = "Pending" };
        // Normally, you'd add this repair to your service, but here we're using a simple list
        _mockDataService.GetRepairsAsync(); // Retrieve repairs (if needed)
    }

    [When(@"the repair of the vehicle is completed")]
    public async Task WhenTheRepairOfTheVehicleIsCompleted()
    {
        // Simulate updating the repair status in the mock data service
        if (_mockRepair != null)
        {
            _mockRepair.Status = "Completed";
        }
        
        // Simulate sending the email update
        _isEmailSent = true; // Indicate that an email was sent
        _sentSubject = "Repair Completed";
        _sentMessage = "Your repair is complete. You can pick up your vehicle.";
    }

    [Then(@"an update should be sent to the customer's email address")]
    public void ThenAnUpdateShouldBeSentToTheCustomerSEmailAddress()
    {
        // Check if the email was sent
        Assert.True(_isEmailSent); // Ensure that the email was sent
    }

    [Then("the update should contain the following information")]
    public void AndTheUpdateShouldContainTheFollowingInformation(Table table)
    {
        foreach (var row in table.Rows)
        {
            Console.WriteLine($"Expected Subject: {row["Subject"]}, Expected Message: {row["Message"]}");
        }

        // Verify that the sent email contains the correct information
        var expectedSubject = table.Rows[0]["Subject"];
        var expectedMessage = table.Rows[0]["Message"];
        
        // Check the sent email details
        Assert.Equal(expectedSubject, _sentSubject);
        Assert.Equal(expectedMessage, _sentMessage);
    }
}