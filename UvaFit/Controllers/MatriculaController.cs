using Microsoft.AspNetCore.Mvc;
using UvaFit.Data;
using UvaFit.Enums;
using UvaFit.Models;

public class MatriculaController : Controller
{
    private readonly BancoContext _context;

    public MatriculaController(BancoContext context)
    {
        _context = context;
    }

    // Exibe a primeira etapa
    [HttpGet]
    public IActionResult Etapa1()
    {
        return View(new MatriculaModel());
    }

    // Processa a primeira etapa e avança para a segunda
    [HttpPost]
    public IActionResult Etapa1(MatriculaModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        TempData["MatriculaData"] = System.Text.Json.JsonSerializer.Serialize(model);
        return RedirectToAction("Etapa2");
    }

    // Exibe a segunda etapa
    [HttpGet]
    public IActionResult Etapa2()
    {
        return View();
    }

    // Processa a segunda etapa e avança para a terceira
    [HttpPost]
    public IActionResult Etapa2(PlanoMatriculaEnum plano)
    {
        var matriculaJson = TempData["MatriculaData"] as string;
        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        model.PlanoMatricula = plano;
        TempData["MatriculaData"] = System.Text.Json.JsonSerializer.Serialize(model);
        return RedirectToAction("Etapa3");
    }

    // Exibe a última etapa para revisão e confirmação
    [HttpGet]
    public IActionResult Etapa3()
    {
        var matriculaJson = TempData["MatriculaData"] as string;
        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        return View(model);
    }

    // Finaliza o processo e salva no banco
    [HttpPost]
    public IActionResult Finalizar()
    {
        var matriculaJson = TempData["MatriculaData"] as string;
        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        model.DataCadastro = DateTime.Now;
        model.DataPagamento = DateTime.Now.AddMonths(1); // Exemplo

        _context.Matriculas.Add(model);
        _context.SaveChanges();

        TempData["MensagemSucesso"] = "Matrícula realizada com sucesso!";
        return RedirectToAction("Index", "Home");
    }
}
