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

        public DbSet<WinningOffer.Models.Property> Property { get; set; }

        public DbSet<WinningOffer.Models.Item> Item { get; set; }

        public DbSet<WinningOffer.Models.Propane> Propane { get; set; }

    }
}
