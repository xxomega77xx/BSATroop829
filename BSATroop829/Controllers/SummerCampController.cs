using BSATroop829.Data;
using BSATroop829.Models;
using BSATroop829.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BSATroop829.Controllers
{
    public class SummerCampController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly LogService _logService;

        public SummerCampController(ApplicationDbContext db, LogService logService)
        {
            _db = db;
            _logService = logService;
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
            var items = new List<SelectListItem>
            {
                new SelectListItem { Value = "American Cultures", Text = "American Cultures" },
                new SelectListItem { Value = "American Heritage", Text = "American Heritage" },
                new SelectListItem { Value = "Animation", Text = "Animation" },
                new SelectListItem { Value = "Archery", Text = "Archery" },
                new SelectListItem { Value = "Art", Text = "Art" },
                new SelectListItem { Value = "Astronomy", Text = "Astronomy" },
                new SelectListItem { Value = "Automotive Maintenance", Text = "Automotive Maintenance" },
                new SelectListItem { Value = "Backpacking", Text = "Backpacking" },
                new SelectListItem { Value = "Basketry", Text = "Basketry" },
                new SelectListItem { Value = "Bird Study", Text = "Bird Study" },
                new SelectListItem { Value = "Camping ", Text = "Camping " },
                new SelectListItem { Value = "Canoeing", Text = "Canoeing" },
                new SelectListItem { Value = "Chemistry", Text = "Chemistry" },
                new SelectListItem { Value = "Chess", Text = "Chess" },
                new SelectListItem { Value = "Citizenship In The Nation ", Text = "Citizenship In The Nation " },
                new SelectListItem { Value = "Citizenship In The World ", Text = "Citizenship In The World " },
                new SelectListItem { Value = "Climbing", Text = "Climbing" },
                new SelectListItem { Value = "Cooking ", Text = "Cooking " },
                new SelectListItem { Value = "Cycling ", Text = "Cycling " },
                new SelectListItem { Value = "Electricity", Text = "Electricity" },
                new SelectListItem { Value = "Emergency Preparedness ", Text = "Emergency Preparedness " },
                new SelectListItem { Value = "Environmental Science ", Text = "Environmental Science " },
                new SelectListItem { Value = "First Aid ", Text = "First Aid " },
                new SelectListItem { Value = "Fishing", Text = "Fishing" },
                new SelectListItem { Value = "Forestry", Text = "Forestry" },
                new SelectListItem { Value = "Game Design", Text = "Game Design" },
                new SelectListItem { Value = "Geology", Text = "Geology" },
                new SelectListItem { Value = "Hiking ", Text = "Hiking " },
                new SelectListItem { Value = "Home Repairs", Text = "Home Repairs" },
                new SelectListItem { Value = "Indian Lore", Text = "Indian Lore" },
                new SelectListItem { Value = "Kayaking", Text = "Kayaking" },
                new SelectListItem { Value = "Lifesaving ", Text = "Lifesaving " },
                new SelectListItem { Value = "Mammal Study", Text = "Mammal Study" },
                new SelectListItem { Value = "Metalwork", Text = "Metalwork" },
                new SelectListItem { Value = "Music", Text = "Music" },
                new SelectListItem { Value = "Nature", Text = "Nature" },
                new SelectListItem { Value = "Oceanography", Text = "Oceanography" },
                new SelectListItem { Value = "Orienteering", Text = "Orienteering" },
                new SelectListItem { Value = "Painting", Text = "Painting" },
                new SelectListItem { Value = "Photography", Text = "Photography" },
                new SelectListItem { Value = "Plant Science", Text = "Plant Science" },
                new SelectListItem { Value = "Plumbing", Text = "Plumbing" },
                new SelectListItem { Value = "Pottery", Text = "Pottery" },
                new SelectListItem { Value = "Public Speaking", Text = "Public Speaking" },
                new SelectListItem { Value = "Radio", Text = "Radio" },
                new SelectListItem { Value = "Reptile And Amphibian Study", Text = "Reptile And Amphibian Study" },
                new SelectListItem { Value = "Rifle Shooting", Text = "Rifle Shooting" },
                new SelectListItem { Value = "Rowing", Text = "Rowing" },
                new SelectListItem { Value = "Scouting Heritage", Text = "Scouting Heritage" },
                new SelectListItem { Value = "Scuba Diving", Text = "Scuba Diving" },
                new SelectListItem { Value = "Sculpture", Text = "Sculpture" },
                new SelectListItem { Value = "Search And Rescue", Text = "Search And Rescue" },
                new SelectListItem { Value = "Shotgun Shooting", Text = "Shotgun Shooting" },
                new SelectListItem { Value = "Signs, Signals, And Codes", Text = "Signs, Signals, And Codes" },
                new SelectListItem { Value = "Small-Boat Sailing", Text = "Small-Boat Sailing" },
                new SelectListItem { Value = "Soil And Water Conservation", Text = "Soil And Water Conservation" },
                new SelectListItem { Value = "Space Exploration", Text = "Space Exploration" },
                new SelectListItem { Value = "Swimming ", Text = "Swimming " },
                new SelectListItem { Value = "Textile", Text = "Textile" },
                new SelectListItem { Value = "Traffic Safety", Text = "Traffic Safety" },
                new SelectListItem { Value = "Weather", Text = "Weather" },
                new SelectListItem { Value = "Wilderness Survival", Text = "Wilderness Survival" },
                new SelectListItem { Value = "Wood Carving", Text = "Wood Carving" }
            };
            ViewBag.DropdownItems = items;
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
                _logService.Log(User.Identity.Name, "added a new scout to the summer camp roster for " + obj.ScoutName);
                return RedirectToAction("Index");
            }
            return View(obj);
        }

        //GET
        [Authorize(Roles = "Activities Coordinator,ScoutMaster,AsstScoutMaster,Committee Member,Admin,SuperAdmin")]
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
                _logService.Log(User.Identity.Name, "updated a scout's information on the summer camp roster for " + obj.ScoutName);
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        //GET
        [Authorize(Roles = "Activities Coordinator, ScoutMaster, AsstScoutMaster,Committee Member,Admin,SuperAdmin")]
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
            _logService.Log(User.Identity.Name, "removed a scout from the summer camp roster for " + obj.ScoutName);
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
                    Value = meritBadge.Id.ToString()
                });
            }
            return meritBadgeSelectList;
        }

    }
}
