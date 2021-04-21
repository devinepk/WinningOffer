using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WinningOffer.Data;
using WinningOffer.Models;

namespace WinningOffer.Controllers
{
    public class PropanesController : Controller
    {
        private readonly WinningOfferContext _context;

        public PropanesController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: Propanes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Propane.ToListAsync());
        }

        // GET: Propanes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propane = await _context.Propane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propane == null)
            {
                return NotFound();
            }

            return View(propane);
        }

        // GET: Propanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Propanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Owned,Leaded,WillRemain,NotRemain,NotApplication")] Propane propane)
        {
            if (ModelState.IsValid)
            {
                _context.Add(propane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(propane);
        }

        // GET: Propanes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propane = await _context.Propane.FindAsync(id);
            if (propane == null)
            {
                return NotFound();
            }
            return View(propane);
        }

        // POST: Propanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Owned,Leaded,WillRemain,NotRemain,NotApplication")] Propane propane)
        {
            if (id != propane.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(propane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropaneExists(propane.Id))
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
            return View(propane);
        }

        // GET: Propanes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var propane = await _context.Propane
                .FirstOrDefaultAsync(m => m.Id == id);
            if (propane == null)
            {
                return NotFound();
            }

            return View(propane);
        }

        // POST: Propanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var propane = await _context.Propane.FindAsync(id);
            _context.Propane.Remove(propane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropaneExists(int id)
        {
            return _context.Propane.Any(e => e.Id == id);
        }
    }
}
