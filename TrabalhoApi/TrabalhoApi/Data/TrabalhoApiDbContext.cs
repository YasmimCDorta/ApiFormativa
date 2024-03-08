using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data.Map;
using TrabalhoApi.Models;

namespace TrabalhoApi.Data
{
    public class TrabalhoApiDbContext : DbContext
    {
        public TrabalhoApiDbContext(DbContextOptions<TrabalhoApiDbContext> options)
            : base(options)
        {

        }
        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<PedidosModel> Pedidos { get; set; }
        public DbSet<CategoriaModel> Categoria { get; set; }
        public DbSet<ProdutoModel> Produto { get; set; }
        public DbSet<PedidosProdutosModel> PedidosProdutos { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new PedidosMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new PedidosProdutosMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
