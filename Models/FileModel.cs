using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace LightningOffer.Models
{
    public class FileModel
    {
        public IFormFile file { get; set; }

    }
}
