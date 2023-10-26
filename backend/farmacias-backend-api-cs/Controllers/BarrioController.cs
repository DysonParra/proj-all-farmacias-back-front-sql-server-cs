/*
 * @fileoverview    {BarrioController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementation done.
 * @version 2.0     Documentation added.
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farmacias.Data;
using Project.Models;

namespace Farmacias.Controllers
{
    public class BarrioController : Controller
    {
        private readonly FarmaciasContext _context;

        public BarrioController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: Barrio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Barrio.ToListAsync());
        }

        // GET: Barrio/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Barrio == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrio
                .FirstOrDefaultAsync(m => m.IntIdBarrio == id);
            if (barrio == null)
            {
                return NotFound();
            }

            return View(barrio);
        }

        // GET: Barrio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Barrio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdBarrio,StrNombre,IntIdCiudad")] Barrio barrio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(barrio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(barrio);
        }

        // GET: Barrio/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Barrio == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrio.FindAsync(id);
            if (barrio == null)
            {
                return NotFound();
            }
            return View(barrio);
        }

        // POST: Barrio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdBarrio,StrNombre,IntIdCiudad")] Barrio barrio)
        {
            if (id != barrio.IntIdBarrio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(barrio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BarrioExists(barrio.IntIdBarrio))
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
            return View(barrio);
        }

        // GET: Barrio/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Barrio == null)
            {
                return NotFound();
            }

            var barrio = await _context.Barrio
                .FirstOrDefaultAsync(m => m.IntIdBarrio == id);
            if (barrio == null)
            {
                return NotFound();
            }

            return View(barrio);
        }

        // POST: Barrio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Barrio == null)
            {
                return Problem("Entity set 'FarmaciasContext.Barrio'  is null.");
            }
            var barrio = await _context.Barrio.FindAsync(id);
            if (barrio != null)
            {
                _context.Barrio.Remove(barrio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BarrioExists(long? id)
        {
            return _context.Barrio.Any(e => e.IntIdBarrio == id);
        }
    }
}
