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
    public class FarmaciaController : Controller
    {
        private readonly FarmaciasContext _context;

        public FarmaciaController(FarmaciasContext context)
        {
            _context = context;
        }

        // GET: Farmacia
        public async Task<IActionResult> Index()
        {
            return View(await _context.Farmacia.ToListAsync());
        }

        // GET: Farmacia/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.IntCodigoFarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // GET: Farmacia/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Farmacia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IntCodigoFarmacia,StrCelular,StrNit,StrNombre,StrTelefonoFijo,StrUrlExtraccion,IntIdBarrio")] Farmacia farmacia)
        {
            if (ModelState.IsValid)
            {
                _context.Add(farmacia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(farmacia);
        }

        // GET: Farmacia/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia.FindAsync(id);
            if (farmacia == null)
            {
                return NotFound();
            }
            return View(farmacia);
        }

        // POST: Farmacia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long? id, [Bind("IntCodigoFarmacia,StrCelular,StrNit,StrNombre,StrTelefonoFijo,StrUrlExtraccion,IntIdBarrio")] Farmacia farmacia)
        {
            if (id != farmacia.IntCodigoFarmacia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(farmacia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FarmaciaExists(farmacia.IntCodigoFarmacia))
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
            return View(farmacia);
        }

        // GET: Farmacia/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null || _context.Farmacia == null)
            {
                return NotFound();
            }

            var farmacia = await _context.Farmacia
                .FirstOrDefaultAsync(m => m.IntCodigoFarmacia == id);
            if (farmacia == null)
            {
                return NotFound();
            }

            return View(farmacia);
        }

        // POST: Farmacia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long? id)
        {
            if (_context.Farmacia == null)
            {
                return Problem("Entity set 'FarmaciasContext.Farmacia'  is null.");
            }
            var farmacia = await _context.Farmacia.FindAsync(id);
            if (farmacia != null)
            {
                _context.Farmacia.Remove(farmacia);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FarmaciaExists(long? id)
        {
            return _context.Farmacia.Any(e => e.IntCodigoFarmacia == id);
        }
    }
}
