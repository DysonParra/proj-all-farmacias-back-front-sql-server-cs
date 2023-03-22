/*
 * @fileoverview    {FarmaciaMedicamentoController}
 *
 * @version         2.0
 *
 * @author          Dyson Arley Parra Tilano <dysontilano@gmail.com>
 *
 * @copyright       Dyson Parra
 * @see             github.com/DysonParra
 *
 * History
 * @version 1.0     Implementación realizada.
 * @version 2.0     Documentación agregada.
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
    public class FarmaciaMedicamentoController : Controller
    {
        private readonly FarmaciasContext _context;

        public FarmaciaMedicamentoController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: FarmaciaMedicamento
        public async Task<IActionResult> Index()
        {
            return View(await _context.FarmaciaMedicamento.ToListAsync());
        }

        // GET: FarmaciaMedicamento/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.FarmaciaMedicamento == null)
            {
                return NotFound();
            }

            var farmaciaMedicamento = await _context.FarmaciaMedicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (farmaciaMedicamento == null)
            {
                return NotFound();
            }

            return View(farmaciaMedicamento);
        }

        // GET: FarmaciaMedicamento/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FarmaciaMedicamento/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntId,IntIdFarmacia,IntIdMedicamento")] FarmaciaMedicamento farmaciaMedicamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmaciaMedicamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmaciaMedicamento);
        }

        // GET: FarmaciaMedicamento/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.FarmaciaMedicamento == null)
            {
                return NotFound();
            }

            var farmaciaMedicamento = await _context.FarmaciaMedicamento.FindAsync(id);
            if (farmaciaMedicamento == null)
            {
                return NotFound();
            }
            return View(farmaciaMedicamento);
        }

        // POST: FarmaciaMedicamento/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntId,IntIdFarmacia,IntIdMedicamento")] FarmaciaMedicamento farmaciaMedicamento)
        {
            if (id != farmaciaMedicamento.IntId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmaciaMedicamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciaMedicamentoExists(farmaciaMedicamento.IntId))
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
            return View(farmaciaMedicamento);
        }

        // GET: FarmaciaMedicamento/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.FarmaciaMedicamento == null)
            {
                return NotFound();
            }

            var farmaciaMedicamento = await _context.FarmaciaMedicamento
                .FirstOrDefaultAsync(m => m.IntId == id);
            if (farmaciaMedicamento == null)
            {
                return NotFound();
            }

            return View(farmaciaMedicamento);
        }

        // POST: FarmaciaMedicamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.FarmaciaMedicamento == null)
            {
                return Problem("Entity set 'FarmaciasContext.FarmaciaMedicamento'  is null.");
            }
            var farmaciaMedicamento = await _context.FarmaciaMedicamento.FindAsync(id);
            if (farmaciaMedicamento != null)
            {
                _context.FarmaciaMedicamento.Remove(farmaciaMedicamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciaMedicamentoExists(long? id)
        {
            return _context.FarmaciaMedicamento.Any(e => e.IntId == id);
        }
    }
}
