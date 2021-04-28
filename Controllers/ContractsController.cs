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
    public class ContractsController : Controller
    {
        private readonly WinningOfferContext _context;

        public ContractsController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: Contracts
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contract.ToListAsync());
        }

        // GET: Contracts/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // GET: Contracts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contracts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CreatedDate,MlsNumber,Address,City,PostalCode,Country,DeedBook,Page,BlockNum,LotNum,SubLotNum,County,Refrigerator,StoveRange,DishWasher,Microwave,ClothesWasher,ClothesDryer,Other,Propane_Owned,Propane_Leased,Propane_Will_Remain,Propane_NotRemain,Propane_NotApplicable,Purchase_Price,EMD,Cash,LineOfEquity,Gift,Other_Financing,Conventional,FHA,VA,Fixed_Rate,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker,Lender_Appraisal_Required,Buyer_Appraisal_Required,No_Appraisal_Required,HW,HW_Price,Seller_To_Pay_HW,Buyer_To_Pay_HW,New_Construction_HW,Buyer_Waves_Right_To_HW,Buyer_To_Purchase_HW_Later,Seller_Disclosure_Recieved,No_Lead_Paint,Buyer_Waives_Lead_Paint_Inspection,Contingent_On_Lead_Paint,Lead_Paint_Inspection_Window,Seller_Lead_Paint_Response_Window,As_Is,Buyer_Inspection_Window,Seller_Repair_Request_Response_Window,Last_Best_Request_Window,Contingent_On_Survey,Specific_Closing_Date,Closing_Window,Closing_Window_Soonest,Closing_Window_Latest,Keys_at_Closing,Keys_after_Closing,Active_Lease,Buyer_Title_Insurance,Other_Provisions,HOA_Addendum,Delayed_Possession_Addendum,Contingent_Addendum,Other_Addendum,ImageURLs")] Contract contract)
        {
            if (ModelState.IsValid)
            {
                contract.Id = Guid.NewGuid();
                _context.Add(contract);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contract);
        }

        // GET: Contracts/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract.FindAsync(id);
            if (contract == null)
            {
                return NotFound();
            }
            return View(contract);
        }

        // POST: Contracts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,CreatedDate,MlsNumber,Address,City,PostalCode,Country,DeedBook,Page,BlockNum,LotNum,SubLotNum,County,Refrigerator,StoveRange,DishWasher,Microwave,ClothesWasher,ClothesDryer,Other,Propane_Owned,Propane_Leased,Propane_Will_Remain,Propane_NotRemain,Propane_NotApplicable,Purchase_Price,EMD,Cash,LineOfEquity,Gift,Other_Financing,Conventional,FHA,VA,Fixed_Rate,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker,Lender_Appraisal_Required,Buyer_Appraisal_Required,No_Appraisal_Required,HW,HW_Price,Seller_To_Pay_HW,Buyer_To_Pay_HW,New_Construction_HW,Buyer_Waves_Right_To_HW,Buyer_To_Purchase_HW_Later,Seller_Disclosure_Recieved,No_Lead_Paint,Buyer_Waives_Lead_Paint_Inspection,Contingent_On_Lead_Paint,Lead_Paint_Inspection_Window,Seller_Lead_Paint_Response_Window,As_Is,Buyer_Inspection_Window,Seller_Repair_Request_Response_Window,Last_Best_Request_Window,Contingent_On_Survey,Specific_Closing_Date,Closing_Window,Closing_Window_Soonest,Closing_Window_Latest,Keys_at_Closing,Keys_after_Closing,Active_Lease,Buyer_Title_Insurance,Other_Provisions,HOA_Addendum,Delayed_Possession_Addendum,Contingent_Addendum,Other_Addendum,ImageURLs")] Contract contract)
        {
            if (id != contract.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contract);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContractExists(contract.Id))
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
            return View(contract);
        }

        // GET: Contracts/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contract = await _context.Contract
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contract == null)
            {
                return NotFound();
            }

            return View(contract);
        }

        // POST: Contracts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var contract = await _context.Contract.FindAsync(id);
            _context.Contract.Remove(contract);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContractExists(Guid id)
        {
            return _context.Contract.Any(e => e.Id == id);
        }
    }
}
