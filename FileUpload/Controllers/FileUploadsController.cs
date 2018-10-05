namespace FileUpload.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile file)
        {
                var filePath = Path.Combine(ApplicationSettings.SharedDirectory, $"{Guid.NewGuid()}-{file.FileName}");
                if (file.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }
                }
            return Ok(new {formFile = filePath});
        }
    }
}