using Microsoft.AspNetCore.Mvc;
using UvaFit.Models;
using UvaFit.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UvaFit.Controllers
{
    public class GerenciarEquipamentoController : Controller
    {

        private readonly IEquipamentoRepositorio _equipamentoRepositorio;


        public GerenciarEquipamentoController(IEquipamentoRepositorio equipamentoRepositorio)
        {
            _equipamentoRepositorio = equipamentoRepositorio;
        }
        public IActionResult Index()
        {
            List<EquipamentoModel> equipamentos = _equipamentoRepositorio.BuscarTodos();
            return View(equipamentos);
        }

        public IActionResult EquipamentoAlunoIndex()
        {
            List<EquipamentoModel> equipamentos = _equipamentoRepositorio.BuscarTodos();
            return View(equipamentos);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            EquipamentoModel equipamento = _equipamentoRepositorio.ListarPorId(id);
            return View(equipamento);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            EquipamentoModel equipamento = _equipamentoRepositorio.ListarPorId(id);
            return View(equipamento);
        }

        public IActionResult Deletar(int id)
        {
            try
            {
                bool deletado = _equipamentoRepositorio.Deletar(id);

                if (deletado)
                {
                    TempData["MensagemSucesso"] = "Equipamento deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar o equipamento";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível apagar o equipamento ! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(EquipamentoModel equipamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _equipamentoRepositorio.Adicionar(equipamento);
                    TempData["MensagemSucesso"] = "Equipamento adicionado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(equipamento);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível adicionar o equipamento! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(EquipamentoModel equipamento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _equipamentoRepositorio.Atualizar(equipamento);
                    TempData["MensagemSucesso"] = "Equipamento editado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(equipamento);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível editar o equipamento! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
