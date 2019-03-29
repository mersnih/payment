using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Payment.API.Controllers
{
    public class FullBack : Controller
    {
        public IActionResult Index()
        {
            return PhysicalFile(Path.Combine(Directory.GetCurrentDirectory(),
                               "wwwroot", "index.html"), "text/HTML");
        }
    }
}