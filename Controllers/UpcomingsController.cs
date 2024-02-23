using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class UpcomingsController : Controller
    {
        private readonly WebProjectContext _context;

        public UpcomingsController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: Upcomings
        public async Task<IActionResult> Index()
        {
            return _context.Upcomings != null ?
                        View(await _context.Upcomings.ToListAsync()) :
                        Problem("Entity set 'WebProjectContext.Upcomings'  is null.");
        }

        // GET: Upcomings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Upcomings == null)
            {
                return NotFound();
            }

            var upcoming = await _context.Upcomings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upcoming == null)
            {
                return NotFound();
            }

            return View(upcoming);
        }

        // GET: Upcomings/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SeriesName,Season,Episode,DurationTime,ReleaseDate")] Upcoming upcoming)
        {
            if (ModelState.IsValid)
            {
                _context.Add(upcoming);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(upcoming);
        }

        // GET: Upcomings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Upcomings == null)
            {
                return NotFound();
            }

            var upcoming = await _context.Upcomings.FindAsync(id);
            if (upcoming == null)
            {
                return NotFound();
            }
            return View(upcoming);
        }

        // POST: Upcomings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SeriesName,Season,Episode,DurationTime,ReleaseDate")] Upcoming upcoming)
        {
            if (id != upcoming.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(upcoming);
                    await _context.SaveChangesAsync();
                    TempData["keyMessage"] = "Record edited successfully";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UpcomingExists(upcoming.Id))
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
            return View(upcoming);
        }

        // GET: Upcomings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Upcomings == null)
            {
                return NotFound();
            }

            var upcoming = await _context.Upcomings
                .FirstOrDefaultAsync(m => m.Id == id);
            if (upcoming == null)
            {
                return NotFound();
            }

            return View(upcoming);
        }

        // POST: Upcomings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Upcomings == null)
            {
                return Problem("Entity set 'WebProjectContext.Upcomings'  is null.");
            }
            var upcoming = await _context.Upcomings.FindAsync(id);
            if (upcoming != null)
            {
                _context.Upcomings.Remove(upcoming);
            }

            await _context.SaveChangesAsync();
            TempData["keyMessage"] = "Record deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool UpcomingExists(int id)
        {
            return (_context.Upcomings?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}