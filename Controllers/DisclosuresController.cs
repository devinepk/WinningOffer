using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightningOffer.Data;
using LightningOffer.Models;

namespace LightningOffer.Controllers
{
    public class DisclosuresController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DisclosuresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Disclosures
        public async Task<IActionResult> Index()
        {
            return View(await _context.Disclosure.ToListAsync());
        }

        // GET: Disclosures/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disclosure = await _context.Disclosure
                .FirstOrDefaultAsync(m => m.Disclosure_id == id);
            if (disclosure == null)
            {
                return NotFound();
            }

            return View(disclosure);
        }

        // GET: Disclosures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Disclosures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Disclosure_id,CreatedDate,Seller_Disclosure_Recieved,No_Lead_Paint,Buyer_Waives_Lead_Paint_Inspection,Contingent_On_Lead_Paint,Lead_Paint_Inspection_Window,Seller_Lead_Paint_Response_Window")] Disclosure disclosure)
        {
            if (ModelState.IsValid)
            {
                disclosure.Disclosure_id = Guid.NewGuid();
                _context.Add(disclosure);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(disclosure);
        }

        // GET: Disclosures/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disclosure = await _context.Disclosure.FindAsync(id);
            if (disclosure == null)
            {
                return NotFound();
            }
            return View(disclosure);
        }

        // POST: Disclosures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Disclosure_id,CreatedDate,Seller_Disclosure_Recieved,No_Lead_Paint,Buyer_Waives_Lead_Paint_Inspection,Contingent_On_Lead_Paint,Lead_Paint_Inspection_Window,Seller_Lead_Paint_Response_Window")] Disclosure disclosure)
        {
            if (id != disclosure.Disclosure_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(disclosure);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DisclosureExists(disclosure.Disclosure_id))
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
            return View(disclosure);
        }

        // GET: Disclosures/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var disclosure = await _context.Disclosure
                .FirstOrDefaultAsync(m => m.Disclosure_id == id);
            if (disclosure == null)
            {
                return NotFound();
            }

            return View(disclosure);
        }

        // POST: Disclosures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var disclosure = await _context.Disclosure.FindAsync(id);
            _context.Disclosure.Remove(disclosure);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DisclosureExists(Guid id)
        {
            return _context.Disclosure.Any(e => e.Disclosure_id == id);
        }
    }
}
