using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Author : BaseEntity
{
    public string Nombre {get; set;}
    public string Apellido {get; set;}
    public DateOnly Nacimiento {get; set;}
    public string Email {get; set;}
    public string AcercaDe {get; set;}
    public int IdPais {get; set;}
    public Pais Pais {get; set;}
    public ICollection<Libro> Libros {get; set;}
}