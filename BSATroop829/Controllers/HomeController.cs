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
        
        public async Task<IActionResult> EaglesAsync(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ScoutName" : "";
            var Scouts = from s in _db.TroopEagles
                         select s;
            switch (sortOrder)
            {
                case "ScoutName":
                    Scouts = Scouts.OrderByDescending(s => s.ScoutName);
                    break;
            }
            return View(await Scouts.ToListAsync());
        }
        
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

        public IActionResult FAQ()
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