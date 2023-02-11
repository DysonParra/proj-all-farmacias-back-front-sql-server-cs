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
    public class LaboratorioController : Controller
    {
        private readonly FarmaciasContext _context;

        public LaboratorioController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: Laboratorio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Laboratorio.ToListAsync());
        }

        // GET: Laboratorio/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Laboratorio == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio
                .FirstOrDefaultAsync(m => m.IntIdLaboratorio == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // GET: Laboratorio/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Laboratorio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdLaboratorio,StrDireccion,StrNit,StrNombre")] Laboratorio laboratorio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(laboratorio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(laboratorio);
        }

        // GET: Laboratorio/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Laboratorio == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio.FindAsync(id);
            if (laboratorio == null)
            {
                return NotFound();
            }
            return View(laboratorio);
        }

        // POST: Laboratorio/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdLaboratorio,StrDireccion,StrNit,StrNombre")] Laboratorio laboratorio)
        {
            if (id != laboratorio.IntIdLaboratorio)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(laboratorio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LaboratorioExists(laboratorio.IntIdLaboratorio))
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
            return View(laboratorio);
        }

        // GET: Laboratorio/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Laboratorio == null)
            {
                return NotFound();
            }

            var laboratorio = await _context.Laboratorio
                .FirstOrDefaultAsync(m => m.IntIdLaboratorio == id);
            if (laboratorio == null)
            {
                return NotFound();
            }

            return View(laboratorio);
        }

        // POST: Laboratorio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Laboratorio == null)
            {
                return Problem("Entity set 'FarmaciasContext.Laboratorio'  is null.");
            }
            var laboratorio = await _context.Laboratorio.FindAsync(id);
            if (laboratorio != null)
            {
                _context.Laboratorio.Remove(laboratorio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LaboratorioExists(long? id)
        {
            return _context.Laboratorio.Any(e => e.IntIdLaboratorio == id);
        }
    }
}
