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
    public class MovieNameDirectorsController : Controller
    {
        private readonly WebProjectContext _context;

        public MovieNameDirectorsController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: MovieNameDirectors
        public async Task<IActionResult> Index()
        {
            return _context.MovieNameDirectors != null ?
                        View(await _context.MovieNameDirectors.ToListAsync()) :
                        Problem("Entity set 'WebProjectContext.MovieNameDirectors'  is null.");
        }

        // GET: MovieNameDirectors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.MovieNameDirectors == null)
            {
                return NotFound();
            }

            var movieNameDirector = await _context.MovieNameDirectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieNameDirector == null)
            {
                return NotFound();
            }

            return View(movieNameDirector);
        }

        // GET: MovieNameDirectors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MovieNameDirectors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MovieName,MovieDirector")] MovieNameDirector movieNameDirector)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movieNameDirector);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movieNameDirector);
        }

        // GET: MovieNameDirectors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.MovieNameDirectors == null)
            {
                return NotFound();
            }

            var movieNameDirector = await _context.MovieNameDirectors.FindAsync(id);
            if (movieNameDirector == null)
            {
                return NotFound();
            }
            return View(movieNameDirector);
        }

        // POST: MovieNameDirectors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MovieName,MovieDirector")] MovieNameDirector movieNameDirector)
        {
            if (id != movieNameDirector.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movieNameDirector);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieNameDirectorExists(movieNameDirector.Id))
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
            return View(movieNameDirector);
        }

        // GET: MovieNameDirectors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.MovieNameDirectors == null)
            {
                return NotFound();
            }

            var movieNameDirector = await _context.MovieNameDirectors
                .FirstOrDefaultAsync(m => m.Id == id);
            if (movieNameDirector == null)
            {
                return NotFound();
            }

            return View(movieNameDirector);
        }

        // POST: MovieNameDirectors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.MovieNameDirectors == null)
            {
                return Problem("Entity set 'WebProjectContext.MovieNameDirectors'  is null.");
            }
            var movieNameDirector = await _context.MovieNameDirectors.FindAsync(id);
            if (movieNameDirector != null)
            {
                _context.MovieNameDirectors.Remove(movieNameDirector);
            }

            await _context.SaveChangesAsync();
            TempData["keyMessage"] = "Record deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool MovieNameDirectorExists(int id)
        {
            return (_context.MovieNameDirectors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}