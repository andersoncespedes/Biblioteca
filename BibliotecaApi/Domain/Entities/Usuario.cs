using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities;
    public class Usuario : BaseEntity
    {
        public string UserName {get; set;}
        public string PassName {get; set;}
        public string Nombre {get; set;}
        public string Apellido {get; set;}
        public int IdTipoDocumento {get; set;}
        public TipoDocumento TipoDocumento {get; set;}
        public string Documento {get; set;}
        public int IdCiudadFk {get; set;}
        public Ciudad Ciudad {get; set;}
        public string Direccion {get; set;}
    }