using UvaFit.Data;
using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public class TreinoRepositorio : ITreinoRepositorio
    {

        private readonly BancoContext _bancoContext;

        public TreinoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public TreinoModel ListarPorId(int id)
        {
            return _bancoContext.Treinos.FirstOrDefault(x => x.Id == id);
        }

        public List<TreinoModel> BuscarTodos()
        {
            return _bancoContext.Treinos.ToList();
        }

        public TreinoModel Adicionar(TreinoModel treino)
        {
            _bancoContext.Treinos.Add(treino);
            _bancoContext.SaveChanges();
            return treino;
        }

        public TreinoModel Atualizar(TreinoModel treino)
        {
            TreinoModel treinoDB = ListarPorId(treino.Id);
            if (treinoDB == null) throw new SystemException("Houve um erro na atualização do treino!");

            treinoDB.Nome = treino.Nome;
            treinoDB.CPF = treino.CPF;
            treinoDB.Treino = treino.Treino;

            _bancoContext.Treinos.Update(treinoDB);
            _bancoContext.SaveChanges();

            return treinoDB;
        }

        public bool Deletar(int id)
        {
            TreinoModel treinoDB = ListarPorId(id);
            if (treinoDB == null) throw new SystemException("Houve um erro na deleção do treino!");

            _bancoContext.Treinos.Remove(treinoDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
