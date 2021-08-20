using Azure.Storage.Blobs;
using LightningOffer.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace LightningOffer
{
    public static class Helper
    {
        
        private static readonly IFileManagerLogic _fileManagerLogic;
        private static readonly BlobServiceClient _blobServiceClient;
       //TODO private static ILogger _logger;

        static Helper()
        {
            _blobServiceClient = new BlobServiceClient(Startup.StaticConfiguration.GetConnectionString("BlobStorage"));
            _fileManagerLogic = new FileManagerLogic(_blobServiceClient);
            //_logger = new Logger();
        }
        public static async void Upload(IFormFile file)
        {
            if (file != null)
            { 
                try
                {
                    await _fileManagerLogic.Upload(file);
                    _logger.LogInformation("It worked!");
                    return;
                }
                catch (Exception ex)
                {

                    {
                        _logger.LogCritical("Unable to upload file.  Please see the following error: " + ex.Message);

                    }

                }
            }
            return;
        }
    }
}
