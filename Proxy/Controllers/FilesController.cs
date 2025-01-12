using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace YourNamespace.Controllers
{
    public class FilesController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly string _uploadPath;

        public FilesController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
            _uploadPath = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
        }

        public IActionResult Index()
        {
            var files = Directory.GetFiles(_uploadPath);
            ViewBag.Files = files.Select(f => Path.GetFileName(f)).ToList();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile[] files)
        {
            if (files != null && files.Length > 0)
            {
                foreach (var file in files)
                {
                    if (file.Length > 0)
                    {
                        string filePath = Path.Combine(_uploadPath, file.FileName);
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(stream);
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult Download(string filename)
        {
            var filePath = Path.Combine(_uploadPath, filename);
            if (System.IO.File.Exists(filePath))
            {
                var memory = new MemoryStream();
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                return File(memory, "application/octet-stream", filename);
            }
            return NotFound();
        }
    }
}
