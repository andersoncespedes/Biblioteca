using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Dtos;
    public class EditorialDto
    {
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int IdCiudad {   get; set; }
        public string WebSite { get; set; }
    }
