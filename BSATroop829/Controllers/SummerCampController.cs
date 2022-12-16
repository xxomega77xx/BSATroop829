using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Mvc;

namespace BSATroop829.Controllers
{
    public class SummerCampController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SummerCampController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<SummerCampViewModel> objList = _db.SummerCamp;
            return View(objList);
        }
        //GET
        public IActionResult Create()
        {
            return View();
        }
    }
}
