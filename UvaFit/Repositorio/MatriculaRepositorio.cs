using Microsoft.EntityFrameworkCore;
using UvaFit.Data;
using UvaFit.Models;

namespace UvaFit.Repositorio
{
    public class MatriculaRepositorio : IMatriculaRepositorio
    {
        private readonly BancoContext _context;

        public MatriculaRepositorio(BancoContext context)
        {
            _context = context;
        }

        public MatriculaModel Adicionar(MatriculaModel matricula)
        {
            _context.Matriculas.Add(matricula);
            _context.SaveChanges();
            return matricula;
        }

        public List<MatriculaModel> BuscarTodas()
        {
            return _context.Matriculas.ToList();
        }

        public MatriculaModel BuscarPorId(int id)
        {
            return _context.Matriculas.FirstOrDefault(m => m.Id == id);
        }

        public MatriculaModel Atualizar(MatriculaModel matricula)
        {
            _context.Matriculas.Update(matricula);
            _context.SaveChanges();
            return matricula;
        }

        public bool Remover(int id)
        {
            var matricula = BuscarPorId(id);
            if (matricula == null) return false;

            _context.Matriculas.Remove(matricula);
            _context.SaveChanges();
            return true;
        }
    }
}
