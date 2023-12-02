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
    }
}