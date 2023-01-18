using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSATroop829.Data;
using BSATroop829.Models;
using Microsoft.AspNetCore.Authorization;

namespace BSATroop829.Controllers
{
    [Authorize]
    public class TroopEaglesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TroopEaglesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TroopEagles
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
              return _context.TroopEagles != null ? 
                          View(await _context.TroopEagles.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TroopEagles'  is null.");
        }

        // GET: TroopEagles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TroopEagles == null)
            {
                return NotFound();
            }

            var troopEaglesViewModel = await _context.TroopEagles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (troopEaglesViewModel == null)
            {
                return NotFound();
            }

            return View(troopEaglesViewModel);
        }

        // GET: TroopEagles/Create
        [Authorize(Roles = "Activities Coordinator,ScoutMaster,AsstScoutMaster,Commitee Member,Admin,SuperAdmin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: TroopEagles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScoutName,Troop,BoardofReviewDate")] TroopEaglesViewModel troopEaglesViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(troopEaglesViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(troopEaglesViewModel);
        }

        // GET: TroopEagles/Edit/5
        [Authorize(Roles = "Activities Coordinator,ScoutMaster,AsstScoutMaster,Commitee Member,Admin,SuperAdmin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TroopEagles == null)
            {
                return NotFound();
            }

            var troopEaglesViewModel = await _context.TroopEagles.FindAsync(id);
            if (troopEaglesViewModel == null)
            {
                return NotFound();
            }
            return View(troopEaglesViewModel);
        }

        // POST: TroopEagles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScoutName,Troop,BoardofReviewDate")] TroopEaglesViewModel troopEaglesViewModel)
        {
            if (id != troopEaglesViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(troopEaglesViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TroopEaglesViewModelExists(troopEaglesViewModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(troopEaglesViewModel);
        }

        // GET: TroopEagles/Delete/5
        [Authorize(Roles = "Activities Coordinator,ScoutMaster,AsstScoutMaster,Commitee Member,Admin,SuperAdmin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TroopEagles == null)
            {
                return NotFound();
            }

            var troopEaglesViewModel = await _context.TroopEagles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (troopEaglesViewModel == null)
            {
                return NotFound();
            }

            return View(troopEaglesViewModel);
        }

        // POST: TroopEagles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TroopEagles == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TroopEagles'  is null.");
            }
            var troopEaglesViewModel = await _context.TroopEagles.FindAsync(id);
            if (troopEaglesViewModel != null)
            {
                _context.TroopEagles.Remove(troopEaglesViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TroopEaglesViewModelExists(int id)
        {
          return (_context.TroopEagles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
