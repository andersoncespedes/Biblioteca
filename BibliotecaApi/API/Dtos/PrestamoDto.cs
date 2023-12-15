using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos
{
    public class PrestamoDto
    {
        public int IdClienteFk {get; set;}
        public int IdLibroFk {get; set;}
        public int IdUsuario {get; set; }
        public DateOnly FechaPrestada {get; set;}
        public DateOnly FechaVencimiento {get; set;}
        public DateOnly ? FechaDevolucion {get; set;}
    }
}