using ApiTarefa.Data.Map;
using ApiTarefa.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefa.Data
{
    public class SistemaTarefaDbContext : DbContext
    {
        public SistemaTarefaDbContext(DbContextOptions<SistemaTarefaDbContext> options)
            : base(options)
        {
        }
        public DbSet<UsuarioModel> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    }

}
