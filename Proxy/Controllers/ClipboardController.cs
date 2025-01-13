using Microsoft.AspNetCore.Mvc;

namespace Proxy.Controllers
{
    public class ClipboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
