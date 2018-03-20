using Microsoft.EntityFrameworkCore;

namespace Api_Venda.Models
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetalhesPed> DetalhesPeds { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }

}
