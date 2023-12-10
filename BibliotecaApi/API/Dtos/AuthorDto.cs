using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class AuthorDto
{

    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public DateOnly Nacimiento { get; set; }
    public string Email { get; set; }
    public string AcercaDe { get; set; }
    public int IdPais { get; set; }
}
