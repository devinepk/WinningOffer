using Azure.Storage.Blobs;
using LightningOffer.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        
   

        static Helper()
        {
            _blobServiceClient = new BlobServiceClient(Startup.StaticConfiguration.GetConnectionString("BlobStorage"));
            _fileManagerLogic = new FileManagerLogic(_blobServiceClient);
         
        }
        public static async void Upload(IFormFile file)
        {
            if (file != null)
            { 
                try
                {
                    await _fileManagerLogic.Upload(file);
                    //TODO: ("It worked!");
                    return;
                }
                catch (Exception ex)
                {

                    {
                        Console.WriteLine(ex.Message);// TODO:("Azure file upload failed: " + ex.Message);

                    }

                }
            }

            return;
        }
    }
}
