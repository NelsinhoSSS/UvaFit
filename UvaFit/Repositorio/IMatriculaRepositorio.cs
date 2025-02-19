using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public interface IMatriculaRepositorio
    {
        MatriculaModel Adicionar(MatriculaModel matricula);
        List<MatriculaModel> BuscarTodas();
        MatriculaModel BuscarPorId(int id);
        MatriculaModel Atualizar(MatriculaModel matricula);
        bool Remover(int id);
    }
}
