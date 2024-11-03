namespace IntegrationTests.Services;

public class MockDataService
{
    private readonly List<Customer> _customers = new List<Customer>
    {
        new Customer { EmailAddress = "customer@example.com", Name = "John Doe" },
    };

    private readonly List<RepairOrder> _repairs = new List<RepairOrder>
    {
        new RepairOrder { CustomerEmail = "customer@example.com", Status = "Pending" },
    };

    private readonly List<Rejection> _rejections = new List<Rejection>
    {
        new Rejection(Guid.NewGuid(), "Reason 1", DateTime.Now),
        new Rejection(Guid.NewGuid(), "Reason 2", DateTime.Now)
    };

    public Task<IEnumerable<RepairOrder>> GetRepairsAsync()
    {
        return Task.FromResult<IEnumerable<RepairOrder>>(_repairs);
    }

    public Task<Customer> GetCustomerByEmailAsync(string email)
    {
        var customer = _customers.FirstOrDefault(c => c.EmailAddress == email);
        return Task.FromResult(customer);
    }

    public Task<IEnumerable<Rejection>> GetRejectionsAsync()
    {
        return Task.FromResult<IEnumerable<Rejection>>(_rejections);
    }
}