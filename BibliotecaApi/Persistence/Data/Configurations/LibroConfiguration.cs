using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configurations;
public class LibroConfiguration : IEntityTypeConfiguration<Libro>
{
    public void Configure(EntityTypeBuilder<Libro> builder)
    {
        builder.ToTable("libro");

        builder.Property(e => e.Nombre)
        .HasColumnName("nombre")
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(e => e.Sinopsis)
        .HasColumnName("sinopsis")
        .IsRequired()
        .HasMaxLength(255);

        builder.Property(e => e.Publicacion)
        .HasColumnType("date")
        .HasColumnName("fecha_publicacion")
        .IsRequired();

        builder.Property(e => e.Cantidad)
        .HasColumnName("cantidad")
        .IsRequired();

        builder.HasOne(e => e.Estado)
        .WithMany(e => e.Libros)
        .HasForeignKey(e => e.IdEstado);

        builder.HasOne(e => e.Editorial)
        .WithMany(e => e.Libros)
        .HasForeignKey(e => e.IdEditorial);
        builder.HasOne(e => e.Author)
        .WithMany(e => e.Libros)
        .HasForeignKey(e => e.IdAutor);
        builder.HasMany(e => e.Generos)
        .WithMany(e => e.Libros)
        .UsingEntity<LibroGenero>(
            j => j.HasOne(e => e.Genero)
            .WithMany(e => e.libroGeneros)
            .HasForeignKey(e => e.IdGenero),

            j => j.HasOne(e => e.Libro)
            .WithMany(e => e.LibroGeneros)
            .HasForeignKey(e => e.IdLibro),

            j => {
                j.ToTable("libro_genero");

                j.HasKey(e => new {e.IdGenero, e.IdLibro});
            }
        );

        builder.HasMany(e => e.Clientes)
        .WithMany(e => e.Libros)
        .UsingEntity<Prestamo>(
            j =>  j.HasOne(e => e.Cliente)
            .WithMany(e => e.Prestamos)
            .HasForeignKey(e => e.IdClienteFk),

            j => j.HasOne(e => e.Libro)
            .WithMany(e => e.Prestamos)
            .HasForeignKey(e => e.IdLibroFk),

            j => {
                j.ToTable("prestamo");

                j.HasOne(e =>e.Usuario)
                .WithMany(e => e.Prestamos)
                .HasForeignKey(e => e.IdUsuario);

                j.Property(e => e.FechaDevolucion)
                .HasColumnType("date");

                j.Property(e => e.FechaPrestada)
                .IsRequired()
                .HasColumnType("date");

                j.Property(e => e.FechaVencimiento)
                .IsRequired()
                .HasColumnType("date");
                j.HasKey(e => new { e.IdLibroFk, e.IdUsuario});
            }
        );
    }
}