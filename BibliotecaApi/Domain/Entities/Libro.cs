using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Libro : BaseEntity
{
    public string Nombre { get; set; }
    public DateOnly Publicacion {get; set;}
    public string Sinopsis { get; set; }
    public int Cantidad {get; set;}
    public int IdAutor {get; set;}
    public Author Author {get; set;}
    public int IdEditorial {get; set;}
    public Editorial Editorial {get; set;}
    public int IdEstado {get; set;}
    public Estado Estado {get; set;}
    public ICollection<LibroGenero> LibroGeneros {get; set;}
    public ICollection<Genero> Generos {get; set;}
    public ICollection<Prestamo> Prestamos {get; set;}
    public ICollection<Cliente> Clientes {get; set;}
}