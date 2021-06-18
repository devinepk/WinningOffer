using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightningOffer.Data;
using LightningOffer.Models;
using Microsoft.AspNetCore.Identity;

namespace LightningOffer.Controllers
{
    public class FuelPropanesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public FuelPropanesController(ApplicationDbContext context,
                                    UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: FuelPropanes
        public async Task<IActionResult> Index()
        {
            return View(await _context.FuelPropane.ToListAsync());
        }

        // GET: FuelPropanes/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelPropane = await _context.FuelPropane
                .FirstOrDefaultAsync(m => m.FuelPropane_id == id);
            if (fuelPropane == null)
            {
                return NotFound();
            }

            return View(fuelPropane);
        }

        // GET: FuelPropanes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FuelPropanes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid Id, [Bind("FuelPropane_id,CreatedDate,Propane_Tank_Ownership,Propane_Tank_Status")] FuelPropane fuelPropane)
        {
            if (ModelState.IsValid)
            {
                FuelPropane newFuelPropane = new();
                
                // User (userId)
                string userId = new string(_userManager.GetUserId(User));
                newFuelPropane.UserId = userId;

                newFuelPropane.FuelPropane_id = Guid.NewGuid(); // new Guid
                // Contract id from properties > appliances
                Guid contractId = Id;

                newFuelPropane.ContractId = Id;

                _context.Add(newFuelPropane);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fuelPropane);
        }

        // GET: FuelPropanes/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelPropane = await _context.FuelPropane.FindAsync(id);
            if (fuelPropane == null)
            {
                return NotFound();
            }
            return View(fuelPropane);
        }

        // POST: FuelPropanes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("FuelPropane_id,CreatedDate,Propane_Tank_Ownership,Propane_Tank_Status")] FuelPropane fuelPropane)
        {
            if (id != fuelPropane.FuelPropane_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fuelPropane);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuelPropaneExists(fuelPropane.FuelPropane_id))
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
            return View(fuelPropane);
        }

        // GET: FuelPropanes/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fuelPropane = await _context.FuelPropane
                .FirstOrDefaultAsync(m => m.FuelPropane_id == id);
            if (fuelPropane == null)
            {
                return NotFound();
            }

            return View(fuelPropane);
        }

        // POST: FuelPropanes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var fuelPropane = await _context.FuelPropane.FindAsync(id);
            _context.FuelPropane.Remove(fuelPropane);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuelPropaneExists(Guid id)
        {
            return _context.FuelPropane.Any(e => e.FuelPropane_id == id);
        }
    }
}
