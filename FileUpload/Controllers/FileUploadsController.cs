namespace FileUpload.Controllers
{
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
        [HttpPost("upload")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            var filePathsList = new List<string>();

            foreach (var formFile in files)
            {
                var filePath = Path.Combine(ApplicationSettings.SharedDirectory, formFile.FileName);
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }

                filePathsList.Add(filePath);
            }

            return Ok(new {count = files.Count, size, filePathsList});
        }
    }
}