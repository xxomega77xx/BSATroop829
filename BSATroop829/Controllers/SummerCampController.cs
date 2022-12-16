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
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SummerCampViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.SummerCamp.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Scout information created successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.SummerCamp.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SummerCampViewModel obj)
        {
            if (ModelState.IsValid)
            {
                _db.SummerCamp.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Scout information updated successfully.";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.SummerCamp.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.SummerCamp.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            _db.SummerCamp.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Scout information removed successfully.";
            return RedirectToAction("Index");
        }
    }
}
