﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TrabalhoApi.Models;


namespace TrabalhoApi.Data.Map
{
    public class PedidosMap : IEntityTypeConfiguration<PedidosModel>
    {
        public void Configure(EntityTypeBuilder<PedidosModel> builder)
        {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.EnderecoEntrega).IsRequired().HasMaxLength(255);
        builder.Property(x => x.UsuarioId);
        builder.HasOne(x => x.Usuario);
        }
    }
}
