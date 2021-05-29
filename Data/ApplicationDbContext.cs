using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using LightningOffer.Models;

namespace LightningOffer.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<LightningOffer.Models.Addendum> Addendum { get; set; }
        public DbSet<LightningOffer.Models.Appliance> Appliance { get; set; }
        public DbSet<LightningOffer.Models.Appraisal> Appraisal { get; set; }
        public DbSet<LightningOffer.Models.Closing> Closing { get; set; }
        public DbSet<LightningOffer.Models.Contract> Contract { get; set; }
        public DbSet<LightningOffer.Models.Disclosure> Disclosure { get; set; }
        public DbSet<LightningOffer.Models.Financial> Financial { get; set; }
        public DbSet<LightningOffer.Models.FuelPropane> FuelPropane { get; set; }
        public DbSet<LightningOffer.Models.HomeWarranty> HomeWarranty { get; set; }
        public DbSet<LightningOffer.Models.Inspection> Inspection { get; set; }
        public DbSet<LightningOffer.Models.Person> Person { get; set; }
        public DbSet<LightningOffer.Models.Property> Property { get; set; }
    }
}
