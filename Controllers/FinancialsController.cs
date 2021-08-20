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
    public class FinancialsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger _logger;
        //private readonly IFileManagerLogic _fileManagerLogic;



        public FinancialsController(ApplicationDbContext context,
                            UserManager<IdentityUser> userManager,
                            ILogger<FinancialsController> logger)
                           // IFileManagerLogic fileManagerLogic)
        {
            _context = context;
            _userManager = userManager;
            _logger = logger;
            //_fileManagerLogic = fileManagerLogic;
           
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
            //Messages
            ViewBag.RequiredField = "This is required, please make a selection.";
            

            return View();
            
        }

        // POST: Financials/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile File, int ARM_Limits, string Buyer_Loan_Application_Start, double Interest_Rate, int Loan_Length, string Rate_Type, string LoanType, string DownPaymentFormat, Guid Id, int Purchase_Price, string EMD, string DownPaymentSource, string DownPaymentAmount, [Bind("Financial_id,CreatedDate,Purchase_Price,EMD,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker,DownPaymentAmount,LoanType, Rate_Type,ContractId, UserId")] Financial financial)
        {
            // Assign GUIDs and userID

            Financial newFinancial = new();
            newFinancial.Financial_id = Guid.NewGuid();
            newFinancial.CreatedDate = DateTime.Now;
            //newFinancial.File = File;

            Guid contractId = Id; // passd from appliances

            //Set the contractGUID as the viewdata and use that to pass it to the next controller.
            ViewBag.ContractId = Id;
            _logger.LogInformation("{0} is the contract and viewbag id", Id);

            newFinancial.ContractId = Id;

            // Find and assign logged in user id
            string userId = new string(_userManager.GetUserId(User));
            string username = new string (_userManager.GetUserName(User));
            newFinancial.UserId = userId;

            _logger.LogInformation("New financial section with ID {0} created with contract ID {1} by User {2}", newFinancial.Financial_id, contractId, username);

            // Financial specific logic
            newFinancial.Purchase_Price = Purchase_Price;
            newFinancial.EMD = EMD;
            newFinancial.EMD_With_ListingBroker = true; // set listing broker to true
            newFinancial.EMD_With_SellingBroker = false; // and selling broker to false
            
            newFinancial.DownPaymentSource = DownPaymentSource;
            newFinancial.DownPaymentAmount = DownPaymentAmount;
            newFinancial.DownPaymentFormat = DownPaymentFormat;

            // Financing
            newFinancial.LoanType = LoanType;
            newFinancial.Rate_Type = Rate_Type;
            newFinancial.Loan_Length = Loan_Length;

            if (newFinancial.Loan_Length == 15)
            {

                newFinancial.Interest_Rate = Interest_Rate;

            } else if (newFinancial.Loan_Length == 30)
            {

                newFinancial.Interest_Rate = Interest_Rate;

            }


            // Get the 15 and 30 yr mortgage rate
            DateTime datetime = DateTime.Now;

            // Get the api key
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var apikeys = configuration["APIKeys:IEX_Test"];


            ///
            /// To switch to prod, changes the api key to API_Prod, and replace sandbox30/sandbox15 with mortgage30/mortgage15
            /// 

            string token = "";
            token = apikeys.ToString();

            string sandbox30 = "https://sandbox.iexapis.com/stable/data-points/market/MORTGAGE30US?token=" + token;
            string sandbox15 = "https://sandbox.iexapis.com/stable/data-points/market/MORTGAGE30US?token=" + token;


            string mortgage30 = "https://cloud.iexapis.com/stable/data-points/market/MORTGAGE30US?token=" + token;
            string mortgage15 = "https://cloud.iexapis.com/stable/data-points/market/MORTGAGE15US?token=" + token;


            if (newFinancial.Loan_Length == 30)
            {

                try
                {
                    //30 yr
                    var client30 = new RestClient(sandbox30);
                    client30.Timeout = -1;
                    var request30 = new RestRequest(Method.GET);
                    request30.AddHeader("Cookie", "ctoken=4c301396d1a6446b9ae42c7894164293");
                    IRestResponse response30 = client30.Execute(request30);
                    string current30Yr = response30.Content;
                    double ThirtyYr = Convert.ToDouble(current30Yr);
                    newFinancial.Interest_Rate = ThirtyYr;

                    _logger.LogInformation("The 30 year mortage API call was successful.  The current 30 year mortgage rate is {0}% on {1}.", current30Yr, datetime);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Unable to get the 30 year mortgage because something failed with the API.  Please see the following error: " + ex.Message);
                }

            } else if (newFinancial.Loan_Length == 15) 
            {

                try
                {
                    //15 yr
                    var client15 = new RestClient(sandbox15);
                    client15.Timeout = -1;
                    var request15 = new RestRequest(Method.GET);
                    request15.AddHeader("Cookie", "ctoken=4c301396d1a6446b9ae42c7894164293");
                    IRestResponse response15 = client15.Execute(request15);
                    string current15Yr = response15.Content;
                    double FifteenYr = Convert.ToDouble(current15Yr);
                    newFinancial.Interest_Rate = FifteenYr;

                    _logger.LogInformation("The 15 year mortgage API call was successful.  The current 15 year mortgage rate is {0}% on {1}.", current15Yr, datetime);
                }
                catch (Exception ex)
                {
                    _logger.LogCritical("Unable to get the 15 year mortgage because something failed with the API.  Please see the following error: " + ex.Message);

                }
            }


            //TODO: API Call for current rate
            
            newFinancial.ARM_Limits = ARM_Limits;

            if (Buyer_Loan_Application_Start == "No")
            {

                newFinancial.Buyer_Loan_Application_Start = DateTime.Today.AddDays(10).ToString("MM/dd/yyyy");

            } else if (Buyer_Loan_Application_Start == "Yes")
            {

                //assign todays date
                newFinancial.Buyer_Loan_Application_Start = DateTime.Today.ToString("MM/dd/yyyy");

                //upload the preapproval letter
     
            }

            //upload using Helper class
  
            Helper.Upload(File);
       


            if (ModelState.IsValid)
            {
      
                _context.Add(newFinancial);
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
