namespace Pitstop.CustomerSupportAPI.Repositories;

public interface ICustomerSupportDataRepository
{
    public Task<IEnumerable<Rejection>> GetRejectionsAsync();
}