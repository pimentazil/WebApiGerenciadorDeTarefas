using Microsoft.EntityFrameworkCore;
using GerenciadorDeTarefas.Repository.Models;

namespace GerenciadorDeTarefas.Repository
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TabTarefas> tabTarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TabTarefas>().ToTable("tabTarefas"); 
        }
    }
}
