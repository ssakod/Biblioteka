using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.IO;

namespace Biblioteka.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        [HttpGet("pdf")]
        public IActionResult GetPdf([FromQuery] string filePath)
        {
            if (string.IsNullOrWhiteSpace(filePath) || !System.IO.File.Exists(filePath))
            {
                return NotFound("File not found.");
            }

            try
            {
                var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                return File(stream, "application/pdf", enableRangeProcessing: true); // Allows streaming
            }
            catch (Exception ex)
            {
                return BadRequest($"Error loading PDF: {ex.Message}");
            }
        }
    }

}
