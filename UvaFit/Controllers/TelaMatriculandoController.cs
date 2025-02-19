using Microsoft.AspNetCore.Mvc;
using UvaFit.Data;
using UvaFit.Enums;
using UvaFit.Models;
using System;

public class TelaMatriculandoController : Controller
{
    private readonly BancoContext _context;

    public TelaMatriculandoController(BancoContext context)
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
        // Verifica se o TempData["MatriculaData"] existe
        var matriculaJson = TempData.Peek("MatriculaData") as string;

        // Verifica se o TempData não é null ou vazio
        if (string.IsNullOrEmpty(matriculaJson))
        {
            TempData["MensagemErro"] = "Dados da matrícula não encontrados!";
            return RedirectToAction("Etapa1");
        }

        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        // Verifica se o modelo foi corretamente desserializado
        if (model == null)
        {
            TempData["MensagemErro"] = "Erro ao carregar dados da matrícula!";
            return RedirectToAction("Etapa1");
        }

        TempData.Keep("MatriculaData");  // Manter os dados de TempData para a próxima etapa
        return View(model);
    }

    // Processa a segunda etapa e avança para a terceira
    [HttpPost]
    public IActionResult Etapa2(PlanoMatriculaEnum plano)
    {
        var matriculaJson = TempData.Peek("MatriculaData") as string;
        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        if (model == null)
        {
            TempData["MensagemErro"] = "Dados não encontrados para continuar o processo!";
            return RedirectToAction("Etapa1");
        }

        model.PlanoMatricula = plano;
        TempData["MatriculaData"] = System.Text.Json.JsonSerializer.Serialize(model);
        return RedirectToAction("Etapa3");
    }

    // Exibe a última etapa para revisão e confirmação
    [HttpGet]
    public IActionResult Etapa3()
    {
        var matriculaJson = TempData.Peek("MatriculaData") as string;

        // Verifica se o TempData não é null ou vazio
        if (string.IsNullOrEmpty(matriculaJson))
        {
            TempData["MensagemErro"] = "Dados da matrícula não encontrados!";
            return RedirectToAction("Etapa1");
        }

        var model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);

        // Verifica se o modelo foi corretamente desserializado
        if (model == null)
        {
            TempData["MensagemErro"] = "Erro ao carregar dados da matrícula!";
            return RedirectToAction("Etapa1");
        }

        TempData.Keep("MatriculaData");  // Manter os dados de TempData para a próxima etapa
        return View(model);
    }

    // Finaliza o processo e salva no banco
    [HttpPost]
    public IActionResult Finalizar()
    {
        var matriculaJson = TempData.Peek("MatriculaData") as string;

        // Verifica se o TempData não é null ou vazio
        if (string.IsNullOrEmpty(matriculaJson))
        {
            TempData["MensagemErro"] = "Dados da matrícula não encontrados!";
            return RedirectToAction("Etapa1");
        }

        // Tenta desserializar o objeto
        MatriculaModel model;
        try
        {
            model = System.Text.Json.JsonSerializer.Deserialize<MatriculaModel>(matriculaJson);
        }
        catch (Exception ex)
        {
            TempData["MensagemErro"] = $"Erro ao processar os dados da matrícula: {ex.Message}";
            return RedirectToAction("Etapa1");
        }

        // Verifica se o modelo foi corretamente desserializado
        if (model == null)
        {
            TempData["MensagemErro"] = "Dados inválidos! Tente novamente.";
            return RedirectToAction("Etapa1");
        }

        model.DataCadastro = DateTime.Now;
        model.DataPagamento = DateTime.Now.AddMonths(1); // Exemplo de data

        // Salva no banco de dados
        _context.Matriculas.Add(model);
        _context.SaveChanges();

        TempData["MensagemSucesso"] = "Matrícula realizada com sucesso!";
        return RedirectToAction("Index", "Home");
    }
}
