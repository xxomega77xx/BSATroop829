using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BSATroop829.Controllers
{
    [Authorize(Roles ="User")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        #region BoyTroop
        public IActionResult BoyTroop()
        {
            return View();
        }
        public IActionResult BoyTroopCal()
        {
            return View();
        }
        public IActionResult BoyTroopOrgChart()
        {
            return View();
        }
        #endregion BoyTroop

        #region GirlTroop
        public IActionResult GirlTroop()
        {
            return View();
        }
        public IActionResult GirlTroopCal()
        {
            return View();
        }
        public IActionResult GirlTroopOrgChart()
        {
            return View();
        }

        #endregion GirlTroop
        
        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }
        
        public IActionResult Details()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Credits()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult FAQ()
        {
            return View();
        }

        public IActionResult FinancialAidForm()
        {
            return View();
        }
        
        public IActionResult ReimbursementForm()
        {
            return View();
        }

        public IActionResult MeritBadgeCollegeRegistrationForm()
        {
            return View();
        }

        public IActionResult EventDueDates()
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