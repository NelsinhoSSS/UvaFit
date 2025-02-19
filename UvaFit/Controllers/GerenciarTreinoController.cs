using Microsoft.AspNetCore.Mvc;
using UvaFit.Models;
using UvaFit.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UvaFit.Controllers
{
    public class GerenciarTreinoController : Controller
    {

        private readonly ITreinoRepositorio _treinoRepositorio;


        public GerenciarTreinoController(ITreinoRepositorio treinoRepositorio)
        {
            _treinoRepositorio = treinoRepositorio;
        }
        public IActionResult Index()
        {
            List<TreinoModel> treinos = _treinoRepositorio.BuscarTodos();
            return View(treinos);
        }

        public IActionResult TreinoAlunoIndex()
        {
            List<TreinoModel> treinos = _treinoRepositorio.BuscarTodos();
            return View(treinos);
        }


        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            TreinoModel treino = _treinoRepositorio.ListarPorId(id);
            return View(treino);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            TreinoModel treino = _treinoRepositorio.ListarPorId(id);
            return View(treino);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _treinoRepositorio.Deletar(id);

                if (deletado)
                {
                    TempData["MensagemSucesso"] = "Treino deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar o treino";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível apagar o treino! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(TreinoModel treinol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _treinoRepositorio.Adicionar(treinol);
                    TempData["MensagemSucesso"] = "Treino adicionado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(treinol);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível adicionar o treino! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(TreinoModel treinol)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _treinoRepositorio.Atualizar(treinol);
                    TempData["MensagemSucesso"] = "Treino editado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(treinol);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível editar o treino! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
