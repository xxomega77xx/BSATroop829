using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BSATroop829.Controllers
{
    public class SummerCampController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SummerCampController(ApplicationDbContext db)
        {
            _db = db;
        }
        
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["NameSortParm"] = String.IsNullOrEmpty(sortOrder) ? "ScoutName" : "";
            var Scouts = from s in _db.SummerCamp
                         select s;
            switch (sortOrder)
            {
                case "ScoutName":
                    Scouts = Scouts.OrderByDescending(s => s.ScoutName);
                    break;
            }
            return View(await Scouts.ToListAsync());
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
        [Authorize(Roles = "Activities Coordinator,ScoutMaster,AsstScoutMaster,Commitee,Admin,SuperAdmin")]
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
        [Authorize(Roles = "Activities Coordinator, ScoutMaster, AsstScoutMaster,Commitee,Admin,SuperAdmin")]
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
