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
    public class ClosingsController : Controller
    {
        private readonly WinningOfferContext _context;

        public ClosingsController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: Closings
        public async Task<IActionResult> Index()
        {
            return View(await _context.Closing.ToListAsync());
        }

        // GET: Closings/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing
                .FirstOrDefaultAsync(m => m.Closing_id == id);
            if (closing == null)
            {
                return NotFound();
            }

            return View(closing);
        }

        // GET: Closings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Closings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Closing_id,CreatedDate,Specific_Closing_Date,Closing_Window,Closing_Window_Soonest,Closing_Window_Latest,Keys_at_Closing,Keys_after_Closing,Active_Lease,Buyer_Title_Insurance,Other_Provisions")] Closing closing)
        {
            if (ModelState.IsValid)
            {
                closing.Closing_id = Guid.NewGuid();
                _context.Add(closing);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(closing);
        }

        // GET: Closings/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing.FindAsync(id);
            if (closing == null)
            {
                return NotFound();
            }
            return View(closing);
        }

        // POST: Closings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Closing_id,CreatedDate,Specific_Closing_Date,Closing_Window,Closing_Window_Soonest,Closing_Window_Latest,Keys_at_Closing,Keys_after_Closing,Active_Lease,Buyer_Title_Insurance,Other_Provisions")] Closing closing)
        {
            if (id != closing.Closing_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(closing);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClosingExists(closing.Closing_id))
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
            return View(closing);
        }

        // GET: Closings/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var closing = await _context.Closing
                .FirstOrDefaultAsync(m => m.Closing_id == id);
            if (closing == null)
            {
                return NotFound();
            }

            return View(closing);
        }

        // POST: Closings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var closing = await _context.Closing.FindAsync(id);
            _context.Closing.Remove(closing);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClosingExists(Guid id)
        {
            return _context.Closing.Any(e => e.Closing_id == id);
        }
    }
}
