using Microsoft.AspNetCore.Mvc;

namespace UvaFit.Controllers
{
    public class PlanosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
