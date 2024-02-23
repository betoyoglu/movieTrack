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
    public class AnimesController : Controller
    {
        private readonly WebProjectContext _context;

        public AnimesController(WebProjectContext context)
        {
            _context = context;
        }

        // GET: Animes
        public async Task<IActionResult> Index()
        {
            return _context.Animes != null ?
                        View(await _context.Animes.ToListAsync()) :
                        Problem("Entity set 'WebProjectContext.Animes'  is null.");
        }

        // GET: Animes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // GET: Animes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Animes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AnimeName,AnimeCategory,AnimeReleaseDate")] Anime anime)
        {
            if (ModelState.IsValid)
            {
                _context.Add(anime);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(anime);
        }

        // GET: Animes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes.FindAsync(id);
            if (anime == null)
            {
                return NotFound();
            }
            return View(anime);
        }

        // POST: Animes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AnimeName,AnimeCategory,AnimeReleaseDate")] Anime anime)
        {
            if (id != anime.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(anime);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnimeExists(anime.Id))
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
            return View(anime);
        }

        // GET: Animes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Animes == null)
            {
                return NotFound();
            }

            var anime = await _context.Animes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (anime == null)
            {
                return NotFound();
            }

            return View(anime);
        }

        // POST: Animes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Animes == null)
            {
                return Problem("Entity set 'WebProjectContext.Animes'  is null.");
            }
            var anime = await _context.Animes.FindAsync(id);
            if (anime != null)
            {
                _context.Animes.Remove(anime);
            }

            await _context.SaveChangesAsync();
            TempData["keyMessage"] = "Record deleted successfully";
            return RedirectToAction(nameof(Index));
        }

        private bool AnimeExists(int id)
        {
            return (_context.Animes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}