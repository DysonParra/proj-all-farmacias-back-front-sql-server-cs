/*
 * @fileoverview    {CiudadController}
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

namespace Farmacias.Controllers {

    /**
     * TODO: Description of {@code CiudadController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class CiudadController : Controller {
        private readonly FarmaciasContext _context;

        public CiudadController(FarmaciasContext context) {
            _context = context;
        }

        // GET: Ciudad
        public async Task<IActionResult> Index() {
            return View(await _context.Ciudad.ToListAsync());
        }

        // GET: Ciudad/Details/5
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Ciudad == null) {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .FirstOrDefaultAsync(m => m.IntIdCiudad == id);
            if (ciudad == null) {
                return NotFound();
            }

            return View(ciudad);
        }

        // GET: Ciudad/Create
        public IActionResult Create() {
            return View();
        }

        // POST: Ciudad/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdCiudad,IntIdDane,IntIdEstado,StrEstado,StrNombre")] Ciudad ciudad) {
            if (ModelState.IsValid) {
                _context.Add(ciudad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudad/Edit/5
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Ciudad == null) {
                return NotFound();
            }

            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad == null) {
                return NotFound();
            }
            return View(ciudad);
        }

        // POST: Ciudad/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdCiudad,IntIdDane,IntIdEstado,StrEstado,StrNombre")] Ciudad ciudad) {
            if (id != ciudad.IntIdCiudad) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!CiudadExists(ciudad.IntIdCiudad)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(ciudad);
        }

        // GET: Ciudad/Delete/5
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Ciudad == null) {
                return NotFound();
            }

            var ciudad = await _context.Ciudad
                .FirstOrDefaultAsync(m => m.IntIdCiudad == id);
            if (ciudad == null) {
                return NotFound();
            }

            return View(ciudad);
        }

        // POST: Ciudad/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Ciudad == null) {
                return Problem("Entity set 'FarmaciasContext.Ciudad'  is null.");
            }
            var ciudad = await _context.Ciudad.FindAsync(id);
            if (ciudad != null) {
                _context.Ciudad.Remove(ciudad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CiudadExists(long? id) {
            return _context.Ciudad.Any(e => e.IntIdCiudad == id);
        }
    }
}
