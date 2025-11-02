using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetMvcWithBlazor.Models;

namespace NetMvcWithBlazor.Controllers
{
    public class BlazorViewController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<BlazorViewController> _logger;

        [ViewData]
        public bool IsBlazorEnabled { get; init; }

        public BlazorViewController(
            IConfiguration configuration,
            ILogger<BlazorViewController> logger
            )
        {
            _configuration = configuration;
            _logger = logger;
            IsBlazorEnabled = _configuration.GetValue<bool>("IsBlazorEnabled");
        }

        //public IActionResult Importer()
        public IActionResult Index()
        {
            return View("~/Views/BlazorView/Importer.cshtml");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
