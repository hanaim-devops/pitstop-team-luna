namespace IntegrationTests.Services;

public class MockDataService
{
    private readonly List<Rejection> _rejections =
    [
        new(Guid.NewGuid(), "Reason 1", DateTime.Now),
        new(Guid.NewGuid(), "Reason 2", DateTime.Now)
    ];

    public Task<IEnumerable<Rejection>> GetRejectionsAsync()
    {
        return Task.FromResult<IEnumerable<Rejection>>(_rejections);
    }
}