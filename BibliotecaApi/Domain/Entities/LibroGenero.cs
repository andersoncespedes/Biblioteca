using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class LibroGenero
{
    public int IdGenero {get; set;}
    public Genero Genero {get; set;}
    public int IdLibro {get; set;}
    public Libro Libro {get; set;}
}