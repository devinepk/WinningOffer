using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Identity;

namespace LightningOffer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)

                            // TODO: Figure out how to set these based on debug vs release.
                        
                           // For pushing to production
                           /*
                         .ConfigureAppConfiguration((context, config) =>
                         {
                            var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
                            config.AddAzureKeyVault(
                            keyVaultEndpoint,
                            new DefaultAzureCredential());
                         })
                           */

                            // For inhouse testing
                         .ConfigureWebHostDefaults(webBuilder =>
                         {
                            webBuilder.UseStartup<Startup>();
                         });
    }
}
