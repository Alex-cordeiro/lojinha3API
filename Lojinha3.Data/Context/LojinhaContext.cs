using Lojinha3.Domain.Model;
using Lojinha3.Domain.Model.Relations;
using Microsoft.EntityFrameworkCore;

namespace Lojinha3API.Context
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Desenvolvedora> Desenvolvedoras { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<JogoDesenvolvedora> JogosDesenvolvedoras { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<JogoPlataforma> JogosPlataformas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojinhaContext).Assembly);
        }
    }
}
