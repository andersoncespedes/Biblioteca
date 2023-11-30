using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
public class Cliente : BaseEntity
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono {get; set; }
    public int IdTipoDocumento {get; set;}
    public TipoDocumento TipoDocumento {get; set;}
    public string Direccion {get; set;}
    public int IdCiudad {get; set;}
    public Ciudad Ciudad {get; set;}
    public ICollection<Libro> Libros {get; set;}
    public ICollection<Prestamo> Prestamos {get; set;}

}