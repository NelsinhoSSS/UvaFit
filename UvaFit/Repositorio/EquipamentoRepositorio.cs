using UvaFit.Data;
using UvaFit.Models;

using UvaFit.Data;
using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public class EquipamentoRepositorio : IEquipamentoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public EquipamentoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public EquipamentoModel ListarPorId(int id)
        {
            return _bancoContext.Equipamentos.FirstOrDefault(x => x.Id == id);
        }

        public List<EquipamentoModel> BuscarTodos()
        {
            return _bancoContext.Equipamentos.ToList();
        }

        public EquipamentoModel Adicionar(EquipamentoModel equipamento)
        {
            _bancoContext.Equipamentos.Add(equipamento);
            _bancoContext.SaveChanges();
            return equipamento;
        }

        public EquipamentoModel Atualizar(EquipamentoModel equipamento)
        {
            EquipamentoModel equipamentoDB = ListarPorId(equipamento.Id);
            if (equipamentoDB == null) throw new SystemException("Houve um erro na atualização do equipamento!");

            equipamentoDB.Nome = equipamento.Nome;
            equipamentoDB.SituacaoEquipamento = equipamento.SituacaoEquipamento;

            _bancoContext.Equipamentos.Update(equipamentoDB);
            _bancoContext.SaveChanges();

            return equipamentoDB;
        }

        public bool Deletar(int id)
        {
            EquipamentoModel equipamentoDB = ListarPorId(id);
            if (equipamentoDB == null) throw new SystemException("Houve um erro na deleção do equipamento!");

            _bancoContext.Equipamentos.Remove(equipamentoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}

