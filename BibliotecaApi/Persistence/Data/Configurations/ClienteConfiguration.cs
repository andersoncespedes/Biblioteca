using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("cliente");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Direccion)
        .HasColumnName("direccion")
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(e => e.Telefono)
        .IsRequired()
        .HasColumnName("telefono")
        .HasMaxLength(20);

        builder.Property(e => e.Apellido)
        .IsRequired()
        .HasMaxLength(40)
        .HasColumnName("apellido");

        builder.HasOne(e => e.Ciudad)
        .WithMany(e => e.Clientes)
        .HasForeignKey(e => e.IdCiudad);

        builder.HasOne(e => e.TipoDocumento)
        .WithMany(e => e.Clientes)
        .HasForeignKey(e => e.IdTipoDocumento);
        
    }
}