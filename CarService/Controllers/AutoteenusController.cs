using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CarService.Models;

namespace CarService.Controllers
{
    public class AutoteenusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AutoteenusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Autoteenus
        public async Task<IActionResult> Index()
        {
              return View(await _context.Autoteenus.ToListAsync());
        }

        // GET: Autoteenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Autoteenus == null)
            {
                return NotFound();
            }

            var autoteenus = await _context.Autoteenus
                .FirstOrDefaultAsync(m => m.AutoteenusID == id);
            if (autoteenus == null)
            {
                return NotFound();
            }

            return View(autoteenus);
        }

        // GET: Autoteenus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autoteenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AutoteenusID,autoteenus,Hind,Aeg")] Autoteenus autoteenus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(autoteenus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autoteenus);
        }

        // GET: Autoteenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Autoteenus == null)
            {
                return NotFound();
            }

            var autoteenus = await _context.Autoteenus.FindAsync(id);
            if (autoteenus == null)
            {
                return NotFound();
            }
            return View(autoteenus);
        }

        // POST: Autoteenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AutoteenusID,autoteenus,Hind,Aeg")] Autoteenus autoteenus)
        {
            if (id != autoteenus.AutoteenusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(autoteenus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AutoteenusExists(autoteenus.AutoteenusID))
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
            return View(autoteenus);
        }

        // GET: Autoteenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Autoteenus == null)
            {
                return NotFound();
            }

            var autoteenus = await _context.Autoteenus
                .FirstOrDefaultAsync(m => m.AutoteenusID == id);
            if (autoteenus == null)
            {
                return NotFound();
            }

            return View(autoteenus);
        }

        // POST: Autoteenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Autoteenus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Autoteenus'  is null.");
            }
            var autoteenus = await _context.Autoteenus.FindAsync(id);
            if (autoteenus != null)
            {
                _context.Autoteenus.Remove(autoteenus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AutoteenusExists(int id)
        {
          return _context.Autoteenus.Any(e => e.AutoteenusID == id);
        }
    }
}
