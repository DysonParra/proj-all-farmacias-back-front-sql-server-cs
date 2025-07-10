/*
 * @overview        {MedicamentoController}
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
     * TODO: Description of {@code MedicamentoController}.
     *
     * @author Dyson Parra
     * @since .NET 8 (LTS), C# 12
     */
    public class MedicamentoController : Controller {
        private readonly FarmaciasContext _context;

        /**
         * TODO: Description of method {@code MedicamentoController}.
         *
         */
        public MedicamentoController(FarmaciasContext context) {
            _context = context;
        }

        /**
         * GET: Medicamento
         *
         */
        public async Task<IActionResult> Index() {
            return View(await _context.Medicamento.ToListAsync());
        }

        /**
         * GET: Medicamento/Details/5
         *
         */
        public async Task<IActionResult> Details(long? id) {
            if (id == null || _context.Medicamento == null) {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (medicamento == null) {
                return NotFound();
            }

            return View(medicamento);
        }

        /**
         * GET: Medicamento/Create
         *
         */
        public IActionResult Create() {
            return View();
        }

        /**
         * POST: Medicamento/Create
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,BitMedicamentoPos,DtFechaCreacion,IntIdLaboratorio,StrAccionTerapeutica,StrCantidad,StrCodigoAtc,StrConcentracion,StrEan,StrMarca,StrNombre,StrNombreComercial,StrNombreGenerico,StrPresentacion,StrPrincipioActivo,StrRegistroInvima,StrUnidadMedida")] Medicamento medicamento) {
            if (ModelState.IsValid) {
                _context.Add(medicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        /**
         * GET: Medicamento/Edit/5
         *
         */
        public async Task<IActionResult> Edit(long? id) {
            if (id == null || _context.Medicamento == null) {
                return NotFound();
            }

            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento == null) {
                return NotFound();
            }
            return View(medicamento);
        }

        /**
         * POST: Medicamento/Edit/5
         * To protect from overposting attacks, enable the specific properties you want to bind to.
         * For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
         *
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,BitMedicamentoPos,DtFechaCreacion,IntIdLaboratorio,StrAccionTerapeutica,StrCantidad,StrCodigoAtc,StrConcentracion,StrEan,StrMarca,StrNombre,StrNombreComercial,StrNombreGenerico,StrPresentacion,StrPrincipioActivo,StrRegistroInvima,StrUnidadMedida")] Medicamento medicamento) {
            if (id != medicamento.IntId) {
                return NotFound();
            }

            if (ModelState.IsValid) {
                try {
                    _context.Update(medicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MedicamentoExists(medicamento.IntId)) {
                        return NotFound();
                    }
                    else {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(medicamento);
        }

        /**
         * GET: Medicamento/Delete/5
         *
         */
        public async Task<IActionResult> Delete(long? id) {
            if (id == null || _context.Medicamento == null) {
                return NotFound();
            }

            var medicamento = await _context.Medicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (medicamento == null) {
                return NotFound();
            }

            return View(medicamento);
        }

        /**
         * POST: Medicamento/Delete/5
         *
         */
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id) {
            if (_context.Medicamento == null) {
                return Problem("Entity set 'FarmaciasContext.Medicamento'  is null.");
            }
            var medicamento = await _context.Medicamento.FindAsync(id);
            if (medicamento != null) {
                _context.Medicamento.Remove(medicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        /**
         * TODO: Description of method {@code MedicamentoExists}.
         *
         */
        private bool MedicamentoExists(long? id) {
            return _context.Medicamento.Any(e => e.IntId == id);
        }
    }
}
