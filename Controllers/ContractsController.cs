using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using RestSharp;
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

        // GET: Contracts/Appliances
        public async Task<IActionResult> Appliance()
        {
            return View();
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
        public async Task<IActionResult> Create(string Address, string County, [Bind("Id,CreatedDate,MlsNumber,ListAgentPhone,Address,City,PostalCode,Country,DeedBook,Page,BlockNum,LotNum,SubLotNum,County,Refrigerator,StoveRange,DishWasher,Microwave,ClothesWasher,ClothesDryer,Other,Propane_Owned,Propane_Leased,Propane_Will_Remain,Propane_NotRemain,Propane_NotApplicable,Purchase_Price,EMD,Cash,LineOfEquity,Gift,Other_Financing,Conventional,FHA,VA,Fixed_Rate,Loan_Length,Interest_Rate,ARM_Limits,Buyer_Loan_Application_Start,EMD_With_ListingBroker,EMD_With_SellingBroker,Lender_Appraisal_Required,Buyer_Appraisal_Required,No_Appraisal_Required,HW,HW_Price,Seller_To_Pay_HW,Buyer_To_Pay_HW,New_Construction_HW,Buyer_Waves_Right_To_HW,Buyer_To_Purchase_HW_Later,Seller_Disclosure_Recieved,No_Lead_Paint,Buyer_Waives_Lead_Paint_Inspection,Contingent_On_Lead_Paint,Lead_Paint_Inspection_Window,Seller_Lead_Paint_Response_Window,As_Is,Buyer_Inspection_Window,Seller_Repair_Request_Response_Window,Last_Best_Request_Window,Contingent_On_Survey,Specific_Closing_Date,Closing_Window,Closing_Window_Soonest,Closing_Window_Latest,Keys_at_Closing,Keys_after_Closing,Active_Lease,Buyer_Title_Insurance,Other_Provisions,HOA_Addendum,Delayed_Possession_Addendum,Contingent_Addendum,Other_Addendum,ImageURLs")] Contract contract)
        {
            // create a new instance of the property object
            Contract newContract = new Contract();

            // Get the api key
            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var apikeys = configuration["APIKeys:Datafiniti"];

            // Make the API call, passing the "Address" in from the view

            //Shelby County Query
            if (County == "Shelby")
            {
                //append the entered address to the request
                var addressentered = "https://api.datafiniti.co/v4/properties/search?address=" + Address;

                //access the api key from the app.config file
                string bearertoken = string.Empty;

                //var apikeys = ConfigurationManager.GetSection("ApiKeys") as NameValueCollection;
                if (apikeys != null)
                {
                    bearertoken = apikeys.ToString();
                }

                var client = new RestClient(addressentered);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", bearertoken);
                request.AddParameter("application/json", "{\r\n    \"query\": \"address:\\\"" + Address + "\\\" AND mlsNumber:* AND statuses.type:\\\"For Sale\\\" AND postalCode:(40067 OR 40022 OR 40065 OR 40003 OR 40076 OR 40057 OR 40019 OR 40601) AND country:(US)\",\r\n    \"num_records\": 1\r\n}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                //the actual json response
                string json = response.Content;

                //parse the json response for key/value pairs
                dynamic api = JObject.Parse(json);

                if (api.num_found != 0)
                {

                    //generate a new GUID
                    Random rnd = new Random();
                    //build the records
                    var records = api.records;
                    contract.Id = Guid.NewGuid();
                    contract.Address = api.records[0].address;
                    contract.MlsNumber = api.records[0].mlsNumber;
                    contract.City = api.records[0].city;
                    contract.PostalCode = api.records[0].postalCode;
                    contract.Country = api.records[0].country;
                    contract.Purchase_Price = api.records[0].prices[0].amountMax;

                    var listingBrokerDates = api.records[0].brokers;
                    //find the most recent broker
                    var listingBrokerInfo = listingBrokerDates[listingBrokerDates.Count - 1];
                    contract.ListCompany = listingBrokerInfo.company; //company name
                    contract.ListAgent = listingBrokerInfo.agent; //agent name  
                    if (api["phones"] != null) //check is the object key exists.  It's not always available and will crash if not handled.
                    {
                        
                        contract.ListAgentPhone = listingBrokerInfo.phones[0]; //agent number.

                    } else{
                        
                        contract.ListAgentPhone = null; //set it to null.

                    }


                    //misc property info (image URL and parcel num)
                    contract.ImageURLs = api.records[0].imageURLS; //what to do if the record doesn't exist?

               
                    var recordsParcelInfo = api.records[0].features[28];

                    contract.DeedBook = "";// public string DeedBook
                    contract.Page = "";// pubic string Page
                    contract.BlockNum = "";// public blockNum
                    contract.LotNum = ""; // public lotNum use the Key value method here
                    contract.SubLotNum = "";// public subLotNum
                    contract.County = County;// county

                    DateTime now = DateTime.Now;
                    contract.CreatedDate = now;

                }
                else
                {
                    Console.WriteLine("No property found");
                    return View();
                }


            }
            else if (County == "Jefferson")  //Jeferson County Query
            {
                //append the entered address to the request
                var addressentered = "https://api.datafiniti.co/v4/properties/search?address=" + Address;

                //access the api key from the app.config file
                string bearertoken = string.Empty;

                //var apikeys = ConfigurationManager.GetSection("ApiKeys") as NameValueCollection;
                if (apikeys != null)
                {
                    bearertoken = apikeys.ToString();
                }

                var client = new RestClient(addressentered);
                client.Timeout = -1;
                var request = new RestRequest(Method.POST);
                request.AddHeader("Content-Type", "application/json");
                request.AddHeader("Authorization", bearertoken);
                request.AddParameter("application/json", "{\r\n    \"query\": \"address:\\\"" + Address + "\\\" AND mlsNumber:* AND statuses.type:\\\"For Sale\\\" AND postalCode:(40018 or 40023 or40025 or 40027 or 40041 or 40059 or 40118 or 40201 or 40202 or 40203 or 40204 or 40205 or 40206 or 40207 or 40208 or 40209 or 40210 or 40211 or 40212 or 40213 or 40214 or 40215 or 40216 or 40217 or 40218 or 40219 or 40220 or 40221 or 40222 or 40223 or 40224 or 40225 or 40228 or 40229 or 40231 or 40232 or 40233 or 40241 or 40242 or 40243 or 40245 or 40250 or 40251 or 40252 or 40253 or 40255 or 40256 or 40257 or 40258 or 40259 or 40261 or 40266 or 40268 or 40269 or 40270 or 40272 or 40280 or 40281 or 40282 or 40283 or 40285 or 40287 or 40289 or 40290 or 40291 or 40292 or 40293 or 40294 or 40295 or 40296 or 40297 or 40298 or 40299) AND country:(US)\",\r\n    \"num_records\": 1\r\n}", ParameterType.RequestBody);

                IRestResponse response = client.Execute(request);

                //the actual json response
                string json = response.Content;

                //parse the json response for key/value pairs
                dynamic api = JObject.Parse(json);

                //build the records
                var records = api.records;
                contract.Address = api.records[0].address;
                contract.MlsNumber = api.records[0].mlsNumber;
                contract.City = api.records[0].city;
                contract.PostalCode = api.records[0].postalCode;
                contract.Country = api.records[0].country;
                contract.Purchase_Price = api.records[0].prices[0].amountMax;

                var listingBrokerDates = api.records[0].brokers;
                //find the most recent broker
                var listingBrokerInfo = listingBrokerDates[listingBrokerDates.Count - 1];
                contract.ListCompany = listingBrokerInfo.company; //company name
                contract.ListAgent = listingBrokerInfo.agent; //agent name
                contract.ListAgentPhone = listingBrokerInfo.phones[0]; //agent number (not always available)

                //misc property info (image URL and parcel num)
                contract.ImageURLs = api.records[0].imageURLS; //what to do if the record doesn't exist?

                //TODO:
                var recordsParcelInfo = api.records[0].features[28];

                contract.DeedBook = "";// public string DeedBook
                contract.Page = "";// pubic string Page
                contract.BlockNum = "";// public blockNum
                contract.LotNum = recordsParcelInfo.// public lotNum use the Key value method here
                contract.SubLotNum = "";// public subLotNum
                contract.County = County;// county

                DateTime now = DateTime.Now;
                contract.CreatedDate = now;

            }


            if (ModelState.IsValid)
            {
                _context.Add(contract);
                await _context.SaveChangesAsync(); //the changes get saved to the db 
                return Redirect("Appliance"); //TODO: redirect to adding the appliances + propane tanks
            } else
            {
                return View(); //TODO: messaging that the property is not available
            }

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
