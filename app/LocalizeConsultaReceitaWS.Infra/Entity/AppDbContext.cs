using LocalizeConsultaReceitaWS.Domain.Pedido;
using LocalizeConsultaReceitaWS.Domain.Usuario;
using Microsoft.EntityFrameworkCore;

namespace LocalizeConsultaReceitaWS.Infra.Entity
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
