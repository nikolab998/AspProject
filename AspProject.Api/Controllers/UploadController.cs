using AspProject.Application;
using AspProject.DataAccess;
using AspProject.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AspProject.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly UseCaseExecutor _executor;
        private readonly IApplicationActor _actor;
        private readonly AspProjectContext _context;

        public UploadController(UseCaseExecutor executor, IApplicationActor actor, AspProjectContext context)
        {
            _executor = executor;
            _actor = actor;
            _context = context;
        }

        // POST api/<UploadController>
        [HttpPost]
        public IActionResult Post([FromForm] UploadDto dto)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(dto.Image.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                dto.Image.CopyTo(fileStream);
            }

            var image = new Image
            {
                ImagePath = newFileName,
                IsActive = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.Images.Add(image);
            _context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created);
        }
    }

    public class UploadDto
    {
        public IFormFile Image { get; set; }
    }
}
