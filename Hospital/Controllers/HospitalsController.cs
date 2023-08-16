using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Hospital.Data;
using Hospital.Models;

namespace Hospital.Controllers
{
    public class HospitalsController : Controller
    {
        private readonly MyDBContext _context;

        public HospitalsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: Hospitals
        public async Task<IActionResult> Index()
        {
              return _context.hospitals != null ? 
                          View(await _context.hospitals.ToListAsync()) :
                          Problem("Entity set 'MyDBContext.hospitals'  is null.");
        }

        // GET: Hospitals/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.hospitals == null)
            {
                return NotFound();
            }

            var hospitals = await _context.hospitals
                .FirstOrDefaultAsync(m => m.name == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        // GET: Hospitals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Hospitals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("name,location,department,mainSpecialty,roomName,registeredDate")] Hospitals hospitals)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hospitals);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hospitals);
        }

        // GET: Hospitals/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.hospitals == null)
            {
                return NotFound();
            }

            var hospitals = await _context.hospitals.FindAsync(id);
            if (hospitals == null)
            {
                return NotFound();
            }
            return View(hospitals);
        }

        // POST: Hospitals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("name,location,department,mainSpecialty,roomName,registeredDate")] Hospitals hospitals)
        {
            if (id != hospitals.name)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hospitals);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HospitalsExists(hospitals.name))
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
            return View(hospitals);
        }

        // GET: Hospitals/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.hospitals == null)
            {
                return NotFound();
            }

            var hospitals = await _context.hospitals
                .FirstOrDefaultAsync(m => m.name == id);
            if (hospitals == null)
            {
                return NotFound();
            }

            return View(hospitals);
        }

        // POST: Hospitals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.hospitals == null)
            {
                return Problem("Entity set 'MyDBContext.hospitals'  is null.");
            }
            var hospitals = await _context.hospitals.FindAsync(id);
            if (hospitals != null)
            {
                _context.hospitals.Remove(hospitals);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HospitalsExists(string id)
        {
          return (_context.hospitals?.Any(e => e.name == id)).GetValueOrDefault();
        }
    }
}
