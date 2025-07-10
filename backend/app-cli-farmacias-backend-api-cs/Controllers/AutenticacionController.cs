/*
 * @overview        {AutenticacionController}
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
     * TODO: Description of {@code AutenticacionController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class AutenticacionController : Controller {
        private readonly FarmaciasContext _context;

        /**
         * TODO: Description of method {@code AutenticacionController}.
         *
         */
        public AutenticacionController(FarmaciasContext context) {
            _context = context;
        }

        /**
         * GET: Autenticacion
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Autenticacion.ToListAsync());
        }

        /**
         * GET: Autenticacion/Details/5
         *
         */
        public async Task<IActionResult> Details(string id) {
            if (id == null || _context.Autenticacion == null) {
                return NotFound();
            }

            var autenticacion = await _context.Autenticacion
                .FirstOrDefaultAsync(m => m.StrUsuario == id);
            if (autenticacion == null) {
                return NotFound();
            }

            return View(autenticacion);
        }

        /**
         * GET: Autenticacion/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Autenticacion/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StrUsuario,StrContrasena")] Autenticacion autenticacion) {
            if (ModelState.IsValid) {
                _context.Add(autenticacion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(autenticacion);
        }

        /**
         * GET: Autenticacion/Edit/5
         *
         */
        public async Task<IActionResult> Edit(string id) {
            if (id == null || _context.Autenticacion == null) {
                return NotFound();
            }

            var autenticacion = await _context.Autenticacion.FindAsync(id);
            if (autenticacion == null) {
                return NotFound();
            }
            return View(autenticacion);
        }

        /**
         * POST: Autenticacion/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StrUsuario,StrContrasena")] Autenticacion autenticacion) {
            if (id != autenticacion.StrUsuario) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(autenticacion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!AutenticacionExists(autenticacion.StrUsuario)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(autenticacion);
        }

        /**
         * GET: Autenticacion/Delete/5
         *
         */
        public async Task<IActionResult> Delete(string id) {
            if (id == null || _context.Autenticacion == null) {
                return NotFound();
            }

            var autenticacion = await _context.Autenticacion
                .FirstOrDefaultAsync(m => m.StrUsuario == id);
            if (autenticacion == null) {
                return NotFound();
            }

            return View(autenticacion);
        }

        /**
         * POST: Autenticacion/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id) {
            if (_context.Autenticacion == null) {
                return Problem("Entity set 'FarmaciasContext.Autenticacion'  is null.");
            }
            var autenticacion = await _context.Autenticacion.FindAsync(id);
            if (autenticacion != null) {
                _context.Autenticacion.Remove(autenticacion);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code AutenticacionExists}.
         *
         */
        private bool AutenticacionExists(string id) {
            return _context.Autenticacion.Any(e => e.StrUsuario == id);
        }
    }
}
