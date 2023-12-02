using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("author");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .HasMaxLength(40)
        .IsRequired();

        builder.Property(e => e.Apellido)
        .IsRequired()
        .HasMaxLength(40)
        .HasColumnName("apellido");

        builder.Property(e => e.Nacimiento)
        .HasColumnName("nacimiento")
        .IsRequired()
        .HasColumnType("date");

        builder.Property(e => e.Email)
        .HasColumnName("email")
        .IsRequired()
        .HasMaxLength(60);

        builder.Property(e => e.AcercaDe)
        .HasColumnName("acerca_de")
        .IsRequired()
        .HasColumnType("text");

        builder.HasOne(e => e.Pais)
        .WithMany(e => e.Authores)
        .HasForeignKey(e => e.IdPais);
    }
}