using GamerProject_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace GamerProject_MVC.Infra
{
    public class Context : DbContext
    {
        public Context()
        {
        }

        public Context(DbContextOptions<Context> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //string de conexão com o banco
                // data source: nome do servidor do gerenciador do banco

                // AUTENTICACAO PELO WINDOWS

                // integrated security: autenticacao pelo windows
                // TrustServerCertificate: autenticacao pelo windows

                // AUTENTICACAO PELO SQLSERVER
                // user Id = "nome do seu usuario de login"
                // pwd = "senha do seu usuario"
                optionsBuilder.UseSqlServer("Data Source = NOTE22-S15; Initial catalog = gamerManha; User Id = sa; pwd = Senai@134; TrustServerCertificate = true"); //string de conexão com o banco
            }
        }

        // referencia de classes e tabelas
        public DbSet<Jogador> Jogador { get; set; }
        public DbSet<Equipe> Equipe { get; set; }
    }
}