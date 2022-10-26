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
    public class TellimusController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TellimusController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tellimus
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Tellimus.Include(t => t.Autoteenus).Include(t => t.Klient).Include(t => t.Tootaja);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Tellimus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tellimus == null)
            {
                return NotFound();
            }

            var tellimus = await _context.Tellimus
                .Include(t => t.Autoteenus)
                .Include(t => t.Klient)
                .Include(t => t.Tootaja)
                .FirstOrDefaultAsync(m => m.TellimusID == id);
            if (tellimus == null)
            {
                return NotFound();
            }

            return View(tellimus);
        }

        // GET: Tellimus/Create
        public IActionResult Create()
        {
            ViewData["AutoteenusID"] = new SelectList(_context.Set<Autoteenus>(), "AutoteenusID", "AutoteenusID");
            ViewData["KlientID"] = new SelectList(_context.Klient, "KlientID", "KlientID");
            ViewData["TootajaID"] = new SelectList(_context.Set<Tootaja>(), "TootajaID", "TootajaID");
            return View();
        }

        // POST: Tellimus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TellimusID,TootajaID,AutoteenusID,KlientID,Kuupaev,Aeg")] Tellimus tellimus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tellimus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AutoteenusID"] = new SelectList(_context.Set<Autoteenus>(), "AutoteenusID", "AutoteenusID", tellimus.AutoteenusID);
            ViewData["KlientID"] = new SelectList(_context.Klient, "KlientID", "KlientID", tellimus.KlientID);
            ViewData["TootajaID"] = new SelectList(_context.Set<Tootaja>(), "TootajaID", "TootajaID", tellimus.TootajaID);
            return View(tellimus);
        }

        // GET: Tellimus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tellimus == null)
            {
                return NotFound();
            }

            var tellimus = await _context.Tellimus.FindAsync(id);
            if (tellimus == null)
            {
                return NotFound();
            }
            ViewData["AutoteenusID"] = new SelectList(_context.Set<Autoteenus>(), "AutoteenusID", "AutoteenusID", tellimus.AutoteenusID);
            ViewData["KlientID"] = new SelectList(_context.Klient, "KlientID", "KlientID", tellimus.KlientID);
            ViewData["TootajaID"] = new SelectList(_context.Set<Tootaja>(), "TootajaID", "TootajaID", tellimus.TootajaID);
            return View(tellimus);
        }

        // POST: Tellimus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TellimusID,TootajaID,AutoteenusID,KlientID,Kuupaev,Aeg")] Tellimus tellimus)
        {
            if (id != tellimus.TellimusID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tellimus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TellimusExists(tellimus.TellimusID))
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
            ViewData["AutoteenusID"] = new SelectList(_context.Set<Autoteenus>(), "AutoteenusID", "AutoteenusID", tellimus.AutoteenusID);
            ViewData["KlientID"] = new SelectList(_context.Klient, "KlientID", "KlientID", tellimus.KlientID);
            ViewData["TootajaID"] = new SelectList(_context.Set<Tootaja>(), "TootajaID", "TootajaID", tellimus.TootajaID);
            return View(tellimus);
        }

        // GET: Tellimus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tellimus == null)
            {
                return NotFound();
            }

            var tellimus = await _context.Tellimus
                .Include(t => t.Autoteenus)
                .Include(t => t.Klient)
                .Include(t => t.Tootaja)
                .FirstOrDefaultAsync(m => m.TellimusID == id);
            if (tellimus == null)
            {
                return NotFound();
            }

            return View(tellimus);
        }

        // POST: Tellimus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tellimus == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Tellimus'  is null.");
            }
            var tellimus = await _context.Tellimus.FindAsync(id);
            if (tellimus != null)
            {
                _context.Tellimus.Remove(tellimus);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TellimusExists(int id)
        {
          return _context.Tellimus.Any(e => e.TellimusID == id);
        }
    }
}
