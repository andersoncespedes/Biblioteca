using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class LibroDto
{
    public string Nombre { get; set; }
    public DateOnly Publicacion { get; set; }
    public string Sinopsis { get; set; }
    public int Cantidad { get; set; }
    public int IdAutor { get; set; }
    public AuthorDto ? Author { get; set; }
    public int IdEditorial { get; set; }
    public EditorialDto ? Editorial { get; set; }
    public int IdEstado { get; set; }
    public ICollection<GeneroDto> Generos { get; set; }
}