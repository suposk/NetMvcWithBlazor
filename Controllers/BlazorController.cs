using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetMvcWithBlazor.Models;

namespace NetMvcWithBlazor.Controllers
{
    public class BlazorController : Controller
    {
        private readonly ILogger<BlazorController> _logger;

        public BlazorController(ILogger<BlazorController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
