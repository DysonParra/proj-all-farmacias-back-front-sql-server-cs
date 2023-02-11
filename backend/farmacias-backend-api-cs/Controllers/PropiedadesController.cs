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
    public class PropiedadesController : Controller
    {
        private readonly FarmaciasContext _context;

        public PropiedadesController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: Propiedades
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propiedades.ToListAsync());
        }

        // GET: Propiedades/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedades = await _context.Propiedades
                .FirstOrDefaultAsync(m => m.IntIdPropiedad == id);
            if (propiedades == null)
            {
                return NotFound();
            }

            return View(propiedades);
        }

        // GET: Propiedades/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propiedades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntIdPropiedad,StrDescripcionPropiedad,StrGrupo,StrNombrePropiedad,StrValorPropiedad")] Propiedades propiedades)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propiedades);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propiedades);
        }

        // GET: Propiedades/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedades = await _context.Propiedades.FindAsync(id);
            if (propiedades == null)
            {
                return NotFound();
            }
            return View(propiedades);
        }

        // POST: Propiedades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntIdPropiedad,StrDescripcionPropiedad,StrGrupo,StrNombrePropiedad,StrValorPropiedad")] Propiedades propiedades)
        {
            if (id != propiedades.IntIdPropiedad)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propiedades);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropiedadesExists(propiedades.IntIdPropiedad))
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
            return View(propiedades);
        }

        // GET: Propiedades/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Propiedades == null)
            {
                return NotFound();
            }

            var propiedades = await _context.Propiedades
                .FirstOrDefaultAsync(m => m.IntIdPropiedad == id);
            if (propiedades == null)
            {
                return NotFound();
            }

            return View(propiedades);
        }

        // POST: Propiedades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Propiedades == null)
            {
                return Problem("Entity set 'FarmaciasContext.Propiedades'  is null.");
            }
            var propiedades = await _context.Propiedades.FindAsync(id);
            if (propiedades != null)
            {
                _context.Propiedades.Remove(propiedades);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropiedadesExists(long? id)
        {
            return _context.Propiedades.Any(e => e.IntIdPropiedad == id);
        }
    }
}
