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
    public class AddendumsController : Controller
    {
        private readonly WinningOfferContext _context;

        public AddendumsController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: Addendums
        public async Task<IActionResult> Index()
        {
            return View(await _context.Addendum.ToListAsync());
        }

        // GET: Addendums/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addendum = await _context.Addendum
                .FirstOrDefaultAsync(m => m.Addendum_id == id);
            if (addendum == null)
            {
                return NotFound();
            }

            return View(addendum);
        }

        // GET: Addendums/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Addendums/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Addendum_id,CreatedDate,HOA_Addendum,Delayed_Possession_Addendum,Contingent_Addendum,Other_Addendum")] Addendum addendum)
        {
            if (ModelState.IsValid)
            {
                addendum.Addendum_id = Guid.NewGuid();
                _context.Add(addendum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(addendum);
        }

        // GET: Addendums/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addendum = await _context.Addendum.FindAsync(id);
            if (addendum == null)
            {
                return NotFound();
            }
            return View(addendum);
        }

        // POST: Addendums/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Addendum_id,CreatedDate,HOA_Addendum,Delayed_Possession_Addendum,Contingent_Addendum,Other_Addendum")] Addendum addendum)
        {
            if (id != addendum.Addendum_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(addendum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AddendumExists(addendum.Addendum_id))
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
            return View(addendum);
        }

        // GET: Addendums/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var addendum = await _context.Addendum
                .FirstOrDefaultAsync(m => m.Addendum_id == id);
            if (addendum == null)
            {
                return NotFound();
            }

            return View(addendum);
        }

        // POST: Addendums/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var addendum = await _context.Addendum.FindAsync(id);
            _context.Addendum.Remove(addendum);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AddendumExists(Guid id)
        {
            return _context.Addendum.Any(e => e.Addendum_id == id);
        }
    }
}
