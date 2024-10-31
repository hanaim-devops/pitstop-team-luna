namespace Pitstop.CustomerSupportService.Repositories;

public interface ICustomerSupportRepository
{
    Task RegisterRejectionAsync(Rejection rejection);
}