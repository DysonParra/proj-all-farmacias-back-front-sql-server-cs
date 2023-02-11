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
    public class TipoPersonaController : Controller
    {
        private readonly FarmaciasContext _context;

        public TipoPersonaController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: TipoPersona
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoPersona.ToListAsync());
        }

        // GET: TipoPersona/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.IntIdTipoPersona == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // GET: TipoPersona/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoPersona/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdTipoPersona,StrDescripcion,StrNombre")] TipoPersona tipoPersona)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoPersona);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoPersona);
        }

        // GET: TipoPersona/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            if (tipoPersona == null)
            {
                return NotFound();
            }
            return View(tipoPersona);
        }

        // POST: TipoPersona/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdTipoPersona,StrDescripcion,StrNombre")] TipoPersona tipoPersona)
        {
            if (id != tipoPersona.IntIdTipoPersona)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoPersona);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoPersonaExists(tipoPersona.IntIdTipoPersona))
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
            return View(tipoPersona);
        }

        // GET: TipoPersona/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.TipoPersona == null)
            {
                return NotFound();
            }

            var tipoPersona = await _context.TipoPersona
                .FirstOrDefaultAsync(m => m.IntIdTipoPersona == id);
            if (tipoPersona == null)
            {
                return NotFound();
            }

            return View(tipoPersona);
        }

        // POST: TipoPersona/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.TipoPersona == null)
            {
                return Problem("Entity set 'FarmaciasContext.TipoPersona'  is null.");
            }
            var tipoPersona = await _context.TipoPersona.FindAsync(id);
            if (tipoPersona != null)
            {
                _context.TipoPersona.Remove(tipoPersona);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoPersonaExists(long? id)
        {
            return _context.TipoPersona.Any(e => e.IntIdTipoPersona == id);
        }
    }
}
