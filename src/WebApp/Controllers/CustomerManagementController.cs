using System.Diagnostics;

namespace PitStop.WebApp.Controllers;

public class CustomerManagementController : Controller
{
    private readonly ICustomerManagementAPI _customerManagementAPI;
    private readonly Microsoft.Extensions.Logging.ILogger _logger;
    private ResiliencyHelper _resiliencyHelper;
    private readonly ActivitySource _activitySource = new ActivitySource("test-source");

    public CustomerManagementController(ICustomerManagementAPI customerManagementAPI, ILogger<CustomerManagementController> logger)
    {
        _customerManagementAPI = customerManagementAPI;
        _logger = logger;
        _resiliencyHelper = new ResiliencyHelper(_logger);
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        using (var activity = _activitySource.StartActivity("YourAction"))
        {
            activity?.SetTag("your-tag", "value");
            return await _resiliencyHelper.ExecuteResilient(async () =>
        {
            var model = new CustomerManagementViewModel
            {
                Customers = await _customerManagementAPI.GetCustomers()
            };
            return View(model);
        }, View("Offline", new CustomerManagementOfflineViewModel()));
        }
    }

    [HttpGet]
    public async Task<IActionResult> Details(string id)
    {
        return await _resiliencyHelper.ExecuteResilient(async () =>
        {
            var model = new CustomerManagementDetailsViewModel
            {
                Customer = await _customerManagementAPI.GetCustomerById(id)
            };
            return View(model);
        }, View("Offline", new CustomerManagementOfflineViewModel()));
    }

    [HttpGet]
    public IActionResult New()
    {
        var model = new CustomerManagementNewViewModel
        {
            Customer = new Customer()
        };
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromForm] CustomerManagementNewViewModel inputModel)
    {
        if (ModelState.IsValid)
        {
            return await _resiliencyHelper.ExecuteResilient(async () =>
            {
                RegisterCustomer cmd = inputModel.MapToRegisterCustomer();
                await _customerManagementAPI.RegisterCustomer(cmd);
                return RedirectToAction("Index");
            }, View("Offline", new CustomerManagementOfflineViewModel()));
        }
        else
        {
            return View("New", inputModel);
        }
    }
}