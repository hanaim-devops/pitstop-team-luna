namespace Pitstop.CustomerSupportAPI.Controllers;

[Route("api/[controller]")]
public class CustomerSupportController : Controller
{
    private readonly ICustomerSupportDataRepository _repo;

    public CustomerSupportController(ICustomerSupportDataRepository repo)
    {
        _repo = repo;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllAsync()
    {
        return Ok(await _repo.GetRejectionsAsync());
    }
}