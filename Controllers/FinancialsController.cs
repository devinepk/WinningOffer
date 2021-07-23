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

namespace LightningOffer.Controllers
{
    public class FinancialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;


        public FinancialsController(ApplicationDbContext context,
                            UserManager<IdentityUser> userManager,
                            ILogger<FinancialsController> logger)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
           
        }


        // GET: Financials
        public async Task<IActionResult> Index()
        {
            return View(await _context.Financial.ToListAsync());
        }

        // GET: Financials/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financial = await _context.Financial
                .FirstOrDefaultAsync(m => m.Financial_id == id);
            if (financial == null)
            {
                return NotFound();
            }

            return View(financial);
        }

        // GET: Financials/Create
        public IActionResult Create()
        
        {
            _logger.LogInformation("Beginning the financial section");
            return View();
        }

        // POST: Financials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Guid Id, [Bind("Financial_id,CreatedDate,Purchase_Price,EMD,Cash,LineOfEquity,Gift,Other_Financing,Conventional,FHA,VA,Fixed_Rate,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker")] Financial financial)
        {
            // Assign GUIDs and userID
            
            Financial newFinancial = new();
            newFinancial.Financial_id = Guid.NewGuid();

            Guid contractId = Id; // pass from appliances
            newFinancial.ContractId = Id;

            // Find and assign logged in user id
            string userId = new string(_userManager.GetUserId(User));
            newFinancial.UserId = userId;

            _logger.LogInformation("New financial section with ID {newFinancial.Financial_id} created with contract ID {contractId} by User {userId}", newFinancial.Financial_id, contractId, userId);

            // Financial specific logic

            if (ModelState.IsValid)
            {
                financial.Financial_id = Guid.NewGuid();
                _context.Add(financial);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Create", "Appraisals");
            }
            return View(financial);
        }

        // GET: Financials/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financial = await _context.Financial.FindAsync(id);
            if (financial == null)
            {
                return NotFound();
            }
            return View(financial);
        }

        // POST: Financials/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Financial_id,CreatedDate,Purchase_Price,EMD,Cash,LineOfEquity,Gift,Other_Financing,Conventional,FHA,VA,Fixed_Rate,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker")] Financial financial)
        {
            if (id != financial.Financial_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(financial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FinancialExists(financial.Financial_id))
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
            return View(financial);
        }

        // GET: Financials/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var financial = await _context.Financial
                .FirstOrDefaultAsync(m => m.Financial_id == id);
            if (financial == null)
            {
                return NotFound();
            }

            return View(financial);
        }

        // POST: Financials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var financial = await _context.Financial.FindAsync(id);
            _context.Financial.Remove(financial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FinancialExists(Guid id)
        {
            return _context.Financial.Any(e => e.Financial_id == id);
        }
    }
}
