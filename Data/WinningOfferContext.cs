using Microsoft.EntityFrameworkCore;
using WinningOffer.Models;
using WinningOffer.Data;

namespace WinningOffer.Data
{
    public class WinningOfferContext : DbContext
    {

        public WinningOfferContext(DbContextOptions<WinningOfferContext> options)
            : base(options)
        {
        }

        public DbSet<Contract> Contract {get; set;}

        public DbSet<WinningOffer.Models.Contract> Property { get; set; }

        public DbSet<WinningOffer.Models.Property> Property_1 { get; set; }

        public DbSet<WinningOffer.Models.Person> Person { get; set; }

        public DbSet<WinningOffer.Models.Appliance> Appliance { get; set; }

        public DbSet<WinningOffer.Models.FuelPropane> FuelPropane { get; set; }

        public DbSet<WinningOffer.Models.Financial> Financial { get; set; }

        public DbSet<WinningOffer.Models.Appraisal> Appraisal { get; set; }

        public DbSet<WinningOffer.Models.HomeWarranty> HomeWarranty { get; set; }

        public DbSet<WinningOffer.Models.Disclosure> Disclosure { get; set; }

        public DbSet<WinningOffer.Models.Inspection> Inspection { get; set; }

        public DbSet<WinningOffer.Models.Closing> Closing { get; set; }

        public DbSet<WinningOffer.Models.Addendum> Addendum { get; set; }

       
 
    }
}
