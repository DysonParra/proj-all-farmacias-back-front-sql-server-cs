/*
 * @fileoverview    {LaboratorioMedicamentoController}
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
    public class LaboratorioMedicamentoController : Controller
    {
        private readonly FarmaciasContext _context;

        public LaboratorioMedicamentoController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: LaboratorioMedicamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.LaboratorioMedicamento.ToListAsync());
        }

        // GET: LaboratorioMedicamento/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.LaboratorioMedicamento == null)
            {
                return NotFound();
            }

            var laboratorioMedicamento = await _context.LaboratorioMedicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (laboratorioMedicamento == null)
            {
                return NotFound();
            }

            return View(laboratorioMedicamento);
        }

        // GET: LaboratorioMedicamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LaboratorioMedicamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,IntIdLaboratorio,IntIdMedicamento")] LaboratorioMedicamento laboratorioMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratorioMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratorioMedicamento);
        }

        // GET: LaboratorioMedicamento/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.LaboratorioMedicamento == null)
            {
                return NotFound();
            }

            var laboratorioMedicamento = await _context.LaboratorioMedicamento.FindAsync(id);
            if (laboratorioMedicamento == null)
            {
                return NotFound();
            }
            return View(laboratorioMedicamento);
        }

        // POST: LaboratorioMedicamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,IntIdLaboratorio,IntIdMedicamento")] LaboratorioMedicamento laboratorioMedicamento)
        {
            if (id != laboratorioMedicamento.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratorioMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratorioMedicamentoExists(laboratorioMedicamento.IntId))
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
            return View(laboratorioMedicamento);
        }

        // GET: LaboratorioMedicamento/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.LaboratorioMedicamento == null)
            {
                return NotFound();
            }

            var laboratorioMedicamento = await _context.LaboratorioMedicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (laboratorioMedicamento == null)
            {
                return NotFound();
            }

            return View(laboratorioMedicamento);
        }

        // POST: LaboratorioMedicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.LaboratorioMedicamento == null)
            {
                return Problem("Entity set 'FarmaciasContext.LaboratorioMedicamento'  is null.");
            }
            var laboratorioMedicamento = await _context.LaboratorioMedicamento.FindAsync(id);
            if (laboratorioMedicamento != null)
            {
                _context.LaboratorioMedicamento.Remove(laboratorioMedicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioMedicamentoExists(long? id)
        {
            return _context.LaboratorioMedicamento.Any(e => e.IntId == id);
        }
    }
}
