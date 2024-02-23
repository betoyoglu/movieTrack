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
    public class WatchListsController : Controller
    {
        private readonly ApplicationDbCon _context;

        public WatchListsController(ApplicationDbCon context)
        {
            _context = context;
        }

        // GET: WatchLists
        public async Task<IActionResult> Index()
        {
              return _context.WatchList != null ? 
                          View(await _context.WatchList.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbCon.WatchList'  is null.");
        }

        // GET: WatchLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // GET: WatchLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WatchLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Did_you_watch_it,Date")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchList);
                await _context.SaveChangesAsync();
                TempData["keyMessage"] = "Record created successfully..";
                return RedirectToAction(nameof(Index));
            }
            return View(watchList);
        }

        // GET: WatchLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }
            return View(watchList);
        }

        // POST: WatchLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Did_you_watch_it,Date")] WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchList);
                    await _context.SaveChangesAsync();
                    TempData["keyMessage"] = "Record edited successfully..";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchListExists(watchList.Id))
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
            return View(watchList);
        }

        // GET: WatchLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // POST: WatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WatchList == null)
            {
                return Problem("Entity set 'ApplicationDbCon.WatchList'  is null.");
            }
            var watchList = await _context.WatchList.FindAsync(id);
            if (watchList != null)
            {
                _context.WatchList.Remove(watchList);
            }
            
            await _context.SaveChangesAsync();
            TempData["keyMessage"] = "Record deleted successfully..";
            return RedirectToAction(nameof(Index));
        }

        private bool WatchListExists(int id)
        {
          return (_context.WatchList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
