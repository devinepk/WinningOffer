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
    public class HomeWarrantiesController : Controller
    {
        private readonly WinningOfferContext _context;

        public HomeWarrantiesController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: HomeWarranties
        public async Task<IActionResult> Index()
        {
            return View(await _context.HomeWarranty.ToListAsync());
        }

        // GET: HomeWarranties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeWarranty = await _context.HomeWarranty
                .FirstOrDefaultAsync(m => m.HomeWarranty_id == id);
            if (homeWarranty == null)
            {
                return NotFound();
            }

            return View(homeWarranty);
        }

        // GET: HomeWarranties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HomeWarranties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HomeWarranty_id,CreatedDate,HW,HW_Price,Seller_To_Pay_HW,Buyer_To_Pay_HW,New_Construction_HW,Buyer_Waves_Right_To_HW,Buyer_To_Purchase_HW_Later")] HomeWarranty homeWarranty)
        {
            if (ModelState.IsValid)
            {
                homeWarranty.HomeWarranty_id = Guid.NewGuid();
                _context.Add(homeWarranty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(homeWarranty);
        }

        // GET: HomeWarranties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeWarranty = await _context.HomeWarranty.FindAsync(id);
            if (homeWarranty == null)
            {
                return NotFound();
            }
            return View(homeWarranty);
        }

        // POST: HomeWarranties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("HomeWarranty_id,CreatedDate,HW,HW_Price,Seller_To_Pay_HW,Buyer_To_Pay_HW,New_Construction_HW,Buyer_Waves_Right_To_HW,Buyer_To_Purchase_HW_Later")] HomeWarranty homeWarranty)
        {
            if (id != homeWarranty.HomeWarranty_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(homeWarranty);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HomeWarrantyExists(homeWarranty.HomeWarranty_id))
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
            return View(homeWarranty);
        }

        // GET: HomeWarranties/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var homeWarranty = await _context.HomeWarranty
                .FirstOrDefaultAsync(m => m.HomeWarranty_id == id);
            if (homeWarranty == null)
            {
                return NotFound();
            }

            return View(homeWarranty);
        }

        // POST: HomeWarranties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var homeWarranty = await _context.HomeWarranty.FindAsync(id);
            _context.HomeWarranty.Remove(homeWarranty);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HomeWarrantyExists(Guid id)
        {
            return _context.HomeWarranty.Any(e => e.HomeWarranty_id == id);
        }
    }
}
