using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BSATroop829.Data;
using BSATroop829.Models;

namespace BSATroop829.Controllers
{
    public class LoggingController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LoggingController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Logging
        public async Task<IActionResult> Index()
        {
              return _context.LogEnties != null ? 
                          View(await _context.LogEnties.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.LogEnties'  is null.");
        }

        // GET: Logging/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LogEnties == null)
            {
                return NotFound();
            }

            var loggingViewModel = await _context.LogEnties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loggingViewModel == null)
            {
                return NotFound();
            }

            return View(loggingViewModel);
        }

        // GET: Logging/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Logging/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Action,TimeStamp")] LoggingViewModel loggingViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loggingViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loggingViewModel);
        }

        // GET: Logging/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LogEnties == null)
            {
                return NotFound();
            }

            var loggingViewModel = await _context.LogEnties.FindAsync(id);
            if (loggingViewModel == null)
            {
                return NotFound();
            }
            return View(loggingViewModel);
        }

        // POST: Logging/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Action,TimeStamp")] LoggingViewModel loggingViewModel)
        {
            if (id != loggingViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loggingViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoggingViewModelExists(loggingViewModel.Id))
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
            return View(loggingViewModel);
        }

        // GET: Logging/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LogEnties == null)
            {
                return NotFound();
            }

            var loggingViewModel = await _context.LogEnties
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loggingViewModel == null)
            {
                return NotFound();
            }

            return View(loggingViewModel);
        }

        // POST: Logging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LogEnties == null)
            {
                return Problem("Entity set 'ApplicationDbContext.LogEnties'  is null.");
            }
            var loggingViewModel = await _context.LogEnties.FindAsync(id);
            if (loggingViewModel != null)
            {
                _context.LogEnties.Remove(loggingViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoggingViewModelExists(int id)
        {
          return (_context.LogEnties?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
