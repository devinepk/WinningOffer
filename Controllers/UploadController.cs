using LightningOffer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LightningOffer.Controllers
{
    public class UploadController : Controller
    {

        private readonly IFileManagerLogic _fileManagerLogic;
        private readonly ILogger _logger;

        public UploadController()
        { 
        }

        public UploadController(IFileManagerLogic fileManagerLogic,
                                ILogger<UploadController> logger)
        {
            _fileManagerLogic = fileManagerLogic;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        // UPLOAD FILE
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file != null)
                {
                    await _fileManagerLogic.Upload(file);
                    _logger.LogInformation("It worked!");
                }
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Unable to upload file.  Please see the following error: " + ex.Message);

            }

            return Ok();
        }
    }
}
