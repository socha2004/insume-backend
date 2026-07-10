using Microsoft.AspNetCore.Mvc;

namespace insume_backend.Api.Controllers
{
    public class InsumoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
