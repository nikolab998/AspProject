using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace AspProject.Application.DataTransfer
{
    public class UploadDto
    {
        public IFormFile Image { get; set; }
    }
}
