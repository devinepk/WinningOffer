using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightningOffer.Data;
using LightningOffer.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using RestSharp;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;


namespace LightningOffer.Controllers
{
    public class HomeWarrantiesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;

        public HomeWarrantiesController(ApplicationDbContext context,
                                UserManager<IdentityUser> userManager,
                                ILogger<FinancialsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
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
        public async Task<IActionResult> Create(Guid Id, string Who_Pays, string Who_Chooses, double Price, string Buyer_Final_Options, [Bind("HomeWarranty_id,CreatedDate,Who_Pays, Who_Chooses, Price, Buyer_Final_Options, ContractId")] HomeWarranty homeWarranty)
        {
            // Assign GUIDS and UserId
            HomeWarranty newHomeWarranty = new();
            newHomeWarranty.HomeWarranty_id = Guid.NewGuid();
            newHomeWarranty.CreatedDate = DateTime.Now;
            newHomeWarranty.ContractId = Id;
            
            string userId = new string(_userManager.GetUserId(User));
            string username = new string(_userManager.GetUserName(User));

            _logger.LogInformation("New home warranty section with ID {0} created with contract ID {1} by User {2}", newHomeWarranty.HomeWarranty_id, Id, username);

            // Who pays and chooses logic
            if (Who_Pays.Equals("sellerPaysNo"))
            {

                newHomeWarranty.Who_Pays = Who_Pays;
                newHomeWarranty.Price = 0;
                newHomeWarranty.Who_Chooses = "N/A";
                newHomeWarranty.Buyer_Final_Options = Buyer_Final_Options;


            }
            else if (Who_Pays.Equals("sellerPaysYes"))
            {

                newHomeWarranty.Who_Pays = Who_Pays;
                newHomeWarranty.Price = Price;
                newHomeWarranty.Who_Chooses = Who_Chooses;
                newHomeWarranty.Buyer_Final_Options = null;


            }


            if (ModelState.IsValid)
            {
                try
                {

                    _context.Add(homeWarranty);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("User {0} successfully created the home warranty section of the contract {1}. Next step: dislosures.", username, newHomeWarranty.ContractId);
                    return RedirectToAction("Create", "Disclosures", new { Id = newHomeWarranty.ContractId });

                }
                catch (Exception ex)
                {

                    _logger.LogCritical("Home warranty changes by {0} for contract {1} did not save.  See error: " + ex.InnerException + ".", username, newHomeWarranty.ContractId);
                    return RedirectToAction("Error", "Home");

                }

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
