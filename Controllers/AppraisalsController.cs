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
    public class AppraisalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppraisalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appraisals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appraisal.ToListAsync());
        }

        // GET: Appraisals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisal = await _context.Appraisal
                .FirstOrDefaultAsync(m => m.Appraisal_id == id);
            if (appraisal == null)
            {
                return NotFound();
            }

            return View(appraisal);
        }

        // GET: Appraisals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appraisals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Appraisal_id,CreatedDate,Lender_Appraisal_Required,Buyer_Appraisal_Required,No_Appraisal_Required")] Appraisal appraisal)
        {
            if (ModelState.IsValid)
            {
                appraisal.Appraisal_id = Guid.NewGuid();
                _context.Add(appraisal);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appraisal);
        }

        // GET: Appraisals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisal = await _context.Appraisal.FindAsync(id);
            if (appraisal == null)
            {
                return NotFound();
            }
            return View(appraisal);
        }

        // POST: Appraisals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Appraisal_id,CreatedDate,Lender_Appraisal_Required,Buyer_Appraisal_Required,No_Appraisal_Required")] Appraisal appraisal)
        {
            if (id != appraisal.Appraisal_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appraisal);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppraisalExists(appraisal.Appraisal_id))
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
            return View(appraisal);
        }

        // GET: Appraisals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appraisal = await _context.Appraisal
                .FirstOrDefaultAsync(m => m.Appraisal_id == id);
            if (appraisal == null)
            {
                return NotFound();
            }

            return View(appraisal);
        }

        // POST: Appraisals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appraisal = await _context.Appraisal.FindAsync(id);
            _context.Appraisal.Remove(appraisal);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppraisalExists(Guid id)
        {
            return _context.Appraisal.Any(e => e.Appraisal_id == id);
        }
    }
}
