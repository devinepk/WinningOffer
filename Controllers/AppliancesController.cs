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
    public class AppliancesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppliancesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appliances
        public async Task<IActionResult> Index()
        {
            return View(await _context.Appliance.ToListAsync());
        }

        // GET: Appliances/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .FirstOrDefaultAsync(m => m.Appliance_id == id);
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // GET: Appliances/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appliances/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Appliance_id,CreatedDate,Refrigerator,StoveRange,DishWasher,Microwave,ClothesWasher,ClothesDryer,Other")] Appliance appliance)
        {

            //1 = stays, 2 = goes, 3 = n/a

            DateTime now = DateTime.Now;
            appliance.CreatedDate = now;


            if (ModelState.IsValid)
            {
                appliance.Appliance_id = Guid.NewGuid();
                _context.Add(appliance);
                await _context.SaveChangesAsync();
                return RedirectToAction("Create", "FuelPropanes");
            }
            return View(appliance);
        }

        // GET: Appliances/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance.FindAsync(id);
            if (appliance == null)
            {
                return NotFound();
            }
            return View(appliance);
        }

        // POST: Appliances/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Appliance_id,CreatedDate,Refrigerator,StoveRange,DishWasher,Microwave,ClothesWasher,ClothesDryer,Other")] Appliance appliance)
        {
            if (id != appliance.Appliance_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appliance);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApplianceExists(appliance.Appliance_id))
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
            return View(appliance);
        }

        // GET: Appliances/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appliance = await _context.Appliance
                .FirstOrDefaultAsync(m => m.Appliance_id == id);
            if (appliance == null)
            {
                return NotFound();
            }

            return View(appliance);
        }

        // POST: Appliances/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var appliance = await _context.Appliance.FindAsync(id);
            _context.Appliance.Remove(appliance);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApplianceExists(Guid id)
        {
            return _context.Appliance.Any(e => e.Appliance_id == id);
        }
    }
}
