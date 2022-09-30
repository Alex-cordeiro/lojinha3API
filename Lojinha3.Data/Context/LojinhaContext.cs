using Lojinha3.Domain.Model.Access;
using Lojinha3.Domain.Model.Access.Relations;
using Lojinha3.Domain.Model.Games;
using Lojinha3.Domain.Model.Inventory;
using Lojinha3.Domain.Model.Navigation;
using Lojinha3.Domain.Model.Relations;
using Microsoft.EntityFrameworkCore;

namespace Lojinha3API.Context
{
    public class LojinhaContext : DbContext
    {
        public LojinhaContext(DbContextOptions options) : base(options)
        {
        }

        //Games
        public DbSet<Jogo> Jogos { get; set; }
        public DbSet<Desenvolvedora> Desenvolvedoras { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<JogoDesenvolvedora> JogosDesenvolvedoras { get; set; }
        public DbSet<Plataforma> Plataformas { get; set; }
        public DbSet<JogoPlataforma> JogosPlataformas { get; set; }


        //Access
        public DbSet<CategoriaAcesso> CategoriaMenuAcessos { get; set; }
        public DbSet<PermissaoUsuario> PermissaoUsuarios { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }



        //Navigation
        public DbSet<Menu> Menus { get; set; }
        //Inventory
        public DbSet<Estoque> Estoques { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(LojinhaContext).Assembly);
        }
    }
}
