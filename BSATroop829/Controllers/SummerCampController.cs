using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
            ViewBag.DropdownItems = GetMeritBadgeInfo();
            ViewBag.SelectList = GetMeritBadgeSelectList();
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

        public List<MeritBadgesViewModel> GetMeritBadgeInfo()
        {
            return _db.MeritBadges.ToList();
        }

        public List<SelectListItem> GetMeritBadgeSelectList()
        {
            var meritBadges = _db.MeritBadges.ToList();
            var meritBadgeSelectList = new List<SelectListItem>();
            foreach (var meritBadge in meritBadges)
            {
                meritBadgeSelectList.Add(new SelectListItem
                {
                    Text = meritBadge.Name,
                    Value = meritBadge.Name
                });
            }
            return meritBadgeSelectList;
        }

    }
}
