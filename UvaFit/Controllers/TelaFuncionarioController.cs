using Microsoft.AspNetCore.Mvc;

namespace UvaFit.Controllers
{
    public class TelaFuncionarioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
