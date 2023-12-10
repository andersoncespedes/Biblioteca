using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
    public class LibroDatDto
    {
    public string Nombre { get; set; }
    public DateOnly Publicacion { get; set; }
    public string Sinopsis { get; set; }
    public int Cantidad { get; set; }
    public int IdAutor { get; set; }
    public int IdEditorial { get; set; }
    public int IdEstado { get; set; }
    public ICollection<string> Generos { get; set; }
    }