using Microsoft.AspNetCore.Mvc;
using UvaFit.Data;
using UvaFit.Models;
using System.Linq;
using UvaFit.Enums;

public class TelaLoginController : Controller
{
    private readonly BancoContext _context;

    public TelaLoginController(BancoContext context)
    {
        _context = context;
    }

    // Exibe a página de login
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    // Processa o login
    [HttpPost]
    public IActionResult Login(string email, string senha)
    {
        // Verifica se o usuário existe no banco de dados
        var user = _context.Usuarios.SingleOrDefault(u => u.Email == email);

        if (user == null || user.Senha != senha)
        {
            // Caso o usuário não exista ou a senha esteja incorreta
            TempData["LoginError"] = "Usuário ou senha inválidos!";
            return RedirectToAction("Index"); // Volta para a tela de login
        }

        // Verifica o perfil do usuário e redireciona para a tela correspondente
        if (user.Perfil == PerfilEnum.Aluno)
        {
            return RedirectToAction("Index", "TelaAluno");
        }
        else
        {
            return RedirectToAction("Index", "TelaFuncionario");
        }
    }
}
