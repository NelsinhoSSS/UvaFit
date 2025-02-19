using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel ListarPorId(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel Usuario);
        UsuarioModel Atualizar(UsuarioModel Usuario);
        bool Deletar(int id);
    }
}
