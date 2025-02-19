using Microsoft.EntityFrameworkCore;
using UvaFit.Models;

namespace UvaFit.Data
{
    public class BancoContext : DbContext
    {
        // Construtor do contexto, configurado para receber as opções
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }

        // DbSets para mapear as tabelas do banco de dados
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<EquipamentoModel> Equipamentos { get; set; }
        public DbSet<MatriculaModel> Matriculas { get; set; }
        public DbSet<TreinoModel> Treinos { get; set; }

        // Configurações adicionais de mapeamento
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            // Outras configurações de entidades podem ser adicionadas aqui
        }
    }
}
