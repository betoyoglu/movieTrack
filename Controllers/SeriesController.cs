using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebProject.Data;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class SeriesController : Controller
    {
        private readonly ApplicationDbCon _context;

        public SeriesController(ApplicationDbCon context)
        {
            _context = context;
        }

        // GET: Series
        public async Task<IActionResult> Index()
        {
              return _context.Seriess != null ? 
                          View(await _context.Seriess.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbCon.Seriess'  is null.");
        }

        // GET: Series/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Seriess == null)
            {
                return NotFound();
            }

            var series = await _context.Seriess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // GET: Series/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Series/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Genre,OriginalLanguage")] Series series)
        {
            if (ModelState.IsValid)
            {
                _context.Add(series);
                await _context.SaveChangesAsync();
                TempData["keyMessage"] = "Record created successfully..";
                return RedirectToAction(nameof(Index));
            }
            return View(series);
        }

        // GET: Series/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Seriess == null)
            {
                return NotFound();
            }

            var series = await _context.Seriess.FindAsync(id);
            if (series == null)
            {
                return NotFound();
            }
            return View(series);
        }

        // POST: Series/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Genre,OriginalLanguage")] Series series)
        {
            if (id != series.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(series);
                    await _context.SaveChangesAsync();
                    TempData["keyMessage"] = "Record edited successfully..";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeriesExists(series.Id))
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
            return View(series);
        }

        // GET: Series/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Seriess == null)
            {
                return NotFound();
            }

            var series = await _context.Seriess
                .FirstOrDefaultAsync(m => m.Id == id);
            if (series == null)
            {
                return NotFound();
            }

            return View(series);
        }

        // POST: Series/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Seriess == null)
            {
                return Problem("Entity set 'ApplicationDbCon.Seriess'  is null.");
            }
            var series = await _context.Seriess.FindAsync(id);
            if (series != null)
            {
                _context.Seriess.Remove(series);
            }
            
            await _context.SaveChangesAsync();
            TempData["keyMessage"]="Record deleted successfully..";
            return RedirectToAction(nameof(Index));
        }

        private bool SeriesExists(int id)
        {
          return (_context.Seriess?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
