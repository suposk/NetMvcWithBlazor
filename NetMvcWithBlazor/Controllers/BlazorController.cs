using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetMvcWithBlazor.Models;

namespace NetMvcWithBlazor.Controllers
{
    public class BlazorController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlazorController> _logger;

        [ViewData]
        public bool IsBlazorEnabled { get; init; }

        public BlazorController(
            IConfiguration configuration,
            ILogger<BlazorController> logger
            )
        {
            _configuration = configuration;
            _logger = logger;
            IsBlazorEnabled = _configuration.GetValue<bool>("IsBlazorEnabled");
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult NotWorking()
        {
            return View(); //does not work, must be Index always for blazor
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
