using System;
using LightningOffer.Data;
using LightningOffer.Models;
using LightningOffer.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LightningOffer.Areas.Identity.IdentityHostingStartup))]
namespace LightningOffer.Areas.Identity
{
   
    public class IdentityHostingStartup : IHostingStartup
    {

        public IdentityHostingStartup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void Configure(IWebHostBuilder builder)
        {



            builder.ConfigureServices((context, services) => {


                // requires
                // using Microsoft.AspNetCore.Identity.UI.Services;
                // using WebPWrecover.Services;
                services.AddTransient<IEmailSender, EmailSender>();
                services.Configure<AuthMessageSenderOptions>(Configuration);
            });

        }
    }
}