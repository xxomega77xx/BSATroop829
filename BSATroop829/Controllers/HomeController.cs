using BSATroop829.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BSATroop829.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult BoyTroop()
        {
            return View();
        }
        public IActionResult BoyTroopCal()
        {
            return View();
        }
        public IActionResult BoyTroopPhotos()
        {
            return View();
        }
        public IActionResult BoyTroopOrgChart()
        {
            return View();
        }

        public IActionResult GirlTroop()
        {
            return View();
        }
        public IActionResult GirlTroopCal()
        {
            return View();
        }
        public IActionResult GirlTroopPhotos()
        {
            return View();
        }
        public IActionResult GirlTroopOrgChart()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}