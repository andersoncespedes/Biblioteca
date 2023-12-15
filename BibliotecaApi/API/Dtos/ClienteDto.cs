using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
public class ClienteDto
{
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Telefono { get; set; }
    public int IdTipoDocumento { get; set; }
    public string Direccion { get; set; }
    public int IdCiudad { get; set; }

}