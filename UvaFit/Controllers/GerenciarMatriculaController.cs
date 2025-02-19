using Microsoft.AspNetCore.Mvc;
using UvaFit.Models;
using UvaFit.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UvaFit.Controllers
{
    public class GerenciarMatriculaController : Controller
    {

        private readonly IMatriculaRepositorio _matriculaRepositorio;


        public GerenciarMatriculaController(IMatriculaRepositorio matriculaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
        }
        public IActionResult Index()
        {
            List<MatriculaModel> matriculas = _matriculaRepositorio.BuscarTodas();
            return View(matriculas);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            MatriculaModel matricula = _matriculaRepositorio.BuscarPorId(id);
            return View(matricula);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            MatriculaModel matricula = _matriculaRepositorio.BuscarPorId(id);
            return View(matricula);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _matriculaRepositorio.Remover(id);

                if (deletado)
                {
                    TempData["MensagemSucesso"] = "Matrícula deletada com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar a matrícula";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível deletar a matrícula! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(MatriculaModel matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _matriculaRepositorio.Adicionar(matricula);
                    TempData["MensagemSucesso"] = "Matrícula adicionada com sucesso";
                    return RedirectToAction("Index");

                }

                return View(matricula);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível adicionar a matrícula! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(MatriculaModel matricula)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _matriculaRepositorio.Atualizar(matricula);
                    TempData["MensagemSucesso"] = "Matricula editada com sucesso";
                    return RedirectToAction("Index");

                }

                return View(matricula);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível editar a matrícula! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
