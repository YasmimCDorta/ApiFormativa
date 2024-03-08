using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrabalhoApi.Models;


namespace TrabalhoApi.Data.Map
{
    public class PedidosProdutosMap : IEntityTypeConfiguration<PedidosProdutosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosProdutosModel> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.CategoriaId);
        builder.Property(x => x.ProdutoId);
        builder.HasOne(x => x.Categoria);
        builder.HasOne(x => x.Produto);
        builder.Property(x => x.Quantidade).IsRequired().HasMaxLength(10); ;
    }
    }
}
