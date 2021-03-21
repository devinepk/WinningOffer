using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WinningOffer.Data;
using WinningOffer.Models;
using RestSharp;
using Microsoft.IdentityModel.Protocols;
using System.Collections.Specialized;
using System.Configuration;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.IO;

namespace WinningOffer.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly WinningOfferContext _context;
        
        public class APIKeyOptions
        {
            public const string SectionName = "APIKeys";

            public string Datafiniti { get; set; }

            IOptions<APIKeyOptions> apiKeyOptions;

        }



        public PropertiesController(WinningOfferContext context)
        {
            _context = context;
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Property.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // GET: Properties/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Properties/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(string Address, string City, string PostalCode, [Bind("Id,Address,City,PostalCode,Country,DateAdded,DateUpdated,GeoLocation,ImageURLs,MlsNumber,NumBathroom,NumBedroom,Price,SourceURLs,Agent,Company,Phones")] Property @property)
        {

            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");
            var configuration = builder.Build();
            var apikeys = configuration["APIKeys:Datafiniti"];

            // Make the API call, passing the "Address" in from the view

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

            //build the records
            var records = api.records;
            var recordsAddress = api.records[0].address;
            var recordsMlsNum = api.records[0].mlsNumber;

            var listingBrokerDates = api.records[0].brokers;
            //find the most recent broker
            var listingBrokerInfo = listingBrokerDates[listingBrokerDates.Count - 1];
            var listingBrokerCompanyName = listingBrokerInfo.company; //company name
            var listingBrokerAgentName = listingBrokerInfo.agent; //agent name
            var listingBrokerAgentPhoneNumber = listingBrokerInfo.phones; //agent number (not always available)

            //misc property info (image URL and parcel num)
            var recordsImageLink = api.records[0].imageURLS;
            var recordsParcelInfo = api.records[0].features[0].value;

            try
            {

                if (response.Content.Length > 43)
                {

                                                                                                                                                    
            
                }
                else
                {
               
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
              
            }

            if (ModelState.IsValid)
            {
                _context.Add(@property);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(@property);
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property.FindAsync(id);
            if (@property == null)
            {
                return NotFound();
            }
            return View(@property);
        }

        // POST: Properties/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Address,City,PostalCode,Country,DateAdded,DateUpdated,GeoLocation,ImageURLs,MlsNumber,NumBathroom,NumBedroom,Price,SourceURLs,Agent,Company,Phones")] Property @property)
        {
            if (id != @property.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(@property);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PropertyExists(@property.Id))
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
            return View(@property);
        }

        // GET: Properties/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var @property = await _context.Property.FindAsync(id);
            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(int id)
        {
            return _context.Property.Any(e => e.Id == id);
        }
    }
}
