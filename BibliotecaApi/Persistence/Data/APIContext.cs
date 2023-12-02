
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Persistence.Data;
public class APIContext : DbContext
{
    public DbSet<Author> Authores {get; set;}
    public DbSet<Ciudad> Ciudades {get; set;}
    public DbSet<Cliente> Clientes {get; set;}
    public DbSet<Departamento> Departamentos {get; set;}
    public DbSet<Editorial> Editoriales {get; set;}
    public DbSet<Estado> Estados {get; set;}
    public DbSet<Genero> Generos {get; set;}
    public DbSet<Libro> Libros {get; set;}
    public DbSet<Pais> Paises {get; set;}
    public DbSet<Prestamo> Prestamos {get; set;}
    public DbSet<Rol> Roles {get; set;}
    public DbSet<TipoDocumento> TipoDocumentos {get; set;}
    public DbSet<Usuario> Usuarios {get; set;}

    public APIContext(DbContextOptions<APIContext> options) : base(options){

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
} 