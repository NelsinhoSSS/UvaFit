using Microsoft.AspNetCore.Mvc;

namespace UvaFit.Controllers
{
    public class TelaAlunoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Visualizar()
        {
            return View();
        }

        public IActionResult Treino()
        {
            return View();
        }
    }
}
