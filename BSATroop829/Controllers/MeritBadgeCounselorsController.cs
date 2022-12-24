using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BSATroop829.Data;
using BSATroop829.Models;

namespace BSATroop829.Controllers
{
    public class MeritBadgeCounselorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MeritBadgeCounselorsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: MeritBadgeCounselorsViewModels
        public async Task<IActionResult> Index()
        {
            return _context.MeritBadgeCounselors != null ?
                        View(await _context.MeritBadgeCounselors.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.MeritBadgeCounselors'  is null.");
        }

        // GET: MeritBadgeCounselorsViewModels/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _context.MeritBadgeCounselors == null)
            {
                return NotFound();
            }

            var meritBadgeCounselorsViewModel = await _context.MeritBadgeCounselors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meritBadgeCounselorsViewModel == null)
            {
                return NotFound();
            }

            return View(meritBadgeCounselorsViewModel);
        }

        // GET: MeritBadgeCounselorsViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MeritBadgeCounselorsViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MeritBadgeName,CounselorName,CounselorPhoneNumber")] MeritBadgeCounselorsViewModel meritBadgeCounselorsViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(meritBadgeCounselorsViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(meritBadgeCounselorsViewModel);
        }

        // GET: MeritBadgeCounselorsViewModels/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _context.MeritBadgeCounselors == null)
            {
                return NotFound();
            }

            var meritBadgeCounselorsViewModel = await _context.MeritBadgeCounselors.FindAsync(id);
            if (meritBadgeCounselorsViewModel == null)
            {
                return NotFound();
            }
            return View(meritBadgeCounselorsViewModel);
        }

        // POST: MeritBadgeCounselorsViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MeritBadgeName,CounselorName,CounselorPhoneNumber")] MeritBadgeCounselorsViewModel meritBadgeCounselorsViewModel)
        {
            if (id != meritBadgeCounselorsViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(meritBadgeCounselorsViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MeritBadgeCounselorsViewModelExists(meritBadgeCounselorsViewModel.Id))
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
            return View(meritBadgeCounselorsViewModel);
        }

        // GET: MeritBadgeCounselorsViewModels/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _context.MeritBadgeCounselors == null)
            {
                return NotFound();
            }

            var meritBadgeCounselorsViewModel = await _context.MeritBadgeCounselors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (meritBadgeCounselorsViewModel == null)
            {
                return NotFound();
            }

            return View(meritBadgeCounselorsViewModel);
        }

        // POST: MeritBadgeCounselorsViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.MeritBadgeCounselors == null)
            {
                return Problem("Entity set 'ApplicationDbContext.MeritBadgeCounselors'  is null.");
            }
            var meritBadgeCounselorsViewModel = await _context.MeritBadgeCounselors.FindAsync(id);
            if (meritBadgeCounselorsViewModel != null)
            {
                _context.MeritBadgeCounselors.Remove(meritBadgeCounselorsViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeritBadgeCounselorsViewModelExists(int id)
        {
            return (_context.MeritBadgeCounselors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
