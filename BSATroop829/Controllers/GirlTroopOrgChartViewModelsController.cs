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
    public class GirlTroopOrgChartViewModelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public GirlTroopOrgChartViewModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GirlTroopOrgChartViewModels
        public async Task<IActionResult> Index()
        {
              return _context.GirlTroopOrgChart != null ? 
                          View(await _context.GirlTroopOrgChart.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.GirlTroopOrgChart'  is null.");
        }
        public async Task<IActionResult> GirlTroopOrgChart()
        {
            return _context.GirlTroopOrgChart != null ?
                        View(await _context.GirlTroopOrgChart.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.GirlTroopOrgChart'  is null.");
        }

        // GET: GirlTroopOrgChartViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GirlTroopOrgChart == null)
            {
                return NotFound();
            }

            var girlTroopOrgChartViewModel = await _context.GirlTroopOrgChart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (girlTroopOrgChartViewModel == null)
            {
                return NotFound();
            }

            return View(girlTroopOrgChartViewModel);
        }

        // GET: GirlTroopOrgChartViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GirlTroopOrgChartViewModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ScoutMaster,AssistantScoutMaster,AssistantScoutMaster2,AssistantScoutMaster3,SeniorPatrolLeader,AssistantSeniorPatrolLeader,PatrolLeader,PatrolLeader2,PatrolLeader3,AssistantPatrolLeader,AssistantPatrolLeader2,AssistantPatrolLeader3,Quartermaster,Instructor,Bugler,Quartermaster,ChaplainAide,Librarian,Historian,Scribe")] GirlTroopOrgChartViewModel girlTroopOrgChartViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(girlTroopOrgChartViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(girlTroopOrgChartViewModel);
        }

        // GET: GirlTroopOrgChartViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GirlTroopOrgChart == null)
            {
                return NotFound();
            }

            var girlTroopOrgChartViewModel = await _context.GirlTroopOrgChart.FindAsync(id);
            if (girlTroopOrgChartViewModel == null)
            {
                return NotFound();
            }
            return View(girlTroopOrgChartViewModel);
        }

        // POST: GirlTroopOrgChartViewModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ScoutMaster,AssistantScoutMaster,AssistantScoutMaster2,AssistantScoutMaster3,SeniorPatrolLeader,AssistantSeniorPatrolLeader,PatrolLeader,PatrolLeader2,PatrolLeader3,AssistantPatrolLeader,AssistantPatrolLeader2,AssistantPatrolLeader3,Quartermaster,Instructor,Bugler,Quartermaster,ChaplainAide,Librarian,Historian,Scribe")] GirlTroopOrgChartViewModel girlTroopOrgChartViewModel)
        {
            if (id != girlTroopOrgChartViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(girlTroopOrgChartViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GirlTroopOrgChartViewModelExists(girlTroopOrgChartViewModel.Id))
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
            return View(girlTroopOrgChartViewModel);
        }

        // GET: GirlTroopOrgChartViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GirlTroopOrgChart == null)
            {
                return NotFound();
            }

            var girlTroopOrgChartViewModel = await _context.GirlTroopOrgChart
                .FirstOrDefaultAsync(m => m.Id == id);
            if (girlTroopOrgChartViewModel == null)
            {
                return NotFound();
            }

            return View(girlTroopOrgChartViewModel);
        }

        // POST: GirlTroopOrgChartViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GirlTroopOrgChart == null)
            {
                return Problem("Entity set 'ApplicationDbContext.GirlTroopOrgChart'  is null.");
            }
            var girlTroopOrgChartViewModel = await _context.GirlTroopOrgChart.FindAsync(id);
            if (girlTroopOrgChartViewModel != null)
            {
                _context.GirlTroopOrgChart.Remove(girlTroopOrgChartViewModel);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GirlTroopOrgChartViewModelExists(int id)
        {
          return (_context.GirlTroopOrgChart?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
