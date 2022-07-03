using Lojinha3API.Models;
using Microsoft.EntityFrameworkCore;

namespace Lojinha3API.Context
{
    public class LojinhaContext : DbContext
    {
        protected LojinhaContext()
        {
        }

        public LojinhaContext(DbContextOptions <LojinhaContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Desenvolvedora> Desenvolvedoras { get; set; }
        public DbSet<EstoqueJogos> EstoqueJogos { get; set; }
        public DbSet<JogoDesenvolvedora> JogoDesenvolvedoras { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }


    }
}
