using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LightningOffer.Data;
using LightningOffer.Models;
using Microsoft.Extensions.Configuration;
using RestSharp;
using System.IO;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Logging;

namespace LightningOffer.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Returns Appliances View
        public IActionResult Appliance()
        {
            return View();
        }

        // GET: Properties
        public async Task<IActionResult> Index()
        {
            return View(await _context.Property.ToListAsync());
        }

        // GET: Properties/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Property_id == id);
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
        public async Task<IActionResult> Create(string Address, string County, [Bind("Id,Address,City,PostalCode,Country,ImageURLs,MlsNumber,Price,ListingAgent, ListingCompany, ListingAgentPhone,SourceURLs,DeedBook, Page, BlockNum,LotNum, SubLotNum,County")] Property @property)
        {
            // create a new instance of the property object
            Property newProperty = new Property();
            Contract newContract = new Contract();
            Person newPerson = new Person();

            // set the values for the contract
            newContract.OwnerID = User.Identity.Name;
            newContract.CreatedDate = DateTime.Now;



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

                    
                    //build the records
                    var records = api.records;

                    //Property model
                    newProperty.Address = api.records[0].address;
                    newProperty.MlsNumber = api.records[0].mlsNumber;
                    newProperty.City = api.records[0].city;
                    newProperty.PostalCode = api.records[0].postalCode;
                    newProperty.Country = api.records[0].country;
                    //list price = api.records[0].prices[0].amountMax;

                    var listingBrokerDates = api.records[0].brokers;
                    //find the most recent broker
                    var listingBrokerInfo = listingBrokerDates[listingBrokerDates.Count - 1];
                    newPerson.ListCompany = listingBrokerInfo.company; //company name
                    newPerson.ListAgent = listingBrokerInfo.agent; //agent name
                    
                    if (api["phones"] != null) //check is the object key exists.  It's not always available and will crash if not handled.
                    {
                        newPerson.ListAgentPhone = listingBrokerInfo.phones[0]; 
                    } else
                    {
                        newPerson.ListAgentPhone = null;
                    }
                        

                    //misc property info (image URL and parcel num)
                    newProperty.ImageURLs = api.records[0].imageURLS; //what to do if the record doesn't exist?

                    //TODO:
                    var recordsParcelInfo = api.records[0].features[28];

                    newProperty.DeedBook = "";// public string DeedBook
                    newProperty.Page = "";// pubic string Page
                    newProperty.BlockNum = "";// public blockNum
                    newProperty.LotNum = ""; // public lotNum use the Key value method here
                    newProperty.SubLotNum = "";// public subLotNum
                    newProperty.County = County;// county

                    DateTime now = DateTime.Now;
                    newProperty.CreatedDate = now;

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

                //Property model
                //newProperty.Property_id = rnd.Next();
                newProperty.Address = api.records[0].address;
                newProperty.MlsNumber = api.records[0].mlsNumber;
                newProperty.City = api.records[0].city;
                newProperty.PostalCode = api.records[0].postalCode;
                newProperty.Country = api.records[0].country;
                //list price = api.records[0].prices[0].amountMax;

                var listingBrokerDates = api.records[0].brokers;
                //find the most recent broker
                var listingBrokerInfo = listingBrokerDates[listingBrokerDates.Count - 1];
                newPerson.ListCompany = listingBrokerInfo.company; //company name
                newPerson.ListAgent = listingBrokerInfo.agent; //agent name
                
                if (api["phones"] != null) //check is the object key exists.  It's not always available and will crash if not handled.
                {
                    newPerson.ListAgentPhone = listingBrokerInfo.phones[0];
                }
                else
                {
                    newPerson.ListAgentPhone = null;
                }

                //misc property info (image URL and parcel num)
                newProperty.ImageURLs = api.records[0].imageURLS; //what to do if the record doesn't exist?

                //TODO:
                var recordsParcelInfo = api.records[0].features[28];

                newProperty.DeedBook = "";// public string DeedBook
                newProperty.Page = "";// pubic string Page
                newProperty.BlockNum = "";// public blockNum
                newProperty.LotNum = recordsParcelInfo.// public lotNum use the Key value method here
                newProperty.SubLotNum = "";// public subLotNum
                newProperty.County = County;// county

                DateTime now = DateTime.Now;
                newProperty.CreatedDate = now;

            }



            if (ModelState.IsValid)
            {
                _context.Add(newProperty);
                _context.Add(newContract);

                await _context.SaveChangesAsync(); //the changes get saved to the db 
                return RedirectToAction("Create","Appliances"); //redirect to adding the appliances
            } else
            {
                return View(); // TODO: messaging that the property is not available
            }
        }

        // GET: Properties/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
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
        public async Task<IActionResult> Edit(Guid id, [Bind("Property_id,CreatedDate,MlsNumber,Address,City,PostalCode,Country,DeedBook,Page,BlockNum,LotNum,SubLotNum,County,ImageURLs")] Property @property)
        {
            if (id != @property.Property_id)
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
                    if (!PropertyExists(@property.Property_id))
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
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var @property = await _context.Property
                .FirstOrDefaultAsync(m => m.Property_id == id);
            if (@property == null)
            {
                return NotFound();
            }

            return View(@property);
        }

        // POST: Properties/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var @property = await _context.Property.FindAsync(id);
            _context.Property.Remove(@property);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PropertyExists(Guid id)
        {
            return _context.Property.Any(e => e.Property_id == id);
        }
    }
}
