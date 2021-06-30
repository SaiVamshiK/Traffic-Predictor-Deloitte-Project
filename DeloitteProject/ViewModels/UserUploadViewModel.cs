using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeloitteProject.ViewModels
{
    public class UserUploadViewModel
    {
        public IFormFile File { get; set; }
    }
}
