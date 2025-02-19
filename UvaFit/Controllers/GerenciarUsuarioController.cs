using Microsoft.AspNetCore.Mvc;
using UvaFit.Models;
using UvaFit.Repositorio;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UvaFit.Controllers
{
    public class GerenciarUsuarioController : Controller
    {

        private readonly IUsuarioRepositorio _usuarioRepositorio;


        public GerenciarUsuarioController(IUsuarioRepositorio usuarioRepositorio) 
        { 
            _usuarioRepositorio = usuarioRepositorio;
        }
        public IActionResult Index()
        {
            List<UsuarioModel> usuarios = _usuarioRepositorio.BuscarTodos();
            return View(usuarios);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            UsuarioModel usuario =  _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult DeletarConfirmacao(int id)
        {
            UsuarioModel usuario = _usuarioRepositorio.ListarPorId(id);
            return View(usuario);
        }

        public IActionResult Deletar(int id) 
        {
            try
            {
                bool deletado = _usuarioRepositorio.Deletar(id);

                if (deletado) 
                {
                    TempData["MensagemSucesso"] = "Usuário deletado com sucesso";
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível deletar o usuário";
                }
                return RedirectToAction("Index");
            }
            catch (Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível apagar o usuário! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Adicionar(UsuarioModel usuario) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Adicionar(usuario);
                    TempData["MensagemSucesso"] = "Usuário adicionado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível adicionar o usuário! Detalhe do erro: {erro.Message} ";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(UsuarioModel usuario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _usuarioRepositorio.Atualizar(usuario);
                    TempData["MensagemSucesso"] = "Usuário editado com sucesso";
                    return RedirectToAction("Index");

                }

                return View(usuario);
            }
            catch (System.Exception erro)
            {

                TempData["MensagemErro"] = $"Não foi possível editar o usuário! Detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
