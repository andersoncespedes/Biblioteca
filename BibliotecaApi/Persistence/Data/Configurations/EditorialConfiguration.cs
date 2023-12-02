using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class EditorialConfiguration : IEntityTypeConfiguration<Editorial>
{
    public void Configure(EntityTypeBuilder<Editorial> builder)
    {
        builder.ToTable("editorial");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.WebSite)
        .HasColumnName("website")
        .HasMaxLength(70);

        builder.Property(e => e.Direccion)
        .HasColumnName("direccion")
        .IsRequired()
        .HasMaxLength(55);

        builder.HasOne(e => e.Ciudad)
        .WithMany(e => e.Editoriales)
        .HasForeignKey(e => e.IdCiudad);
    }
}
