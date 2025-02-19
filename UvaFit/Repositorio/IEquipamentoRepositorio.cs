using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public interface IEquipamentoRepositorio
    {
        EquipamentoModel ListarPorId(int id);
        List<EquipamentoModel> BuscarTodos();
        EquipamentoModel Adicionar(EquipamentoModel Equipamento);
        EquipamentoModel Atualizar(EquipamentoModel Equipamento);
        bool Deletar(int id);
    }
}
