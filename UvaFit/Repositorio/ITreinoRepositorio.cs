using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public interface ITreinoRepositorio
    {
        TreinoModel ListarPorId(int id);
        List<TreinoModel> BuscarTodos();
        TreinoModel Adicionar(TreinoModel Treino);
        TreinoModel Atualizar(TreinoModel Treino);
        bool Deletar(int id);
    }
}