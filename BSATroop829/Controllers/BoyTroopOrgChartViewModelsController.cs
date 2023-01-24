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
    public class BoyTroopOrgChartViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BoyTroopOrgChartViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BoyTroopOrgChartViewModels
        public async Task<IActionResult> Index()
        {
            return _context.BoyTroopOrgChart != null ?
                        View(await _context.BoyTroopOrgChart.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.BoyTroopOrgChart'  is null.");
        }

        public async Task<IActionResult> BoyTroopOrgChart()
        {
            return _context.BoyTroopOrgChart != null ?
                        View(await _context.BoyTroopOrgChart.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.BoyTroopOrgChart'  is null.");
        }

        // GET: BoyTroopOrgChartViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BoyTroopOrgChart == null)
            {
                return NotFound();
            }

            var boyTroopOrgChartViewModel = await _context.BoyTroopOrgChart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boyTroopOrgChartViewModel == null)
            {
                return NotFound();
            }

            return View(boyTroopOrgChartViewModel);
        }

        // GET: BoyTroopOrgChartViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoyTroopOrgChartViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScoutMaster,AssistantScoutMaster,AssistantScoutMaster2,AssistantScoutMaster3,SeniorPatrolLeader,AssistantSeniorPatrolLeader,PatrolLeader,PatrolLeader2,PatrolLeader3,AssistantPatrolLeader,AssistantPatrolLeader2,AssistantPatrolLeader3,Quartermaster,Instructor,Bugler,Quartermaster,ChaplainAide,Librarian,Historian,Scribe")] BoyTroopOrgChartViewModel boyTroopOrgChartViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(boyTroopOrgChartViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boyTroopOrgChartViewModel);
        }

        // GET: BoyTroopOrgChartViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BoyTroopOrgChart == null)
            {
                return NotFound();
            }

            var boyTroopOrgChartViewModel = await _context.BoyTroopOrgChart.FindAsync(id);
            if (boyTroopOrgChartViewModel == null)
            {
                return NotFound();
            }
            return View(boyTroopOrgChartViewModel);
        }

        // POST: BoyTroopOrgChartViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScoutMaster,AssistantScoutMaster,AssistantScoutMaster2,AssistantScoutMaster3,SeniorPatrolLeader,AssistantSeniorPatrolLeader,PatrolLeader,PatrolLeader2,PatrolLeader3,AssistantPatrolLeader,AssistantPatrolLeader2,AssistantPatrolLeader3,Quartermaster,Instructor,Bugler,Quartermaster,ChaplainAide,Librarian,Historian,Scribe")] BoyTroopOrgChartViewModel boyTroopOrgChartViewModel)
        {
            if (id != boyTroopOrgChartViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boyTroopOrgChartViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoyTroopOrgChartViewModelExists(boyTroopOrgChartViewModel.Id))
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
            return View(boyTroopOrgChartViewModel);
        }

        // GET: BoyTroopOrgChartViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BoyTroopOrgChart == null)
            {
                return NotFound();
            }

            var boyTroopOrgChartViewModel = await _context.BoyTroopOrgChart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boyTroopOrgChartViewModel == null)
            {
                return NotFound();
            }

            return View(boyTroopOrgChartViewModel);
        }

        // POST: BoyTroopOrgChartViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BoyTroopOrgChart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.BoyTroopOrgChart'  is null.");
            }
            var boyTroopOrgChartViewModel = await _context.BoyTroopOrgChart.FindAsync(id);
            if (boyTroopOrgChartViewModel != null)
            {
                _context.BoyTroopOrgChart.Remove(boyTroopOrgChartViewModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoyTroopOrgChartViewModelExists(int id)
        {
            return (_context.BoyTroopOrgChart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
